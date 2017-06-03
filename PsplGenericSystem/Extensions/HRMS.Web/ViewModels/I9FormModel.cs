using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Web.ViewModels
{
    public class I9FormModel
    {
        public I9FormModel()
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

        public Employee employee { get; set; }
        public EmployeeW4Form employeeW4form { get; set; }
        public string StateName { get; set; }
        public WorkAuthorization WorkAuthorization { get; set; }
        public WorkAuthorizationDocumentation WorkAuthorizationDocumentation { get; set; }
        public WorkAuthorizationDocumentationType WorkAuthorizationDocumentationType { get; set; }
        public EmployeeSign EmployeeSign { get; set; }

        public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        public List<CountryRegion> AlienAuthorisedCitizenofList { get; set; }
        public List<CountryRegion> CountryofList { get; set; }
        public List<CountryRegion> AlienCitizenofList { get; set; }
        public List<LookUpDataEntity> I9AcceptableDocuments1List { get; set; }
        public List<LookUpDataEntity> I9AcceptableDocuments2List { get; set; }
        public List<LookUpDataEntity> I9AcceptableDocuments3List { get; set; }
        public List<WorkAuthorizationDocumentationType> I9DocumentationTypeList { get; set; }
        public List<EmployeeSign> EmployeeSignList { get; set; }
    }
}