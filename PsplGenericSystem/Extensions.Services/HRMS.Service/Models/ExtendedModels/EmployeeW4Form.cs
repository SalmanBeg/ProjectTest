using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeW4FormMetaData))]
    public partial class EmployeeW4Form
    {
        public bool Single { get; set; }
        public bool Married { get; set; }
        public bool MarriedWithHolding { get; set; }
        public bool IsSSNLastNameDiffers { get; set; }
    }
     public partial class EmployeeW4FormMetaData
     {
         public int Employeew4formId { get; set; }
         public int? UserId { get; set; }
         public int? CompanyId { get; set; }
         public string PersonalAllowancesA { get; set; }
         public int? PersonalAllowancesB { get; set; }
         public string PersonalAllowancesC { get; set; }
         public int? PersonalAllowancesD { get; set; }
         public string PersonalAllowancesE { get; set; }
         public string PersonalAllowancesF { get; set; }
         public string PersonalAllowancesG { get; set; }
         public string PersonalAllowancesH { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string SSNNO { get; set; }
         public string HomeAddress { get; set; }
         public string CityTownStateZip { get; set; }
         public bool EmployeesWithHolding3 { get; set; }
         public bool EmployeesWithHolding4 { get; set; }
         public double? EmployeesWithHolding5 { get; set; }
         public double? EmployeesWithHolding6 { get; set; }
         public string EmployeesWithHolding7 { get; set; }
         public int? EmployeeSignId { get; set; }
         public DateTime? SignDate { get; set; }
         public string EmployerAddress { get; set; }
         public string EmployeeOfficeCode { get; set; }
         public string IdentificationNo { get; set; }
         public double? Deductions1 { get; set; }
         public double? Deductions2 { get; set; }
         public double? Deductions3 { get; set; }
         public double? Deductions4 { get; set; }
         public double? Deductions5 { get; set; }
         public double? Deductions6 { get; set; }
         public double? Deductions7 { get; set; }
         public double? Deductions8 { get; set; }
         public double? Deductions9 { get; set; }
         public double? Deductions10 { get; set; }
         public string Earnings1 { get; set; }
         public string Earnings2 { get; set; }
         public string Earnings3 { get; set; }
         public string Earnings4 { get; set; }
         public string Earnings5 { get; set; }
         public string Earnings6 { get; set; }
         public int? Earnings7 { get; set; }
         public int? Earnings8 { get; set; }
         public int? Earnings9 { get; set; }
        
     }
}
