using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class DirectDepositRepository:IDirectDepositRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class DirectDepositDetailFields
        {
            public const string CompanyId = "CompanyID";
            public const string UserId = "UserID";
            public const string EmployeeDirectDepositDetailID = "EmployeeDirectDepositDetailID";
            public const string EmployeeDirectDepositDetailCode = "EmployeeDirectDepositDetailCode";
            public const string AccountType = "AccountType";
            public const string AccountTypeName = "AccountTypeName";
            public const string TransitorABANumber = "TransitorABANumber";
            public const string AccountNumber = "AccountNumber";
            public const string Amount = "Amount";
    }

        public bool AddDirectDepositDetail(EmployeeDirectDepositDetail employeeDirectDepositDetailobj)
        {

            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyID", employeeDirectDepositDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", employeeDirectDepositDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@AccountType", employeeDirectDepositDetailobj.AccountType);
                _oDatabaseHelper.AddParameter("@TransitorABANumber", employeeDirectDepositDetailobj.TransitorABANumber);
                _oDatabaseHelper.AddParameter("@AccountNumber", employeeDirectDepositDetailobj.AccountNumber);
                _oDatabaseHelper.AddParameter("@Amount", employeeDirectDepositDetailobj.Amount);
                
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDirectDepositDetailInsert", ref executionState);
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
        public bool DeleteDirectDepositDetail(int employeeDirectDepositDetailId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeDirectDepositDetailID", employeeDirectDepositDetailId);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDirectDepositDetailDelete", ref executionState);
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
        public bool UpdateDirectDepositDetail(EmployeeDirectDepositDetail employeeDirectDepositDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeDirectDepositDetailID", employeeDirectDepositDetailobj.EmployeeDirectDepositDetailId);
                _oDatabaseHelper.AddParameter("@AccountType", employeeDirectDepositDetailobj.AccountType);
                _oDatabaseHelper.AddParameter("@TransitorABANumber", employeeDirectDepositDetailobj.TransitorABANumber);
                _oDatabaseHelper.AddParameter("@AccountNumber", employeeDirectDepositDetailobj.AccountNumber);
                _oDatabaseHelper.AddParameter("@Amount", employeeDirectDepositDetailobj.Amount);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeDirectDepositDetailUpdate", ref executionState);
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
        public List<EmployeeDirectDepositDetail> SelectDirectDepositDetail(int CompanyId,int UserId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
               
                List<EmployeeDirectDepositDetail> directDepositDetialList = new List<EmployeeDirectDepositDetail>();
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", UserId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeDirectDepositDetailSelect", ref executionState);
                while (rdr.Read())
                {
                    EmployeeDirectDepositDetail directDepositDetialObj = new EmployeeDirectDepositDetail();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.CompanyId)))
                        directDepositDetialObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.UserId)))
                        directDepositDetialObj.UserId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailID)))
                        directDepositDetialObj.EmployeeDirectDepositDetailId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailCode)))
                        directDepositDetialObj.EmployeeDirectDepositDetailCode = rdr.GetGuid(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountType)))
                        directDepositDetialObj.AccountType = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.AccountType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountTypeName)))
                        directDepositDetialObj.AccountTypeName = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.AccountTypeName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountNumber)))
                        directDepositDetialObj.AccountNumber = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.AccountNumber));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.Amount)))
                        directDepositDetialObj.Amount = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.Amount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.TransitorABANumber)))
                        directDepositDetialObj.TransitorABANumber = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.TransitorABANumber));
                    directDepositDetialList.Add(directDepositDetialObj);
                }
                _oDatabaseHelper.Dispose();

                return directDepositDetialList;
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
        public EmployeeDirectDepositDetail SelectDirectDepositDetailById(int CompanyId, int UserId,int DirectDepositDetailId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();

                EmployeeDirectDepositDetail directDepositDetialObj = new EmployeeDirectDepositDetail();
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                _oDatabaseHelper.AddParameter("@UserID", UserId);
                _oDatabaseHelper.AddParameter("@DirectDepositDetailId", DirectDepositDetailId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeDirectDepositDetailSelectById", ref executionState);
                while (rdr.Read())
                {
                    
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.CompanyId)))
                        directDepositDetialObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.UserId)))
                        directDepositDetialObj.UserId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailID)))
                        directDepositDetialObj.EmployeeDirectDepositDetailId = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailCode)))
                        directDepositDetialObj.EmployeeDirectDepositDetailCode = rdr.GetGuid(rdr.GetOrdinal(DirectDepositDetailFields.EmployeeDirectDepositDetailCode)).ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountType)))
                        directDepositDetialObj.AccountType = rdr.GetInt32(rdr.GetOrdinal(DirectDepositDetailFields.AccountType));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountTypeName)))
                        directDepositDetialObj.AccountTypeName = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.AccountTypeName));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.AccountNumber)))
                        directDepositDetialObj.AccountNumber = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.AccountNumber));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.Amount)))
                        directDepositDetialObj.Amount = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.Amount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(DirectDepositDetailFields.TransitorABANumber)))
                        directDepositDetialObj.TransitorABANumber = rdr.GetString(rdr.GetOrdinal(DirectDepositDetailFields.TransitorABANumber));
                     }
                _oDatabaseHelper.Dispose();

                return directDepositDetialObj;
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
