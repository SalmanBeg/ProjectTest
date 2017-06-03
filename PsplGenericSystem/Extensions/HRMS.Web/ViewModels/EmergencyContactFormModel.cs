using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class EmergencyContactFormModel
    {
        public EmergencyContactFormModel()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            RelationShipList = new List<LookUpDataEntity>();
        }
        public EmployeeEmergencyContact EmployeeEmergencyContact { get; set; }
        public int EmployeeEmergencyContactId { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }
        public string EmployeeEmergencyContactDetailCode { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only please")]  
        public string Name { get; set; }       
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }      
        public string CellPhone { get; set; }      
        public string PersonalEmail { get; set; }      
        public string WorkEmail { get; set; }      
        public string Street1 { get; set; }        
        public string Street2 { get; set; }       
        public string City { get; set; }
        public string Zip { get; set; }       
        public Boolean IsPrimaryContact { get; set; } 
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //public bool IsPrimaryContact
        //{

        //    get
        //    {
        //        return (EmployeeEmergencyContact != null && EmployeeEmergencyContact.IsPrimaryContact != null);
        //    }
        //}

        #region Dropdown Properties      
        public List<CountryRegion> CountryList { get; set; }       
        public List<StateProvince> StateList { get; set; }
        public List<LookUpDataEntity> RelationShipList { get; set; }       
        public int Relationship { get; set; }
        public string RelationshipName { get; set; }
        #endregion
    }
}