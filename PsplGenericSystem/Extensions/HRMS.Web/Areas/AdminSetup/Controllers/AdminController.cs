using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HRMS.Common.Enums;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using System.Configuration;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using Newtonsoft.Json;

namespace HRMS.Web.Areas.AdminSetup.Controllers
{
    public class AdminController : Controller
    {

        #region Class Level Variables and constructor
        private readonly IHireConfigurationSetupRepository _hireConfigurationSetupRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AdminController(IRegisteredUsersRepository registeredUsersRepository
            , IUtilityRepository utilityRepository
            , IEmployeeRepository employeeRepository, IHireConfigurationSetupRepository hireConfigurationSetupRepository)
        {

            _registeredUsersRepository = registeredUsersRepository;
            _utilityRepository = utilityRepository;
            _employeeRepository = employeeRepository;
            _hireConfigurationSetupRepository = hireConfigurationSetupRepository;
        }



        #endregion
        //
        // GET: /AdminSetup/Admin/
        [Authorize]
        public ActionResult CreateSuperAdmin()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public JsonResult CreateSuperAdmin(RegisterFormModel registerFormModelObj)
        {

            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("EMail");
            ModelState.Remove("HireDate");


            var passwordgenerator = new RandomStringGenerator();
            //string password = passwordgenerator.Generate("LlnlnLlL");
            registerFormModelObj.Password = Encryption.Encrypt(registerFormModelObj.Password);
            var employeeObj = new Employee
            {
                CompanyId = 0,
                Email = registerFormModelObj.Email,
                FirstName = registerFormModelObj.FirstName,
                LastName = registerFormModelObj.LastName
            };
            var registeredUsersObj = new RegisteredUsers()
            {
                UserName = registerFormModelObj.Email,
                Password = registerFormModelObj.Password,
                IsApproved = true
            };

            var employeePay = new EmployeePay() { 
                Compensation=0,
                CompensationFrequency=0
            };
            var onboardingObj = new OnBoarding();
            var listHireStepMaster = new List<HireStepMaster>();

            bool success = _hireConfigurationSetupRepository.CreateEmployeeConfigurationSetup(employeeObj, employeePay, registeredUsersObj, onboardingObj, listHireStepMaster, GeneralEnum.RoleName.Superadministrator, 0);


            return Json(success, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult SelectAllSuperAdmins()
        {
            List<UserLoginModel> userLoginModelList = _registeredUsersRepository.SelectAllSuperAdmin();
            if (userLoginModelList == null) throw new ArgumentNullException("userLoginModelList");
            var userLoginFormModelList = new List<UserLoginFormModel>();
            foreach (var userlogin in userLoginModelList)
            {
                var userloginobj = new UserLoginFormModel
                {
                    FirstName = userlogin.FirstName,
                    LastName = userlogin.LastName,
                    UserName=userlogin.UserName,
                    RoleName = userlogin.RoleName,
                    Email = userlogin.Email,
                    UserId = userlogin.UserId,
                    RoleId = userlogin.RoleId
                };
                userLoginFormModelList.Add(userloginobj);
            }
            return View(userLoginFormModelList);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginFormModel loginFormModelobj, string redirecturl, FormCollection frmcoll)
        {
            if (ModelState.IsValid)
            {
                var username = ConfigurationManager.AppSettings["_username"];
                var password = ConfigurationManager.AppSettings["_password"];
                if (username.Equals(loginFormModelobj.Email) && password.Equals(loginFormModelobj.Password))
                {

                    if (loginFormModelobj.Email != null)
                    {
                        string basicuserdata = JsonConvert.SerializeObject(loginFormModelobj);

                        var authTicket = new FormsAuthenticationTicket(
                            1,
                            "HRMSlogin",
                            DateTime.Now,
                            DateTime.Now.AddMinutes(15),
                            loginFormModelobj.Rememberme,
                            basicuserdata);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        Response.Cookies.Add(faCookie);
                        if (loginFormModelobj.Rememberme)
                        {
                            var cookie = new HttpCookie("HRMSlogin");
                            cookie.Values.Add("un", loginFormModelobj.Email.ToLower());
                            cookie.Values.Add("pwd", loginFormModelobj.Email.ToLower());
                            cookie.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            var httpCookie = Response.Cookies["HRMSlogin"];
                            if (httpCookie != null)
                                httpCookie.Expires = DateTime.Now.AddMinutes(20);
                        }
                        GlobalsVariables.CurrentUserName = "Administrator";
                        GlobalsVariables.CurrentUserId = "0";
                    }

                    return RedirectToAction("SelectAllSuperAdmins");
                }
                else
                {
                    ModelState.AddModelError("", "The email or password provided is incorrect.");
                }
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowExceptions()
        {
            List<ExceptionLog> exceptionLogList = _utilityRepository.ListExceptions();
            return View(exceptionLogList);
        }
      
        //[Authorize]
        //public ActionResult UpdateSuperAdmin()
        //{
        //    var userloginmodelobj = new UserLoginFormModel();
        //    var companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
        //    var id = Request.QueryString["UserId"];
        //    var  registeruserloginmodelobj = _registeredUsersRepository.SelectAllEmployeesListByRoleandUser(companyId, 1, Convert.ToInt32(id)).FirstOrDefault();
        //    return View(registeruserloginmodelobj);
        //}
        //[HttpPost]
        //[Authorize]
        //public ActionResult UpdateSuperAdmin()
        //{
        //    bool success = _registeredUsersRepository.UpdateEmployeeDependent(employeeDependentFormModelobj.EmployeeDependent);
        //    if (success)
        //    {
        //        ModelState.AddModelError("", "Super Admin Detail(s) Updated Successfully.");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Super Admin Details(s) cannot be updated, Please try again.");
        //    }
        //    return RedirectToAction("SelectAllSuperAdmins");
        //}

    }
}