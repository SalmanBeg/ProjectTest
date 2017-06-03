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
    public class I9FormRepository:II9FormRepository
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

        public class I9FormFields
        {
            public const string I9FormId="I9FormId";
            public const string I9FormCode = "I9FormCode";
            public const string UserId = "UserId";
            public const string TransactionId = "TransactionId";
            public const string SignatureDate = "SignatureDate";
            public const string IPAddress = "IPAddress";
            public const string CitizenOfUS = "CitizenOfUS";
            public const string AlienNumber = "AlienNumber";
            public const string PermanetResidentExpire = "PermanetResidentExpire";
            public const string AlienAuthorisedDate = "AlienAuthorisedDate";
            public const string AlienAutharisedCitizenof = "AlienAutharisedCitizenof";
            public const string FederalLaw = "FederalLaw";
            public const string SSN = "SSN";
            public const string Sign = "Sign";
            public const string I9Status = "I9Status";
            public const string Alien = "Alien";
            public const string Expires = "Expires";
            public const string AlienCitizenof = "AlienCitizenof";
            public const string Confirmation = "Confirmation";
            public const string DocumentTitle = "DocumentTitle";
            public const string DocumentTitle1 = "DocumentTitle1";
            public const string DocumentTitle2 = "DocumentTitle2";
            public const string FileName = "FileName";
            public const string DocumentSize = "DocumentSize";
            public const string Content = "Content";
            public const string ContentType = "ContentType";
            public const string ExprirationDate = "ExprirationDate";
            public const string EmploymentOn = "EmploymentOn";
            public const string CompanyId = "CompanyId";
            public const string CreatedBy = "CreatedBy";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedBy = "ModifiedBy";
            public const string ModifiedOn = "ModifiedOn";
            public const string IsEmployerSign = "IsEmployerSign";
            public const string EmployerUserid = "EmployerUserid";
            public const string EmployerTransactionId = "EmployerTransactionId";
            public const string EmployerSignDate = "EmployerSignDate";
        }

        public I9Form GetI9FormInfo(int userId)
        {
            var i9FormObj = new I9Form();
            _oDatabaseHelper = new DatabaseHelper();
            bool executionState = false;
            _oDatabaseHelper.AddParameter("@UserID", userId);
            IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.I9FormSelect", ref executionState);

            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.I9FormId)))
                    i9FormObj.I9FormId = rdr.GetInt32(rdr.GetOrdinal(I9FormFields.I9FormId));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.I9FormCode)))
                    i9FormObj.I9FormCode = rdr.GetInt32(rdr.GetOrdinal(I9FormFields.I9FormCode));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.TransactionId)))
                    i9FormObj.TransactionId = rdr.GetString(rdr.GetOrdinal(I9FormFields.TransactionId));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.SignatureDate)))
                    i9FormObj.SignatureDate = rdr.GetDateTime(rdr.GetOrdinal(I9FormFields.SignatureDate));
                if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.IPAddress)))
                    i9FormObj.IPAddress = rdr.GetString(rdr.GetOrdinal(I9FormFields.IPAddress));
                //if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.CitizenOfUS)))
                //    i9FormObj.CitizenOfUS = rdr.GetInt32(rdr.GetOrdinal(I9FormFields.CitizenOfUS));
                //if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.AlienNumber)))
                //    i9FormObj.AlienNumber = rdr.GetString(rdr.GetOrdinal(I9FormFields.AlienNumber));
                //if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.I9Status)))
                //    i9FormObj.I9Status = rdr.GetString(rdr.GetOrdinal(I9FormFields.I9Status));
                //if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.Alien)))
                //    i9FormObj.Alien = rdr.GetString(rdr.GetOrdinal(I9FormFields.Alien));
                //if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.Confirmation)))
                //    i9FormObj.Confirmation = rdr.GetString(rdr.GetOrdinal(I9FormFields.Confirmation));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.DocumentTitle)))
                //     i9FormObj.DocumentTitle = rdr.GetString(rdr.GetOrdinal(I9FormFields.DocumentTitle));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.DocumentTitle1)))
                //     i9FormObj.DocumentTitle1 = rdr.GetString(rdr.GetOrdinal(I9FormFields.DocumentTitle1));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.DocumentTitle2)))
                //     i9FormObj.DocumentTitle2 = rdr.GetString(rdr.GetOrdinal(I9FormFields.DocumentTitle2));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.FileName)))
                //     i9FormObj.FileName = rdr.GetString(rdr.GetOrdinal(I9FormFields.FileName));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.DocumentSize)))
                //     i9FormObj.DocumentSize = rdr.GetString(rdr.GetOrdinal(I9FormFields.DocumentSize));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.ContentType)))
                //     i9FormObj.ContentType = rdr.GetString(rdr.GetOrdinal(I9FormFields.ContentType));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.CreatedBy)))
                //     i9FormObj.CreatedBy = rdr.GetInt32(rdr.GetOrdinal(I9FormFields.CreatedBy));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.ModifiedBy)))
                //      i9FormObj.ModifiedBy = rdr.GetInt32(rdr.GetOrdinal(I9FormFields.ModifiedBy));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.EmployerUserid)))
                //      i9FormObj.EmployerUserid = rdr.GetString(rdr.GetOrdinal(I9FormFields.EmployerUserid));
                // if (!rdr.IsDBNull(rdr.GetOrdinal(I9FormFields.EmployerTransactionId)))
                //      i9FormObj.EmployerTransactionId = rdr.GetString(rdr.GetOrdinal(I9FormFields.EmployerTransactionId));
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
    }
}
