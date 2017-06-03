using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class EmployeeEmergencyContactDetailFields
        {
            public const string EmployeeEmergencyContactDetailId = "EmployeeEmergencyContactDetailId";
            public const string EmployeeEmergencyContactDetailCode = "EmployeeEmergencyContactDetailCode";
            public const string CompanyId = "CompanyId";
            public const string UserId = "UserId";
            public const string Name = "Name";
            public const string HomePhone = "HomePhone";
            public const string WorkPhone = "WorkPhone";
            public const string CellPhone = "CellPhone";
            public const string PersonalEmail = "PersonalEmail";
            public const string WorkEmail = "WorkEmail";
            public const string Relationship = "Relationship";
            public const string Street1 = "Street1";
            public const string Street2 = "Street2";
            public const string City = "City";
            public const string CountryId = "CountryId";
            public const string StateId = "StateId";
            public const string Zip = "Zip";
            public const string RelationshipName = "RelationshipName";
            public const string IsPrimaryContact = "IsPrimaryContact";
        }
        public bool AddEmergencyContactDetail(EmployeeEmergencyContactDetail employeeEmergencyContactDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                _oDatabaseHelper.AddParameter("@CompanyID", employeeEmergencyContactDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", employeeEmergencyContactDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@Name", employeeEmergencyContactDetailobj.Name);
                _oDatabaseHelper.AddParameter("@HomePhone", employeeEmergencyContactDetailobj.HomePhone);
                _oDatabaseHelper.AddParameter("@WorkPhone", employeeEmergencyContactDetailobj.WorkPhone);
                _oDatabaseHelper.AddParameter("@CellPhone", employeeEmergencyContactDetailobj.CellPhone);
                _oDatabaseHelper.AddParameter("@PersonalEmail", employeeEmergencyContactDetailobj.PersonalEmail);
                _oDatabaseHelper.AddParameter("@WorkEmail", employeeEmergencyContactDetailobj.WorkEmail);
                _oDatabaseHelper.AddParameter("@Relationship", employeeEmergencyContactDetailobj.Relationship);
                _oDatabaseHelper.AddParameter("@Street1", employeeEmergencyContactDetailobj.Street1);
                _oDatabaseHelper.AddParameter("@Street2", employeeEmergencyContactDetailobj.Street2);
                _oDatabaseHelper.AddParameter("@City", employeeEmergencyContactDetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeEmergencyContactDetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeEmergencyContactDetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeEmergencyContactDetailobj.Zip);
                _oDatabaseHelper.AddParameter("@IsPrimaryContact", employeeEmergencyContactDetailobj.IsPrimaryContact);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeEmergencyContactDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeEmergencyContactDetailobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeEmergencyContactDetailInsert", ref executionState);
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
        public bool DeleteEmergencyContactDetail(int EmployeeEmergencyContactDetailID)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeEmergencyContactDetailID", EmployeeEmergencyContactDetailID);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeEmergencyContactDetailDelete", ref executionState);
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
        public bool UpdateEmergencyContactDetail(EmployeeEmergencyContactDetail employeeEmergencyContactDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeEmergencyContactDetailID", employeeEmergencyContactDetailobj.EmployeeEmergencyContactDetailId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeEmergencyContactDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", employeeEmergencyContactDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@Name", employeeEmergencyContactDetailobj.Name);
                _oDatabaseHelper.AddParameter("@HomePhone", employeeEmergencyContactDetailobj.HomePhone);
                _oDatabaseHelper.AddParameter("@WorkPhone", employeeEmergencyContactDetailobj.WorkPhone);
                _oDatabaseHelper.AddParameter("@CellPhone", employeeEmergencyContactDetailobj.CellPhone);
                _oDatabaseHelper.AddParameter("@PersonalEmail", employeeEmergencyContactDetailobj.PersonalEmail);
                _oDatabaseHelper.AddParameter("@WorkEmail", employeeEmergencyContactDetailobj.WorkEmail);
                _oDatabaseHelper.AddParameter("@Relationship", employeeEmergencyContactDetailobj.Relationship);
                _oDatabaseHelper.AddParameter("@Street1", employeeEmergencyContactDetailobj.Street1);
                _oDatabaseHelper.AddParameter("@Street2", employeeEmergencyContactDetailobj.Street2);
                _oDatabaseHelper.AddParameter("@City", employeeEmergencyContactDetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeEmergencyContactDetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeEmergencyContactDetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeEmergencyContactDetailobj.Zip);
                _oDatabaseHelper.AddParameter("@IsPrimaryContact", employeeEmergencyContactDetailobj.IsPrimaryContact);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeEmergencyContactDetailobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeEmergencyContactDetailUpdate", ref executionState);
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
        public List<EmployeeEmergencyContactDetail> SelectAllEmergencyContactDetail(int userId, int companyId)
        {
            try
            {
                var employeeEmergencyContactDetailList = new List<EmployeeEmergencyContactDetail>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@UserID", userId);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeEmergencyContactDetailSelectAll", ref executionState);

                while (emergencyContactredr.Read())
                {
                    var employeeEmergencyContactDetailobj = new EmployeeEmergencyContactDetail();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailId)))
                        employeeEmergencyContactDetailobj.EmployeeEmergencyContactDetailId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailCode)))
                        employeeEmergencyContactDetailobj.EmployeeEmergencyContactDetailCode = emergencyContactredr.GetGuid(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailCode)).ToString();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CompanyId)))
                        employeeEmergencyContactDetailobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.UserId)))
                        employeeEmergencyContactDetailobj.UserId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.UserId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Name)))
                        employeeEmergencyContactDetailobj.Name = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Name));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.HomePhone)))
                        employeeEmergencyContactDetailobj.HomePhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.HomePhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkPhone)))
                        employeeEmergencyContactDetailobj.WorkPhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkPhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CellPhone)))
                        employeeEmergencyContactDetailobj.CellPhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CellPhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.PersonalEmail)))
                        employeeEmergencyContactDetailobj.PersonalEmail = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.PersonalEmail));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkEmail)))
                        employeeEmergencyContactDetailobj.WorkEmail = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkEmail));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Relationship)))
                        employeeEmergencyContactDetailobj.Relationship = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Relationship));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.RelationshipName)))
                        employeeEmergencyContactDetailobj.RelationshipName = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.RelationshipName));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street1)))
                        employeeEmergencyContactDetailobj.Street1 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street1));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street2)))
                        employeeEmergencyContactDetailobj.Street2 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street2));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.City)))
                        employeeEmergencyContactDetailobj.City = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.City));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CountryId)))
                        employeeEmergencyContactDetailobj.CountryId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CountryId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.StateId)))
                        employeeEmergencyContactDetailobj.StateId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.StateId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Zip)))
                        employeeEmergencyContactDetailobj.Zip = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Zip));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.IsPrimaryContact)))
                        employeeEmergencyContactDetailobj.IsPrimaryContact = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.IsPrimaryContact));

                    employeeEmergencyContactDetailList.Add(employeeEmergencyContactDetailobj);
                }
                emergencyContactredr.Close();
                return employeeEmergencyContactDetailList;
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

        public List<EmployeeEmergencyContactDetail> SelectEmergencyContactDetailByEmergencyContactId(int emergencyContactId, int companyId)
        {
            try
            {
                var employeeEmergencyContactDetailList = new List<EmployeeEmergencyContactDetail>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@EmployeeEmergencyContactDetailID", emergencyContactId);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeEmergencyContactDetailSelect", ref executionState);

                while (emergencyContactredr.Read())
                {
                    var employeeEmergencyContactDetailobj = new EmployeeEmergencyContactDetail();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailId)))
                        employeeEmergencyContactDetailobj.EmployeeEmergencyContactDetailId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailCode)))
                        employeeEmergencyContactDetailobj.EmployeeEmergencyContactDetailCode = emergencyContactredr.GetGuid(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.EmployeeEmergencyContactDetailCode)).ToString();
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CompanyId)))
                        employeeEmergencyContactDetailobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.UserId)))
                        employeeEmergencyContactDetailobj.UserId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.UserId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Name)))
                        employeeEmergencyContactDetailobj.Name = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Name));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.HomePhone)))
                        employeeEmergencyContactDetailobj.HomePhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.HomePhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkPhone)))
                        employeeEmergencyContactDetailobj.WorkPhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkPhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CellPhone)))
                        employeeEmergencyContactDetailobj.CellPhone = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CellPhone));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.PersonalEmail)))
                        employeeEmergencyContactDetailobj.PersonalEmail = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.PersonalEmail));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkEmail)))
                        employeeEmergencyContactDetailobj.WorkEmail = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.WorkEmail));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Relationship)))
                        employeeEmergencyContactDetailobj.Relationship = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Relationship));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street1)))
                        employeeEmergencyContactDetailobj.Street1 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street1));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street2)))
                        employeeEmergencyContactDetailobj.Street2 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Street2));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.City)))
                        employeeEmergencyContactDetailobj.City = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.City));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CountryId)))
                        employeeEmergencyContactDetailobj.CountryId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.CountryId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.StateId)))
                        employeeEmergencyContactDetailobj.StateId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.StateId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Zip)))
                        employeeEmergencyContactDetailobj.Zip = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.Zip));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.IsPrimaryContact)))
                        employeeEmergencyContactDetailobj.IsPrimaryContact = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(EmployeeEmergencyContactDetailFields.IsPrimaryContact));
                    employeeEmergencyContactDetailList.Add(employeeEmergencyContactDetailobj);
                }
                emergencyContactredr.Close();
                return employeeEmergencyContactDetailList;
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
