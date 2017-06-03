using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using System.Data;
using HRMS.Service.Models.ExtensionProc;
using System.Reflection;
using System.Data.SqlClient;

namespace HRMS.Service.Repositories
{
    public class ImportEmployeecsvRepository : IImportEmployeecsvRepository
    {
        public class EmployeecsvFields
        {
            public const string EmploymentDetailId = "EmploymentDetailId";
            public const string UserName = "UserName";
            public const string UserId = "UserId";
            public const string CompanyId = "CompanyId";
            public const string EmployeeId = "EmployeeId";
            public const string EmploymentId = "EmploymentId";
            public const string HireDate = "HireDate";
            public const string OriginalHireDate = "OriginalHireDate";
            public const string TerminationDate = "TerminationDate";
            public const string TerminationReason = "TerminationReason";
            public const string StartDate = "StartDate";
            public const string SeniorityDate = "SeniorityDate";
            public const string LastPaidDate = "LastPaidDate";
            public const string LastPayRise = "LastPayRise";
            public const string LastPromotionDate = "LastPromotionDate";
            public const string LastReviewDate = "LastReviewDate";
            public const string NextReviewDate = "NextReviewDate";
            public const string NewHireReportDate = "NewHireReportDate";
            public const string EmploymentStatus = "EmploymentStatus";
            public const string JobProfileId = "JobProfileId";
            public const string PositionId = "PositionId";
            public const string PayGroup = "PayGroup";
            public const string LocationId = "LocationId";
            public const string DivisionId = "DivisionId";
            public const string DepartmentId = "DepartmentId";
            public const string ManagerId = "ManagerId";
            public const string EmploymentType = "EmploymentType";
            public const string ComplianceCode = "ComplianceCode";
            public const string BenefitClass = "BenefitClass";
            public const string FLSAStatus = "FLSAStatus";
            public const string Union = "Union";
            public const string DistrictCode = "DistrictCode";
            public const string CheckDistribution = "CheckDistribution";
            public const string DirectDepositEmail = "DirectDepositEmail";
            public const string OkToRehire = "OkToRehire";
            public const string WCJobClassCode = "WCJobClassCode";
            public const string WCStatus = "WCStatus";
            public const string WCType = "WCType";
            public const string ChangeReason = "ChangeReason";
            public const string WorkPhone = "WorkPhone";
            public const string WorkEmail = "WorkEmail";
            public const string WorkersCompCode = "WorkersCompCode";
            public const string Salutation = "Salutation";
            public const string FirstName = "FirstName";
            public const string MiddleName = "MiddleName";
            public const string LastName = "LastName";
            public const string Suffix = "Suffix";
            public const string Email = "Email";
            public const string Address1 = "Address1";
            public const string Address2 = "Address2";
            public const string City = "City";
            public const string Zip = "ZIP";
            public const string CountryId = "CountryId";
            public const string StateId = "StateId";
            public const string Ssn = "SSN";
            public const string HomePhone = "HomePhone";
            public const string BirthDate = "BirthDate";
            public const string Gender = "Gender";
            public const string MaritalStatus = "MaritalStatus";
            public const string HomeEmail = "HomeEmail";
            public const string CreatedOn = "CreatedOn";
            public const string ImportTag = "ImportTag";
        }


        public bool CreateEmployee(ImportEmployeedata importEmployeedataobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                //var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                //System.Data.Entity.Core.Objects.ObjectParameter errorobj = null;
                //var result = hrmsEntity.usp_EmployeeInsertORUpdate(importEmployeedataobj.UserId, importEmployeedataobj.CompanyId, importEmployeedataobj.ChangeReason, importEmployeedataobj.HireDate
                //    , importEmployeedataobj.OriginalHireDate, importEmployeedataobj.TerminationDate, importEmployeedataobj.TerminationReason, importEmployeedataobj.StartDate
                //        , importEmployeedataobj.SeniorityDate, importEmployeedataobj.LastPaidDate, importEmployeedataobj.LastPayRise, importEmployeedataobj.LastPromotionDate
                //        , importEmployeedataobj.LastReviewDate, importEmployeedataobj.NextReviewDate, importEmployeedataobj.NewHireReportDate, importEmployeedataobj.EmploymentStatus, importEmployeedataobj.JobProfileId
                //        , importEmployeedataobj.PositionId, importEmployeedataobj.PayGroup, importEmployeedataobj.LocationId, importEmployeedataobj.DivisionId, importEmployeedataobj.DepartmentId
                //        , importEmployeedataobj.ManagerId, importEmployeedataobj.EmploymentType, importEmployeedataobj.ComplianceCode, importEmployeedataobj.BenefitClass, importEmployeedataobj.FLSAStatus
                //        , importEmployeedataobj.Union, importEmployeedataobj.DistrictCode, importEmployeedataobj.CheckDistribution, importEmployeedataobj.DirectDepositEmail, importEmployeedataobj.OkToRehire
                //        , importEmployeedataobj.WCJobClassCode, importEmployeedataobj.WCStatus, importEmployeedataobj.WCType, importEmployeedataobj.WorkPhone, importEmployeedataobj.WorkEmail
                //        , importEmployeedataobj.Salutation, importEmployeedataobj.FirstName, importEmployeedataobj.MiddleName, importEmployeedataobj.LastName, importEmployeedataobj.Suffix
                //        , importEmployeedataobj.Email, importEmployeedataobj.Address1, importEmployeedataobj.Address2, importEmployeedataobj.City, importEmployeedataobj.ZIP, importEmployeedataobj.CountryId
                //        , importEmployeedataobj.StateId, importEmployeedataobj.SSN, importEmployeedataobj.HomePhone, importEmployeedataobj.BirthDate, importEmployeedataobj.Gender, importEmployeedataobj.MaritalStatus
                //        , importEmployeedataobj.HomeEmail, output).ToList();

                //return result.Count > 0;
                return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }
        public ImportEmployeedata SelectEmployeeById(int userId, int companyId)
        {
            ImportEmployeedata importEmployeedataObj = new ImportEmployeedata();
            return importEmployeedataObj;
        }




        public bool InsertImportData(System.Data.DataTable dt)
        {
            throw new NotImplementedException();
        }

        public bool InsertIntoDummyTable(System.Data.DataTable dt)
        {
            throw new NotImplementedException();
        }


        public bool InsertCSVFileData(DataTable dtImport)
        {
            
            try
            {
                var parameter = new SqlParameter("@tblImportEmployeedata", SqlDbType.Structured);
                parameter.Value = dtImport;
                parameter.TypeName = "dbo.ImportEmployeeType";  
                using (HRMSEntities1 db = new HRMSEntities1())
                {
                    db.Database.ExecuteSqlCommand("exec HumanResources.usp_ImportBulkEmployee @tblImportEmployeedata", parameter);
                }  
               
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }
    }
}
