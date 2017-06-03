using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class I9WorkAuthorization 
    {

        public I9WorkAuthorization()
        {
            StateTaxesLiveinCountryList = new List<CountryRegion>();
            AlienAuthorisedCitizenofList = new List<CountryRegion>();
            CountryofList = new List<CountryRegion>();
            AlienCitizenofList = new List<CountryRegion>();

            I9AcceptableDocuments1List = new List<LookUpDataEntity>();
            I9AcceptableDocuments2List = new List<LookUpDataEntity>();
            I9AcceptableDocuments3List = new List<LookUpDataEntity>();   
            I9DocumentationTypeList = new List<WorkAuthorizationDocumentationType>();
        }

        public int WorkAuthorizationID { get; set; }
        public System.Guid WorkAuthorizationCode { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int TransactionID { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string IPAddress { get; set; }

        [Display(Name = "A Citizen or national of United States")]
        public int CitizenOfUS { get; set; }

        [Display(Name = "(Alien Number):")]
        public string AlienNumber { get; set; }

        [Display(Name = "Expiration Date:")]
        public DateTime? PermanentResidentExpire { get; set; }

       // [Display(Name = "Citizen of:")]
       // public int AlienCitizenof { get; set; }

        [Display(Name = "Expiration Date:")]
        public DateTime? AlienAuthorisedDate { get; set; }

        //[Display(Name = "Citizen of:")]
        //public int AlienAuthorisedCitizenof { get; set; }

        [Display(Name = "I am aware the Federal Law provides for imprisonment and/or fines for false statements or use of false documents in connection with the completion of this form.")]
        public bool FederalLaw { get; set; }

        public bool IsSSN { get; set; }
        public bool IsEmployeeSign { get; set; }
        public string Confirmation { get; set; }
        public DateTime? EmploymentOn { get; set; }
        public bool IsEmployerSign { get; set; }
        public string EmployerUserID { get; set; }
        public string EmployerTransactionID { get; set; }
        public DateTime? EmployerSignDate { get; set; }
        public DateTime? CertificationDateA { get; set; }
        public DateTime? CertificationDateB { get; set; }
        public DateTime? CertificationDateC { get; set; }

        public byte[] Attachment { get; set; }
        public string AttachmentType { get; set; }
        public string AttachmentName { get; set; }

        //[RequiredIfAttribute(
       //[AssertThat("AlienRegistrationNumber != null && AdmissionNumber != null" )]
        public string AlienRegistrationNumber { get; set; }
        public string AdmissionNumber { get; set; }

        [Display(Name = "Foreign Passport Number:")]
        public string PassportNumber { get; set; }
      //  public int Countryof { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }


        #region Dropdown Properties
        // ------------------- Country Dropdown Values ---------------------------
        public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        //[Required(ErrorMessage = "Please select country.")]
        public int StateTaxesLiveinCountry { get; set; }

        public List<CountryRegion> AlienAuthorisedCitizenofList { get; set; }
         [Display(Name = "Citizen of:")]
        public int AlienAuthorisedCitizenof { get; set; }

        public List<CountryRegion> CountryofList { get; set; }
        //[Required(ErrorMessage = "Please select country.")]
        public int Countryof { get; set; }


        
        public List<CountryRegion> AlienCitizenofList { get; set; }
        [Display(Name = "Citizen of:")]
        public int AlienCitizenof { get; set; }


        public List<LookUpDataEntity> I9AcceptableDocuments1List { get; set; }
        [Display(Name = "Document1")]
        public int? I9AcceptableDocuments1 { get; set; }

        public List<LookUpDataEntity> I9AcceptableDocuments2List { get; set; }
        [Display(Name = "Document2")]
        public int? I9AcceptableDocuments2 { get; set; }

        public List<LookUpDataEntity> I9AcceptableDocuments3List { get; set; }
        [Display(Name = "Document3")]
        public int? I9AcceptableDocuments3 { get; set; }

        public List<WorkAuthorizationDocumentationType> I9DocumentationTypeList { get; set; }
        [Display(Name = "List")]
        public int? I9DocumentationType { get; set; }

        #endregion 

       
    }
}
