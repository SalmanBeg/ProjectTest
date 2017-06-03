using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class ConsentFormRepository : IConsentFormRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class ConsentFormFields
        {
            public const string ConsentFormId = "ConsentFormId";
            public const string ConsentCode = "ConsentCode";
            public const string CompanyId = "CompanyId";
            public const string Title = "Title";
            public const string ConsentType = "ConsentType";
            public const string Description = "Description";
            public const string Active = "Active";
            public const string AttachmentFileId = "AttachmentFileId";
            public const string DisplayDocInConsent = "DisplayDocInConsent";
            public const string EnableUploadLink = "EnableUploadLink";
            public const string DocumentName = "DocumentName";
            public const string UploadedOn = "UploadedOn";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string OnBoardingId = "OnBoardingId";
            public const string OnBoardingCode = "OnBoardingCode";
            public const string OnBoardingName = "OnBoardingName";
        }

        public bool CreateOnBoarding(DataTable consentDocTable, OnBoarding onBoardingobj) 
        {
            bool executionState = false;
            _oDatabaseHelper = new DatabaseHelper();
            _oDatabaseHelper.AddParameter("@ust_ConsentdocId", consentDocTable);
            _oDatabaseHelper.AddParameter("@OnBoardingName", onBoardingobj.OnBoardingName);
            _oDatabaseHelper.AddParameter("@CompanyId", onBoardingobj.CompanyId);
            _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            _oDatabaseHelper.ExecuteScalar("HumanResources.usp_OnBoardingInsert", ref executionState);
            _oDatabaseHelper.Dispose();
            return executionState;
        }

        public List<ConsentForm> SelectAllConsentFormByCompanyId(int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<ConsentForm> consentFormList = new List<ConsentForm>();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ConsentFormsSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var consentFormobj = new ConsentForm();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentFormId)))
                        consentFormobj.ConsentFormId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentFormId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentCode)))
                        consentFormobj.ConsentCode = rdr.GetGuid(rdr.GetOrdinal(ConsentFormFields.ConsentCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.CompanyId)))
                        consentFormobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentType)))
                        consentFormobj.ConsentType = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.Description)))
                        consentFormobj.Description = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.Active)))
                        consentFormobj.Active = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.Active));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId)))
                        consentFormobj.AttachmentFileId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DisplayDocInConsent)))
                        consentFormobj.DisplayDocInConsent = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.DisplayDocInConsent));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.EnableUploadLink)))
                        consentFormobj.EnableUploadLink = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.EnableUploadLink));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DocumentName)))
                        consentFormobj.DocumentName = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.DocumentName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.UploadedOn)))
                        consentFormobj.UploadedOn = rdr.GetDateTime(rdr.GetOrdinal(ConsentFormFields.UploadedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.CreatedBy)))
                        consentFormobj.CreatedBy = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.CreatedBy));
                    consentFormList.Add(consentFormobj);
                }
                rdr.Close();
                return consentFormList;
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

        public List<ConsentForm> SelectConsentFormById(int consentFormId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<ConsentForm> consentFormList = new List<ConsentForm>();
                _oDatabaseHelper.AddParameter("@ConsentFormId", consentFormId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_ConsentFormsSelect", ref executionState);
                while (rdr.Read())
                {
                    var consentFormobj = new ConsentForm();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentFormId)))
                        consentFormobj.ConsentFormId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentFormId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentCode)))
                        consentFormobj.ConsentCode = rdr.GetGuid(rdr.GetOrdinal(ConsentFormFields.ConsentCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.CompanyId)))
                        consentFormobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentType)))
                        consentFormobj.ConsentType = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.Description)))
                        consentFormobj.Description = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.Active)))
                        consentFormobj.Active = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.Active));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId)))
                        consentFormobj.AttachmentFileId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DisplayDocInConsent)))
                        consentFormobj.DisplayDocInConsent = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.DisplayDocInConsent));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.EnableUploadLink)))
                        consentFormobj.EnableUploadLink = rdr.GetBoolean(rdr.GetOrdinal(ConsentFormFields.EnableUploadLink));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DocumentName)))
                        consentFormobj.DocumentName = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.DocumentName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.UploadedOn)))
                        consentFormobj.UploadedOn = rdr.GetDateTime(rdr.GetOrdinal(ConsentFormFields.UploadedOn));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.CreatedBy)))
                        consentFormobj.CreatedBy = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.CreatedBy));
                    consentFormList.Add(consentFormobj);
                }
                rdr.Close();
                return consentFormList;
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

        public bool UpdateConsentFormById(ConsentForm consentFormobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@ConsentFormId", consentFormobj.ConsentFormId);
                _oDatabaseHelper.AddParameter("@CompanyID", consentFormobj.CompanyId);
                _oDatabaseHelper.AddParameter("@Title", consentFormobj.Title);
                _oDatabaseHelper.AddParameter("@ConsentType", consentFormobj.ConsentType);
                _oDatabaseHelper.AddParameter("@Description", consentFormobj.Description);
                _oDatabaseHelper.AddParameter("@Active", consentFormobj.Active);
                _oDatabaseHelper.AddParameter("@DisplayDocInConsent", consentFormobj.DisplayDocInConsent);
                _oDatabaseHelper.AddParameter("@EnableUploadLink", consentFormobj.EnableUploadLink);
                _oDatabaseHelper.AddParameter("@ModifiedBy", consentFormobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_ConsentFormsUpdate", ref executionState);
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



        public List<ConsentForm> SelectConsentFormsByOnBoardingId(int onBoardingId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<ConsentForm> consentFormList = new List<ConsentForm>();
                _oDatabaseHelper.AddParameter("@OnBoardingId", onBoardingId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectConsentFormsByOnBoardingId", ref executionState);
                while (rdr.Read())
                {
                    var consentFormobj = new ConsentForm();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentFormId)))
                        consentFormobj.ConsentFormId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentFormId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DocumentName)))
                        consentFormobj.DocumentName = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.DocumentName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId)))
                        consentFormobj.AttachmentFileId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId));
                    consentFormList.Add(consentFormobj);
                }
                rdr.Close();
                return consentFormList;
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

        public List<ConsentForm> SelectConsentFormsByUserId(int userId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                List<ConsentForm> consentFormList = new List<ConsentForm>();
                _oDatabaseHelper.AddParameter("@UserId", userId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_SelectConsentFormsByUserId", ref executionState);
                while (rdr.Read())
                {
                    var consentFormobj = new ConsentForm();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.ConsentFormId)))
                        consentFormobj.ConsentFormId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.ConsentFormId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.DocumentName)))
                        consentFormobj.DocumentName = rdr.GetString(rdr.GetOrdinal(ConsentFormFields.DocumentName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId)))
                        consentFormobj.AttachmentFileId = rdr.GetInt32(rdr.GetOrdinal(ConsentFormFields.AttachmentFileId));
                    consentFormList.Add(consentFormobj);
                }
                rdr.Close();
                return consentFormList;
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
