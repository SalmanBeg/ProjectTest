using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using System.Configuration;
using HRMS.Common.Enums;

namespace HRMS.Web.Controllers
{
    public class EmployeeNotesController : Controller
    {
        #region Class Level Variables and constructor
      
        private readonly IEmployeeNotesRepository _employeeNotesRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        public EmployeeNotesController(IEmployeeNotesRepository employeeNotesRepository, IFilesDBRepository filesDBRepository)
        {
            _employeeNotesRepository = employeeNotesRepository;
            _filesDBRepository = filesDBRepository;
        }

        #endregion

        /// <summary>
        /// View to show all the notes entered for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeNotes()
        {
            var employeeNotesList = _employeeNotesRepository.GetAllEmployeeNotesByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            return View(employeeNotesList);
        }
        /// <summary>
        /// View to add a new note associated to an employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult CreateEmployeeNotes()
        {
            var employeeNoteobj = new EmployeeNote();
            if(Request.QueryString["EmployeeNotesId"]!=null)
            { 
                int employeeNoteId = Convert.ToInt32(Request.QueryString["EmployeeNotesId"]);
                employeeNoteobj = _employeeNotesRepository.GetEmployeeNotesById(employeeNoteId); 
            }         
            return View(employeeNoteobj);
        }
        /// <summary>
        /// View to add a new note associated to an employee(POST method)
        /// </summary>
        /// <param name="employeeNoteobj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult CreateEmployeeNotes(EmployeeNote employeeNoteobj)
        {
            employeeNoteobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            String Filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
            int fileId=0;
            if ((Request.Files.Count > 0) && (Request.Files[0].ContentLength > 0))
            {
                string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
                FilesDB filesDBobj = new FilesDB();
                System.IO.Stream filestream = Request.Files[0].InputStream;
                byte[] bytesInStream = new byte[filestream.Length];
                filestream.Read(bytesInStream, 0, bytesInStream.Length);
                string extension = System.IO.Path.GetExtension(filename);
                filesDBobj.FileName = filename;
                filesDBobj.FileExtension = extension;
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.NotesAttachment.ToString();
                fileId=_filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));
            }
            if (employeeNoteobj.UserId == 0)
            {
                employeeNoteobj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeeNoteobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeNoteobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                employeeNoteobj.AttachmentFileId = fileId;
                int employeeNotesId = _employeeNotesRepository.CreateEmployeeNotes(employeeNoteobj);
               
            }
            else
            {
                employeeNoteobj.AttachmentFileId = fileId;
                var  success = _employeeNotesRepository.UpdateEmployeeNotesById(employeeNoteobj);
            }

            return RedirectToAction("SelectAllEmployeeNotes");
        }
        /// <summary>
        /// Action method to delete an notes record for an employee
        /// </summary>
        /// <param name="employeeNotesIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteNotes(string employeeNotesIds)
        {
            if (employeeNotesIds != null)
            {
                foreach (var employeeNoteId in employeeNotesIds.Split(','))
                {
                    var deleteNote =
                        _employeeNotesRepository.DeleteEmployeeNotesById(Int32.Parse(employeeNoteId));
                }
            }
            return true;
        }

        /// <summary>
        /// Validation to check for duplication of job profiles while in add mode
        /// </summary>
        /// <param name="jobProfileFormModelObj"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(EmployeeNote employeeNoteObj)
        {
            employeeNoteObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _employeeNotesRepository.IsTitleExists(employeeNoteObj);
            if (employeeNoteObj.EmployeeNotesId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }

	}
}