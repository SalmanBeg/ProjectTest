using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeePayFormModel
    {
        public EmployeePayFormModel()
        {
            ReasonList = new List<LookUpDataEntity>();
            PayGradeList = new List<LookUpDataEntity>();
            ShiftTypeList = new List<LookUpDataEntity>();
            EmployeePay = new EmployeePay();
            PayFrequencyList = new List<LookUpDataEntity>();
            ContractStuatusList = new List<LookUpDataEntity>();
            JobAssignmentList = new List<LookUpDataEntity>();
            PayTypeList = new List<PayType>();
        }

        public EmployeePay EmployeePay { get; set; }
       public bool AutoPay
        {

            get
            {
                return ( EmployeePay != null && EmployeePay.AutoPay!=null);
            }
        }
       public bool Tipped
       {

           get
           {
               return (EmployeePay != null && EmployeePay.Tipped != null);
           }
       }
       public List<LookUpDataEntity> ReasonList { get; set; }
        public List<LookUpDataEntity> PayGradeList { get; set; }
        public List<LookUpDataEntity> ShiftTypeList { get; set; }     
        public List<LookUpDataEntity> PayFrequencyList { get; set; }
        public List<LookUpDataEntity> PayStatusList { get; set; }
        public List<LookUpDataEntity> ContractStuatusList { get; set; }
        public List<LookUpDataEntity> JobAssignmentList { get; set; }
        public List<PayType> PayTypeList { get; set; }
        public List<PayType> PayCodeList { get; set; }
        public List<PayPeriods> PayPeriodList { get; set; }
        
    }
}