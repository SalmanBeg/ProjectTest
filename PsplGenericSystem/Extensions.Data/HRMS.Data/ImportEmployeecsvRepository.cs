using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class ImportEmployeecsvRepository : IImportEmployeecsvRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

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

        public bool CreateEmployee(ImportEmployeecsvdata employeeobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserName", employeeobj.UserName);
                _oDatabaseHelper.AddParameter("@UserID", employeeobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeobj.CompanyId);
                _oDatabaseHelper.AddParameter("@ChangeReason", employeeobj.ChangeReason);
                _oDatabaseHelper.AddParameter("@HireDate", employeeobj.HireDate);
                _oDatabaseHelper.AddParameter("@OriginalHireDate", employeeobj.OriginalHireDate);
                _oDatabaseHelper.AddParameter("@TerminationDate", employeeobj.TerminationDate);
                _oDatabaseHelper.AddParameter("@TerminationReason", employeeobj.TerminationReason);
                _oDatabaseHelper.AddParameter("@WorkPhone", employeeobj.WorkPhone);
                _oDatabaseHelper.AddParameter("@WorkEmail", employeeobj.WorkEmail);
                _oDatabaseHelper.AddParameter("@StartDate", employeeobj.StartDate);
                _oDatabaseHelper.AddParameter("@SeniorityDate", employeeobj.SeniorityDate);
                _oDatabaseHelper.AddParameter("@LastPaidDate", employeeobj.LastPaidDate);
                _oDatabaseHelper.AddParameter("@LastPayRise", employeeobj.LastPayRise);
                _oDatabaseHelper.AddParameter("@LastPromotionDate", employeeobj.LastPromotionDate);
                _oDatabaseHelper.AddParameter("@LastReviewDate", employeeobj.LastReviewDate);
                _oDatabaseHelper.AddParameter("@NextReviewDate", employeeobj.NextReviewDate);
                _oDatabaseHelper.AddParameter("@NewHireReportDate", employeeobj.NewHireReportDate);
                _oDatabaseHelper.AddParameter("@EmploymentStatus", employeeobj.EmploymentStatus);
                _oDatabaseHelper.AddParameter("@JobProfileID", employeeobj.JobProfile);
                _oDatabaseHelper.AddParameter("@PositionID", employeeobj.Position);
                _oDatabaseHelper.AddParameter("@PayGroup", employeeobj.PayGroupName);
                _oDatabaseHelper.AddParameter("@LocationID", employeeobj.Location);
                _oDatabaseHelper.AddParameter("@DivisionID", employeeobj.Division);
                _oDatabaseHelper.AddParameter("@DepartmentID", employeeobj.Department);
                _oDatabaseHelper.AddParameter("@ManagerID", employeeobj.Manager);
                _oDatabaseHelper.AddParameter("@EmploymentType", employeeobj.EmploymentType);
                _oDatabaseHelper.AddParameter("@ComplianceCode", employeeobj.ComplianceCode);
                _oDatabaseHelper.AddParameter("@BenefitClass", employeeobj.BenefitClass);
                _oDatabaseHelper.AddParameter("@FLSAStatus", employeeobj.FLSAStatus);
                _oDatabaseHelper.AddParameter("@Union", employeeobj.Union);
                _oDatabaseHelper.AddParameter("@DistrictCode", employeeobj.DistrictCode);
                _oDatabaseHelper.AddParameter("@CheckDistribution", employeeobj.CheckDistribution);
                _oDatabaseHelper.AddParameter("@DirectDepositEmail", employeeobj.DirectDepositEmail);
                _oDatabaseHelper.AddParameter("@OkToRehire", employeeobj.OkToRehire);
                _oDatabaseHelper.AddParameter("@WCJobClassCode", employeeobj.WCJobClassCode);
                _oDatabaseHelper.AddParameter("@WCStatus", employeeobj.WCStatus);
                _oDatabaseHelper.AddParameter("@WCType", employeeobj.WCType);

                _oDatabaseHelper.AddParameter("@Salutation", employeeobj.Salutation);
                _oDatabaseHelper.AddParameter("@FirstName", employeeobj.FirstName);
                _oDatabaseHelper.AddParameter("@MiddleName", employeeobj.MiddleName);
                _oDatabaseHelper.AddParameter("@LastName", employeeobj.LastName);
                _oDatabaseHelper.AddParameter("@Suffix", employeeobj.Suffix);
                _oDatabaseHelper.AddParameter("@Email", employeeobj.Email);
                _oDatabaseHelper.AddParameter("@Address1", employeeobj.Address1);
                _oDatabaseHelper.AddParameter("@Address2", employeeobj.Address2);
                _oDatabaseHelper.AddParameter("@City", employeeobj.City);
                _oDatabaseHelper.AddParameter("@ZIP", employeeobj.Zip);
                _oDatabaseHelper.AddParameter("@CountryID ", employeeobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeobj.StateId);
                _oDatabaseHelper.AddParameter("@SSN", employeeobj.SSN);
                _oDatabaseHelper.AddParameter("@HomePhone", employeeobj.HomePhone);
                _oDatabaseHelper.AddParameter("@BirthDate", employeeobj.BirthDate);
                _oDatabaseHelper.AddParameter("@Gender", employeeobj.Gender);
                _oDatabaseHelper.AddParameter("@MaritalStatus", employeeobj.MaritalStatus);
                _oDatabaseHelper.AddParameter("@HomeEmail", employeeobj.HomeEmail);

                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeInsertORUpdate", ref executionState);
                _oDatabaseHelper.Dispose();
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public ImportEmployeecsvdata SelectEmployeeById(int userId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@UserID", userId);
                IDataReader employeerdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeById", ref executionState);

                var employeeobj = new ImportEmployeecsvdata();
                while (employeerdr.Read())
                {
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentDetailId)))
                        employeeobj.EmploymentDetailId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentDetailId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentId)))
                        employeeobj.EmploymentCode = employeerdr.GetGuid(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentId)).ToString();
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.CompanyId)))
                        employeeobj.CompanyId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.CompanyId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.UserId)))
                        employeeobj.UserId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.UserId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.ChangeReason)))
                        employeeobj.ChangeReason = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.ChangeReason));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.HireDate)))
                        employeeobj.HireDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.HireDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.OriginalHireDate)))
                        employeeobj.OriginalHireDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.OriginalHireDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.TerminationDate)))
                        employeeobj.TerminationDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.TerminationDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.StartDate)))
                        employeeobj.StartDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.StartDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.SeniorityDate)))
                        employeeobj.SeniorityDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.SeniorityDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LastPaidDate)))
                        employeeobj.LastPaidDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.LastPaidDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LastPromotionDate)))
                        employeeobj.LastPromotionDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.LastPromotionDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LastReviewDate)))
                        employeeobj.LastReviewDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.LastReviewDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.NextReviewDate)))
                        employeeobj.NextReviewDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.NextReviewDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.NewHireReportDate)))
                        employeeobj.NewHireReportDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.NewHireReportDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LastPayRise)))
                        employeeobj.LastPayRise = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.LastPayRise));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.TerminationReason)))
                        employeeobj.TerminationReason = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.TerminationReason));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentStatus)))
                        employeeobj.EmploymentStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.JobProfileId)))
                        employeeobj.JobProfile = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.JobProfileId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.PositionId)))
                        employeeobj.Position = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.PositionId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.PayGroup)))
                        employeeobj.PayGroupName = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.PayGroup));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LocationId)))
                        employeeobj.Location = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.LocationId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.DivisionId)))
                        employeeobj.Division = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.DivisionId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.DepartmentId)))
                        employeeobj.Department = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.DepartmentId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.ManagerId)))
                        employeeobj.Manager = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.ManagerId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentType)))
                        employeeobj.EmploymentType = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.EmploymentType));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.ComplianceCode)))
                        employeeobj.ComplianceCode = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.ComplianceCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.BenefitClass)))
                        employeeobj.BenefitClass = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.BenefitClass));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.FLSAStatus)))
                        employeeobj.FLSAStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.FLSAStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Union)))
                        employeeobj.Union = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.Union));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.DistrictCode)))
                        employeeobj.DistrictCode = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.DistrictCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.CheckDistribution)))
                        employeeobj.CheckDistribution = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.CheckDistribution));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.DirectDepositEmail)))
                        employeeobj.DirectDepositEmail = employeerdr.GetBoolean(employeerdr.GetOrdinal(EmployeecsvFields.DirectDepositEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.OkToRehire)))
                        employeeobj.OkToRehire = employeerdr.GetBoolean(employeerdr.GetOrdinal(EmployeecsvFields.OkToRehire));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.WCJobClassCode)))
                        employeeobj.WCJobClassCode = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.WCJobClassCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.WCStatus)))
                        employeeobj.WCStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.WCStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.WCType)))
                        employeeobj.WCType = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.WCType));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.WorkEmail)))
                        employeeobj.WorkEmail = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.WorkEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.WorkPhone)))
                        employeeobj.WorkPhone = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.WorkPhone));

                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Salutation)))
                        employeeobj.Salutation = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Salutation));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.FirstName)))
                        employeeobj.FirstName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.FirstName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.MiddleName)))
                        employeeobj.MiddleName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.MiddleName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.LastName)))
                        employeeobj.LastName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.LastName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Suffix)))
                        employeeobj.Suffix = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Suffix));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Email)))
                        employeeobj.Email = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Email));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.CompanyId)))
                        employeeobj.CompanyId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.CompanyId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Address1)))
                        employeeobj.Address1 = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Address1));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Address2)))
                        employeeobj.Address2 = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Address2));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.City)))
                        employeeobj.City = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.City));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Zip)))
                        employeeobj.Zip = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Zip));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Ssn)))
                        employeeobj.SSN = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.Ssn));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.HomePhone)))
                        employeeobj.HomePhone = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.HomePhone));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.Gender)))
                        employeeobj.Gender = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.Gender));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.MaritalStatus)))
                        employeeobj.MaritalStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.MaritalStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.HomeEmail)))
                        employeeobj.HomeEmail = employeerdr.GetString(employeerdr.GetOrdinal(EmployeecsvFields.HomeEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.CountryId)))
                        employeeobj.CountryId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.CountryId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.StateId)))
                        employeeobj.StateId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeecsvFields.StateId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeecsvFields.BirthDate)))
                        employeeobj.BirthDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeecsvFields.BirthDate));
                    //if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmploymentDetailFields.WorkersCompCode)))
                    //    employmentDetailobj.WorkersCompCode = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmploymentDetailFields.WorkersCompCode));
                }
                employeerdr.Close();
                return employeeobj;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public bool Insertcsvfiledata(DataTable CSVTable)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                //_oDatabaseHelper.AddParameter("@tblImportEmployeedata", CSVTable);
                _oDatabaseHelper.AddParameter("@tblImportEmployeedata", CSVTable);
                // _oDatabaseHelper.ExecuteScalar("InsertImportCSVEmployeedata", ref executionState);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                //_oDatabaseHelper.ExecuteScalar("usp_ImportTEMP1", ref executionState);
                _oDatabaseHelper.ExecuteScalar("[HumanResources].[usp_ImportAndCreateUserSignUpTestesOn22]", ref executionState);
               
                _oDatabaseHelper.Dispose();
                return executionState;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

        public bool InsertImportdata(DataTable dt)
        {
            try
            {
                bool executionState = false;
               
                     _oDatabaseHelper = new DatabaseHelper();                   
                    _oDatabaseHelper.AddParameter("@UserName",dt.Rows[0]["UserName"] );
                    _oDatabaseHelper.AddParameter("@Password", dt.Rows[0]["Password"]);
                    _oDatabaseHelper.AddParameter("@EmployeeNo", dt.Rows[0]["EmployeeNo"]);
                    _oDatabaseHelper.AddParameter("@Salutation", dt.Rows[0]["Salutation"]);
                    _oDatabaseHelper.AddParameter("@FirstName", dt.Rows[0]["FirstName"]);
                    _oDatabaseHelper.AddParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
                    _oDatabaseHelper.AddParameter("@LastName", dt.Rows[0]["LastName"]);
                    _oDatabaseHelper.AddParameter("@Suffix", dt.Rows[0]["Suffix"]);
                    _oDatabaseHelper.AddParameter("@WorkEmail", dt.Rows[0]["HomeEmail"]);
                    _oDatabaseHelper.AddParameter("@Address1", dt.Rows[0]["Address1"]);
                    _oDatabaseHelper.AddParameter("@Address2", dt.Rows[0]["Address2"]);
                    _oDatabaseHelper.AddParameter("@City", dt.Rows[0]["City"]);
                    _oDatabaseHelper.AddParameter("@ZIP", dt.Rows[0]["ZIP"]);
                    _oDatabaseHelper.AddParameter("@CountryId", dt.Rows[0]["CountryId"]);
                    _oDatabaseHelper.AddParameter("@StateId", dt.Rows[0]["State"]);
                    _oDatabaseHelper.AddParameter("@SSN ", dt.Rows[0]["SSN"]);
                    _oDatabaseHelper.AddParameter("@WorkPhone1", dt.Rows[0]["WorkPhone1"]);
                    _oDatabaseHelper.AddParameter("@HomePhone", dt.Rows[0]["HomePhone"]);
                    _oDatabaseHelper.AddParameter("@BirthDate", dt.Rows[0]["BirthDate"]);
                    _oDatabaseHelper.AddParameter("@Gender", dt.Rows[0]["Gender"]);
                    _oDatabaseHelper.AddParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
                    _oDatabaseHelper.AddParameter("@HomeEmail", dt.Rows[0]["HomeEmail"]);
                    _oDatabaseHelper.AddParameter("@ChangeReason", dt.Rows[0]["ChangeReason"]);
                    _oDatabaseHelper.AddParameter("@HireDate", dt.Rows[0]["HireDate"]);
                    _oDatabaseHelper.AddParameter("@OriginalHireDate", dt.Rows[0]["OriginalHireDate"]);
                    _oDatabaseHelper.AddParameter("@TerminationDate", dt.Rows[0]["TerminationDate"]);
                    _oDatabaseHelper.AddParameter("@TerminationReason", dt.Rows[0]["TerminationReason"]);
                    _oDatabaseHelper.AddParameter("@WorkPhone", dt.Rows[0]["WorkPhone"]);
                  //  _oDatabaseHelper.AddParameter("@WorkEmail", dt.Rows[0]["HomeEmail"]);
                    _oDatabaseHelper.AddParameter("@StartDate", dt.Rows[0]["StartDate"]);
                    _oDatabaseHelper.AddParameter("@SeniorityDate", dt.Rows[0]["SeniorityDate"]);
                    _oDatabaseHelper.AddParameter("@LastPaidDate", dt.Rows[0]["LastPaidDate"]);
                    _oDatabaseHelper.AddParameter("@LastPayRise", dt.Rows[0]["LastPayRise"]);
                    _oDatabaseHelper.AddParameter("@LastPromotionDate", dt.Rows[0]["LastPromotionDate"]);
                    _oDatabaseHelper.AddParameter("@LastReviewDate", dt.Rows[0]["LastReviewDate"]);
                    _oDatabaseHelper.AddParameter("@NextReviewDate", dt.Rows[0]["NextReviewDate"]);
                    _oDatabaseHelper.AddParameter("@NewHireReportDate", dt.Rows[0]["NewHireReportDate"]);
                    _oDatabaseHelper.AddParameter("@EmploymentStatus", dt.Rows[0]["EmploymentStatus"]);
                    _oDatabaseHelper.AddParameter("@JobProfileId", dt.Rows[0]["JobProfileId"]);
                    _oDatabaseHelper.AddParameter("@PositionId", dt.Rows[0]["PositionId"]);
                    _oDatabaseHelper.AddParameter("@PayGroup", dt.Rows[0]["PayGroup"]);
                    _oDatabaseHelper.AddParameter("@LocationId", dt.Rows[0]["LocationId"]);
                    _oDatabaseHelper.AddParameter("@DivisionId", dt.Rows[0]["DivisionId"]);
                    _oDatabaseHelper.AddParameter("@DepartmentId", dt.Rows[0]["DepartmentId"]);
                    _oDatabaseHelper.AddParameter("@ManagerId", dt.Rows[0]["ManagerId"]);
                    _oDatabaseHelper.AddParameter("@EmploymentType", dt.Rows[0]["EmploymentType"]);
                    _oDatabaseHelper.AddParameter("@ComplianceCode", dt.Rows[0]["ComplianceCode"]);
                    _oDatabaseHelper.AddParameter("@BenefitClass", dt.Rows[0]["BenefitClass"]);
                    _oDatabaseHelper.AddParameter("@FLSAStatus", dt.Rows[0]["FLSAStatus"]);
                    _oDatabaseHelper.AddParameter("@Union", dt.Rows[0]["Union"]);
                    _oDatabaseHelper.AddParameter("@DistrictCode", dt.Rows[0]["DistrictCode"]);
                    _oDatabaseHelper.AddParameter("@CheckDistribution", dt.Rows[0]["CheckDistribution"]);
                    _oDatabaseHelper.AddParameter("@OkToRehire", dt.Rows[0]["OkToRehire"]);
                    _oDatabaseHelper.AddParameter("@WCJobClassCode", dt.Rows[0]["WCJobClassCode"]);
                    _oDatabaseHelper.AddParameter("@WCStatus", dt.Rows[0]["WCStatus"]);
                    _oDatabaseHelper.AddParameter("@WCType", dt.Rows[0]["WCType"]);
                    _oDatabaseHelper.AddParameter("@CompanyId", dt.Rows[0]["CompanyId"]);                    

                    _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);                     
                    _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ImportAndCreateUserSignUp", ref executionState);
                    //_oDatabaseHelper.ExecuteScalar("usp_ImportTEMP1", ref executionState);
                
                    _oDatabaseHelper.Dispose();                  
                    return executionState;
                //}
                 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

        public bool InsertintoDummytable(DataTable dt)
        {
            try
            {
                bool executionState = false;

                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserName", dt.Rows[0]["UserName"]);
                _oDatabaseHelper.AddParameter("@Password", dt.Rows[0]["Password"]);
                _oDatabaseHelper.AddParameter("@EmployeeNo", dt.Rows[0]["EmployeeNo"]);
                _oDatabaseHelper.AddParameter("@Salutation", dt.Rows[0]["Salutation"]);
                _oDatabaseHelper.AddParameter("@FirstName", dt.Rows[0]["FirstName"]);
                _oDatabaseHelper.AddParameter("@MiddleName", dt.Rows[0]["MiddleName"]);
                _oDatabaseHelper.AddParameter("@LastName", dt.Rows[0]["LastName"]);
                _oDatabaseHelper.AddParameter("@Suffix", dt.Rows[0]["Suffix"]);
                _oDatabaseHelper.AddParameter("@WorkEmail", dt.Rows[0]["HomeEmail"]);
                _oDatabaseHelper.AddParameter("@Address1", dt.Rows[0]["Address1"]);
                _oDatabaseHelper.AddParameter("@Address2", dt.Rows[0]["Address2"]);
                _oDatabaseHelper.AddParameter("@City", dt.Rows[0]["City"]);
                _oDatabaseHelper.AddParameter("@ZIP", dt.Rows[0]["ZIP"]);
                _oDatabaseHelper.AddParameter("@CountryId", dt.Rows[0]["CountryId"]);
                _oDatabaseHelper.AddParameter("@StateId", dt.Rows[0]["State"]);
                _oDatabaseHelper.AddParameter("@SSN ", dt.Rows[0]["SSN"]);
                _oDatabaseHelper.AddParameter("@WorkPhone1", dt.Rows[0]["WorkPhone1"]);
                _oDatabaseHelper.AddParameter("@HomePhone", dt.Rows[0]["HomePhone"]);
                _oDatabaseHelper.AddParameter("@BirthDate", dt.Rows[0]["BirthDate"]);
                _oDatabaseHelper.AddParameter("@Gender", dt.Rows[0]["Gender"]);
                _oDatabaseHelper.AddParameter("@MaritalStatus", dt.Rows[0]["MaritalStatus"]);
                _oDatabaseHelper.AddParameter("@HomeEmail", dt.Rows[0]["HomeEmail"]);
                _oDatabaseHelper.AddParameter("@ChangeReason", dt.Rows[0]["ChangeReason"]);
                _oDatabaseHelper.AddParameter("@HireDate", dt.Rows[0]["HireDate"]);
                _oDatabaseHelper.AddParameter("@OriginalHireDate", dt.Rows[0]["OriginalHireDate"]);
                _oDatabaseHelper.AddParameter("@TerminationDate", dt.Rows[0]["TerminationDate"]);
                _oDatabaseHelper.AddParameter("@TerminationReason", dt.Rows[0]["TerminationReason"]);
                _oDatabaseHelper.AddParameter("@WorkPhone", dt.Rows[0]["WorkPhone"]);
                //  _oDatabaseHelper.AddParameter("@WorkEmail", dt.Rows[0]["HomeEmail"]);
                _oDatabaseHelper.AddParameter("@StartDate", dt.Rows[0]["StartDate"]);
                _oDatabaseHelper.AddParameter("@SeniorityDate", dt.Rows[0]["SeniorityDate"]);
                _oDatabaseHelper.AddParameter("@LastPaidDate", dt.Rows[0]["LastPaidDate"]);
                _oDatabaseHelper.AddParameter("@LastPayRise", dt.Rows[0]["LastPayRise"]);
                _oDatabaseHelper.AddParameter("@LastPromotionDate", dt.Rows[0]["LastPromotionDate"]);
                _oDatabaseHelper.AddParameter("@LastReviewDate", dt.Rows[0]["LastReviewDate"]);
                _oDatabaseHelper.AddParameter("@NextReviewDate", dt.Rows[0]["NextReviewDate"]);
                _oDatabaseHelper.AddParameter("@NewHireReportDate", dt.Rows[0]["NewHireReportDate"]);
                _oDatabaseHelper.AddParameter("@EmploymentStatus", dt.Rows[0]["EmploymentStatus"]);
                _oDatabaseHelper.AddParameter("@JobProfileId", dt.Rows[0]["JobProfileId"]);
                _oDatabaseHelper.AddParameter("@PositionId", dt.Rows[0]["PositionId"]);
                _oDatabaseHelper.AddParameter("@PayGroup", dt.Rows[0]["PayGroup"]);
                _oDatabaseHelper.AddParameter("@LocationId", dt.Rows[0]["LocationId"]);
                _oDatabaseHelper.AddParameter("@DivisionId", dt.Rows[0]["DivisionId"]);
                _oDatabaseHelper.AddParameter("@DepartmentId", dt.Rows[0]["DepartmentId"]);
                _oDatabaseHelper.AddParameter("@ManagerId", dt.Rows[0]["ManagerId"]);
                _oDatabaseHelper.AddParameter("@EmploymentType", dt.Rows[0]["EmploymentType"]);
                _oDatabaseHelper.AddParameter("@ComplianceCode", dt.Rows[0]["ComplianceCode"]);
                _oDatabaseHelper.AddParameter("@BenefitClass", dt.Rows[0]["BenefitClass"]);
                _oDatabaseHelper.AddParameter("@FLSAStatus", dt.Rows[0]["FLSAStatus"]);
                _oDatabaseHelper.AddParameter("@Union", dt.Rows[0]["Union"]);
                _oDatabaseHelper.AddParameter("@DistrictCode", dt.Rows[0]["DistrictCode"]);
                _oDatabaseHelper.AddParameter("@CheckDistribution", dt.Rows[0]["CheckDistribution"]);
                _oDatabaseHelper.AddParameter("@OkToRehire", dt.Rows[0]["OkToRehire"]);
                _oDatabaseHelper.AddParameter("@WCJobClassCode", dt.Rows[0]["WCJobClassCode"]);
                _oDatabaseHelper.AddParameter("@WCStatus", dt.Rows[0]["WCStatus"]);
                _oDatabaseHelper.AddParameter("@WCType", dt.Rows[0]["WCType"]);
                _oDatabaseHelper.AddParameter("@CompanyId", dt.Rows[0]["CompanyId"]);
                _oDatabaseHelper.AddParameter("@Batchkey", dt.Rows[0]["CompanyId"]);
                //_oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
               // _oDatabaseHelper.ExecuteScalar("usp_ImportEmployeedataInsert", ref executionState);
                _oDatabaseHelper.ExecuteScalar("[usp_ImportTEMP3]", ref executionState);

                _oDatabaseHelper.Dispose();
                return executionState;
                //}

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

    }
}
