using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class ScreenVerbiageRepository : IScreenVerbiageRepository
    {

        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class ScreenVerbiageFields
        {
            public const string CompanyId = "CompanyId";
            public const string HireWizardWelcomeText = "HireWizardWelcomeText";
            public const string HireWizardSubmitText = "HireWizardSubmitText";
            public const string HireWizardApprovalText = "HireWizardApprovalText";

        }
        public ScreenVerbiage SelectScreenVerbiage(int CompanyId)
        {
            try
            {
                ScreenVerbiage screenVerbiageObj = new ScreenVerbiage();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ScreenVerbiageSelect", ref executionState);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScreenVerbiageFields.CompanyId)))
                        screenVerbiageObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(ScreenVerbiageFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardWelcomeText)))
                        screenVerbiageObj.HireWizardWelcomeText = rdr.GetString(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardWelcomeText));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardSubmitText)))
                        screenVerbiageObj.HireWizardSubmitText = rdr.GetString(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardSubmitText));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardApprovalText)))
                        screenVerbiageObj.HireWizardApprovalText = rdr.GetString(rdr.GetOrdinal(ScreenVerbiageFields.HireWizardApprovalText));
                }
                _oDatabaseHelper.Dispose();
                return screenVerbiageObj;
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

        public bool InsertScreenVerbiage(ScreenVerbiage ScreenVerbiageObj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@companyId", ScreenVerbiageObj.CompanyId);
                _oDatabaseHelper.AddParameter("@hireWizardWelcome", ScreenVerbiageObj.HireWizardWelcomeText);
                _oDatabaseHelper.AddParameter("@hireWizardSubmit", ScreenVerbiageObj.HireWizardSubmitText);
                _oDatabaseHelper.AddParameter("@hireWizardApproval", ScreenVerbiageObj.HireWizardApprovalText);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ScreenVerbiageInsert", ref executionState);
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

        public bool UpdateScreenVerbiage(ScreenVerbiage ScreenVerbiageObj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@companyId", ScreenVerbiageObj.CompanyId);
                _oDatabaseHelper.AddParameter("@hireWizardWelcome", ScreenVerbiageObj.HireWizardWelcomeText);
                _oDatabaseHelper.AddParameter("@hireWizardSubmit", ScreenVerbiageObj.HireWizardSubmitText);
                _oDatabaseHelper.AddParameter("@hireWizardApproval", ScreenVerbiageObj.HireWizardApprovalText);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ScreenVerbiageUpdate", ref executionState);
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
