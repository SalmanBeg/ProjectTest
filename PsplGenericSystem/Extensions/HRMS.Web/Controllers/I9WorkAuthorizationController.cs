using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using HRMS.Web;
using HRMS.Web.ViewModels;
using System.Data;
using System.IO;


namespace HRMS.Web.Controllers
{
    public class I9WorkAuthorizationController : Controller
    {
        #region Class Level Variables and constructor

        private readonly II9WorkAuthorizationRepository _i9WorkAuthorizationRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IW4FormRepository _w4FromRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSignRepository _employeeSignRepository;
        public I9WorkAuthorizationController(IEmployeeSignRepository employeeSignRepository, II9WorkAuthorizationRepository i9WorkAuthorizationRepository, IUtilityRepository utilityRepo, IEmployeeRepository employeeRepository, IW4FormRepository w4FromRepository)
        {
            _i9WorkAuthorizationRepository = i9WorkAuthorizationRepository;
            _utilityRepository = utilityRepo;
            _w4FromRepository = w4FromRepository;
            _employeeRepository = employeeRepository;
            _employeeSignRepository = employeeSignRepository;
        }

        #endregion
        /// <summary>
        /// View to show I9 form details and for filling work authorization details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult I9WorkAuthorization()
        {

            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var i9FomrmModelobj = new I9FormModel();
            i9FomrmModelobj.AlienCitizenofList = _utilityRepository.GetCountry();
            i9FomrmModelobj.AlienAuthorisedCitizenofList = _utilityRepository.GetCountry();
            i9FomrmModelobj.CountryofList = _utilityRepository.GetCountry();

            i9FomrmModelobj.I9AcceptableDocuments1List = lstlookup.Where(F => F.TableName == LocalizedStrings.I9AcceptableDocuments1).ToList();
            i9FomrmModelobj.I9AcceptableDocuments2List = lstlookup.Where(F => F.TableName == LocalizedStrings.I9AcceptableDocuments2).ToList();
            i9FomrmModelobj.I9AcceptableDocuments3List = lstlookup.Where(F => F.TableName == LocalizedStrings.I9AcceptableDocuments3).ToList();


            var lstworks = _i9WorkAuthorizationRepository.GetI9WorkAuthorizationDetails(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstworks != null && lstworks.Count > 0)
            {

                i9FomrmModelobj.WorkAuthorization.CitizenOfUS = Convert.ToInt32(lstworks[0].CitizenOfUS);
                i9FomrmModelobj.WorkAuthorization.WorkAuthorizationId = lstworks[0].WorkAuthorizationId;
                if (lstworks[0].CitizenOfUS == 2)
                {
                    i9FomrmModelobj.WorkAuthorization.AlienNumber = lstworks[0].AlienNumber;
                    i9FomrmModelobj.WorkAuthorization.PermanentResidentExpire = lstworks[0].PermanentResidentExpire;
                    i9FomrmModelobj.WorkAuthorization.AlienCitizenof = lstworks[0].AlienCitizenof;
                }
                else if (lstworks[0].CitizenOfUS == 3)
                {
                    i9FomrmModelobj.WorkAuthorization.AlienAuthorisedDate = lstworks[0].AlienAuthorisedDate;
                    i9FomrmModelobj.WorkAuthorization.AlienAuthorisedCitizenof = Convert.ToInt32(lstworks[0].AlienAuthorisedCitizenof);
                }
                i9FomrmModelobj.WorkAuthorization.AlienRegistrationNumber = lstworks[0].AlienRegistrationNumber;
                i9FomrmModelobj.WorkAuthorization.AdmissionNumber = lstworks[0].AdmissionNumber;
                i9FomrmModelobj.WorkAuthorization.PassportNumber = lstworks[0].PassportNumber;
                i9FomrmModelobj.WorkAuthorization.Countryof = Convert.ToInt32(lstworks[0].Countryof);
                i9FomrmModelobj.WorkAuthorization.Attachment = lstworks[0].Attachment;
                i9FomrmModelobj.WorkAuthorization.AttachmentName = lstworks[0].AttachmentName;
                i9FomrmModelobj.WorkAuthorization.AttachmentType = lstworks[0].AttachmentType;
                List<WorkAuthorizationDocumentation> lstwrkDoc = _i9WorkAuthorizationRepository.GetI9DoumentationDetails(Convert.ToInt32(lstworks[0].WorkAuthorizationId));
                if (lstwrkDoc[0].WorkAuthorizationDocumentationTypeId == 1)
                {
                    i9FomrmModelobj.WorkAuthorization.CertificationDate = lstworks[0].CertificationDate;
                    i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentTitleA = Convert.ToInt32(lstwrkDoc[0].DocumentTitle);
                    i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityA = lstwrkDoc[0].DocumentIssuingAuthority;
                    i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentNumberA = lstwrkDoc[0].DocumentNumber;
                    i9FomrmModelobj.WorkAuthorizationDocumentation.ExpirationDateA = lstwrkDoc[0].ExpirationDate;
                }
                else if (lstwrkDoc[0].WorkAuthorizationDocumentationTypeId == 2)
                {
                    foreach (var list in lstwrkDoc)
                    {
                        if (list.WorkAuthorizationDocumentationTypeId == 2)
                        {
                            i9FomrmModelobj.WorkAuthorization.CertificationDate = lstworks[0].CertificationDate;
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentTitleB = Convert.ToInt32(list.DocumentTitle);
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityB = list.DocumentIssuingAuthority;
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentNumberB = list.DocumentNumber;
                            i9FomrmModelobj.WorkAuthorizationDocumentation.ExpirationDateB = list.ExpirationDate;
                        }
                        else
                        {
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentTitleC = Convert.ToInt32(list.DocumentTitle);
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityC = list.DocumentIssuingAuthority;
                            i9FomrmModelobj.WorkAuthorizationDocumentation.DocumentNumberC = list.DocumentNumber;
                            i9FomrmModelobj.WorkAuthorizationDocumentation.ExpirationDateC = list.ExpirationDate;
                        }
                    }
                }
            }
            return View(i9FomrmModelobj);
        }
        /// <summary>
        /// View to add work authorization details related to I9 form
        /// </summary>
        /// <param name="i9FormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddI9WorkAuthorization(I9FormModel i9FormModelobj)
        {
            var listType = Convert.ToInt32(Request.Form["List"]);
            var optselect = Convert.ToInt32(Request.Form["OptSelect"]);
            i9FormModelobj.WorkAuthorization.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            i9FormModelobj.WorkAuthorization.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            i9FormModelobj.WorkAuthorization.CreatedOn = DateTime.UtcNow;
            i9FormModelobj.WorkAuthorization.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            i9FormModelobj.WorkAuthorization.CitizenOfUS = optselect;
            i9FormModelobj.WorkAuthorization.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            var lstwork = new List<WorkAuthorizationDocumentation>();
            if (listType == 1)
            {
                i9FormModelobj.WorkAuthorization.CertificationDate = i9FormModelobj.WorkAuthorization.CertificationDate;
                lstwork.Add(new WorkAuthorizationDocumentation()
                {
                    WorkAuthorizationDocumentationTypeId = 1,
                    WorkAuthorizationId = i9FormModelobj.WorkAuthorization.WorkAuthorizationId,
                    DocumentTitle = i9FormModelobj.WorkAuthorizationDocumentation.DocumentTitleA,
                    DocumentIssuingAuthority = i9FormModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityA,
                    DocumentNumber = i9FormModelobj.WorkAuthorizationDocumentation.DocumentNumberA,
                    ExpirationDate = i9FormModelobj.WorkAuthorizationDocumentation.ExpirationDateA
                });
            }
            else
            {
                i9FormModelobj.WorkAuthorization.CertificationDate = i9FormModelobj.WorkAuthorization.CertificationDate;
                lstwork.Add(new WorkAuthorizationDocumentation()
                {
                    WorkAuthorizationDocumentationTypeId = 2,
                    WorkAuthorizationId = i9FormModelobj.WorkAuthorization.WorkAuthorizationId,
                    DocumentTitle = i9FormModelobj.WorkAuthorizationDocumentation.DocumentTitleB,
                    DocumentIssuingAuthority = i9FormModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityB,
                    DocumentNumber = i9FormModelobj.WorkAuthorizationDocumentation.DocumentNumberB,
                    ExpirationDate = i9FormModelobj.WorkAuthorizationDocumentation.ExpirationDateB

                });
                lstwork.Add(new WorkAuthorizationDocumentation()
                {
                    WorkAuthorizationDocumentationTypeId = 3,
                    WorkAuthorizationId = i9FormModelobj.WorkAuthorization.WorkAuthorizationId,
                    DocumentTitle = i9FormModelobj.WorkAuthorizationDocumentation.DocumentTitleC,
                    DocumentIssuingAuthority = i9FormModelobj.WorkAuthorizationDocumentation.DocumentIssuingAuthorityC,
                    DocumentNumber = i9FormModelobj.WorkAuthorizationDocumentation.DocumentNumberC,
                    ExpirationDate = i9FormModelobj.WorkAuthorizationDocumentation.ExpirationDateC

                });
            }
            var httpPostedFileBase = Request.Files[0];
            if (httpPostedFileBase != null && ((Request.Files.Count > 0) && (httpPostedFileBase.ContentLength > 0)))
            {
                var filename = Path.GetFileName(httpPostedFileBase.FileName);
                var filestream = httpPostedFileBase.InputStream;
                var bytesInStream = new byte[filestream.Length];
                filestream.Read(bytesInStream, 0, bytesInStream.Length);
                var extension = Path.GetExtension(filename);

                i9FormModelobj.WorkAuthorization.Attachment = bytesInStream;
                i9FormModelobj.WorkAuthorization.AttachmentName = filename;
                i9FormModelobj.WorkAuthorization.AttachmentType = extension;

            }
            var workAuthorizationobj = i9FormModelobj.WorkAuthorization;
            var workAuthorizationId = _i9WorkAuthorizationRepository.AddI9WorkAuthorizationDetails(workAuthorizationobj, lstwork);
            i9FormModelobj.WorkAuthorization.WorkAuthorizationId = workAuthorizationId;
            if (workAuthorizationId != 0)
            {
                ViewBag.validationmsg = " Saved Successfully ";
                return RedirectToAction("I9WorkAuthorization");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// Showing I9 form html page for e-signature
        /// </summary>
        /// <param name="workAuthorizationId"></param>
        [Authorize]
        public void OpenFile(int workAuthorizationId)
        {
            try
            {
                WorkAuthorization workAuthorizationObj = _i9WorkAuthorizationRepository.SelectFileByWorkAuthorizationID(workAuthorizationId);
                if (workAuthorizationObj == null) throw new ArgumentNullException("workAuthorizationObj");
                string fileName = workAuthorizationObj.AttachmentName;
                byte[] fileBytes = workAuthorizationObj.Attachment;
                string contentType = workAuthorizationObj.AttachmentType;

                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = contentType;
                //Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(fileBytes);
                Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [ActionName("DeleteFile")]
        [Authorize]
        public ActionResult DeleteFile(int? workAuthorizationId)
        {
            bool deletefileStatus = _i9WorkAuthorizationRepository.DeleteFileByWorkAuthorizationID(Convert.ToInt32(workAuthorizationId));

            return RedirectToAction("I9WorkAuthorization");
        }
        /// <summary>
        /// Partial view to load in hire wizard process to add work authorization details
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _I9WorkAuthorizationView()
        {

            var i9FormModelobj = new I9FormModel();
            i9FormModelobj.AlienCitizenofList = _utilityRepository.GetCountry();
            i9FormModelobj.AlienAuthorisedCitizenofList = _utilityRepository.GetCountry();
            i9FormModelobj.CountryofList = _utilityRepository.GetCountry();
            i9FormModelobj.employee = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (i9FormModelobj.employee != null)
            {
                int stateId = Convert.ToInt32(i9FormModelobj.employee.StateId);
                var states =
                    _utilityRepository.GetStateProvinceByStateId(Convert.ToInt32(i9FormModelobj.employee.StateId));
                i9FormModelobj.StateName = (from x in states
                                            select x.Name).SingleOrDefault();
            }


            i9FormModelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            var lstworks = _i9WorkAuthorizationRepository.GetI9WorkAuthorizationDetails(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstworks != null && lstworks.Count > 0)
            {
                i9FormModelobj.WorkAuthorization = new WorkAuthorization();
                i9FormModelobj.WorkAuthorization.CitizenOfUS = Convert.ToInt32(lstworks[0].CitizenOfUS);
                i9FormModelobj.WorkAuthorization.WorkAuthorizationId = lstworks[0].WorkAuthorizationId;
                if (lstworks[0].CitizenOfUS == 2)
                {
                    i9FormModelobj.WorkAuthorization.AlienNumber = lstworks[0].AlienNumber;
                    i9FormModelobj.WorkAuthorization.PermanentResidentExpire = lstworks[0].PermanentResidentExpire;
                    i9FormModelobj.WorkAuthorization.AlienCitizenof = lstworks[0].AlienCitizenof;
                }
                else if (lstworks[0].CitizenOfUS == 3)
                {
                    i9FormModelobj.WorkAuthorization.AlienAuthorisedDate = lstworks[0].AlienAuthorisedDate;
                    i9FormModelobj.WorkAuthorization.AlienAuthorisedCitizenof = Convert.ToInt32(lstworks[0].AlienAuthorisedCitizenof);
                }
                i9FormModelobj.WorkAuthorization.AlienRegistrationNumber = lstworks[0].AlienRegistrationNumber;
                i9FormModelobj.WorkAuthorization.AdmissionNumber = lstworks[0].AdmissionNumber;
                i9FormModelobj.WorkAuthorization.PassportNumber = lstworks[0].PassportNumber;
                i9FormModelobj.WorkAuthorization.Countryof = Convert.ToInt32(lstworks[0].Countryof);
                i9FormModelobj.WorkAuthorization.FederalLaw = Convert.ToBoolean(lstworks[0].FederalLaw);
                i9FormModelobj.WorkAuthorization.IsSSN = Convert.ToBoolean(lstworks[0].IsSSN);
                var employeeSign = _employeeSignRepository.GetEmployeeSign(Convert.ToInt32(i9FormModelobj.WorkAuthorization.EmployeeSignId));
                i9FormModelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
                i9FormModelobj.WorkAuthorization.EmployeeSignId = Convert.ToInt32(lstworks[0].EmployeeSignId);
                i9FormModelobj.WorkAuthorization.EmployeeSignDate = lstworks[0].EmployeeSignDate;
                int signId = Convert.ToInt32(lstworks[0].EmployeeSignId);
                if (signId > 0)
                {
                    TempData["signId"] = signId;
                    i9FormModelobj.EmployeeSign = (from signDetails in i9FormModelobj.EmployeeSignList
                                                   where signDetails.EmployeeSignFileId == signId
                                                   select signDetails).SingleOrDefault();
                }
                else
                    i9FormModelobj.EmployeeSign = new EmployeeSign();
            }
            else
            {
                i9FormModelobj.WorkAuthorization = new WorkAuthorization();
                i9FormModelobj.EmployeeSign = new EmployeeSign();
                var employeeSign = _employeeSignRepository.GetEmployeeSign(Convert.ToInt32(i9FormModelobj.WorkAuthorization.EmployeeSignId));
                i9FormModelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            }
            return PartialView(i9FormModelobj);
        }
        [HttpPost]
        [Authorize]
        public ActionResult _I9WorkAuthorizationView(I9FormModel i9FormModelobj)
        {
            int signId = 0;
            if (TempData["signId"] != null)
                signId = Convert.ToInt32(TempData["signId"]);
            var workAuthorizationId = 0;
            var optselect = Convert.ToInt32(Request.Form["OptSelect"]);
            i9FormModelobj.WorkAuthorization.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            i9FormModelobj.WorkAuthorization.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            i9FormModelobj.WorkAuthorization.CreatedOn = DateTime.UtcNow;
            i9FormModelobj.WorkAuthorization.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            i9FormModelobj.WorkAuthorization.CitizenOfUS = optselect;
            i9FormModelobj.WorkAuthorization.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            i9FormModelobj.WorkAuthorization.EmployeeSignId = signId;
            i9FormModelobj.WorkAuthorization.IsEmployeeSign = true;
            if (signId > 0)
                i9FormModelobj.WorkAuthorization.EmployeeSignDate = DateTime.UtcNow;
            i9FormModelobj.AlienCitizenofList = _utilityRepository.GetCountry();
            i9FormModelobj.AlienAuthorisedCitizenofList = _utilityRepository.GetCountry();
            i9FormModelobj.CountryofList = _utilityRepository.GetCountry();
            var lstWorkdoc = new List<WorkAuthorizationDocumentation>();
            var workAuthorizationobj = i9FormModelobj.WorkAuthorization;
            workAuthorizationId = _i9WorkAuthorizationRepository.AddI9WorkAuthorizationDetails(workAuthorizationobj, lstWorkdoc);
            i9FormModelobj.WorkAuthorization.WorkAuthorizationId = workAuthorizationId;
            i9FormModelobj.EmployeeSign = new EmployeeSign();
            if (workAuthorizationId > 0)
                return PartialView(i9FormModelobj);
            else
                return PartialView();
        }
        [Authorize]
        public ActionResult _I9WorkAuthorizationI9SignupView()
        {
            var i9FomrmModelobj = new I9FormModel();

            return View(i9FomrmModelobj);

        }
        [HttpPost]
        [Authorize]
        public bool _I9WorkAuthorizationI9SignupView(I9FormModel i9FomrmModelobj)
        {

            i9FomrmModelobj.employeeW4form.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            i9FomrmModelobj.employeeW4form.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            bool success = _w4FromRepository.AddEmployeeW4Form(i9FomrmModelobj.employeeW4form);
            return success;
        }
        public void setTempData(int signId)
        {
            TempData["signId"] = signId;
        }
    }

}
