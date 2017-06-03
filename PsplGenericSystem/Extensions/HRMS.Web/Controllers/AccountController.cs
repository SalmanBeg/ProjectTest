using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using System.Web.Security;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IMasterRepository _masterRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly ICompanyLevelSecurityRepository _companyLevelSecurityRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        public const string SetPasswordSuccess = "Password has been changed successfully.";
        public const string SetPasswordFail = "Change password failed.";
        public const string SetUsernameSuccess = "Username Changed Successfully";
        public const string SetUsernameFail = "Please enter a valid username.";
        public AccountController(IRegisteredUsersRepository registeredUsersRepository, IMasterRepository masterRepository, IUtilityRepository utilityRepository,
            ICompanyLevelSecurityRepository companyLevelSecurityRepository, IJobApplicantRepository jobApplicantRepository)
        {
            _registeredUsersRepository = registeredUsersRepository;
            _utilityRepository = utilityRepository;
            _companyLevelSecurityRepository = companyLevelSecurityRepository;
            _masterRepository = masterRepository;
            _jobApplicantRepository = jobApplicantRepository;
        }
        #endregion

        /// <summary>
        /// To call register view
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterUser()
        {
            var regfrmobj = new RegisterFormModel { Country = _utilityRepository.GetCountry() };

            return View(regfrmobj);

        }
        /// <summary>
        /// for form model to validate for emailIds for registration so no duplicates come across
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckForDuplication(string email)
        {
            var isExists = _registeredUsersRepository.ValidateEmailForRegistration(email);
            return Json(!isExists);
        }
        /// <summary>
        /// To Validate usernames for registration so no duplicates come across 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult ValidateUserName(string username)
        {
            var isExists = _registeredUsersRepository.ValidateEmailForRegistration(username);
            return Json(!isExists);
        }
        /// <summary>
        /// To validate for duplicate emails while registering in a company
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckForDuplicationbyCompany(string email)
        {
            var isExists = _registeredUsersRepository.ValidateEmailForRegistrationBasedOnCompany(email, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return Json(!isExists);
        }

        /// <summary>
        /// to register a new user account for company and its administrator
        /// </summary>
        /// <param name="registerFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        public bool RegisterUser(RegisterFormModel registerFormModelobj)
        {
            try
            {
                registerFormModelobj.Country = _utilityRepository.GetCountry();
                if (ModelState.IsValid)
                {
                    var registeredUsersobj = new RegisteredUsers();
                    var employeeobj = new Employee();
                    var companyInfoobj = new CompanyInfo();

                    var encryptedpassword = Encryption.Encrypt(registerFormModelobj.Password);
                    if (encryptedpassword != null)
                        registeredUsersobj.Password = encryptedpassword;
                    registeredUsersobj.Email = registerFormModelobj.Email;
                    registeredUsersobj.IsApproved = true;
                    registeredUsersobj.IsLockedOut = false;
                    registeredUsersobj.UserName = registerFormModelobj.UserName;
                    employeeobj.FirstName = registerFormModelobj.FirstName;
                    employeeobj.LastName = registerFormModelobj.LastName;
                    companyInfoobj.CompanyName = registerFormModelobj.CompanyName;
                    companyInfoobj.Address1 = registerFormModelobj.Address1;
                    companyInfoobj.Address2 = registerFormModelobj.Address2;
                    companyInfoobj.City = registerFormModelobj.City;
                    companyInfoobj.CountryId = registerFormModelobj.CountryId;
                    companyInfoobj.StateId = registerFormModelobj.StateId;
                    companyInfoobj.Phone = registerFormModelobj.Phone;
                    companyInfoobj.ZIP = registerFormModelobj.ZIP;

                    Debug.Assert(_registeredUsersRepository != null, "_userrepo != null");
                    int success = _registeredUsersRepository.CreateUserAccount(registeredUsersobj, employeeobj, companyInfoobj);
                    if (success > 0)
                    {
                        SendEmailtoUser(registerFormModelobj);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        /// <summary>
        /// After registration is finished it executes a email to end user.
        /// </summary>
        /// <param name="registerFormModelobj"></param>
        /// <returns></returns>
        public bool SendEmailtoUser(RegisterFormModel registerFormModelobj)
        {
            try
            {
                string strLoginUrl = ConfigurationManager.AppSettings["_loginurl"];
                var sr = new StreamReader(Server.MapPath("~/Utilities/RegisterUser.htm"));
                sr = System.IO.File.OpenText(Server.MapPath("~/Utilities/RegisterUser.htm"));
                string innerMessage = sr.ReadToEnd();
                sr.Dispose();
                innerMessage = innerMessage.Replace("[UserFullName]", registerFormModelobj.FirstName + " " + registerFormModelobj.LastName);
                innerMessage = innerMessage.Replace("|LoginPage|", strLoginUrl);
                innerMessage = innerMessage.Replace("[companyname]", registerFormModelobj.CompanyName);

                string messageBody = innerMessage;
                string emailError = string.Empty;
                const string strSubject = "Company Registration";
                Common.UtilityManager.sendEmailWithCredentials(registerFormModelobj.Email, "", strSubject, "", "", messageBody, "", "");
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        /// <summary>
        /// A view meant to change password
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        /// <summary>
        /// A view meant to change username
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ChangeUserName()
        {
            return View();
        }
        /// <summary>
        /// post method for updating username 
        /// </summary>
        /// <param name="changeUserNameFormModelobj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult ChangeUserName(ChangeUserNameFormModel changeUserNameFormModelobj)
        {
            if (ModelState.IsValid)
            {
                //change the username based on currentuserid
                int userId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                var result = _registeredUsersRepository.ChangeUsername(userId, changeUserNameFormModelobj.Username);
                if (result)
                {
                    ModelState.AddModelError(string.Empty, SetUsernameSuccess);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, SetUsernameFail);
                }
            }
            return View();
        }
        /// <summary>
        /// An anonymous action method to navigate to login page
        /// </summary>
        /// <param name="redirecturl"></param>
        /// <returns></returns>
        public ActionResult Login(string redirecturl)
        {
            Session.Clear();
            Session.Abandon();
            ViewBag.Redirecturl = redirecturl;
            return View();
        }
        /// <summary>
        /// Post method after login for authenticating the user.
        /// </summary>
        /// <param name="loginFormModelobj"></param>
        /// <param name="redirecturl"></param>
        /// <param name="frmcoll"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginFormModel loginFormModelobj, string redirecturl, FormCollection frmcoll)
        {
            //in order to handle error messages initially clearing the message
            TempData.Remove("Message");
            // validation model
            if (ModelState.IsValid)
            {
                //listing employee after authentication
                var registeredUsersList = _registeredUsersRepository.ValidateUser(loginFormModelobj.Email.ToLower(), Encryption.Encrypt(loginFormModelobj.Password));
                if (registeredUsersList != null && registeredUsersList.Count > 0)
                {
                    var applicationPath = frmcoll["ApplicationPath"];
                    foreach (var registeredUsersobj in registeredUsersList)
                    {

                        //Bind Review Notifications 
                        //TODO:remove performance notification list to client call
                        //int companyId = Convert.ToInt32(userSignUpobj.CompanyId);
                        //List<Reviewee> reviewmasterList = _masterRepository.SelectReviewNotification(userSignUpobj.UserSignUpId, companyId);
                        //Session["ReviewNotificationList"] = reviewmasterList;


                        if (registeredUsersobj.Email != null)
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
                                cookie.Values.Add("un", registeredUsersobj.Email.ToLower());
                                cookie.Values.Add("pwd", registeredUsersobj.Email.ToLower());
                                cookie.Expires = DateTime.Now.AddDays(15);
                                Response.Cookies.Add(cookie);
                            }
                            else
                            {
                                var httpCookie = Response.Cookies["HRMSlogin"];
                                if (httpCookie != null)
                                    httpCookie.Expires = DateTime.Now.AddMinutes(20);
                            }

                            //Storing session values
                            GlobalsVariables.CurrentCompanyId = Convert.ToString(registeredUsersobj.CompanyId);
                            GlobalsVariables.CurrentUserId = Convert.ToString(registeredUsersobj.UserId);
                            GlobalsVariables.SelectedUserId = Convert.ToString(registeredUsersobj.UserId);
                            GlobalsVariables.CurrentUserRoleId = Convert.ToString(registeredUsersobj.RoleId);
                            GlobalsVariables.CurrentCompanyName = Convert.ToString(registeredUsersobj.CompanyName);
                            GlobalsVariables.SelectedUserCode = Convert.ToString(registeredUsersobj.UserCode);
                            GlobalsVariables.CurrentUserRoleName = Convert.ToString(registeredUsersobj.RoleName);
                            GlobalsVariables.CurrentUserCode = Convert.ToString(registeredUsersobj.UserCode);
                            GlobalsVariables.CurrentUserName = Convert.ToString(registeredUsersobj.UserName);
                            GlobalsVariables.LastLogin = Convert.ToString(registeredUsersobj.LastLoginDate);
                            GlobalsVariables.IsHireWizard = "false";
                            GlobalsVariables.ImageFileId = Convert.ToString(registeredUsersobj.FileId);
                            // to an employee who is under self hire process and he has submitted his information
                            if (!string.IsNullOrWhiteSpace(redirecturl) && redirecturl != applicationPath + "/" || registeredUsersobj.IsApproved.Equals(false))
                            {
                                //if he has submitted his details
                                if (registeredUsersobj.IsSubmitted.Equals(true))
                                {

                                    ModelState.AddModelError("", "You are not authorized., please wait until your records get approved.");
                                    return View();
                                }// redirecting the corresponding employee hire wizard
                                else
                                {
                                    GlobalsVariables.IsHireWizard = "true";
                                    GlobalsVariables.HireWizardEmployeeId = GlobalsVariables.CurrentUserId;
                                    redirecturl = (ConfigurationManager.AppSettings["RedirectUrl"]);
                                    redirecturl = Encryption.Encrypt(redirecturl);
                                    redirecturl = Encryption.Decrypt(redirecturl);
                                    Response.Redirect(redirecturl);
                                }

                            }
                            else
                            {// the approved employee
                                // handling security
                                var companyLevelSecurity =
                                    _companyLevelSecurityRepository.SelectCompanyLevelSecurities(
                                        Int32.Parse(GlobalsVariables.CurrentCompanyId),
                                        Int32.Parse(GlobalsVariables.CurrentUserRoleId));
                                if (companyLevelSecurity != null || GlobalsVariables.CurrentUserRoleName.ToLower().Equals("superadministrator"))
                                {
                                    //setting up a view for superadministrator
                                    if (GlobalsVariables.CurrentUserRoleName.ToLower() != "superadministrator")
                                    {
                                        //remove condition null once turning blank database to active
                                        if (companyLevelSecurity != null && (registeredUsersobj.IsApproved == true &&
                                                                             companyLevelSecurity.CanAccessDashboard.Equals(true)))
                                            return RedirectToAction("EmployeeDashboard", "Home");
                                        else if (companyLevelSecurity != null && (registeredUsersobj.IsApproved == true &&
                                                                                  companyLevelSecurity.CanAccessDashboard.Equals(false)))
                                            return RedirectToAction("EmployeeSnapshot", "EmployeeSnapshot");
                                        else
                                        {
                                            ModelState.AddModelError("",
                                                "You are not authorized., please check the url given in mail.");
                                        }
                                    }
                                    else
                                    {
                                        // here as superadmin logsin and he does not show in employee list of a company we select first employee as default selected employee
                                        var firstUser = _registeredUsersRepository.SelectAllEmployeesList(
                                            Int32.Parse(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
                                        GlobalsVariables.SelectedUserId = Convert.ToString(firstUser.UserId);
                                        GlobalsVariables.SelectedUserName = firstUser.UserName;

                                        return RedirectToAction("EmployeeDashboard", "Home");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("",
                                            "Oops!..Please contact administrator something went wrong.");
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "The email or password provided is incorrect.");
                        }
                    }
                }
                else
                {

                    var jobapplicantObj = _jobApplicantRepository.ValidateApplicant(loginFormModelobj.Email,
                         Encryption.Encrypt(loginFormModelobj.Password));
                    if (jobapplicantObj != null)
                    {
                        //create cookie for authentication ticket
                        string basicuserdata = JsonConvert.SerializeObject(loginFormModelobj);

                        var authTicket = new FormsAuthenticationTicket(
                           1,
                           "HRMSJobPortallogin",
                           DateTime.Now,
                           DateTime.Now.AddMinutes(15),
                           false,
                           basicuserdata);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        Response.Cookies.Add(faCookie);
                        var httpCookie = Response.Cookies["HRMSJobPortallogin"];
                        if (httpCookie != null)
                            httpCookie.Expires = DateTime.Now.AddMinutes(20);
                        GlobalsVariables.CurrentCompanyId = Convert.ToString(jobapplicantObj.CompanyId);
                        GlobalsVariables.CurrentUserId = Convert.ToString(jobapplicantObj.JobApplicantId);
                        GlobalsVariables.CurrentUserName = jobapplicantObj.FirstName + " " + jobapplicantObj.LastName;
                        return Redirect("~/JobPortal/JobPortal/AvailableJobs");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The email or password provided is incorrect.");
                    }


                }
            }
            return View();
        }
        /// <summary>
        /// View to change the logged in user password
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UserAccount()
        {
            return View();
        }
        /// <summary>
        /// Post method for updating the new password after verifying the old password
        /// </summary>
        /// <param name="changePasswordFormModelobj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult UserAccount(ChangePasswordFormModel changePasswordFormModelobj)
        {
            if (ModelState.IsValid)
            {
                //change the password based on currentuserid
                int userId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                var result = _registeredUsersRepository.ChangePassword(Encryption.Encrypt(changePasswordFormModelobj.OldPassword), Encryption.Encrypt(changePasswordFormModelobj.NewPassword), userId);
                if (result)
                {
                    ModelState.AddModelError(string.Empty, SetPasswordSuccess);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, SetPasswordFail);
                }
            }
            return View();
        }
        /// <summary>
        /// To fetch states for the country 
        /// </summary>
        /// <param name="countryRegionId"></param>
        /// <returns></returns>
        public JsonResult FillStatesByCountryId(int countryRegionId)
        {
            var model = _utilityRepository.GetStateProvince(countryRegionId);

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Default action method which redirects to login view whenever session timeout
        /// </summary>
        /// <returns></returns>
        public ActionResult TimeoutRedirect()
        {
            return View();
        }
        /// <summary>
        /// Cleara and removes sessions and redirects to login view
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Request.Cookies.Clear();
            return RedirectToAction("Login");
        }
        /// <summary>
        /// sends a password reset link to registered emailid after validating emailid
        /// </summary>
        /// <param name="loginFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        public bool SendPasswordReset(LoginFormModel loginFormModelobj)
        {
            bool success = false;
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var passwordgenerator = new RandomStringGenerator();
                string newPassword = passwordgenerator.Generate("LlnlnLlL");
                loginFormModelobj.Password = newPassword;
                success = _registeredUsersRepository.ResetPassword(loginFormModelobj.Email, Encryption.Encrypt(newPassword));
                if (success)
                {
                    var userLoginModelList = _registeredUsersRepository.ValidateUser(loginFormModelobj.Email.ToLower(), Encryption.Encrypt(newPassword));
                    if (userLoginModelList.Count > 0)
                    {
                        var userLoginModel = userLoginModelList.FirstOrDefault();
                        SendResetPasswordemailtouser(userLoginModel, newPassword);
                    }
                    else
                    {
                        success = false;
                    }
                }
            }

            if (success.Equals(false))
            {
                ModelState.AddModelError("", "The email provided is incorrect.");
            }
            return success;
        }
        /// <summary>
        /// function to email the user with the password reset link
        /// </summary>
        /// <param name="userLoginModelobj"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool SendResetPasswordemailtouser(UserLoginModel userLoginModelobj, string newPassword)
        {
            try
            {
                string strLoginUrl = ConfigurationManager.AppSettings["_loginurl"];
                StreamReader sr = System.IO.File.OpenText(Server.MapPath("~/Utilities/ResetPassword.htm"));
                string innerMessage = sr.ReadToEnd();
                sr.Dispose();
                innerMessage = innerMessage.Replace("|UserFullName|", userLoginModelobj.FirstName + " " + userLoginModelobj.LastName);
                innerMessage = innerMessage.Replace("|UserName|", userLoginModelobj.Email);
                innerMessage = innerMessage.Replace("|Password|", newPassword);
                innerMessage = innerMessage.Replace("|MessageBody|", "Your password has been changed successfully.");
                innerMessage = innerMessage.Replace("|CompanyName|", userLoginModelobj.CompanyName);
                innerMessage = innerMessage.Replace("|LoginPage|", strLoginUrl);
                string messageBody = innerMessage;
                string emailError = string.Empty;
                const string strSubject = "Reset Password.";
                Common.UtilityManager.sendEmailWithCredentials(userLoginModelobj.Email, "", strSubject, "", "", messageBody, "", "");
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        /// <summary>
        /// On selection of a user this method fills the session for selected user
        /// </summary>
        /// <param name="userId"></param>
        [HttpPost]
        [Authorize]
        public void SelectUser(string userId)
        {
            GlobalsVariables.SelectedUserId = userId;
        }
        [Authorize]
        public ActionResult ReviewNotification()
        {
            var reviewobj = new Reviewee();
            reviewobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            int employeeId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            List<Reviewee> reviewmasterList = _masterRepository.SelectReviewNotification(companyId, employeeId);
            Session["ReviewNotificationList"] = reviewmasterList;
            return View();

        }
       
    }
}
