using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class LookUpDataRepository:ILookUpDataRepository
    {
        public class LookUpDataFields
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string CompanyId = "CompanyID";
            public const string Description = "Description";
            public const string Status = "Status";
            public const string TableName = "TableName";
        }
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public List<LookUpDataEntity> SelectLookUpData(string TableName, int CompanyId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                List<LookUpDataEntity> lookUpDataList = new List<LookUpDataEntity>();
                bool executionState = false;
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                _oDatabaseHelper.AddParameter("@TableName", TableName);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_LookUpDataSelect", ref executionState);
                while (rdr.Read())
                {
                    var lookUpObj = new LookUpDataEntity();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Id)))
                        lookUpObj.ID = rdr.GetInt32(rdr.GetOrdinal(LookUpDataFields.Id));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Name)))
                        lookUpObj.Name = rdr.GetString(rdr.GetOrdinal(LookUpDataFields.Name));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Description)))
                        lookUpObj.Description = rdr.GetString(rdr.GetOrdinal(LookUpDataFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Status)))
                        lookUpObj.Status = rdr.GetBoolean(rdr.GetOrdinal(LookUpDataFields.Status));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.CompanyId)))
                        lookUpObj.CompanyID = rdr.GetInt32(rdr.GetOrdinal(LookUpDataFields.CompanyId));
                    lookUpDataList.Add(lookUpObj);
                }
                rdr.Close();
                return lookUpDataList;
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
        public bool AddDepartment(LookUpDataEntity lookUpDataEntityObj, string TableName)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@Name", lookUpDataEntityObj.Name);
                _oDatabaseHelper.AddParameter("@Status", 1);
                _oDatabaseHelper.AddParameter("@Description", lookUpDataEntityObj.Description);
                _oDatabaseHelper.AddParameter("@CompanyID", lookUpDataEntityObj.CompanyID);
                _oDatabaseHelper.AddParameter("@TableName", TableName);
                _oDatabaseHelper.ExecuteScalar("Utility.usp_LookUpDataInsert", ref executionState);
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
        public LookUpDataEntity SelectLookUpDataById(string TableName, int CompanyId,int PrimaryId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                var lookUpObj = new LookUpDataEntity();
                bool executionState = false;
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                _oDatabaseHelper.AddParameter("@TableName", TableName);
                _oDatabaseHelper.AddParameter("@PrimaryID", PrimaryId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_LookUpDataSelectById", ref executionState);
                while (rdr.Read())
                {
                   
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Id)))
                        lookUpObj.ID = rdr.GetInt32(rdr.GetOrdinal(LookUpDataFields.Id));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Name)))
                        lookUpObj.Name = rdr.GetString(rdr.GetOrdinal(LookUpDataFields.Name));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Description)))
                        lookUpObj.Description = rdr.GetString(rdr.GetOrdinal(LookUpDataFields.Description));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.Status)))
                        lookUpObj.Status = rdr.GetBoolean(rdr.GetOrdinal(LookUpDataFields.Status));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(LookUpDataFields.CompanyId)))
                        lookUpObj.CompanyID = rdr.GetInt32(rdr.GetOrdinal(LookUpDataFields.CompanyId));
                    ;
                }
                rdr.Close();
                return lookUpObj;
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
        public bool UpdateLookUpData(LookUpDataEntity lookUpDataEntityObj,string TableName)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@Name", lookUpDataEntityObj.Name);
                _oDatabaseHelper.AddParameter("@Status", 1);
                _oDatabaseHelper.AddParameter("@Description", lookUpDataEntityObj.Description);
                _oDatabaseHelper.AddParameter("@CompanyID", lookUpDataEntityObj.CompanyID);
                _oDatabaseHelper.AddParameter("@TableName",TableName);
                _oDatabaseHelper.AddParameter("@PrimaryID", lookUpDataEntityObj.ID);
                _oDatabaseHelper.ExecuteScalar("Utility.usp_LookUpDataUpdate", ref executionState);
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

        public bool DeleteLookUpData(string TableName, int PrimaryId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@TableName", TableName);
                _oDatabaseHelper.AddParameter("@PrimaryID", PrimaryId);
                _oDatabaseHelper.ExecuteScalar("Utility.usp_LookUpDataDelete", ref executionState);
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
