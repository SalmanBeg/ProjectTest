using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class CommunicationFormModel
    {
        public CommunicationFormModel()
        {
            AlertTemplate = new AlertTemplate();
            SendToList = new List<AlertSendType>();
            PositionsList = new List<LookUpDataEntity>();
            SendCriteriaList = new List<AlertSendCriteria>();
            EmployeeList = new List<UserLoginModel>();
            EmployeeAlertList = new List<EmployeeAlert>();
            LocationsList = new List<LookUpDataEntity>();
            DepartmentsList = new List<LookUpDataEntity>();
            EmploymentStatusList = new List<LookUpDataEntity>();
        }
        public AlertTemplate AlertTemplate { get; set; }
        public List<AlertSendType> SendToList { get; set; }
        public List<AlertSendCriteria> SendCriteriaList { get; set; }
        public List<LookUpDataEntity> PositionsList { get; set; }
        public List<LookUpDataEntity> LocationsList { get; set; }
        public List<LookUpDataEntity> DepartmentsList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<UserLoginModel> EmployeeList { get; set; }
        public List<EmployeeAlert> EmployeeAlertList { get; set; }
    }
}