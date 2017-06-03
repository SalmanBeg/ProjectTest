using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class CompanyRegistrationFields
        {
            public const string CompanyId = "CompanyID";
            public const string CompanyCode = "CompanyCode";
            public const string CompanyName = "CompanyName";
            public const string Address1 = "Address1";
            public const string Address2 = "Address2";
            public const string City = "City";
            public const string Zip = "ZIP";
            public const string CountryId = "CountryID";
            public const string StateId = "StateID";
            public const string Phone = "Phone";
            public const string CompanyEmail = "CompanyEmail";
            public const string ConnectionString = "ConnectionString";
            public const string PrimaryControlId = "PrimaryControlID";
            public const string ControlId = "ControlID";
            public const string ControlType = "ControlType";
            public const string CorporateStructureId = "CorporateStructureID";
            public const string LegalStructureId = "LegalStructureID";
            public const string ParentId = "ParentID";
            public const string Description = "Description";
            public const string FEIN = "FEIN";
            public const string Status = "Status";
            public const string FromDate = "FromDate";
            public const string ToDate = "ToDate";
            public const string Activity = "Activity";
            public const string Website = "Website";
            public const string FISCYear = "FISCYear";
            public const string Currency = "Currency";
            public const string Language = "Language";
            public const string TimeZone = "TimeZone";
            public const string Association = "Association";
            public const string SubscriptionCode = "SubscriptionCode";
            public const string Type = "Type";
            public const string DatabaseName = "DatabaseName";
            public const string ServerName = "ServerName";
            public const string IsPositionManaged = "IsPositionManaged";
            public const string TimeProvider = "TimeProvider";
            public const string PayrollProvider = "PayrollProvider";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";

        }

        public bool CreateCompany(CompanyInfo companyInfoobj,int UserId)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@CompanyName", companyInfoobj.CompanyName);
            _oDatabaseHelper.AddParameter("@Address1", companyInfoobj.Address1);
            _oDatabaseHelper.AddParameter("@Address2", companyInfoobj.Address2);
            _oDatabaseHelper.AddParameter("@City", companyInfoobj.City);
            _oDatabaseHelper.AddParameter("@Zip", companyInfoobj.ZIP);
            _oDatabaseHelper.AddParameter("@CountryID", companyInfoobj.CountryId);
            _oDatabaseHelper.AddParameter("@StateID", companyInfoobj.StateId);
            _oDatabaseHelper.AddParameter("@Phone", companyInfoobj.Phone);
            _oDatabaseHelper.AddParameter("@CompanyEmail", companyInfoobj.CompanyEmail);
            _oDatabaseHelper.AddParameter("@ControlType", companyInfoobj.ControlType);
            _oDatabaseHelper.AddParameter("@ConnectionString", companyInfoobj.ConnectionString);
            _oDatabaseHelper.AddParameter("@PrimaryControlID", companyInfoobj.PrimaryControlId);
            _oDatabaseHelper.AddParameter("@ControlID", companyInfoobj.ControlId);
            _oDatabaseHelper.AddParameter("@CorporateStructureID", companyInfoobj.CorporateStructureId);
            _oDatabaseHelper.AddParameter("@LegalStructureID", companyInfoobj.LegalStructureId);
            _oDatabaseHelper.AddParameter("@ParentID", companyInfoobj.ParentId);
            _oDatabaseHelper.AddParameter("@Description", companyInfoobj.Description);
            _oDatabaseHelper.AddParameter("@FEIN", companyInfoobj.FEIN);
            _oDatabaseHelper.AddParameter("@Status", companyInfoobj.Status);
            _oDatabaseHelper.AddParameter("@FromDate", companyInfoobj.FromDate);
            _oDatabaseHelper.AddParameter("@ToDate", companyInfoobj.ToDate);
            _oDatabaseHelper.AddParameter("@Activity", companyInfoobj.Activity);
            _oDatabaseHelper.AddParameter("@Website", companyInfoobj.Website);
            _oDatabaseHelper.AddParameter("@FISCYear", companyInfoobj.FISCYear);
            _oDatabaseHelper.AddParameter("@Currency", companyInfoobj.Currency);
            _oDatabaseHelper.AddParameter("@Language", companyInfoobj.Language);
            _oDatabaseHelper.AddParameter("@TimeZone", companyInfoobj.TimeZone);
            _oDatabaseHelper.AddParameter("@Association", companyInfoobj.Association);
            _oDatabaseHelper.AddParameter("@SubscriptionCode", companyInfoobj.SubscriptionCode);
            _oDatabaseHelper.AddParameter("@Type", companyInfoobj.Type);
            _oDatabaseHelper.AddParameter("@DatabaseName", companyInfoobj.Database);
            _oDatabaseHelper.AddParameter("@ServerName", companyInfoobj.ServerName);
            _oDatabaseHelper.AddParameter("@IsPositionManaged", companyInfoobj.IsPositionManaged);
            _oDatabaseHelper.AddParameter("@TimeProvider", companyInfoobj.TimeProvider);
            _oDatabaseHelper.AddParameter("@PayrollProvider", companyInfoobj.PayrollProvider);
            _oDatabaseHelper.AddParameter("@UserId", UserId);
            _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_CompanyInfoInsert", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }

        public bool UpdateCompanyById(CompanyInfo companyInfoobj)
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@CompanyID", companyInfoobj.CompanyId);
            _oDatabaseHelper.AddParameter("@CompanyName", companyInfoobj.CompanyName);
            _oDatabaseHelper.AddParameter("@Address1", companyInfoobj.Address1);
            _oDatabaseHelper.AddParameter("@Address2", companyInfoobj.Address2);
            _oDatabaseHelper.AddParameter("@City", companyInfoobj.City);
            _oDatabaseHelper.AddParameter("@Zip", companyInfoobj.ZIP);
            _oDatabaseHelper.AddParameter("@CountryID", companyInfoobj.CountryId);
            _oDatabaseHelper.AddParameter("@StateID", companyInfoobj.StateId);
            _oDatabaseHelper.AddParameter("@Phone", companyInfoobj.Phone);
            _oDatabaseHelper.AddParameter("@CompanyEmail", companyInfoobj.CompanyEmail);
            _oDatabaseHelper.AddParameter("@ControlType", companyInfoobj.ControlType);
            _oDatabaseHelper.AddParameter("@ConnectionString", companyInfoobj.ConnectionString);
            _oDatabaseHelper.AddParameter("@PrimaryControlID", companyInfoobj.PrimaryControlId);
            _oDatabaseHelper.AddParameter("@ControlID", companyInfoobj.ControlId);
            _oDatabaseHelper.AddParameter("@CorporateStructureID", companyInfoobj.CorporateStructureId);
            _oDatabaseHelper.AddParameter("@LegalStructureID", companyInfoobj.LegalStructureId);
            _oDatabaseHelper.AddParameter("@ParentID", companyInfoobj.ParentId);
            _oDatabaseHelper.AddParameter("@Description", companyInfoobj.Description);
            _oDatabaseHelper.AddParameter("@FEIN", companyInfoobj.FEIN);
            _oDatabaseHelper.AddParameter("@Status", companyInfoobj.Status);
            _oDatabaseHelper.AddParameter("@FromDate", companyInfoobj.FromDate);
            _oDatabaseHelper.AddParameter("@ToDate", companyInfoobj.ToDate);
            _oDatabaseHelper.AddParameter("@Activity", companyInfoobj.Activity);
            _oDatabaseHelper.AddParameter("@Website", companyInfoobj.Website);
            _oDatabaseHelper.AddParameter("@FISCYear", companyInfoobj.FISCYear);
            _oDatabaseHelper.AddParameter("@Currency", companyInfoobj.Currency);
            _oDatabaseHelper.AddParameter("@Language", companyInfoobj.Language);
            _oDatabaseHelper.AddParameter("@TimeZone", companyInfoobj.TimeZone);
            _oDatabaseHelper.AddParameter("@Association", companyInfoobj.Association);
            _oDatabaseHelper.AddParameter("@SubscriptionCode", companyInfoobj.SubscriptionCode);
            _oDatabaseHelper.AddParameter("@Type", companyInfoobj.Type);
            _oDatabaseHelper.AddParameter("@DatabaseName", companyInfoobj.Database);
            _oDatabaseHelper.AddParameter("@ServerName", companyInfoobj.ServerName);
            _oDatabaseHelper.AddParameter("@IsPositionManaged", companyInfoobj.IsPositionManaged);
            _oDatabaseHelper.AddParameter("@TimeProvider", companyInfoobj.TimeProvider);
            _oDatabaseHelper.AddParameter("@PayrollProvider", companyInfoobj.PayrollProvider);
            _oDatabaseHelper.AddParameter("@CreatedBy", companyInfoobj.CreatedBy);
            _oDatabaseHelper.AddParameter("@ModifiedBy", companyInfoobj.ModifiedBy);
            _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_CompanyInfoUpdate", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }
        public List<CompanyInfo> GetCompanyInfo(int roleId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
               
                List<CompanyInfo> companyInfoList = new List<CompanyInfo>();
                _oDatabaseHelper.AddParameter("@RoleId", roleId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_CompanyInfoSelectAllByRoleId", ref executionState);
                while (rdr.Read())
                {
                    var companyInfoobj = new CompanyInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyId)))
                        companyInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyName)))
                        companyInfoobj.CompanyName = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.CompanyName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyCode)))
                        companyInfoobj.CompanyCode = rdr.GetGuid(rdr.GetOrdinal(CompanyRegistrationFields.CompanyCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Address1)))
                        companyInfoobj.Address1 = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Address1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Address2)))
                        companyInfoobj.Address2 = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Address2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.City)))
                        companyInfoobj.City = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.City));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Zip)))
                        companyInfoobj.ZIP = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Zip));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CountryId)))
                        companyInfoobj.CountryId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.CountryId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.StateId)))
                        companyInfoobj.StateId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.StateId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Phone)))
                        companyInfoobj.Phone = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Phone));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyEmail)))
                        companyInfoobj.CompanyEmail = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.CompanyEmail));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.City)))
                        companyInfoobj.City = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.City));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Status)))
                        companyInfoobj.Status = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Status));
                    companyInfoList.Add(companyInfoobj);
                }
                rdr.Close();
                return companyInfoList;
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
        public CompanyInfo GetEditCompanyInfo(int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                var companyInfoobj = new CompanyInfo();
                //List<CompanyInfo> companyEditInfoList = new List<CompanyInfo>();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_CompanyInfoSelectAllByCompanyId", ref executionState);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyId)))
                        companyInfoobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyName)))
                        companyInfoobj.CompanyName = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.CompanyName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyCode)))
                        companyInfoobj.CompanyCode = rdr.GetGuid(rdr.GetOrdinal(CompanyRegistrationFields.CompanyCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Address1)))
                        companyInfoobj.Address1 = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Address1));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Address2)))
                        companyInfoobj.Address2 = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Address2));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.City)))
                        companyInfoobj.City = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.City));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Zip)))
                        companyInfoobj.ZIP = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Zip));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CountryId)))
                        companyInfoobj.CountryId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.CountryId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.StateId)))
                        companyInfoobj.StateId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.StateId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Phone)))
                        companyInfoobj.Phone = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Phone));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CompanyEmail)))
                        companyInfoobj.CompanyEmail = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.CompanyEmail));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ControlType)))
                        companyInfoobj.ControlType = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.ControlType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ConnectionString)))
                        companyInfoobj.ConnectionString = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.ConnectionString));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.PrimaryControlId)))
                        companyInfoobj.PrimaryControlId = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.PrimaryControlId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ControlId)))
                        companyInfoobj.ControlId = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.ControlId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.CorporateStructureId)))
                        companyInfoobj.CorporateStructureId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.CorporateStructureId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.LegalStructureId)))
                        companyInfoobj.LegalStructureId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.LegalStructureId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ParentId)))
                        companyInfoobj.ParentId = rdr.GetInt32(rdr.GetOrdinal(CompanyRegistrationFields.ParentId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Description)))
                        companyInfoobj.Description = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.FEIN)))
                        companyInfoobj.FEIN = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.FEIN));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Status)))
                        companyInfoobj.Status = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Status));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.FromDate)))
                        companyInfoobj.FromDate = rdr.GetDateTime(rdr.GetOrdinal(CompanyRegistrationFields.FromDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ToDate)))
                        companyInfoobj.ToDate = rdr.GetDateTime(rdr.GetOrdinal(CompanyRegistrationFields.ToDate));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Activity)))
                        companyInfoobj.Activity = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Activity));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Website)))
                        companyInfoobj.Website = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Website));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.FISCYear)))
                        companyInfoobj.FISCYear = rdr.GetDateTime(rdr.GetOrdinal(CompanyRegistrationFields.FISCYear));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Currency)))
                        companyInfoobj.Currency = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Currency));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Language)))
                        companyInfoobj.Language = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Language));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.TimeZone)))
                        companyInfoobj.TimeZone = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.TimeZone));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Association)))
                        companyInfoobj.Association = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Association));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.SubscriptionCode)))
                        companyInfoobj.SubscriptionCode = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.SubscriptionCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Type)))
                        companyInfoobj.Type = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Type));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.DatabaseName)))
                        companyInfoobj.Database = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.DatabaseName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.ServerName)))
                        companyInfoobj.ServerName = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.ServerName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.Status)))
                        companyInfoobj.Status = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.Status));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.IsPositionManaged)))
                        companyInfoobj.IsPositionManaged = rdr.GetBoolean(rdr.GetOrdinal(CompanyRegistrationFields.IsPositionManaged));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.TimeProvider)))
                        companyInfoobj.TimeProvider = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.TimeProvider));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CompanyRegistrationFields.PayrollProvider)))
                        companyInfoobj.PayrollProvider = rdr.GetString(rdr.GetOrdinal(CompanyRegistrationFields.PayrollProvider));
                    //  companyEditInfoList.Add(companyInfoobj);
                }
                rdr.Close();
                return companyInfoobj;
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
