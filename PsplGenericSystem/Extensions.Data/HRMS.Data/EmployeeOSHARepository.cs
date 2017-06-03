using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;



namespace HRMS.Data
{
    public class EmployeeOSHARepository : IEmployeeOSHARepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class EmployeeOSHADetailFields
        {
            public const string UserId = "UserID";
            public const string CompanyId = "CompanyID";
            public const string EmployeeOSHADetailId = "EmployeeOSHADetailID";
            public const string EmployeeOSHADetailCode = "EmployeeOSHADetailCode";
            public const string CaseNumber = "CaseNumber";
            public const string IncidentDateTime = "IncidentDateTime";
            public const string IsNotReported = "IsNotReported";
            public const string MedicalCosts = "MedicalCosts";
            public const string Advisor = "Advisor";
            public const string CaseClosedOn = "CaseClosedOn";
            public const string CompletedBy = "CompletedBy";
            public const string WorkPhone = "WorkPhone";
            public const string FiledOn = "FiledOn";
            public const string ClaimType = "ClaimType";
            public const string OutCome = "OutCome";
            public const string IsEmployeeinEmergency = "IsEmployeeinEmergency";
            public const string IsEmployeeInPatient = "IsEmployeeInPatient";
            public const string Physician = "Physician";
            public const string Street = "Street";
            public const string Facility = "Facility";
            public const string City = "City";
            public const string CountryId = "CountryID";
            public const string StateId = "StateID";
            public const string Zip = "Zip";
            public const string IncidentDetailsMisc1 = "IncidentDetailsMisc1";
            public const string IncidentDetailsMisc2 = "IncidentDetailsMisc2";
            public const string IncidentDetailsMisc3 = "IncidentDetailsMisc3";
            public const string InjuryDetailsMisc1 = "InjuryDetailsMisc1";
            public const string InjuryDetailsMisc2 = "InjuryDetailsMisc2";
            public const string InjuryDetailsMisc3 = "InjuryDetailsMisc3";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";
            public const string JobTitle = "JobTitle";

        }


