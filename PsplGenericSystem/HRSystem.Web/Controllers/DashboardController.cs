using HRSystem.Services.Interfaces;
using HRSystem.Services.Models;
using HRSystem.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;

namespace HRSystem.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAccounts _accounts;
        private readonly ICompanyDashboard _companyDashboard;
        private readonly IChat _chat;
        int companyId = 266;
        public DashboardController(IAccounts accounts, ICompanyDashboard companyDashboard, IChat chat)
        {
            _accounts = accounts;
            _companyDashboard = companyDashboard;
            _chat = chat;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            var objUserDetails = new MainEmployee();
            objUserDetails = _accounts.GetUserDetails(Globals.gUserName, Globals.connectionString);
            Globals.gUserId = objUserDetails.UserId;
            Globals.gRoleName = objUserDetails.RoleName;
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.GetCompanyDashboard(companyId, Globals.connectionString);
            if (companyDashboard.Count > 0)
            {
                if (companyDashboard[0].Count > 0)
                {
                    objUserDetails.RecentHire = companyDashboard[0].Count;
                }
                else
                {
                    objUserDetails.RecentHire = 0;
                }
                if (companyDashboard[1].Count > 0)
                {
                    objUserDetails.Termination = companyDashboard[1].Count;
                }
                else
                {
                    objUserDetails.Termination = 0;
                }
                if (companyDashboard[2].Count > 0)
                {
                    objUserDetails.OpenEnrollments = companyDashboard[2].Count;
                }
                else
                {
                    objUserDetails.OpenEnrollments = 0;
                }
            }
            else
            {
                objUserDetails.RecentHire = 0;
                objUserDetails.Termination = 0;
                objUserDetails.OpenEnrollments = 0;
            }
            var photo = _accounts.GetEmployeePhotoByuserID(Globals.gUserId, Convert.ToString(companyId), Globals.connectionString);
            if (photo.Image != null)
            {
                objUserDetails.Image = (byte[])photo.Image;
            }
            var personal = _accounts.GetEmployeePersonalInfo(Globals.gUserId, Globals.connectionString);
            if (personal != null)
            {
                objUserDetails.Address = personal.Address;
                if (!string.IsNullOrEmpty(personal.CellPhone))
                {
                    objUserDetails.CellPhone = string.Format("({0}) {1}-{2}", personal.CellPhone.Substring(0, 3), personal.CellPhone.Substring(3, 3), personal.CellPhone.Substring(6, 4));
                }
                if (!string.IsNullOrEmpty(personal.HomePhone))
                {
                    objUserDetails.HomePhone = string.Format("({0}) {1}-{2}", personal.HomePhone.Substring(0, 3), personal.HomePhone.Substring(3, 3), personal.HomePhone.Substring(6, 4)); ;
                }
            }
            var listDOB = new List<DOB>();
            listDOB = _companyDashboard.GetDOBBasedOnCompanyId(companyId, Globals.connectionString);
            objUserDetails.DOB_List = listDOB;
            var listRecentActivity = new List<RecentActivity>();
            listRecentActivity = _companyDashboard.GetRecentActivityList(companyId, Globals.connectionString);
            objUserDetails.RecentActivity_List = listRecentActivity;
            var listPlanType = new List<Plan>();
            listPlanType = _companyDashboard.GetAllPlanList(companyId, Globals.connectionString);
            objUserDetails.Plan_List = listPlanType;
            var listEnrollmentType = new List<EnrollmentType>();
            listEnrollmentType = _companyDashboard.GetAllEnrollmentList();
            objUserDetails.Enrollment_List = listEnrollmentType;
            var objONLCount = new List<CompanyDashboards>();
            objONLCount = _companyDashboard.GetEnrollmentsByType(companyId, Globals.connectionString);
            objUserDetails.OECount = objONLCount[0].Count;
            objUserDetails.NHCount = objONLCount[1].Count;
            objUserDetails.LECount = objONLCount[2].Count;
            return View(objUserDetails);
        }

        [HttpPost]
        public ActionResult Index(string prefix)
        {
            var objUserDetails = new MainEmployee();
            objUserDetails = _accounts.GetUserDetails(Globals.gUserName, Globals.connectionString);
            var objEmployeeList = new List<Employee>();
            objEmployeeList = _companyDashboard.GetEmployeeList(objUserDetails.UserId, companyId, objUserDetails.RoleId, false, false, Globals.connectionString);
            var Name = (from N in objEmployeeList
                        where N.LastName.StartsWith(prefix)
                        select new { N.LastName, N.FirstName });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecentHireNew()
        {
            var objUserDetails = new MainEmployee();
            List<Employee> listRecentHire = _accounts.GetRecentHireEmployeeInfo(Convert.ToString(companyId), Globals.connectionString);
            objUserDetails.Employee_List = listRecentHire;
            return View(objUserDetails);
        }

        public ActionResult Termination()
        {
            var objUserDetails = new MainEmployee();
            List<Employee> listTermination = _accounts.GetTerminationEmployeeInfo(Convert.ToString(companyId), Globals.connectionString);
            objUserDetails.Employee_List = listTermination;
            return View(objUserDetails);
        }

        public ActionResult OpenEnrollments()
        {
            var objUserDetails = new MainEmployee();
            List<Employee> listEnrollments = _accounts.GetOpenEnrollmentEmployeeInfo(Convert.ToString(companyId), Globals.connectionString);
            objUserDetails.Employee_List = listEnrollments;
            return View(objUserDetails);
        }

        public ActionResult SendBirthDayEmail(string email)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(email);
            string emailId = item["emailId"];
            string birthdayWish = item["birthdayWish"];
            int port = 587;
            string host = "smtp.gmail.com";
            string password = "hrmsmvc123";
            string username = "hrmsmvc@gmail.com";
            string From = "advancedhr@evolutionhcm.com";
            bool SSL = true;
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailAddress _FromADD = new System.Net.Mail.MailAddress(From, From);
            message.From = _FromADD;
            message.To.Add(emailId);
            message.Subject = birthdayWish;
            message.Body = birthdayWish;
            message.IsBodyHtml = true;
            using (var mySMTPclient = new System.Net.Mail.SmtpClient(host, port))
            {
                System.Net.NetworkCredential userCredetials = new System.Net.NetworkCredential(username, password);
                mySMTPclient.UseDefaultCredentials = false;
                mySMTPclient.Credentials = userCredetials;
                mySMTPclient.EnableSsl = SSL;
                mySMTPclient.Send(message);
            }
            return Content("Success");
        }

        [HttpGet]
        public JsonResult OpenEnrollmentStatuses()
        {
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.GetOpenEnrollmentStatuses(companyId, Globals.connectionString);
            return Json(companyDashboard, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEnrollmentByType()
        {
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.GetEnrollmentsByType(companyId, Globals.connectionString);
            return Json(companyDashboard, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult OpenEnrollmentStatusesByPlanType(string Type)
        {
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.OpenEnrollmentStatusesByPlanType(companyId, Type, Globals.connectionString);
            return Json(companyDashboard, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetEnrollmentByTypeByEnrollmentType(string Type)
        {
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.GetEnrollmentByTypeByEnrollmentType(companyId, Type, Globals.connectionString);
            return Json(companyDashboard, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetOpenEnrollEmpInfo()
        {
            var objEmplist = new List<MainEmployee>();
            objEmplist = _companyDashboard.GetOpenEnrollmentEmployeeInfo(companyId, Globals.connectionString);
            return View(objEmplist);
        }
        [HttpGet]
        public ActionResult GetNewHireEmpInfo()
        {
            var objEmplist = new List<MainEmployee>();
            objEmplist = _companyDashboard.GetNewHireEmployeeInfo(companyId, Globals.connectionString);
            return View(objEmplist);
        }
        [HttpGet]
        public ActionResult GetLifeEventEmpInfo()
        {
            var objEmplist = new List<MainEmployee>();
            objEmplist = _companyDashboard.GetLifeEventEmployeeInfo(companyId, Globals.connectionString);
            return View(objEmplist);
        }

        [HttpGet]
        public JsonResult GetBenefitEnrollmentByLoc()
        {
            var benefitEnrollment = new List<BenefitEnrollment>();
            benefitEnrollment = _companyDashboard.GetBenefitEnrollmentByLoc(companyId, Globals.connectionString);
            return Json(benefitEnrollment, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetailsInfoAboutUser()
        {
            var detailsInfo = _chat.GetSync("users/me");
            return Json(detailsInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllGroups()
        {
            var getAllGroups = _chat.GetSync("groups");
            return Json(getAllGroups, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecificGroup(string groupId)
        {
            var getSpecificGroup = _chat.GetSync("groups/" + groupId + "/messages");
            return Json(getSpecificGroup, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CreateNewGroup(string groupName)
        {
            var makeNewGroupDto = new CreateNewGroupDto();
            makeNewGroupDto.name = groupName;
            makeNewGroupDto.description = "";
            makeNewGroupDto.share = true;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeNewGroup(makeNewGroupDto);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CreateNewMessageToGroup(string Message)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(Message);
            string groupId = item["groupId"];
            string message = item["message"];
            var messageCreateDto = new MessageCreateDto();
            messageCreateDto.source_guid = Convert.ToString(Guid.NewGuid());
            messageCreateDto.text = message;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeMessageCreateObject(messageCreateDto);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupId + "/messages", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UpdateUserName(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string name = item["name"];
            string email = item["email"];
            var updateUser = new UpdateUserDto();
            updateUser.name = name;
            updateUser.email = email;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateUser(updateUser);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("users/update", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UpdateUserEmail(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string name = item["name"];
            string email = item["email"];
            var updateUser = new UpdateUserDto();
            updateUser.name = name;
            updateUser.email = email;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateUser(updateUser);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("users/update", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadSpecificGroupInfo(string groupId)
        {
            var getSpecificGroup = _chat.GetSync("groups/" + groupId);
            return Json(getSpecificGroup, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AddMembersInGroup(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string NickName = item["NickName"];
            string Phone = item["Phone"];
            string Email = item["Email"];
            string groupId = item["groupId"];
            string ShareUrl = item["ShareUrl"];
            var addMembersInGroup = new AddMembersInGroupDto();
            addMembersInGroup.nickname = NickName;
            addMembersInGroup.user_id = Convert.ToString(Guid.NewGuid());
            addMembersInGroup.phone_number = Phone;
            addMembersInGroup.email = Email;
            addMembersInGroup.guid = Convert.ToString(Guid.NewGuid());
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeAddMembersInGroup(addMembersInGroup);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupId + "/members/add", content);
            SendAddMembersMail(Email: Email, ShareUrl: ShareUrl, NickName: NickName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LikeAMessage(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string groupid = item["groupId"];
            string messageId = item["messageId"];
            var result = _chat.PostSync("messages/" + groupid + "/" + messageId + "/like", "");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UnLikeAMessage(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string groupid = item["groupId"];
            string messageId = item["messageId"];
            var result = _chat.PostSync("messages/" + groupid + "/" + messageId + "/unlike", "");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SendDirectMessageToUser(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string receipientId = item["receipientId"];
            string text = item["message"];
            var createDirectMessage = new CreateDirectMessageDto();
            createDirectMessage.source_guid = Convert.ToString(Guid.NewGuid());
            createDirectMessage.recipient_id = receipientId;
            createDirectMessage.text = text;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeCreateDirectMessageToUser(createDirectMessage);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("direct_messages", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MyLikedMessages(string groupId)
        {
            var result = _chat.GetSync("groups/" + groupId + "/likes/mine");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListOfMessagesLikedForMe(string groupId)
        {
            var result = _chat.GetSync("groups/" + groupId + "/likes/for_me");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private void SendAddMembersMail(string Email, string ShareUrl, string NickName)
        {
            StringBuilder Subject = new StringBuilder();
            Subject.Append("Hello" + " " + NickName + "\n");
            Subject.Append("Please Join to the Group By using this URL:" + "\n");
            Subject.Append(ShareUrl);
            int port = 587;
            string host = "smtp.gmail.com";
            string password = "hrmsmvc123";
            string username = "hrmsmvc@gmail.com";
            string From = "advancedhr@evolutionhcm.com";
            bool SSL = true;
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailAddress _FromADD = new System.Net.Mail.MailAddress(From, From);
            message.From = _FromADD;
            message.To.Add(Email);
            message.Subject = "Welcome to GroupMe!";
            message.Body = Convert.ToString(Subject);
            message.IsBodyHtml = true;
            using (var mySMTPclient = new System.Net.Mail.SmtpClient(host, port))
            {
                System.Net.NetworkCredential userCredetials = new System.Net.NetworkCredential(username, password);
                mySMTPclient.UseDefaultCredentials = false;
                mySMTPclient.Credentials = userCredetials;
                mySMTPclient.EnableSsl = SSL;
                mySMTPclient.Send(message);
            }
        }
        public ActionResult Index1()
        {
            var objUserDetails = new MainEmployee();
            objUserDetails = _accounts.GetUserDetails(Globals.gUserName, Globals.connectionString);
            Globals.gUserId = objUserDetails.UserId;
            Globals.gRoleName = objUserDetails.RoleName;
            var companyDashboard = new List<CompanyDashboards>();
            companyDashboard = _companyDashboard.GetCompanyDashboard(companyId, Globals.connectionString);
            if (companyDashboard.Count > 0)
            {
                if (companyDashboard[0].Count > 0)
                {
                    objUserDetails.RecentHire = companyDashboard[0].Count;
                }
                else
                {
                    objUserDetails.RecentHire = 0;
                }
                if (companyDashboard[1].Count > 0)
                {
                    objUserDetails.Termination = companyDashboard[1].Count;
                }
                else
                {
                    objUserDetails.Termination = 0;
                }
                if (companyDashboard[2].Count > 0)
                {
                    objUserDetails.OpenEnrollments = companyDashboard[2].Count;
                }
                else
                {
                    objUserDetails.OpenEnrollments = 0;
                }
            }
            else
            {
                objUserDetails.RecentHire = 0;
                objUserDetails.Termination = 0;
                objUserDetails.OpenEnrollments = 0;
            }
            var photo = _accounts.GetEmployeePhotoByuserID(Globals.gUserId, Convert.ToString(companyId), Globals.connectionString);
            if (photo.Image != null)
            {
                objUserDetails.Image = (byte[])photo.Image;
            }
            var personal = _accounts.GetEmployeePersonalInfo(Globals.gUserId, Globals.connectionString);
            if (personal != null)
            {
                objUserDetails.Address = personal.Address;
                if (!string.IsNullOrEmpty(personal.CellPhone))
                {
                    objUserDetails.CellPhone = string.Format("({0}) {1}-{2}", personal.CellPhone.Substring(0, 3), personal.CellPhone.Substring(3, 3), personal.CellPhone.Substring(6, 4));
                }
                if (!string.IsNullOrEmpty(personal.HomePhone))
                {
                    objUserDetails.HomePhone = string.Format("({0}) {1}-{2}", personal.HomePhone.Substring(0, 3), personal.HomePhone.Substring(3, 3), personal.HomePhone.Substring(6, 4)); ;
                }
            }
            var listDOB = new List<DOB>();
            listDOB = _companyDashboard.GetDOBBasedOnCompanyId(companyId, Globals.connectionString);
            objUserDetails.DOB_List = listDOB;
            var listRecentActivity = new List<RecentActivity>();
            listRecentActivity = _companyDashboard.GetRecentActivityList(companyId, Globals.connectionString);
            objUserDetails.RecentActivity_List = listRecentActivity;
            var listPlanType = new List<Plan>();
            listPlanType = _companyDashboard.GetAllPlanList(companyId, Globals.connectionString);
            objUserDetails.Plan_List = listPlanType;
            var listEnrollmentType = new List<EnrollmentType>();
            listEnrollmentType = _companyDashboard.GetAllEnrollmentList();
            objUserDetails.Enrollment_List = listEnrollmentType;
            var objONLCount = new List<CompanyDashboards>();
            objONLCount = _companyDashboard.GetEnrollmentsByType(companyId, Globals.connectionString);
            objUserDetails.OECount = objONLCount[0].Count;
            objUserDetails.NHCount = objONLCount[1].Count;
            objUserDetails.LECount = objONLCount[2].Count;
            return View(objUserDetails);
        }
        [HttpGet]
        public JsonResult UpdateGroupName(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string name = item["name"];
            string groupid = item["groupId"];
            bool share = true;
            var updateGroup = new UpdateGroupDto();
            updateGroup.name = name;
            updateGroup.share = share;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateGroup(updateGroup);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupid + "/update", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult UpdateTopicName(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string topic = item["topic"];
            string name= item["name"];
            string groupid = item["groupId"];
            bool share = true;
            var updateGroup = new UpdateGroupDto();
            updateGroup.name = name;
            updateGroup.description = topic;
            updateGroup.share = share;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateGroup(updateGroup);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupid + "/update", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult UpdateNickName(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string name = item["name"];
            string groupid = item["groupId"];
            var updateMembership = new UpdateMembershipNickNameDto();
            updateMembership.nickname = name;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateNickName(updateMembership);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupid + "/memberships/update", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult EndGroup(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string groupid = item["groupId"];
            var destroyGroup = new UpdateGroupDto();
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeUpdateGroup(destroyGroup);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupid + "/destroy", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LeaveGroup(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(data);
            string groupid = item["groupId"];
            string memberid = item["memberid"];
            var removemember = new RemoveMemberDto();
            removemember.membership_id = memberid;
            MakeApiObject objApiObject = new MakeApiObject();
            var requiredData = objApiObject.MakeRemoveMember(removemember);
            JsonContent objJsonContent = new JsonContent();
            var content = objJsonContent.GetJsonContent(requiredData);
            var result = _chat.PostSync("groups/" + groupid + "/members/" +memberid + "/remove", content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}