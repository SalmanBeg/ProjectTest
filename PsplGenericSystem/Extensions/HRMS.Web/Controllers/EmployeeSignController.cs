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
    public class EmployeeSignController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IEmployeeSignRepository _employeeSignRepository;
        private string Filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
        int fileId = 0;
        public EmployeeSignController(IEmployeeSignRepository employeeSignRepository, IFilesDBRepository filesDBRepository)
        {
            _employeeSignRepository = employeeSignRepository;
            _filesDBRepository = filesDBRepository;
        }

        #endregion
        /// <summary>
        /// View to show all the employee signatures for an employee in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeSign()
        {
            List<EmployeeSign> employeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.CurrentUserId));
            foreach (var userlogin in employeeSignList)
            {
                userlogin.SignString = GetEmployeeSign(userlogin.EmployeeSignFileId.GetValueOrDefault());
            }
            return View(employeeSignList);
        }
        /// <summary>
        /// View to create a new signature as a template
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateNewSign()
        {
            var employeeSignobj = new EmployeeSign();

            return View(employeeSignobj);
        }
        /// <summary>
        /// Partial view to show signatures at position where esign is required
        /// </summary>
        [Authorize]
        public void _EmployeeSignView()
        {
            var employeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            ViewBag.EmployeeSign = employeeSignList;
        }
        
        /// <summary>
        /// For Saving Employee Sign from Ajax Calls.
        /// </summary>
        /// <param name="eSignName"></param>
        /// <param name="eSignValue"></param>
        /// <returns></returns>
        [Authorize]
        public bool SaveEmployeeSign(string eSignName, string eSignValue)
        {
            const bool isUploaded = false;
            var employeeSignobj = new EmployeeSign();
            string path = Server.MapPath(Filepath);
            if (eSignValue.Length > 0)
            {
                byte[] bytes = System.Convert.FromBase64String(eSignValue);
                string signimagepath = path + "test.png";
                System.IO.File.WriteAllBytes(signimagepath, bytes);
                var filesDBobj = new FilesDB();
                byte[] bytesInStream = System.Convert.FromBase64String(eSignValue);
                filesDBobj.FileName = eSignName;
                filesDBobj.FileExtension = "jpg";
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.EmployeeSign.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.SelectedUserId));

                employeeSignobj.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                employeeSignobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeSignobj.Name = eSignName;
                employeeSignobj.EmployeeSignFileId = fileId;
                var success = _employeeSignRepository.CreateEmployeeSign(employeeSignobj);
            }
            return isUploaded;
        }
        /// <summary>
        /// To retrieve an individual record based on record id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public string GetEmployeeSign(int id)
        { //transform the picture's data from string to an array of bytes
            var imagedata = _filesDBRepository.SelectFileByFileDBId(id);
            var thePictureDataAsBytes = imagedata[0].FileBytes;
            var contentdata = new FileContentResult(thePictureDataAsBytes, "image/jpeg");
            var contentdatastring = Convert.ToBase64String(contentdata.FileContents);
            string imagevalue = "data:image/png;base64," + Convert.ToBase64String(contentdata.FileContents);
            return imagevalue;
            //return array of bytes as the image's data to action's response. We set the image's content mime type to image/jpeg
        }

        [HttpPost]
        [Authorize]
        public bool DeleteSignature(string signIds)
        {
            if (signIds != null)
            {
                foreach (var employeesignId in signIds.Split(','))
                {
                    var deleteSign = _employeeSignRepository.DeleteEmployeeSignById(Convert.ToInt32(employeesignId));
                }
            }
            return true;

        }
        /// <summary>
        /// To update existing signature record for an employee
        /// </summary>
        /// <param name="signId"></param>
        /// <returns></returns>
        [Authorize]
        public bool UpdateDefaultSignature(int signId)
        {
            if (signId != 0)
            {
                _employeeSignRepository.UpdateEmployeeDefaultSign(Convert.ToInt32(GlobalsVariables.CurrentUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId), signId);
            }
            return true;
        }
        /// <summary>
        /// Action method to delete employee sign record
        /// </summary>
        /// <param name="deletesignIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteEmployeeSign(string deletesignIds)
        {
            if (!String.IsNullOrEmpty(deletesignIds))
            {
                foreach (var deleteSignId in deletesignIds.Split(','))
                {
                    var deleteEmployeeSign = _employeeSignRepository.DeleteEmployeeSign(Convert.ToInt32(deleteSignId));
                }
            }

            return true;
        }
    }
}