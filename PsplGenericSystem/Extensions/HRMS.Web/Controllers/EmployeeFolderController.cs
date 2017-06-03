using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Common.Enums;

namespace HRMS.Web.Controllers
{
    public class EmployeeFolderController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmployeeFolderRepository _employeeFolderRepository;
        private readonly IFilesDBRepository _filesDbRepository;
        private readonly IUtilityRepository _utilityRepository;
        int fileId = 0;
        public EmployeeFolderController(
            IEmployeeFolderRepository employeeFolderRepository,
            IFilesDBRepository filesDbRepository,
            IUtilityRepository utilityRepository)
        {
            _employeeFolderRepository = employeeFolderRepository;
            _filesDbRepository = filesDbRepository;
            _utilityRepository = utilityRepository;
        }

        #endregion


        /// <summary>
        /// Displays all EmployeeFolder records.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllEmployeeFolder")]
        [Authorize]
        public ActionResult SelectAllEmployeeFolder()
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<EmployeeFolder> employeeFolderList = _employeeFolderRepository.SelectAllEmployeeFolderByCompanyId(userId, companyId);
            return View(employeeFolderList);
        }
        /// <summary>
        /// Returns the AddEmployeFolderView to insert the new record.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddEmployeeFolder")]
        [Authorize]
        public ActionResult AddEmployeeFolder()
        {
            var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            EmployeeFolderFormModel employeeFolderFormModelObj = new EmployeeFolderFormModel();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            //Loads Document Category
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeFolderFormModelObj.DocumentCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.DocumentCategory).ToList();
            employeeFolderFormModelObj.DocumentCategoryList.Insert(0, lookUpDataEntityObj);

            if (Request.QueryString["EmployeeFolderId"] != null)
            {
                var employeeFolderId = Request.QueryString["EmployeeFolderId"];
                employeeFolderFormModelObj.EmployeeFolder = _employeeFolderRepository.SelectEmployeeFolderById(companyId, Convert.ToInt32(employeeFolderId)).FirstOrDefault();

                //Return Files
                var filesDBList = new List<FilesDB>();
                int filedbId = Convert.ToInt32(employeeFolderFormModelObj.EmployeeFolder.FilesDBId);
                filesDBList = _filesDbRepository.SelectFileByFileDBId(filedbId);
                employeeFolderFormModelObj.FilesDBList = filesDBList;
                return View(employeeFolderFormModelObj);
            }

            return View(employeeFolderFormModelObj);
        }
        /// <summary>
        /// Submits and inserts the AddEmployeeFolder View information.
        /// </summary>
        /// <param name="employeeFolderFormModelObj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [ActionName("AddEmployeeFolder")]
        [Authorize]
        public ActionResult AddEmployeeFolder(EmployeeFolderFormModel employeeFolderFormModelObj)
        {
            //Returns the Output Parameter. Updates the EmployeeFolder(FilesDBId) with the inserted FilesDB(FilesDBId).
            //Multiple Files
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {
                
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string filename = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    FilesDB filesDBobj = new FilesDB();
                    System.IO.Stream filestream = Request.Files[i].InputStream;
                    byte[] bytesInStream = new byte[filestream.Length];
                    filestream.Read(bytesInStream, 0, bytesInStream.Length);
                    string extension = System.IO.Path.GetExtension(filename);
                    filesDBobj.FileName = filename;
                    filesDBobj.FileExtension = extension;
                    filesDBobj.FileBytes = bytesInStream;
                    filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                    filesDBobj.FileType = GeneralEnum.FileType.Document.ToString();
                   
                    fileId = _filesDbRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
                }
            }

            if (employeeFolderFormModelObj.EmployeeFolder.EmployeeFolderId == 0)
            {
                //FilesDB filesDBobj = new FilesDB();
                employeeFolderFormModelObj.EmployeeFolder.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeeFolderFormModelObj.EmployeeFolder.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeFolderFormModelObj.EmployeeFolder.FilesDBId = fileId;
                //employeeFolderFormModelObj.EmployeeFolder.File = filesDBobj.FileName;
                int employeefolderId = _employeeFolderRepository.CreateEmployeeFolder(employeeFolderFormModelObj.EmployeeFolder);
            }
            else
            {
                int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                int employeefolderId = employeeFolderFormModelObj.EmployeeFolder.EmployeeFolderId;
                if (fileId != 0)
                    employeeFolderFormModelObj.EmployeeFolder.FilesDBId = fileId;
                bool success = _employeeFolderRepository.UpdateEmployeeFolder(employeeFolderFormModelObj.EmployeeFolder);
            }
            return RedirectToAction("SelectAllEmployeeFolder");
        }
        /// <summary>
        /// Deletes the selected records by employeefolderIds.
        /// </summary>
        /// <param name="employeeFolderIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteEmployeeFolder(string employeeFolderIds)
        {
            if (employeeFolderIds != null)
            {
                foreach (var employeefolderId in employeeFolderIds.Split(','))
                {
                    var deleteDependentDetail =
                        _employeeFolderRepository.DeleteEmployeeFolder(Convert.ToInt32(employeefolderId));
                }
            }
            return true;
        }
        #region File Handling
        /// <summary>
        /// Opens the File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //public FileResult OpenFile(int fileDBId)
        public void OpenFile(int fileDBId)
        {
            try
            {
                var filesDBList = new List<FilesDB>();
                filesDBList = _filesDbRepository.SelectFileByFileDBId(fileDBId);
                string fileName = filesDBList[0].FileName;
                byte[] fileBytes = filesDBList[0].FileBytes;
                string contentType = filesDBList[0].ContentType;

                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = contentType;
                //Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(fileBytes);
                Response.End();

                //return File(new FileStream(fileName, FileMode.Open), "application/octetstream", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="fileDBId"></param>
        /// <returns></returns>
       
        [ActionName("DeleteFile")]
        public ActionResult DeleteFile(int? fileDBId)
        {
            bool deletefileStatus = _filesDbRepository.DeleteFileinFilesDB(Convert.ToInt32(fileDBId));    

            //page without refresh....
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
    }
}