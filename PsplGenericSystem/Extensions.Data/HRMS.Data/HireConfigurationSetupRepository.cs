using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class HireConfigurationSetupRepository : IHireConfigurationSetupRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class HireConfigurationSetupFields
        {
            public const string CompanyId = "CompanyID";
            public const string UserSignUpId = "UserSignUpID";
            public const string UserSignUpCode = "UserSignUpCode";
            public const string UserId = "UserSignUpID";
            
        }

        public bool CreateHireConfigurationSetup(HireConfigurationSetup hireConfigurationSetupobj, string currentUserId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserSignUpID", hireConfigurationSetupobj.UserSignUpID);
                _oDatabaseHelper.AddParameter("@CompanyID", hireConfigurationSetupobj.CompanyID);
                _oDatabaseHelper.AddParameter("@UserSignUpCode", hireConfigurationSetupobj.UserSignUpCode);
                _oDatabaseHelper.AddParameter("@CreatedBy", currentUserId);
                _oDatabaseHelper.AddParameter("@CreatedOn", DateTime.UtcNow);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("usp_HireConfigurationSetupInsert", ref executionState);
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

        public HireConfigurationSetup NewUserConfigurationSetupSelect(string userId, string companyId)
        {
            try
            {
                var hireConfigurationSetupobj = new HireConfigurationSetup();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", companyId);
                _oDatabaseHelper.AddParameter("@UserID", userId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_NewUserConfigurationSetupSelect", ref executionState);

                while (rdr.Read())
                {

                    if (!rdr.IsDBNull(rdr.GetOrdinal(HireConfigurationSetupFields.CompanyId)))
                        hireConfigurationSetupobj.CompanyID = rdr.GetInt32(rdr.GetOrdinal(HireConfigurationSetupFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HireConfigurationSetupFields.UserSignUpId)))
                        hireConfigurationSetupobj.UserSignUpID = rdr.GetInt32(rdr.GetOrdinal(HireConfigurationSetupFields.UserSignUpId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(HireConfigurationSetupFields.UserSignUpCode)))
                        hireConfigurationSetupobj.UserSignUpCode = rdr.GetGuid(rdr.GetOrdinal(HireConfigurationSetupFields.UserSignUpCode)).ToString();
                    }
                rdr.Close();
                return hireConfigurationSetupobj;
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
        
        public bool UpdateHireStatusofEmployee(int userId, bool status)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", userId);
                _oDatabaseHelper.AddParameter("@Status", status);
                _oDatabaseHelper.ExecuteScalar("usp_UpdateHireStatusofEmployee", ref executionState);
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

        public List<HireStepMaster> SelectAllHireSteps()
        {
            try
            {
                List<HireStepMaster> hireStepMasterList = new List<HireStepMaster>();
                bool executionState = false;
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_HireStepMasterSelect", ref executionState);
                while (rdr.Read())
                {
                    HireStepMaster hireStepMasterObj = new HireStepMaster();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("StepId")))
                        hireStepMasterObj.StepId = rdr.GetInt32(rdr.GetOrdinal("StepId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("StepName")))
                        hireStepMasterObj.StepName = rdr.GetString(rdr.GetOrdinal("StepName"));
                    hireStepMasterList.Add(hireStepMasterObj);
                }
                _oDatabaseHelper.Dispose();
                return hireStepMasterList;
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
        public List<HireApprovalSetup> SelectAllHireStepsById(int userId)
        {
            try
            {
                List<HireApprovalSetup> hireApprovalSetupList = new List<HireApprovalSetup>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserId", userId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_HireApprovalSetupSelect", ref executionState);
                while (rdr.Read())
                {
                    HireApprovalSetup hireApprovalSetuphireStepMasterObj = new HireApprovalSetup();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("UserId")))
                        hireApprovalSetuphireStepMasterObj.UserId = rdr.GetInt32(rdr.GetOrdinal("UserId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("StepName")))
                        hireApprovalSetuphireStepMasterObj.StepName = rdr.GetString(rdr.GetOrdinal("StepName"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("StepId")))
                        hireApprovalSetuphireStepMasterObj.StepId = rdr.GetInt32(rdr.GetOrdinal("StepId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("IsActive")))
                        hireApprovalSetuphireStepMasterObj.IsActive = rdr.GetBoolean(rdr.GetOrdinal("IsActive"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("IsApproved")))
                        hireApprovalSetuphireStepMasterObj.IsApproved = rdr.GetBoolean(rdr.GetOrdinal("IsApproved"));
                    hireApprovalSetupList.Add(hireApprovalSetuphireStepMasterObj);
                }
                _oDatabaseHelper.Dispose();
                return hireApprovalSetupList;
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
        public bool UpdateStepSubmitStatus(int userId, int stepId, bool status)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", userId);
                _oDatabaseHelper.AddParameter("@StepId", stepId);
                _oDatabaseHelper.AddParameter("@Status", status);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_HireApprovalSetupIsSubmitUpdate", ref executionState);
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
