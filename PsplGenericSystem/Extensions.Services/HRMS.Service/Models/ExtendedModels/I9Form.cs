using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(I9FormMetaData))]
    public partial class I9Form
    {
    }
    public partial class I9FormMetaData
    {
        public I9FormMetaData()
        {
            StateTaxesLiveinCountryList = new List<CountryRegion>();
            I9AcceptableDocuments1List = new List<LookUpDataEntity>();
            I9AcceptableDocuments2List = new List<LookUpDataEntity>();
            I9AcceptableDocuments3List = new List<LookUpDataEntity>();
        }
        public int I9FormId { get; set; }
        public int I9FormCode { get; set; }
        public int UserId { get; set; }
        public string TransactionId { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string IPAddress { get; set; }

        [Display(Name = "A Citizen or national of United States")]
        public int CitizenOfUS { get; set; }

        [Display(Name = "(Alien Number):")]
        public string AlienNumber { get; set; }

        [Display(Name = "Expiration Date:")]
        public DateTime? PermanetResidentExpire { get; set; }

        [Display(Name = "Expiration Date:")]
        public DateTime? AlienAuthorisedDate { get; set; }
        [Display(Name = "Citizen of:")]
        public Char AlienAutharisedCitizenof { get; set; }

        [Display(Name = "I am aware the Federal Law provides for imprisonment and/or fines for false statements or use of false documents in connection with the completion of this form.")]
        public bool FederalLaw { get; set; }

        public bool SSN { get; set; }
        public Char Sign { get; set; }
        [Display(Name = "Do not display my Social Security Number on my I-9 form.")]
        public string I9Status { get; set; }
        public string Alien { get; set; }
        public DateTime? Expires { get; set; }
        [Display(Name = "Citizen of:")]
        public Char AlienCitizenof { get; set; }

        public string Confirmation { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentTitle1 { get; set; }
        public string DocumentTitle2 { get; set; }
        public string FileName { get; set; }
        public string DocumentSize { get; set; }
        public Byte Content { get; set; }
        public string ContentType { get; set; }
        public DateTime? ExprirationDate { get; set; }
        public DateTime? EmploymentOn { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsEmployerSign { get; set; }
        public string EmployerUserid { get; set; }
        public string EmployerTransactionId { get; set; }
        public DateTime? EmployerSignDate { get; set; }



        #region Dropdown Properties


        // ------------------- Country Dropdown Values ---------------------------
        public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        [Required(ErrorMessage = "Please select country.")]
        public int StateTaxesLiveinCountry { get; set; }


        //public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        //[Display(Name = "Live-in Country")]
        //[Required(ErrorMessage = "Please select live-in country.")]
        //public int StateTaxesLiveinCountry { get; set; }


        public List<LookUpDataEntity> I9AcceptableDocuments1List { get; set; }
        [Display(Name = "Document1")]
        public int? I9AcceptableDocuments1 { get; set; }

        public List<LookUpDataEntity> I9AcceptableDocuments2List { get; set; }
        [Display(Name = "Document2")]
        public int? I9AcceptableDocuments2 { get; set; }

        public List<LookUpDataEntity> I9AcceptableDocuments3List { get; set; }
        [Display(Name = "Document3")]
        public int? I9AcceptableDocuments3 { get; set; }


        #endregion 
    }
}
