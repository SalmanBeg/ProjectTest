using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using System.IO;
using System.Configuration;
using HRMS.Common.Enums;
using HRMS.Service.Repositories;

namespace HRMS.Web.Controllers
{
    public class CommunicationController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IAlertTemplateRepository _alertTemplateRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IRegisteredUsersRepository registeredUsersRepository;
        private readonly IPayRepository _payRepository;
        public CommunicationController(IAlertTemplateRepository alertTemplateRepository, IUtilityRepository utilityRepo, IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, IFilesDBRepository filesDbRepository, IPayRepository payRepository )
        {
            _alertTemplateRepository = alertTemplateRepository;
            _utilityRepository = utilityRepo;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _filesDBRepository = filesDbRepository;
            _payRepository = payRepository;
        }

        #endregion
        /// <summary>
        /// A view displaying all the tiles which corresponds to Communication Dashboard
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CommunicationDashboard()
        {
            return View();
        }
        /// <summary>
        /// Main view for listing alerts for a company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Alert()
        {
           
            List<AlertTemplate> alertTemplateList = new List<AlertTemplate>();          
            alertTemplateList = _alertTemplateRepository.SelectAllAlertTemplate(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(alertTemplateList);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Alert(CommunicationFormModel communicationFormModelobj)
        {
            communicationFormModelobj.AlertTemplate.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            communicationFormModelobj.AlertTemplate.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
           
            int alertTemplateId = _alertTemplateRepository.AddAlertTemplate(communicationFormModelobj.AlertTemplate);
            return View(communicationFormModelobj);
        }
        /// <summary>
        /// A view to add a new alert for a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddAlert()
        {
            int alertTemplateId = Convert.ToInt32(Request.QueryString["AlertTemplateId"]);
            var alertTemplateObj = new AlertTemplate();
            var communicationFormModelobj = new CommunicationFormModel();
            communicationFormModelobj.AlertTemplate = _alertTemplateRepository.SelectAlertTemplateById(alertTemplateId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            communicationFormModelobj.SendToList = _utilityRepository.GetAlertSendType();
            communicationFormModelobj.SendCriteriaList = _utilityRepository.GetAlertSendCriteria();
           
           var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            communicationFormModelobj.PositionsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            communicationFormModelobj.DepartmentsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            communicationFormModelobj.LocationsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            communicationFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            communicationFormModelobj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (communicationFormModelobj.AlertTemplate == null)
                communicationFormModelobj.AlertTemplate = new AlertTemplate();
            communicationFormModelobj.AlertTemplate.CriteriaConditionList = _alertTemplateRepository.GetSendingAlertCondition();
            communicationFormModelobj.AlertTemplate.CriteriaDurationList = _alertTemplateRepository.GetSendingAlertDuration();
            communicationFormModelobj.AlertTemplate.CriteriaTimingList = _alertTemplateRepository.GetSendingAlertTiming();
            communicationFormModelobj.AlertTemplate.ScheduleValueList = _alertTemplateRepository.GetSendingAlertSchedule();
            communicationFormModelobj.AlertTemplate.SendViaList = _alertTemplateRepository.GetSendingAlertVia();
            return View(communicationFormModelobj);
        }
        /// <summary>
        /// Post method with supplied data to controller to save an alert
        /// </summary>
        /// <param name="communicationFormModelobj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlert(CommunicationFormModel communicationFormModelobj)
        {
            bool success;
            int fileId = 0;
            /* Add attachment file if exists */
            var httpPostedFileBase = Request.Files[0];
            if (httpPostedFileBase != null && ((Request.Files.Count > 0) && (httpPostedFileBase.ContentLength > 0)))
            {
                string filename = Path.GetFileName(httpPostedFileBase.FileName);
                FilesDB filesDBobj = new FilesDB();
                Stream filestream = httpPostedFileBase.InputStream;
                byte[] bytesInStream = new byte[filestream.Length];
                filestream.Read(bytesInStream, 0, bytesInStream.Length);
                string extension = Path.GetExtension(filename);
                filesDBobj.FileName = filename;
                filesDBobj.FileExtension = extension;
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.AlertAttachment.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));
            }
            #region
            int criteriaValue = Convert.ToInt32(communicationFormModelobj.AlertTemplate.CriteriaValue);
            DateTime alertDate = new DateTime();
          
            /* set alertdate to custom date if exists else set based on condition */
            if (communicationFormModelobj.AlertTemplate.CustomDate != null)
                alertDate = Convert.ToDateTime(communicationFormModelobj.AlertTemplate.CustomDate);
            else
                alertDate = GetAlertDate(Convert.ToInt32(communicationFormModelobj.AlertTemplate.CriteriaCondition), communicationFormModelobj.AlertTemplate.EmployeeId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            DateTime dateToSend = new DateTime();
            int dateDiff = 0;
            List<DateTime> lstIntervalDates = new List<DateTime>();
            int scheduleValue = Convert.ToInt32(communicationFormModelobj.AlertTemplate.ScheduleValue);
            int criteriaTiming = Convert.ToInt32(communicationFormModelobj.AlertTemplate.CriteriaTiming);
            int criteriaCount = Convert.ToInt32(communicationFormModelobj.AlertTemplate.CriteriaValue);
            /* if day/month/year exists */
            if (communicationFormModelobj.AlertTemplate.CriteriaDuration != null || communicationFormModelobj.AlertTemplate.CustomDate != null)
            {
                if (communicationFormModelobj.AlertTemplate.CriteriaDuration == 1)
                {
                    if (criteriaTiming == 1)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddDays(-criteriaCount);
                    }
                    else if (criteriaTiming == 3)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddDays(criteriaCount);
                    }
                }
                if (communicationFormModelobj.AlertTemplate.CriteriaDuration == 2)
                {
                    if (criteriaTiming == 1)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddMonths(-criteriaCount);
                    }
                    else if (criteriaTiming == 3)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddMonths(criteriaCount);
                    }
                }
                if (communicationFormModelobj.AlertTemplate.CriteriaDuration == 3)
                {
                    if (criteriaTiming == 1)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddYears(-criteriaCount);
                    }
                    else if (criteriaTiming == 3)
                    {
                        if (alertDate != DateTime.MinValue)
                            dateToSend = alertDate.AddYears(criteriaCount);
                    }
                }
                /*checkfor days*/
                if (criteriaTiming != 2)
                {
                    if (alertDate != DateTime.MinValue)
                        lstIntervalDates = CalculateDays(scheduleValue, alertDate, criteriaTiming, criteriaCount,
                            dateToSend);
                }
                else
                {
                    if (alertDate != DateTime.MinValue)
                        lstIntervalDates.Add(alertDate);
                }

            }

            //TODO:Save by looping through the lstIntervalDates,alter the function in alerttemplate repository
            #endregion
            #region save or update alert
            /* If templateid doesnt exist add new alert else update existing */
            if (communicationFormModelobj.AlertTemplate.AlertTemplateId == 0)
            {
                communicationFormModelobj.AlertTemplate.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                communicationFormModelobj.AlertTemplate.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                communicationFormModelobj.AlertTemplate.AttachmentId = fileId;
                int alertTemplateId = _alertTemplateRepository.AddAlertTemplate(communicationFormModelobj.AlertTemplate);


                switch (communicationFormModelobj.AlertTemplate.SendTo)
                {
                    case 1:
                        {
                            communicationFormModelobj.AlertTemplate.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                            InsertToEmployeeAlert(communicationFormModelobj.AlertTemplate.EmployeeList, alertTemplateId);
                            break;
                        }
                    case 2:
                        {
                            communicationFormModelobj.AlertTemplate.EmployeeList = _registeredUsersRepository.SelectAllManager(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                            InsertToEmployeeAlert(communicationFormModelobj.AlertTemplate.EmployeeList, alertTemplateId);
                            break;
                        }
                    case 3:
                        if (communicationFormModelobj.AlertTemplate.individualEmployeeIdList != null)
                        {
                            foreach (var employeeId in communicationFormModelobj.AlertTemplate.individualEmployeeIdList.Split(','))
                            {
                                Employee employeeObj = _employeeRepository.SelectEmployeeById(Convert.ToInt32(employeeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                                if (employeeObj != null)
                                    _alertTemplateRepository.AddAlertEmployee(alertTemplateId, employeeObj.UserId, true, employeeObj.Email, employeeObj.FirstName + " " + employeeObj.LastName);
                            }
                        }
                        break;
                    case 4:
                        _alertTemplateRepository.AddAlertEmployee(alertTemplateId, 0, true, communicationFormModelobj.AlertTemplate.ExternalEmail, "");
                        break;
                    case 5:
                        AddAlertEmployeeByCriteria(communicationFormModelobj.AlertTemplate.positionIdList, communicationFormModelobj.AlertTemplate.departmentIdList, communicationFormModelobj.AlertTemplate.locationIdList, communicationFormModelobj.AlertTemplate.employmentstatusIdList, alertTemplateId);
                        break;
                }
            }
            else
            {
                communicationFormModelobj.AlertTemplate.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                communicationFormModelobj.AlertTemplate.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                communicationFormModelobj.AlertTemplate.AttachmentId = fileId;
                success = _alertTemplateRepository.UpdateAlertTemplate(communicationFormModelobj.AlertTemplate);
            }
            #endregion
            return RedirectToAction("Alert");
        }
        //TODO:Calculate intervals for monthly,quarterly and yearly schedules
        public List<DateTime> CalculateDays(int scheduleValue, DateTime alertDate, int criteriaTiming, int criteriaValue, DateTime dateToSend)
        {
            int dateDiff = 0;
            DateTime tempdate = new DateTime();
            List<DateTime> lstIntervalDates = new List<DateTime>();
            switch (scheduleValue)
            {
                case 1:
                    {//schedule=daily
                        if (criteriaTiming == 1)
                        { tempdate = DateTime.Now.Date; dateDiff = Convert.ToInt32((alertDate.Date - DateTime.Now.Date).TotalDays + 1); }
                        else
                        { tempdate = alertDate; dateDiff = Convert.ToInt32((dateToSend.Date - alertDate.Date).TotalDays); }

                        for (int i = dateDiff - 1; i >= 0 && tempdate.Date >= DateTime.Now.Date; i--)
                        {
                            if (criteriaTiming == 1 && tempdate.Date <= alertDate.Date)
                                tempdate = alertDate.AddDays(-i).Date;
                            else if (criteriaTiming == 3 && tempdate.Date >= alertDate.Date)
                                tempdate = alertDate.AddDays(i).Date;
                            lstIntervalDates.Add(tempdate.Date);
                        }
                    }
                    break;
                case 2:
                    {//schedule=weekly
                        if (criteriaTiming == 1)
                        { tempdate = DateTime.Now.Date; dateDiff = Convert.ToInt32((alertDate.Date - DateTime.Now.Date).TotalDays); }
                        else
                        { tempdate = alertDate; dateDiff = Convert.ToInt32((dateToSend.Date - alertDate.Date).TotalDays); }
                        for (int i = dateDiff - 1; i >= 0 && tempdate.Date >= DateTime.Now.Date; i = i - 7)
                        {
                            if (criteriaTiming == 1 && tempdate.Date <= alertDate.Date)
                                tempdate = alertDate.AddDays(-i).Date;
                            else if (criteriaTiming == 3 && tempdate.Date >= alertDate.Date)
                                tempdate = alertDate.AddDays(i).Date;
                            lstIntervalDates.Add(tempdate.Date);
                        }
                    } break;
                case 3:
                    {//schedule=monthly
                        if (criteriaTiming == 1)
                        { tempdate = DateTime.Now.Date; dateDiff = Convert.ToInt32((alertDate.Date - dateToSend.Date).TotalDays); }
                        else
                        { tempdate = alertDate; dateDiff = Convert.ToInt32((dateToSend.Date - alertDate.Date).TotalDays); }

                        for (int i = dateDiff - 1; i >= 0; i = (i - Convert.ToInt32((tempdate.Date - tempdate.AddMonths(-1).Date).TotalDays)))
                        {
                            if (criteriaTiming == 1)
                                tempdate = alertDate.AddDays(-i).Date;
                            else if (criteriaTiming == 3)
                                tempdate = alertDate.AddDays(i).Date;
                            if (tempdate.Date >= DateTime.Now.Date)
                                lstIntervalDates.Add(tempdate.Date);
                        }
                    } break;
                case 4:
                    {//schedule=Quarterly
                        if (criteriaTiming == 1)
                        { tempdate = DateTime.Now.Date; dateDiff = Convert.ToInt32((alertDate.Date - dateToSend.Date).TotalDays); }
                        else
                        { tempdate = alertDate; dateDiff = Convert.ToInt32((dateToSend - alertDate).TotalDays); }
                        for (int i = dateDiff - 1; i >= 0 && tempdate.Date >= DateTime.Now.Date; i = (i - Convert.ToInt32((tempdate.Date - tempdate.AddMonths(-3).Date).TotalDays)))
                        {
                            if (criteriaTiming == 1)
                                tempdate = alertDate.AddDays(-i).Date;
                            else if (criteriaTiming == 3)
                                tempdate = alertDate.AddDays(i).Date;
                            lstIntervalDates.Add(tempdate.Date);
                        }
                    } break;
                case 5:
                    {//schedule=Quarterly
                        if (criteriaTiming == 1)
                        { tempdate = DateTime.Now.Date; dateDiff = Convert.ToInt32((alertDate.Date - dateToSend.Date).TotalDays); }
                        else
                        { tempdate = alertDate; dateDiff = Convert.ToInt32((dateToSend - alertDate).TotalDays); }
                        for (int i = dateDiff - 1; i >= 0 && tempdate.Date >= DateTime.Now.Date; i = (i - Convert.ToInt32((tempdate.Date - tempdate.AddYears(-1).Date).TotalDays)))
                        {
                            if (criteriaTiming == 1)
                                tempdate = alertDate.AddDays(-i).Date;
                            else if (criteriaTiming == 3)
                                tempdate = alertDate.AddDays(i).Date;
                            lstIntervalDates.Add(tempdate.Date);
                        }
                    } break;
            }
            return lstIntervalDates;
        }
        [Authorize]
        public DateTime GetAlertDate(int criteriaCondition, int employeeId, int companyId)
        {

            Employee employeeData = _employeeRepository.SelectEmployeeById(employeeId, companyId);

            var employeePayObj = _payRepository.SelectPay(companyId, employeeId);
            var alertDate = new DateTime();
            switch (criteriaCondition)
            {
                case 2:
                    //get open enrollment start date
                    break;
                case 3:
                    //get Pay Check End Date
                    break;
                case 4:
                    //get Education End Date
                    break;
                case 5:
                    //get Certification Renewal Date
                    break;
                case 6:
                    //get Birth Date
                    if (employeeData != null)
                        alertDate = Convert.ToDateTime(employeeData.BirthDate);
                    break;
                case 7:
                    //get Dependant Birth Date
                    break;
                case 8:
                    //get Driver License Expiration Date
                    break;
                case 9:
                    //get Pay Period Start Date
                    if (employeePayObj != null)
                        alertDate = Convert.ToDateTime(employeePayObj.PayPeriodStartDate);
                    break;
                case 10:
                    //get Pay Period End Date
                    if (employeePayObj != null)
                        alertDate = Convert.ToDateTime(employeePayObj.PayPeriodEndDate);
                    break;
                case 11:
                    //get OSHA Incident Date
                    break;
                case 12:
                    //get OSHA Case Closed Date
                    break;
                case 13:
                    //get Hire Date
                    if (employeeData != null)
                        alertDate = Convert.ToDateTime(employeeData.HireDate);
                    break;
                case 14:
                    //get Seniority Date
                    if (employeeData != null)
                        alertDate = Convert.ToDateTime(employeeData.SeniorityDate);
                    break;
                case 15:
                    //get Termination Date
                    if (employeeData != null)
                        alertDate = Convert.ToDateTime(employeeData.TerminationDate);
                    break;
                case 16:
                    //get Next Review Date
                    if (employeeData != null)
                        alertDate = Convert.ToDateTime(employeeData.NextReviewDate);
                    break;
                case 17:
                    //get Benefit Eligible Date
                    break;
            }
            return alertDate;
        }
        /// <summary>
        /// To remove an alert from a company
        /// </summary>
        /// <param name="templateIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteAlert(string templateIds)
        {
            if (templateIds != null)
            {
                foreach (var templateId in templateIds.Split(','))
                {
                    var deleteAlert =
                        _alertTemplateRepository.DeleteAlertTemplate(Int32.Parse(templateId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
        /// <summary>
        /// Assigning an alert to employee based on criteria setup
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="alertTemplateId"></param>
        [Authorize]
        public void InsertToEmployeeAlert(List<UserLoginModel> employeeList, int alertTemplateId)
        {
            if (employeeList != null)
            {
                foreach (var empList in employeeList)
                {
                    _alertTemplateRepository.AddAlertEmployee(alertTemplateId, empList.UserId, true, empList.Email, empList.UserName);
                }
            }
        }
        [Authorize]
        public void AddAlertEmployeeByCriteria(string positionIdList, string departmentIdList, string locationIdList, string employmentStatusIdList, int alertTemplateId)
        {
            List<Employee> employeeList = new List<Employee>();
            List<AlertSendCriteria> criteriaList = _utilityRepository.GetAlertSendCriteria();
            if (positionIdList != null)
            {
                var alertSendCriteriaId = (from x in criteriaList where x.AlertSendCriteriaName == "Positions" select x.AlertSendCriteriaId).First();
                foreach (var positionId in positionIdList.Split(','))
                {
                    //employeeList = _userSignUpRepository.SelectEmployeesByPosition(Convert.ToInt32(positionId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    //_alertTemplateRepository.SaveAlertCriteria(Convert.ToInt32(alertSendCriteriaId), alertTemplateId, Convert.ToInt32(positionId));
                }
            }
            if (locationIdList != null)
            {
                foreach (var locationId in locationIdList.Split(','))
                {
                    var alertSendCriteriaId = (from x in criteriaList where x.AlertSendCriteriaName == "Locations" select x.AlertSendCriteriaId).First();
                    //List<Employee> loctionList = _userSignUpRepository.SelectEmployeesByLocation(Convert.ToInt32(locationId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    //employeeList.AddRange(loctionList);
                    //_alertTemplateRepository.SaveAlertCriteria(Convert.ToInt32(alertSendCriteriaId), alertTemplateId, Convert.ToInt32(locationId));
                }
            }
            if (departmentIdList != null)
            {
                foreach (var departmentId in departmentIdList.Split(','))
                {
                    var alertSendCriteriaId = (from x in criteriaList where x.AlertSendCriteriaName == "Departments" select x.AlertSendCriteriaId).First();
                    //List<Employee> departmentList = _userSignUpRepository.SelectEmployeesByDepartment(Convert.ToInt32(departmentId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    //employeeList.AddRange(departmentList);
                    //_alertTemplateRepository.SaveAlertCriteria(Convert.ToInt32(alertSendCriteriaId), alertTemplateId, Convert.ToInt32(departmentId));
                }
            }
            if (employmentStatusIdList != null)
            {
                foreach (var employmentStatusId in employmentStatusIdList.Split(','))
                {
                    var alertSendCriteriaId = (from x in criteriaList where x.AlertSendCriteriaName == "EmploymentStatus" select x.AlertSendCriteriaId).First();
                    //List<Employee> employmentStatusList = _userSignUpRepository.SelectEmployeesByEmploymentStatus(Convert.ToInt32(employmentStatusId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    //employeeList.AddRange(employmentStatusList);
                    //_alertTemplateRepository.SaveAlertCriteria(Convert.ToInt32(alertSendCriteriaId), alertTemplateId, Convert.ToInt32(employmentStatusId));
                }
            }
            var distinctList = employeeList.GroupBy(test => test.UserId)
       .Select(group => group.First());
            if (distinctList != null)
            {
                foreach (var employee in distinctList)
                {
                    if (employee.Email != null)
                        _alertTemplateRepository.AddAlertEmployee(alertTemplateId, employee.UserId, true, employee.Email, employee.FirstName);
                }
            }
        }
    }

}
