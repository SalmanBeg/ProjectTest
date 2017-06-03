using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(WorkAuthorizationMetaData))]
    public partial class WorkAuthorization
    {
        public List<CountryRegion> CountryofList { get; set; }
        public bool FederalLaw1
        {
            get
            {
                if (FederalLaw != null)
                    return Convert.ToBoolean(FederalLaw);
                else
                    return false;
            }
            set
            {
                FederalLaw = value;
            }
        }

        public bool IsSSN1
        {
            get
            {
                if (IsSSN != null)
                    return Convert.ToBoolean(IsSSN);
                else
                    return false;
            }
            set
            {
                IsSSN = value;
            }
        }
    }
    public partial class WorkAuthorizationMetaData
    {
        public WorkAuthorizationMetaData()
        {
           
        }
        public DateTime? EmployeeSignDate { get; set; }
        public string IPAddress { get; set; }
        [Display(Name = "I am aware the Federal Law provides for imprisonment and/or fines for false statements or use of false documents in connection with the completion of this form.")]
        public bool FederalLaw { get; set; }
        public bool IsSSN { get; set; }
       

        #region Dropdown Properties
           

    
        
       
        //[Display(Name = "Document1")]
        //public int? I9AcceptableDocuments1 { get; set; }
       
        //[Display(Name = "Document2")]
        //public int? I9AcceptableDocuments2 { get; set; }
       
        //[Display(Name = "Document3")]
        //public int? I9AcceptableDocuments3 { get; set; }
       
        //[Display(Name = "List")]
        //public int? I9DocumentationType { get; set; }

        #endregion 
    }
}
