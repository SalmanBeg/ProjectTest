using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.Helper;
using HRMS.Common.Helpers;
using System.Configuration;
using System.IO;
using HRMS.Web.ViewModels;
using HRMS.Common.Enums;
using System.Data;
using System.ComponentModel;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IHireConfigurationSetupRepository _HireConfigurationSetupRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOnBoardingRepository _onBoardingRepository;
        //private readonly ISubmittedNewHiresRepository _submittedNewHiresrepo;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IEmployeePhotoRepository _employeePhotoRepository;
        private readonly ICompanyLevelSecurityRepository _companyLevelSecurityRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        private readonly IEmployeeNoConfigurationRepository _employeeNoConfigurationRepository;
        private readonly IMasterRepository _masterRepository;
        public HomeController(IRegisteredUsersRepository registeredUsersRepository, IMasterRepository masterRepository
            , IUtilityRepository utilityRepository
            , IEmployeeRepository employeeRepository, IOnBoardingRepository onBoardingRepository, IHireConfigurationSetupRepository hireConfigurationSetupRepository //, ISubmittedNewHiresRepository submittedNewHiresrepo
            , IFilesDBRepository filesDBRepository, IEmployeePhotoRepository employeePhotoRepository, IJobProfileRepository jobProfileRepository, ICompanyLevelSecurityRepository companyLevelSecurityRepository, IEmployeeNoConfigurationRepository employeeNoConfigurationRepository)
        {

            _masterRepository = masterRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _utilityRepository = utilityRepository;
            _employeeRepository = employeeRepository;
            _onBoardingRepository = onBoardingRepository;
            _HireConfigurationSetupRepository = hireConfigurationSetupRepository;
            //_submittedNewHiresrepo = submittedNewHiresrepo;
            _filesDBRepository = filesDBRepository;
            _employeePhotoRepository = employeePhotoRepository;
            _companyLevelSecurityRepository = companyLevelSecurityRepository;
            _jobProfileRepository = jobProfileRepository;
            _employeeNoConfigurationRepository = employeeNoConfigurationRepository;
        }

        DataTable hireWizardStepsTable = new DataTable();

        protected IHireConfigurationSetupRepository HireConfigurationSetupRepository
        {
            get { return _HireConfigurationSetupRepository; }
        }

        private IUtilityRepository UtilityRepository
        {
            get { return _utilityRepository; }
        }
        protected IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository; }
        }

        //protected ISubmittedNewHiresRepository SubmittedNewHiresRepository
        //{
        //    get { return _submittedNewHiresrepo; }
        //}

        #endregion
        /// <summary>
        /// On Employee login its landing page  
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EmployeeDashboard()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var userLoginFormModelList = new List<UserLoginFormModel>();
            List<UserLoginModel> userLoginModelist = _registeredUsersRepository.SelectAllEmployeesListByRoleandUser(companyId, Convert.ToInt32(GlobalsVariables.CurrentUserRoleId), Convert.ToInt32(GlobalsVariables.CurrentUserId));
            if (userLoginModelist == null) throw new ArgumentNullException("userLoginModelist");
            if (userLoginModelist.Count > 0)
            {
                foreach (var userlogin in userLoginModelist)
                {
                    var userloginobj = new UserLoginFormModel();
                    userloginobj.FirstName = userlogin.FirstName;
                    userloginobj.LastName = userlogin.LastName;
                    userloginobj.RoleName = userlogin.RoleName;
                    userloginobj.Email = userlogin.Email;
                    userloginobj.UserId = userlogin.UserId;
                    userloginobj.RoleId = userlogin.RoleId;
                    userLoginFormModelList.Add(userloginobj);
                }
                var pendingUserlist = _HireConfigurationSetupRepository.SelectAllNewHires(companyId);
                if (pendingUserlist.Count() > 0)
                    userLoginFormModelList[0].DashboardCount.NewHireCount = pendingUserlist.Count;
                else
                {
                    userLoginFormModelList[0].DashboardCount.NewHireCount = 0;
                }
                userLoginFormModelList[0].CompanyLevelSecurity =
                    _companyLevelSecurityRepository.SelectCompanyLevelSecurities(
                        Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId));
                TempData["EmpImgValue"] = (!string.IsNullOrEmpty(GlobalsVariables.ImageFileId))
                    ? GetEmployeeAvatar(Convert.ToInt32(GlobalsVariables.ImageFileId))
                    : "";
                GlobalsVariables.EmpImgValue = (!string.IsNullOrEmpty(GlobalsVariables.ImageFileId))
                    ? GetEmployeeAvatar(Convert.ToInt32(GlobalsVariables.ImageFileId))
                    : string.Empty;

            }
            return View(userLoginFormModelList);
        }
        /// <summary>
        /// To show the view where on baording steps would be selected
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ConfigureEmployee()
        {
            string HireType = Request.QueryString["HireType"];
            GlobalsVariables.HireType = HireType;
            var employeeConfigurationFormModelobj = new EmployeeConfigurationFormModel();
            employeeConfigurationFormModelobj.OnBoardingList =
                _onBoardingRepository.SelectAllOnBoardingByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeConfigurationFormModelobj.HireStepList = HireConfigurationSetupRepository.SelectAllHireSteps();
            return View(employeeConfigurationFormModelobj);
        }
        /// <summary>
        /// An view where on boarding steps are configured and be saved for the created employee
        /// </summary>
        /// <param name="stepIds"></param>
        /// <param name="onBoardingId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool ConfigureEmployee(string stepIds, string onBoardingId)
        {
            string[] steps = stepIds.Split(',');
            var employeeConfigurationFormModelobj = new EmployeeConfigurationFormModel();
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("EMail");
            ModelState.Remove("HireDate");
            ModelState.Remove("Personal");
            if (ModelState.IsValid)
            {
                //List<LookUpDataEntity> lstlookup =

                //    UtilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                if (lstlookup == null)
                {
                    throw new ArgumentNullException("lstlookup");
                }
                employeeConfigurationFormModelobj.HireStepList = HireConfigurationSetupRepository.SelectAllHireSteps();
                foreach (var step in employeeConfigurationFormModelobj.HireStepList)
                {
                    for (int i = 0; i < steps.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(steps[i]))
                        {
                            if (Convert.ToInt32(steps[i]) == step.StepId)
                                step.IsSelected = true;
                        }
                    }
                }
                employeeConfigurationFormModelobj.OnBoardingId = Convert.ToInt32(onBoardingId);
                employeeConfigurationFormModelobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                
                TempData["Configsetup"] = employeeConfigurationFormModelobj;
                return true;
            }
            else
            {
                ModelState.AddModelError("err", "Please select a check box.");
                return false;
            }
        }
        /// <summary>
        /// To show the view to add a new employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddNewEmployee()
        {
            //variable declared for adding new element in dropdown
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            GlobalsVariables.HireType = Request.QueryString["HireType"];
            var employeeConfigurationFormModelobj = new EmployeeConfigurationFormModel();
            string steps = Convert.ToString(Request.QueryString["Steps"]);
            employeeConfigurationFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            employeeConfigurationFormModelobj.EmploymentStatusList.Insert(0, lookUpDataEntityobj);
            employeeConfigurationFormModelobj.CompensationFrequencyList = lstlookup.Where(j => j.TableName == LocalizedStrings.CompensationFrequency).ToList();
            employeeConfigurationFormModelobj.CompensationFrequencyList.Insert(0, lookUpDataEntityobj);
            employeeConfigurationFormModelobj.ManagerList = SelectEmployeeListByCompanyId().Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.SelectedUserId)).ToList();
            employeeConfigurationFormModelobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            var jobProfileObj = new JobProfile { Title = LocalizedStrings.AddNew, JobProfileId = 0 };
            employeeConfigurationFormModelobj.JobProfileList.Insert(0, jobProfileObj);
            employeeConfigurationFormModelobj.EmployeeNo = _employeeNoConfigurationRepository.GenerateEmployeeNo(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            TempData.Peek("Configsetup");
            //if (TempData["Configsetup"] != null)
            //{
            //    TempData.Keep("Configsetup");

            //    //employeeConfigurationFormModelobj = TempData["Configsetup"] as EmployeeConfigurationFormModel;
            //}

            return PartialView(employeeConfigurationFormModelobj);
        }
        /// <summary>
        /// An method to filter employees based on companyId
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public List<UserLoginModel> SelectEmployeeListByCompanyId()
        {
            return _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        }

        /// <summary>
        /// To create a new employee for selkf hire and new hire registration using a flag and stepIds
        /// </summary>
        /// <param name="employeeConfigurationFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddNewEmployee(EmployeeConfigurationFormModel employeeConfigurationFormModelobj)
        {

            if (TempData["Configsetup"] != null)
            {
                //TempData.Peek("Configsetup");
                var employeeConfigurationFormModelobj1 = TempData["Configsetup"] as EmployeeConfigurationFormModel;
                if (employeeConfigurationFormModelobj1 != null)
                {
                    employeeConfigurationFormModelobj.HireStepList = employeeConfigurationFormModelobj1.HireStepList;
                    employeeConfigurationFormModelobj.OnBoardingId = employeeConfigurationFormModelobj1.OnBoardingId;
                }
            }
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("EMail");
            ModelState.Remove("HireDate");
            employeeConfigurationFormModelobj.CompanyId = GlobalsVariables.CurrentCompanyId != null ? Convert.ToInt32(GlobalsVariables.CurrentCompanyId) : 0;         
            var passwordgenerator = new RandomStringGenerator();
            string password = passwordgenerator.Generate("LlnlnLlL");
            employeeConfigurationFormModelobj.Password = Encryption.Encrypt(password);
            var employeeObj = new Employee
            {
                CompanyId = employeeConfigurationFormModelobj.CompanyId,
                Email = employeeConfigurationFormModelobj.EMail,
                FirstName = employeeConfigurationFormModelobj.FirstName,
                LastName = employeeConfigurationFormModelobj.LastName,
                JobProfileId = employeeConfigurationFormModelobj.JobProfile,
                HireDate = employeeConfigurationFormModelobj.HireDate,
                ManagerId = employeeConfigurationFormModelobj.ManagerId,
                EmploymentStatus = employeeConfigurationFormModelobj.EmploymentStatusId,
                EmployeeNo = employeeConfigurationFormModelobj.EmployeeNo
            };

            bool hirestatus = false;
            if (GlobalsVariables.HireType != (GeneralEnum.HireType.SelfHire.ToString()))
            {
                hirestatus = true;
            }

            var registeredUsersObj = new RegisteredUsers()
            {
                UserName = employeeConfigurationFormModelobj.EMail,
                Password = employeeConfigurationFormModelobj.Password,
                IsApproved = hirestatus
            };

            var onBoardingObj = new OnBoarding()
            {
                OnBoardingId = employeeConfigurationFormModelobj.OnBoardingId
            };

            var employeePayObj = new EmployeePay()
            {
                Compensation = employeeConfigurationFormModelobj.Compensation,
                CompensationFrequency = employeeConfigurationFormModelobj.CompensationFrequency
            };
            var hireStepMasterList = employeeConfigurationFormModelobj.HireStepList;
            if (ModelState.IsValid)
            {
                bool success = _HireConfigurationSetupRepository.CreateEmployeeConfigurationSetup(employeeObj, employeePayObj, registeredUsersObj, onBoardingObj, hireStepMasterList, GeneralEnum.RoleName.Employee, Int32.Parse(GlobalsVariables.CurrentUserId));
                //if (success)
                Sendemailtouser(employeeConfigurationFormModelobj);
            }
            if (GlobalsVariables.HireType.Equals(GeneralEnum.HireType.SelfHire.ToString()))
            {
                return RedirectToAction("ConfigureEmployee");
            }
            return RedirectToAction("EmployeeDashboard", "Home");
        }
        /// <summary>
        /// Method to supply on employee creation with its credentials
        /// </summary>
        /// <param name="employeeconfigurationFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        public bool Sendemailtouser(EmployeeConfigurationFormModel employeeconfigurationFormModelObj)
        {
            try
            {
                string strLoginURL;
                string redirectUrl = Encryption.Encrypt(ConfigurationManager.AppSettings["RedirectUrl"]);
                redirectUrl = "?redirectUrl=" + redirectUrl;
                strLoginURL = ConfigurationManager.AppSettings["_loginurl"];
                //strResetPwd = ConfigurationManager.AppSettings["ResetPassword"];
                //strResetPwd = strResetPwd + "?UserName=" + Encryption.Encrypt(UserName) + "&CompanyID=" + Encryption.Encrypt(CompanyID.ToString());
                var MessageBody = String.Empty;
                var sr = new StreamReader(Server.MapPath("~/Utilities/EmployeeConfigurationSetup.htm"));
                sr = System.IO.File.OpenText(Server.MapPath("~/Utilities/EmployeeConfigurationSetup.htm"));
                string innerMessage = sr.ReadToEnd();
                sr.Dispose();
                innerMessage = innerMessage.Replace("|UserFullName|", employeeconfigurationFormModelObj.FirstName + " " + employeeconfigurationFormModelObj.LastName);
                innerMessage = innerMessage.Replace("|LoginPage|", strLoginURL + redirectUrl);
                innerMessage = innerMessage.Replace("|UserName|", employeeconfigurationFormModelObj.EMail);
                innerMessage = innerMessage.Replace("|Password|", Encryption.Decrypt(employeeconfigurationFormModelObj.Password));
                innerMessage = innerMessage.Replace("|MessageBody|", "Your account has been created successfully.");
                innerMessage = innerMessage.Replace("|CompanyName|", GlobalsVariables.CurrentCompanyName);
                //InnerMessage = InnerMessage.Replace("|ResetPassword|", strResetPwd);

                MessageBody = innerMessage;
                string emailError = string.Empty;
                const string strSubject = "Account activation information.";
                Common.UtilityManager.sendEmailWithCredentials(employeeconfigurationFormModelObj.EMail, "", strSubject, "", "", MessageBody, "", "");
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        /// <summary>
        /// To retrieve employee details based on selected userId
        /// </summary>
        /// <param name="selectedUserId"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ViewEmployee(string selectedUserId)
        {
            GlobalsVariables.SelectedUserId = selectedUserId;
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            var employeeInfoFormModelobj = new EmployeeInfoFormModel();
            employeeInfoFormModelobj.Employee = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            return View(employeeInfoFormModelobj);
        }
        [Authorize]
        public ActionResult ScheduleTasks()
        {
            return View();
        }
        /// <summary>
        /// To retrieve on boarding profiles based on company
        /// </summary>
        [HttpGet]
        [Authorize]
        public void _SelectOnBoardingsbyCompanyId()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<OnBoarding> onBoardingobjList = _onBoardingRepository.SelectAllOnBoardingByCompanyId(companyId);
            ViewBag.OnBoarding = onBoardingobjList;
        }
        [Authorize]
        public JsonResult FillEmployeesByCompanyId(int companyId)
        {
            var model = _registeredUsersRepository.SelectAllEmployeesList(companyId);

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        [Authorize]
        public JsonResult FillEmployeeListByCompanyIdAndRoleId()
        {
            var model = _registeredUsersRepository.SelectAllEmployeesListByRoleandUser(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32
                (GlobalsVariables.CurrentUserRoleId), Convert.ToInt32(GlobalsVariables.CurrentUserId));
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// To show a view for configuring steps involved in hire process
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectOnBoardingStep()
        {
            return View();
        }
        /// <summary>
        /// post method to upload an image based on fileId
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        [Authorize]
        public bool UploadEmployeePhoto(HttpPostedFileBase fileData)
        {
            int fileId = 0;
            bool IsUploaded = false;
            String Filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
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
                filesDBobj.FileType = GeneralEnum.FileType.userimage.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));

            }
            _employeePhotoRepository.InsertOrUpdateEmployeePhoto(Convert.ToInt32(GlobalsVariables.CurrentUserId), fileId);
            return IsUploaded;
        }
        /// <summary>
        /// return an base64 string to show the image of employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public string GetEmployeeAvatar(int id)
        { //transform the picture's data from string to an array of bytes
            var imagedata = _filesDBRepository.SelectFileByFileDBId(id);
            var thePictureDataAsBytes = imagedata[0].FileBytes;
            var contentdata = new FileContentResult(thePictureDataAsBytes, "image/jpeg");
            var contentdatastring = Convert.ToBase64String(contentdata.FileContents);
            string imagevalue = "data:image/png;base64," + Convert.ToBase64String(contentdata.FileContents);
            return imagevalue;
            //return array of bytes as the image's data to action's response. We set the image's content mime type to image/jpeg
        }
        /// <summary>
        /// To post the content result to post the image for viewing
        /// </summary>
        [HttpPost]
        [Authorize]
        public void SelectEmployeePhotoByUserId()
        {
            var emloyeePhoto = _employeePhotoRepository.GetEmployeePhoto(Convert.ToInt32(GlobalsVariables.CurrentUserId));
            GlobalsVariables.ImageFileId = Convert.ToString(emloyeePhoto.PhotoFileId);
        }

        public void ResetDataBase()
        {
            bool success = _masterRepository.ResetAllData();
            //if(success)

        }
    }
}