        public bool CreateEmployeeOSHADetails(EmployeeOSHADetail employeeoshadetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", employeeoshadetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeoshadetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@CaseNumber", employeeoshadetailobj.CaseNumber);
                _oDatabaseHelper.AddParameter("@IncidentDateTime", employeeoshadetailobj.IncidentDate);
                _oDatabaseHelper.AddParameter("@IsNotReported", employeeoshadetailobj.IsNotReported);
                _oDatabaseHelper.AddParameter("@MedicalCosts", employeeoshadetailobj.MedicalCosts);
                _oDatabaseHelper.AddParameter("@Advisor", employeeoshadetailobj.Advisor);
                _oDatabaseHelper.AddParameter("@CaseClosedOn", employeeoshadetailobj.CaseClosedOn);
                _oDatabaseHelper.AddParameter("@CompletedBy", employeeoshadetailobj.CompletedBy);
                _oDatabaseHelper.AddParameter("@WorkPhone", employeeoshadetailobj.WorkPhone);
                _oDatabaseHelper.AddParameter("@FiledOn", employeeoshadetailobj.FiledOn);
                _oDatabaseHelper.AddParameter("@ClaimType", employeeoshadetailobj.ClaimType);
                _oDatabaseHelper.AddParameter("@OutCome", employeeoshadetailobj.OutCome);
                _oDatabaseHelper.AddParameter("@IsEmployeeinEmergency", employeeoshadetailobj.IsEmployeeinEmergency);
                _oDatabaseHelper.AddParameter("@IsEmployeeInPatient", employeeoshadetailobj.IsEmployeeInPatient);
                _oDatabaseHelper.AddParameter("@Physician", employeeoshadetailobj.Physician);
                _oDatabaseHelper.AddParameter("@Street", employeeoshadetailobj.Street);
                _oDatabaseHelper.AddParameter("@Facility", employeeoshadetailobj.Facility);
                _oDatabaseHelper.AddParameter("@City", employeeoshadetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeoshadetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeoshadetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeoshadetailobj.Zip);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc1", employeeoshadetailobj.IncidentDetailsMisc1);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc2", employeeoshadetailobj.IncidentDetailsMisc2);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc3", employeeoshadetailobj.IncidentDetailsMisc3);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc1", employeeoshadetailobj.InjuryDetailsMisc1);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc2", employeeoshadetailobj.InjuryDetailsMisc2);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc3", employeeoshadetailobj.InjuryDetailsMisc3);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeoshadetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@Jobtitle", employeeoshadetailobj.JobTitle);
                _oDatabaseHelper.AddParameter("@OshaDetailID", ParameterDirection.Output);
                //_oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeOSHADetailInsert", ref executionState);
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

        public bool UpdateEmployeeOSHADetails(EmployeeOSHADetail employeeoshadetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", employeeoshadetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeoshadetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@EmployeeOSHADetailID", employeeoshadetailobj.EmployeeOSHADetailId);
                _oDatabaseHelper.AddParameter("@CaseNumber", employeeoshadetailobj.CaseNumber);
                _oDatabaseHelper.AddParameter("@IncidentDateTime", employeeoshadetailobj.IncidentDate);
                _oDatabaseHelper.AddParameter("@IsNotReported", employeeoshadetailobj.IsNotReported);
                _oDatabaseHelper.AddParameter("@MedicalCosts", employeeoshadetailobj.MedicalCosts);
                _oDatabaseHelper.AddParameter("@Advisor", employeeoshadetailobj.Advisor);
                _oDatabaseHelper.AddParameter("@CaseClosedOn", employeeoshadetailobj.CaseClosedOn);
                _oDatabaseHelper.AddParameter("@CompletedBy", employeeoshadetailobj.CompletedBy);
                _oDatabaseHelper.AddParameter("@WorkPhone", employeeoshadetailobj.WorkPhone);
                _oDatabaseHelper.AddParameter("@FiledOn", employeeoshadetailobj.FiledOn);
                _oDatabaseHelper.AddParameter("@ClaimType", employeeoshadetailobj.ClaimType);
                _oDatabaseHelper.AddParameter("@OutCome", employeeoshadetailobj.OutCome);
                _oDatabaseHelper.AddParameter("@IsEmployeeinEmergency", employeeoshadetailobj.IsEmployeeinEmergency);
                _oDatabaseHelper.AddParameter("@IsEmployeeInPatient", employeeoshadetailobj.IsEmployeeInPatient);
                _oDatabaseHelper.AddParameter("@Physician", employeeoshadetailobj.Physician);
                _oDatabaseHelper.AddParameter("@Street", employeeoshadetailobj.Street);
                _oDatabaseHelper.AddParameter("@Facility", employeeoshadetailobj.Facility);
                _oDatabaseHelper.AddParameter("@City", employeeoshadetailobj.City);
                _oDatabaseHelper.AddParameter("@CountryID", employeeoshadetailobj.CountryId);
                _oDatabaseHelper.AddParameter("@StateID", employeeoshadetailobj.StateId);
                _oDatabaseHelper.AddParameter("@Zip", employeeoshadetailobj.Zip);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc1", employeeoshadetailobj.IncidentDetailsMisc1);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc2", employeeoshadetailobj.IncidentDetailsMisc2);
                _oDatabaseHelper.AddParameter("@IncidentDetailsMisc3", employeeoshadetailobj.IncidentDetailsMisc3);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc1", employeeoshadetailobj.InjuryDetailsMisc1);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc2", employeeoshadetailobj.InjuryDetailsMisc2);
                _oDatabaseHelper.AddParameter("@InjuryDetailsMisc3", employeeoshadetailobj.InjuryDetailsMisc3);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeoshadetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@Jobtitle", employeeoshadetailobj.JobTitle);
                //_oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeOSHADetailUpdate", ref executionState);
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
      
        public EmployeeOSHADetail SelectEmployeeOSHADetailById(int employeeOSHADetailId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                var employeeOSHADetailObj = new EmployeeOSHADetail();
                _oDatabaseHelper.AddParameter("@EmployeeOSHADetailID", employeeOSHADetailId);
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeOSHADetailSelectById", ref executionState);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.UserId)))
                        employeeOSHADetailObj.UserId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CompanyId)))
                        employeeOSHADetailObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailId)))
                        employeeOSHADetailObj.EmployeeOSHADetailId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailCode)))
                        employeeOSHADetailObj.EmployeeOSHADetailCode = rdr.GetGuid(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseNumber)))
                        employeeOSHADetailObj.CaseNumber = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseNumber));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDateTime)))
                        employeeOSHADetailObj.IncidentDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDateTime));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsNotReported)))
                        employeeOSHADetailObj.IsNotReported = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsNotReported));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.MedicalCosts)))
                        employeeOSHADetailObj.MedicalCosts = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.MedicalCosts));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Advisor)))
                        employeeOSHADetailObj.Advisor = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Advisor));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseClosedOn)))
                        employeeOSHADetailObj.CaseClosedOn = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseClosedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CompletedBy)))
                        employeeOSHADetailObj.CompletedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.CompletedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.WorkPhone)))
                        employeeOSHADetailObj.WorkPhone = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.WorkPhone));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.FiledOn)))
                        employeeOSHADetailObj.FiledOn = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.FiledOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.ClaimType)))
                        employeeOSHADetailObj.ClaimType = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.ClaimType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.OutCome)))
                        employeeOSHADetailObj.OutCome = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.OutCome));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeinEmergency)))
                        employeeOSHADetailObj.IsEmployeeinEmergency = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeinEmergency));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeInPatient)))
                        employeeOSHADetailObj.IsEmployeeInPatient = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeInPatient));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Physician)))
                        employeeOSHADetailObj.Physician = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Physician));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Street)))
                        employeeOSHADetailObj.Street = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Street));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Facility)))
                        employeeOSHADetailObj.Facility = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Facility));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.City)))
                        employeeOSHADetailObj.City = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.City));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CountryId)))
                        employeeOSHADetailObj.CountryId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CountryId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.StateId)))
                        employeeOSHADetailObj.StateId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.StateId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Zip)))
                        employeeOSHADetailObj.Zip = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Zip));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc1)))
                        employeeOSHADetailObj.IncidentDetailsMisc1 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc2)))
                        employeeOSHADetailObj.IncidentDetailsMisc2 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc3)))
                        employeeOSHADetailObj.IncidentDetailsMisc3 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc3));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc1)))
                        employeeOSHADetailObj.InjuryDetailsMisc1 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc2)))
                        employeeOSHADetailObj.InjuryDetailsMisc2 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc3)))
                        employeeOSHADetailObj.InjuryDetailsMisc3 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc3));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CreatedBy)))
                        employeeOSHADetailObj.CreatedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.CreatedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.ModifiedBy)))
                        employeeOSHADetailObj.ModifiedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.ModifiedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.JobTitle)))
                        employeeOSHADetailObj.JobTitle = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.JobTitle));
                }
                rdr.Close();
                _oDatabaseHelper.Dispose();
                return employeeOSHADetailObj;
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
        public List<EmployeeOSHADetail> SelectEmployeeOSHADetail(int companyId, int userId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                var employeeOSHADetailList = new List<EmployeeOSHADetail>();

                _oDatabaseHelper.AddParameter("@UserID", userId);
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeOSHADetailSelect", ref executionState);
                while (rdr.Read())
                {
                    var employeeOSHADetailObj = new EmployeeOSHADetail();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.UserId)))
                        employeeOSHADetailObj.UserId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CompanyId)))
                        employeeOSHADetailObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailId)))
                        employeeOSHADetailObj.EmployeeOSHADetailId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailCode)))
                        employeeOSHADetailObj.EmployeeOSHADetailCode = rdr.GetGuid(rdr.GetOrdinal(EmployeeOSHADetailFields.EmployeeOSHADetailCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseNumber)))
                        employeeOSHADetailObj.CaseNumber = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseNumber));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDateTime)))
                        employeeOSHADetailObj.IncidentDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDateTime));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsNotReported)))
                        employeeOSHADetailObj.IsNotReported = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsNotReported));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.MedicalCosts)))
                        employeeOSHADetailObj.MedicalCosts = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.MedicalCosts));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Advisor)))
                        employeeOSHADetailObj.Advisor = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Advisor));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseClosedOn)))
                        employeeOSHADetailObj.CaseClosedOn = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.CaseClosedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CompletedBy)))
                        employeeOSHADetailObj.CompletedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.CompletedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.WorkPhone)))
                        employeeOSHADetailObj.WorkPhone = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.WorkPhone));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.FiledOn)))
                        employeeOSHADetailObj.FiledOn = rdr.GetDateTime(rdr.GetOrdinal(EmployeeOSHADetailFields.FiledOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.ClaimType)))
                        employeeOSHADetailObj.ClaimType = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.ClaimType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.OutCome)))
                        employeeOSHADetailObj.OutCome = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.OutCome));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeinEmergency)))
                        employeeOSHADetailObj.IsEmployeeinEmergency = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeinEmergency));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeInPatient)))
                        employeeOSHADetailObj.IsEmployeeInPatient = rdr.GetBoolean(rdr.GetOrdinal(EmployeeOSHADetailFields.IsEmployeeInPatient));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Physician)))
                        employeeOSHADetailObj.Physician = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Physician));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Street)))
                        employeeOSHADetailObj.Street = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Street));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Facility)))
                        employeeOSHADetailObj.Facility = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Facility));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.City)))
                        employeeOSHADetailObj.City = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.City));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CountryId)))
                        employeeOSHADetailObj.CountryId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.CountryId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.StateId)))
                        employeeOSHADetailObj.StateId = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.StateId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.Zip)))
                        employeeOSHADetailObj.Zip = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.Zip));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc1)))
                        employeeOSHADetailObj.IncidentDetailsMisc1 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc2)))
                        employeeOSHADetailObj.IncidentDetailsMisc2 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc3)))
                        employeeOSHADetailObj.IncidentDetailsMisc3 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.IncidentDetailsMisc3));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc1)))
                        employeeOSHADetailObj.InjuryDetailsMisc1 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc2)))
                        employeeOSHADetailObj.InjuryDetailsMisc2 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc3)))
                        employeeOSHADetailObj.InjuryDetailsMisc3 = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.InjuryDetailsMisc3));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.CreatedBy)))
                        employeeOSHADetailObj.CreatedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.CreatedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.ModifiedBy)))
                        employeeOSHADetailObj.ModifiedBy = rdr.GetString(rdr.GetOrdinal(EmployeeOSHADetailFields.ModifiedBy));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeOSHADetailFields.JobTitle)))
                        employeeOSHADetailObj.JobTitle = rdr.GetInt32(rdr.GetOrdinal(EmployeeOSHADetailFields.JobTitle));
                    employeeOSHADetailList.Add(employeeOSHADetailObj);
                }
                rdr.Close();
                _oDatabaseHelper.Dispose();
                return employeeOSHADetailList;
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

        public bool DeleteOSHADetail(int OSHADetailId,int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeOSHADetailID", OSHADetailId);
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeOSHADetailDelete", ref executionState);
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
