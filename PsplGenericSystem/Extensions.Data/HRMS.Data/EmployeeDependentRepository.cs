using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class EmployeeDependentRepository : IEmployeeDependentRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class EmployeeDependentDetailFields
        {
            public const string EmployeeDependentDetailId = "EmployeeDependentDetailId";
            public const string CompanyId = "CompanyId";
            public const string UserId = "UserId";
            public const string EmployeeDependentDetailCode = "EmployeeDependentDetailCode";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string MiddleName = "MiddleName";
            public const string Suffix = "Suffix";
            public const string Alias = "Alias";
            public const string Salutation = "Salutation";
            public const string Street1 = "Street1";
            public const string Street2 = "Street2";
            public const string City = "City";
            public const string CountryId = "CountryId";
            public const string StateId = "StateId";
            public const string Zip = "Zip";
            public const string HomeEmail = "HomeEmail";
            public const string HomePhone = "HomePhone";
            public const string CellPhone = "CellPhone";
            public const string Ssn = "SSN";
            public const string BirthDate = "BirthDate";
            public const string Gender = "Gender";
            public const string RelationShip = "RelationShip";
            public const string ImputedIncome = "ImputedIncome";
            public const string Disabled = "Disabled";
            public const string Smoker = "Smoker";
            public const string Student = "Student";
            public const string RelationShipName = "RelationShipName";
        }

        public bool AddDependentDetail(EmployeeDependentDetail employeeDependentDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", employeeDependentDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", employeeDependentDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@FirstName", employeeDependentDetailobj.FirstName);
                _oDatabaseHelper.AddParameter("@LastName", employeeDependentDetailobj.LastName);
                _oDatabaseHelper.AddParameter("@MiddleName", employeeDependentDetailobj.MiddleName);
                _oDatabaseHelper.AddParameter("@Suffix", employeeDependentDetailobj.Suffix);
                _oDatabaseHelper.AddParameter("@Alias", employeeDependentDetailobj.Alias);
                _oDatabaseHelper.AddParameter("@Salutation", employeeDependentDetailobj.Salutation);
                _oDatabaseHelper.AddParameter("@Street1", employeeDependentDetailobj.Street1);
                _oDatabaseHelper.AddParameter("@Street2", employeeDependentDetailobj.Street2);
                _oDatabaseHelper.AddParameter("@City", employeeDependentDetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeDependentDetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeDependentDetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeDependentDetailobj.Zip);
                _oDatabaseHelper.AddParameter("@HomeEmail", employeeDependentDetailobj.HomeEmail);
                _oDatabaseHelper.AddParameter("@HomePhone", employeeDependentDetailobj.HomePhone);
                _oDatabaseHelper.AddParameter("@CellPhone", employeeDependentDetailobj.CellPhone);
                _oDatabaseHelper.AddParameter("@SSN", employeeDependentDetailobj.SSN);
                _oDatabaseHelper.AddParameter("@BirthDate", employeeDependentDetailobj.BirthDate);
                _oDatabaseHelper.AddParameter("@Gender", employeeDependentDetailobj.Gender);
                _oDatabaseHelper.AddParameter("@RelationShip", employeeDependentDetailobj.RelationShip);
                _oDatabaseHelper.AddParameter("@ImputedIncome", employeeDependentDetailobj.ImputedIncome);
                _oDatabaseHelper.AddParameter("@Disabled", employeeDependentDetailobj.Disabled);
                _oDatabaseHelper.AddParameter("@Smoker", employeeDependentDetailobj.Smoker);
                _oDatabaseHelper.AddParameter("@Student", employeeDependentDetailobj.Student);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeDependentDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDependentDetailInsert", ref executionState);                
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

        public List<EmployeeDependentDetail> SelectAllEmployeeDependentDetail(int userId, int companyId)
        {
            try
            {
                var employeeDependentDetailList = new List<EmployeeDependentDetail>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@UserID", userId);
                IDataReader employeedependentrdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeDependentDetailSelectAll", ref executionState);

                while (employeedependentrdr.Read())
                {
                    var employeeDependentDetailobj = new EmployeeDependentDetail();
                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailId)))
                        employeeDependentDetailobj.EmployeeDependentDetailId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailCode)))
                        employeeDependentDetailobj.EmployeeDependentDetailCode = employeedependentrdr.GetGuid(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailCode)).ToString();

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CompanyId)))
                        employeeDependentDetailobj.CompanyId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CompanyId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.UserId)))
                        employeeDependentDetailobj.UserId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.UserId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.FirstName)))
                        employeeDependentDetailobj.FirstName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.FirstName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.MiddleName)))
                        employeeDependentDetailobj.MiddleName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.MiddleName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.LastName)))
                        employeeDependentDetailobj.LastName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.LastName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Suffix)))
                        employeeDependentDetailobj.Suffix = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Suffix));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Alias)))
                        employeeDependentDetailobj.Alias = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Alias));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Salutation)))
                        employeeDependentDetailobj.Salutation = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Salutation));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street1)))
                        employeeDependentDetailobj.Street1 = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street1));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street2)))
                        employeeDependentDetailobj.Street2 = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street2));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.City)))
                        employeeDependentDetailobj.City = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.City));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CountryId)))
                        employeeDependentDetailobj.CountryId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CountryId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.StateId)))
                        employeeDependentDetailobj.StateId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.StateId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Zip)))
                        employeeDependentDetailobj.Zip = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Zip));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomeEmail)))
                        employeeDependentDetailobj.HomeEmail = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomeEmail));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomePhone)))
                        employeeDependentDetailobj.HomePhone = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomePhone));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CellPhone)))
                        employeeDependentDetailobj.CellPhone = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CellPhone));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Ssn)))
                        employeeDependentDetailobj.SSN = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Ssn));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.BirthDate)))
                        employeeDependentDetailobj.BirthDate = employeedependentrdr.GetDateTime(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.BirthDate));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender)))
                        employeeDependentDetailobj.Gender = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender));
                       //employeeDependentDetailobj.Gender = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShip)))
                        employeeDependentDetailobj.RelationShip = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShip));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShipName)))
                        employeeDependentDetailobj.RelationShipName = employeedependentrdr.GetString  (employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShipName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.ImputedIncome)))
                        employeeDependentDetailobj.ImputedIncome = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.ImputedIncome));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Disabled)))
                        employeeDependentDetailobj.Disabled = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Disabled));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Smoker)))
                        employeeDependentDetailobj.Smoker = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Smoker));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Student)))
                        employeeDependentDetailobj.Student = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Student));

                    employeeDependentDetailList.Add(employeeDependentDetailobj);
                }
                employeedependentrdr.Close();
                return employeeDependentDetailList;
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

        public List<EmployeeDependentDetail> SelectEmployeeDependentDetailByDependentId(int employeeDependentId, int companyId)
        {
            try
            {
                var employeeDependentDetailList = new List<EmployeeDependentDetail>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@EmployeeDependentDetailID", employeeDependentId);
                IDataReader employeedependentrdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeDependentDetailSelect", ref executionState);

                while (employeedependentrdr.Read())
                {
                    var employeeDependentDetailobj = new EmployeeDependentDetail();
                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailId)))
                        employeeDependentDetailobj.EmployeeDependentDetailId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailCode)))
                        employeeDependentDetailobj.EmployeeDependentDetailCode = employeedependentrdr.GetGuid(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.EmployeeDependentDetailCode)).ToString();

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CompanyId)))
                        employeeDependentDetailobj.CompanyId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CompanyId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.UserId)))
                        employeeDependentDetailobj.UserId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.UserId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.FirstName)))
                        employeeDependentDetailobj.FirstName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.FirstName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.MiddleName)))
                        employeeDependentDetailobj.MiddleName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.MiddleName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.LastName)))
                        employeeDependentDetailobj.LastName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.LastName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Suffix)))
                        employeeDependentDetailobj.Suffix = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Suffix));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Alias)))
                        employeeDependentDetailobj.Alias = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Alias));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Salutation)))
                        employeeDependentDetailobj.Salutation = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Salutation));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street1)))
                        employeeDependentDetailobj.Street1 = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street1));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street2)))
                        employeeDependentDetailobj.Street2 = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Street2));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.City)))
                        employeeDependentDetailobj.City = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.City));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CountryId)))
                        employeeDependentDetailobj.CountryId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CountryId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.StateId)))
                        employeeDependentDetailobj.StateId = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.StateId));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Zip)))
                        employeeDependentDetailobj.Zip = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Zip));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomeEmail)))
                        employeeDependentDetailobj.HomeEmail = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomeEmail));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomePhone)))
                        employeeDependentDetailobj.HomePhone = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.HomePhone));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CellPhone)))
                        employeeDependentDetailobj.CellPhone = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.CellPhone));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Ssn)))
                        employeeDependentDetailobj.SSN = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Ssn));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.BirthDate)))
                        employeeDependentDetailobj.BirthDate = employeedependentrdr.GetDateTime(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.BirthDate));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender)))
                        employeeDependentDetailobj.Gender = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender));
                        //employeeDependentDetailobj.Gender = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Gender));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShip)))
                        employeeDependentDetailobj.RelationShip = employeedependentrdr.GetInt32(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShip));

                    //if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShipName)))
                    //    employeeDependentDetailobj.RelationShipName = employeedependentrdr.GetString(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.RelationShipName));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.ImputedIncome)))
                        employeeDependentDetailobj.ImputedIncome = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.ImputedIncome));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Disabled)))
                        employeeDependentDetailobj.Disabled = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Disabled));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Smoker)))
                        employeeDependentDetailobj.Smoker = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Smoker));

                    if (!employeedependentrdr.IsDBNull(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Student)))
                        employeeDependentDetailobj.Student = employeedependentrdr.GetBoolean(employeedependentrdr.GetOrdinal(EmployeeDependentDetailFields.Student));

                    employeeDependentDetailList.Add(employeeDependentDetailobj);
                }
                employeedependentrdr.Close();
                return employeeDependentDetailList;
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

        public bool UpdateEmployeeDependentDetail(EmployeeDependentDetail employeeDependentDetailobj)
        {

            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", employeeDependentDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@EmployeeDependentDetailID", employeeDependentDetailobj.EmployeeDependentDetailId);
                _oDatabaseHelper.AddParameter("@FirstName", employeeDependentDetailobj.FirstName);
                _oDatabaseHelper.AddParameter("@LastName", employeeDependentDetailobj.LastName);
                _oDatabaseHelper.AddParameter("@MiddleName", employeeDependentDetailobj.MiddleName);
                _oDatabaseHelper.AddParameter("@Suffix", employeeDependentDetailobj.Suffix);
                _oDatabaseHelper.AddParameter("@Alias", employeeDependentDetailobj.Alias);
                _oDatabaseHelper.AddParameter("@Salutation", employeeDependentDetailobj.Salutation);
                _oDatabaseHelper.AddParameter("@Street1", employeeDependentDetailobj.Street1);
                _oDatabaseHelper.AddParameter("@Street2", employeeDependentDetailobj.Street2);
                _oDatabaseHelper.AddParameter("@City", employeeDependentDetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeDependentDetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeDependentDetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeDependentDetailobj.Zip);
                _oDatabaseHelper.AddParameter("@HomeEmail", employeeDependentDetailobj.HomeEmail);
                _oDatabaseHelper.AddParameter("@HomePhone", employeeDependentDetailobj.HomePhone);
                _oDatabaseHelper.AddParameter("@CellPhone", employeeDependentDetailobj.CellPhone);
                _oDatabaseHelper.AddParameter("@SSN", employeeDependentDetailobj.SSN);
                _oDatabaseHelper.AddParameter("@BirthDate", employeeDependentDetailobj.BirthDate);
                _oDatabaseHelper.AddParameter("@Gender",employeeDependentDetailobj.Gender);
                _oDatabaseHelper.AddParameter("@RelationShip", employeeDependentDetailobj.RelationShip);
                _oDatabaseHelper.AddParameter("@ImputedIncome", employeeDependentDetailobj.ImputedIncome);
                _oDatabaseHelper.AddParameter("@Disabled", employeeDependentDetailobj.Disabled);
                _oDatabaseHelper.AddParameter("@Smoker", employeeDependentDetailobj.Smoker);
                _oDatabaseHelper.AddParameter("@Student", employeeDependentDetailobj.Student);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeDependentDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDependentDetailUpdate", ref executionState);
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

        public bool DeleteDependentDetail(int employeeDependentDetailId,int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeDependentDetailId", employeeDependentDetailId);
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDependentDetailDelete", ref executionState);
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
    }
}
