using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System;
using System.Linq;
using System.Web.Http;
using HRMS.Service.Repositories;

namespace HRMS.Web.Controllers
{
    public class HRMSMailerServiceAPIController : ApiController
    {
        #region Class Level Variables and constructor
        private IMailerRepository _empMailRepository;
        private IEmployeeRepository _employeeRepository;
        private IOSHARepository _oSHARepository;
        public HRMSMailerServiceAPIController()
        {
        }
        public HRMSMailerServiceAPIController(IMailerRepository empMailRepository, IEmployeeRepository employeeRepository, IOSHARepository oSHARepository)
        {
            _empMailRepository = empMailRepository;
            _employeeRepository = employeeRepository;
            _oSHARepository = oSHARepository;
        }
        protected IMailerRepository MailerRepository
        {
            get { return _empMailRepository; }
        }

        #endregion
        /// <summary>
        /// Alert template logic to send emails to employees based on selection criteria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool SendMail()
        {
            try
            {
                _empMailRepository = new MailerRepository();

                var employeesMailsList = _empMailRepository.GetMailDetailsByStatus(true);
                foreach (var empMail in employeesMailsList)
                {
                    int criteriaValue = Convert.ToInt32(empMail.CriteriaValue);
                    DateTime alertDate;
                    /* set alertdate to custom date if exists else set based on condition */
                    if (empMail.CustomDate != null)
                        alertDate = Convert.ToDateTime(empMail.CustomDate);
                    else
                        alertDate = GetAlertDate(Convert.ToInt32(empMail.CriteriaCondition), empMail.EmployeeId, Convert.ToInt32(empMail.CompanyId));

                    if (alertDate != DateTime.MinValue)
                    {
                        var dateToSend = new DateTime();
                        /* if day/month/year exists */
                        if (empMail.CriteriaDuration != null || empMail.CustomDate != null)
                        {
                            if (empMail.CriteriaDuration == 1)
                            {
                                /* if timing is on/before/after */
                                if (empMail.CriteriaTiming == 1)
                                    dateToSend = alertDate.AddDays(criteriaValue);
                                else if (empMail.CriteriaTiming == 3)
                                    dateToSend = alertDate.AddDays(-criteriaValue);
                            }
                            else if (empMail.CriteriaDuration == 2)
                            {
                                if (empMail.CriteriaTiming == 1)
                                    dateToSend = alertDate.AddMonths(criteriaValue);
                                else if (empMail.CriteriaTiming == 3)
                                    dateToSend = alertDate.AddMonths(-criteriaValue);
                            }
                            else if (empMail.CriteriaDuration == 3)
                            {
                                if (empMail.CriteriaTiming == 1)
                                    dateToSend = alertDate.AddYears(criteriaValue);
                                else if (empMail.CriteriaTiming == 3)
                                    dateToSend = alertDate.AddYears(-criteriaValue);
                            }
                            if (empMail.CriteriaTiming == 2)
                                dateToSend = alertDate;
                            if (empMail.ScheduleValue == 1)
                            {
                                var criteriavalue = empMail.CriteriaValue;
                                var duration = empMail.CriteriaDuration;
                            }
                            else if (empMail.ScheduleValue == 2) { }
                            else if (empMail.ScheduleValue == 3) { }
                            else if (empMail.ScheduleValue == 4) { }

                            /* if datetosend is same as today's date sendmail */
                            if (dateToSend.Date == DateTime.Now.Date)
                            {
                                var sentStatus = false;
                                if (empMail.Status == true)
                                {
                                    sentStatus = _empMailRepository.sendEmailWithCredentials(empMail.Email, empMail.AlertTemplateSubject, empMail.AlertTemplateBody);
                                }
                                if (sentStatus)
                                {
                                    _empMailRepository.UpdateEmployeeAlertStatus(empMail.Email, empMail.EmployeeId, false);
                                }
                                else { break; }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        /// <summary>
        /// Method to return alert date to send email
        /// </summary>
        /// <param name="criteriaCondition"></param>
        /// <param name="employeeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DateTime GetAlertDate(int criteriaCondition, int employeeId, int companyId)
        {
            var hrmsentities1Obj = new HRMSEntities1();
            _employeeRepository = new EmployeeRepository();

            var employeeData = _employeeRepository.SelectEmployeeById(employeeId, companyId);
            //EmployeeOSHA employeeOSHAData =(from osha in hrmsentities1obj.EmployeeOSHAs
            //                                    where osha.UserId==employeeId && osha.CompanyId==companyId
            //                                    select osha);

            var employeePayObj = (from epay in hrmsentities1Obj.EmployeePay
                                  where epay.UserId == employeeId && epay.CompanyId == companyId
                                  select epay).SingleOrDefault();
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
                    {
                        alertDate = Convert.ToDateTime(employeePayObj.PayPeriodStartDate);
                    }
                    break;
                case 10:
                    //get Pay Period End Date
                    if (employeePayObj != null) alertDate = Convert.ToDateTime(employeePayObj.PayPeriodEndDate);
                    break;
                case 11:
                    //get OSHA Incident Date
                    break;
                case 12:
                    //get OSHA Case Closed Date
                    break;
                case 13:
                    //get Hire Date
                    alertDate = Convert.ToDateTime(employeeData.HireDate);
                    break;
                case 14:
                    //get Seniority Date
                    alertDate = Convert.ToDateTime(employeeData.SeniorityDate);
                    break;
                case 15:
                    //get Termination Date
                    alertDate = Convert.ToDateTime(employeeData.TerminationDate);
                    break;
                case 16:
                    //get Next Review Date
                    alertDate = Convert.ToDateTime(employeeData.NextReviewDate);
                    break;
                case 17:
                    //get Benefit Eligible Date
                    break;
            }
            return alertDate;
        }

    }
}
