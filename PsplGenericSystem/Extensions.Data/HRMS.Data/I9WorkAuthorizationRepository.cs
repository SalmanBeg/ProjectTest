using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;
using System.Globalization;


namespace HRMS.Data
{
    public class I9WorkAuthorizationRepository : II9WorkAuthorizationRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class LookUpFields
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string CompanyId = "CompanyID";
            public const string Description = "Description";
            public const string Status = "Status";
            public const string TableName = "TableName";
        }
        public class I9WorkAuthorizationFields
        {         
            public const string WorkAuthorizationID = "WorkAuthorizationID";
            public const string WorkAuthorizationCode = "WorkAuthorizationCode";
            public const string CompanyID = "CompanyID";
            public const string UserID = "UserID";
            public const string TransactionID = "TransactionID";
            public const string SignatureDate = "SignatureDate";
            public const string IPAddress = "IPAddress";
            public const string CitizenOfUS = "CitizenOfUS";
            public const string AlienNumber = "AlienNumber";
            public const string PermanentResidentExpire = "PermanentResidentExpire";
            public const string AlienCitizenof = "AlienCitizenof";
            public const string AlienAuthorisedDate = "AlienAuthorisedDate";
            public const string AlienAuthorisedCitizenof = "AlienAuthorisedCitizenof";
            public const string FederalLaw = "FederalLaw";
            public const string IsSSN = "IsSSN";
            public const string IsEmployeeSign = "IsEmployeeSign";
            public const string Confirmation = "Confirmation";
            public const string EmploymentOn = "EmploymentOn";
            public const string IsEmployerSign = "IsEmployerSign";
            public const string EmployerUserID = "EmployerUserID";
            public const string EmployerTransactionID = "EmployerTransactionID";
            public const string EmployerSignDate = "EmployerSignDate";
            public const string CertificationDate = "CertificationDate";
            public const string Attachment = "Attachment";
            public const string AttachmentType = "AttachmentType";
            public const string AttachmentName = "AttachmentName";
            public const string AlienRegistrationNumber = "AlienRegistrationNumber";
            public const string AdmissionNumber = "AdmissionNumber";
            public const string PassportNumber = "PassportNumber";
            public const string Countryof = "Countryof";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";
        
        }

        public I9WorkAuthorization GetI9AuthorizationInfo(int userId)
        {
            var i9FormObj = new I9WorkAuthorization();
            _oDatabaseHelper = new DatabaseHelper();
            bool executionState = false;
            _oDatabaseHelper.AddParameter("@UserID", userId);
            IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.I9FormSelect", ref executionState);

            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9WorkAuthorizationFields.WorkAuthorizationID)))
                    i9FormObj.WorkAuthorizationID = rdr.GetInt32(rdr.GetOrdinal(I9WorkAuthorizationFields.WorkAuthorizationID));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9WorkAuthorizationFields.WorkAuthorizationCode)))
                    i9FormObj.WorkAuthorizationCode = rdr.GetGuid(rdr.GetOrdinal(I9WorkAuthorizationFields.WorkAuthorizationCode));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9WorkAuthorizationFields.TransactionID)))
                    i9FormObj.TransactionID = rdr.GetInt32(rdr.GetOrdinal(I9WorkAuthorizationFields.TransactionID));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9WorkAuthorizationFields.SignatureDate)))
                    i9FormObj.SignatureDate = rdr.GetDateTime(rdr.GetOrdinal(I9WorkAuthorizationFields.SignatureDate));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9WorkAuthorizationFields.IPAddress)))
                    i9FormObj.IPAddress = rdr.GetString(rdr.GetOrdinal(I9WorkAuthorizationFields.IPAddress));
            }
            rdr.Close();
            return i9FormObj;
        }

        public List<LookUpDataEntity> GetI9AcceptableDocumentsInfo(int CompanyId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var lstlookup = new List<LookUpDataEntity>();
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_I9AcceptableDocuments1SelectByCompanyID", ref executionState);
                while (rdr.Read())
                {
                    var lookUpobj = new LookUpDataEntity();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.Id)))
                        lookUpobj.ID = rdr.GetInt32(rdr.GetOrdinal(LookUpFields.Id));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.Name)))
                        lookUpobj.Name = rdr.GetString(rdr.GetOrdinal(LookUpFields.Name));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.CompanyId)))
                        lookUpobj.CompanyID = rdr.GetInt32(rdr.GetOrdinal(LookUpFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.Description)))
                        lookUpobj.Description = rdr.GetString(rdr.GetOrdinal(LookUpFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.Status)))
                        lookUpobj.Status = rdr.GetBoolean(rdr.GetOrdinal(LookUpFields.Status));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpFields.TableName)))
                        lookUpobj.TableName = rdr.GetString(rdr.GetOrdinal(LookUpFields.TableName));
                    lstlookup.Add(lookUpobj);
                }
                rdr.Close();
                return lstlookup;
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
        // WorkAuthorizationDocobj, WorkAuthorizationctypeobj
        public bool AddI9WorkAuthorizationDetails(I9WorkAuthorization I9WorkAuthorizationobj, WorkAuthorizationDocumentation WorkAuthorizationDocobj, WorkAuthorizationDocumentationType WorkAuthorizationtypeobj, DataTable DocumentList, int optselect)
        {           
            try
            {                
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
               // _oDatabaseHelper.AddParameter("@WorkAuthorizationID", I9WorkAuthorizationobj.WorkAuthorizationID);              
                _oDatabaseHelper.AddParameter("@CompanyID", I9WorkAuthorizationobj.CompanyID);
                _oDatabaseHelper.AddParameter("@UserID", I9WorkAuthorizationobj.UserID);    
                if (optselect == 1)
                {
                    _oDatabaseHelper.AddParameter("@CitizenOfUS", I9WorkAuthorizationobj.CitizenOfUS);
                }
                else if (optselect == 2)
                {
                    _oDatabaseHelper.AddParameter("@AlienNumber", I9WorkAuthorizationobj.AlienNumber);
                    _oDatabaseHelper.AddParameter("@PermanentResidentExpire", I9WorkAuthorizationobj.PermanentResidentExpire);
                    _oDatabaseHelper.AddParameter("@AlienCitizenof", I9WorkAuthorizationobj.StateTaxesLiveinCountry);
                }
                else
                {
                    _oDatabaseHelper.AddParameter("@AlienAuthorisedDate", I9WorkAuthorizationobj.AlienAuthorisedDate);
                    _oDatabaseHelper.AddParameter("@AlienAutharisedCitizenof", I9WorkAuthorizationobj.StateTaxesLiveinCountry);
                }             
                 _oDatabaseHelper.AddParameter("@CertificationDate", I9WorkAuthorizationobj.CertificationDateA);
                 _oDatabaseHelper.AddParameter("@Attachment", I9WorkAuthorizationobj.Attachment);
                 _oDatabaseHelper.AddParameter("@AttachmentType", I9WorkAuthorizationobj.AttachmentType);
                 _oDatabaseHelper.AddParameter("@AttachmentName", I9WorkAuthorizationobj.AttachmentName);
                 _oDatabaseHelper.AddParameter("@AlienRegistrationNumber", I9WorkAuthorizationobj.AlienRegistrationNumber);
                 _oDatabaseHelper.AddParameter("@AdmissionNumber", I9WorkAuthorizationobj.AdmissionNumber);
                 _oDatabaseHelper.AddParameter("@PassportNumber", I9WorkAuthorizationobj.PassportNumber);
                 _oDatabaseHelper.AddParameter("@Countryof", I9WorkAuthorizationobj.Countryof);        
                _oDatabaseHelper.AddParameter("@ModifiedBy", I9WorkAuthorizationobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@WorkAuthorizationDocumentation", DocumentList);           
                _oDatabaseHelper.ExecuteScalar("InsertUpdateFormI9DocumentationAddNewHireEmployee", ref executionState);
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


        // AddI9WorkAuthorizationPartialDetails
        public bool _AddI9WorkAuthorizationDetails(I9WorkAuthorization I9WorkAuthorizationobj, WorkAuthorizationDocumentation WorkAuthorizationDocobj, WorkAuthorizationDocumentationType WorkAuthorizationtypeobj, int optselect)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                // _oDatabaseHelper.AddParameter("@WorkAuthorizationID", I9WorkAuthorizationobj.WorkAuthorizationID);              
                _oDatabaseHelper.AddParameter("@arg_CompanyID", I9WorkAuthorizationobj.CompanyID);
                _oDatabaseHelper.AddParameter("@arg_UserID", I9WorkAuthorizationobj.UserID);
                _oDatabaseHelper.AddParameter("@arg_TransactionID", I9WorkAuthorizationobj.TransactionID);
                _oDatabaseHelper.AddParameter("@arg_SignatureDate", I9WorkAuthorizationobj.SignatureDate);
                _oDatabaseHelper.AddParameter("@arg_IPAddress", I9WorkAuthorizationobj.IPAddress);
                _oDatabaseHelper.AddParameter("@arg_EmploymentOn", I9WorkAuthorizationobj.EmploymentOn);  
                if (optselect == 1)
                {
                    _oDatabaseHelper.AddParameter("@arg_CitizenOfUS", I9WorkAuthorizationobj.CitizenOfUS);
                }
                else if (optselect == 2)
                {
                    _oDatabaseHelper.AddParameter("@arg_AlienNumber", I9WorkAuthorizationobj.AlienNumber);
                    _oDatabaseHelper.AddParameter("@arg_PermanetResidentExpire", I9WorkAuthorizationobj.PermanentResidentExpire);
                    _oDatabaseHelper.AddParameter("@arg_AlienCitizenof", I9WorkAuthorizationobj.AlienCitizenof);
                }
                else
                {
                    _oDatabaseHelper.AddParameter("@arg_AlienAuthorisedDate", I9WorkAuthorizationobj.AlienAuthorisedDate);
                    _oDatabaseHelper.AddParameter("@AlienAutharisedCitizenof", I9WorkAuthorizationobj.AlienAuthorisedCitizenof);
                }               
                _oDatabaseHelper.AddParameter("@arg_FederalLaw ", I9WorkAuthorizationobj.FederalLaw);
                _oDatabaseHelper.AddParameter("@arg_IsSSN", I9WorkAuthorizationobj.IsSSN);
                _oDatabaseHelper.AddParameter("@arg_IsEmployeeSign ", I9WorkAuthorizationobj.IsEmployerSign);             
                _oDatabaseHelper.AddParameter("@arg_AlienRegistrationNumber", I9WorkAuthorizationobj.AlienRegistrationNumber);
                _oDatabaseHelper.AddParameter("@arg_AdmissionNumber", I9WorkAuthorizationobj.AdmissionNumber);
                _oDatabaseHelper.AddParameter("@arg_PassportNumber", I9WorkAuthorizationobj.PassportNumber);
                _oDatabaseHelper.AddParameter("@arg_Countryof", I9WorkAuthorizationobj.Countryof);             
                _oDatabaseHelper.AddParameter("@arg_CreatedBy", I9WorkAuthorizationobj.CreatedBy);           
                _oDatabaseHelper.ExecuteScalar("[HumanResources].[InsertUpdateWorkAuthorizationFormI9Employee]", ref executionState);
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
