using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class EmployeeFields
        {
            public const string EmploymentDetailId = "EmploymentDetailId";
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
        }

        public bool CreateEmployee(Employee employeeobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
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

        public Employee SelectEmployeeById(int userId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@UserID", userId);
                IDataReader employeerdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectEmployeeById", ref executionState);

                var employeeobj = new Employee();
                while (employeerdr.Read())
                {
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.EmploymentDetailId)))
                        employeeobj.EmploymentDetailId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.EmploymentDetailId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.EmploymentId)))
                        employeeobj.EmploymentCode = employeerdr.GetGuid(employeerdr.GetOrdinal(EmployeeFields.EmploymentId)).ToString();
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.CompanyId)))
                        employeeobj.CompanyId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.CompanyId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.UserId)))
                        employeeobj.UserId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.UserId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.ChangeReason)))
                        employeeobj.ChangeReason = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.ChangeReason));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.HireDate)))
                        employeeobj.HireDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.HireDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.OriginalHireDate)))
                        employeeobj.OriginalHireDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.OriginalHireDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.TerminationDate)))
                        employeeobj.TerminationDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.TerminationDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.StartDate)))
                        employeeobj.StartDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.StartDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.SeniorityDate)))
                        employeeobj.SeniorityDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.SeniorityDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LastPaidDate)))
                        employeeobj.LastPaidDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.LastPaidDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LastPromotionDate)))
                        employeeobj.LastPromotionDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.LastPromotionDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LastReviewDate)))
                        employeeobj.LastReviewDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.LastReviewDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.NextReviewDate)))
                        employeeobj.NextReviewDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.NextReviewDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.NewHireReportDate)))
                        employeeobj.NewHireReportDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.NewHireReportDate));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LastPayRise)))
                        employeeobj.LastPayRise = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.LastPayRise));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.TerminationReason)))
                        employeeobj.TerminationReason = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.TerminationReason));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.EmploymentStatus)))
                        employeeobj.EmploymentStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.EmploymentStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.JobProfileId)))
                        employeeobj.JobProfile = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.JobProfileId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.PositionId)))
                        employeeobj.Position = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.PositionId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.PayGroup)))
                        employeeobj.PayGroupName = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.PayGroup));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LocationId)))
                        employeeobj.Location = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.LocationId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.DivisionId)))
                        employeeobj.Division = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.DivisionId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.DepartmentId)))
                        employeeobj.Department = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.DepartmentId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.ManagerId)))
                        employeeobj.Manager = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.ManagerId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.EmploymentType)))
                        employeeobj.EmploymentType = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.EmploymentType));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.ComplianceCode)))
                        employeeobj.ComplianceCode = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.ComplianceCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.BenefitClass)))
                        employeeobj.BenefitClass = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.BenefitClass));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.FLSAStatus)))
                        employeeobj.FLSAStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.FLSAStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Union)))
                        employeeobj.Union = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.Union));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.DistrictCode)))
                        employeeobj.DistrictCode = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.DistrictCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.CheckDistribution)))
                        employeeobj.CheckDistribution = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.CheckDistribution));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.DirectDepositEmail)))
                        employeeobj.DirectDepositEmail = employeerdr.GetBoolean(employeerdr.GetOrdinal(EmployeeFields.DirectDepositEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.OkToRehire)))
                        employeeobj.OkToRehire = employeerdr.GetBoolean(employeerdr.GetOrdinal(EmployeeFields.OkToRehire));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.WCJobClassCode)))
                        employeeobj.WCJobClassCode = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.WCJobClassCode));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.WCStatus)))
                        employeeobj.WCStatus = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.WCStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.WCType)))
                        employeeobj.WCType = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.WCType));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.WorkEmail)))
                        employeeobj.WorkEmail = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.WorkEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.WorkPhone)))
                        employeeobj.WorkPhone = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.WorkPhone));

                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Salutation)))
                        employeeobj.Salutation = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Salutation));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.FirstName)))
                        employeeobj.FirstName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.FirstName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.MiddleName)))
                        employeeobj.MiddleName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.MiddleName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.LastName)))
                        employeeobj.LastName = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.LastName));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Suffix)))
                        employeeobj.Suffix = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Suffix));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Email)))
                        employeeobj.Email = employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Email));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.CompanyId)))
                        employeeobj.CompanyId =employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.CompanyId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Address1)))
                        employeeobj.Address1 =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Address1));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Address2)))
                        employeeobj.Address2 =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Address2));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.City)))
                        employeeobj.City =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.City));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Zip)))
                        employeeobj.Zip =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Zip));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Ssn)))
                        employeeobj.SSN =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.Ssn));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.HomePhone)))
                        employeeobj.HomePhone =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.HomePhone));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.Gender)))
                        employeeobj.Gender =employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.Gender));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.MaritalStatus)))
                        employeeobj.MaritalStatus =employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.MaritalStatus));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.HomeEmail)))
                        employeeobj.HomeEmail =employeerdr.GetString(employeerdr.GetOrdinal(EmployeeFields.HomeEmail));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.CountryId)))
                        employeeobj.CountryId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.CountryId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.StateId)))
                        employeeobj.StateId = employeerdr.GetInt32(employeerdr.GetOrdinal(EmployeeFields.StateId));
                    if (!employeerdr.IsDBNull(employeerdr.GetOrdinal(EmployeeFields.BirthDate)))
                        employeeobj.BirthDate = employeerdr.GetDateTime(employeerdr.GetOrdinal(EmployeeFields.BirthDate));
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
    }
}
