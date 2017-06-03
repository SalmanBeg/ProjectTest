using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class UtilityRepository : IUtilityRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class CountryRegionFields
        {
            public const string CountryRegionId = "CountryRegionID";
            public const string CountryRegionCode = "CountryRegionCode";
            public const string CountryName = "Name";
        }
        public class StateProvinceFields
        {
            public const string StateProvinceId = "StateProvinceID";
            public const string CountryRegionCode = "CountryRegionCode";
            public const string StateProvinceCode = "StateProvinceCode";
            public const string StateProvinceName = "Name";
        }
        public class LookUpFields
        {
            public const string Id = "ID";
           public const string Name = "Name";
           public const string CompanyId = "CompanyID";
           public const string Description = "Description";
           public const string Status = "Status";
           public const string TableName = "TableName";
        }

        public List<CountryRegion> GetCountry()
        {

            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var lstcountryregion = new List<CountryRegion>();
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_CountryRegionSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var countryregionobj = new CountryRegion();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CountryRegionFields.CountryRegionId)))
                        countryregionobj.CountryRegionId = rdr.GetInt32(rdr.GetOrdinal(CountryRegionFields.CountryRegionId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CountryRegionFields.CountryRegionCode)))
                        countryregionobj.CountryRegionCode = rdr.GetString(rdr.GetOrdinal(CountryRegionFields.CountryRegionCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(CountryRegionFields.CountryName)))
                        countryregionobj.CountryName = rdr.GetString(rdr.GetOrdinal(CountryRegionFields.CountryName));
                    lstcountryregion.Add(countryregionobj);
                }
                rdr.Close();


                return lstcountryregion;
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

        public List<StateProvince> GetState()
        {
            return GetState(0);
        }

        public List<StateProvince> GetState(int countryRegionId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var lststateprovince = new List<StateProvince>();
                _oDatabaseHelper.AddParameter(CountryRegionFields.CountryRegionId, countryRegionId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_StateProvinceSelectAll", ref executionState);
                while (rdr.Read())
                {
                    var stateProvinceobj = new StateProvince();
                    if (!rdr.IsDBNull(rdr.GetOrdinal(StateProvinceFields.StateProvinceId)))
                        stateProvinceobj.StateProvinceId = rdr.GetInt32(rdr.GetOrdinal(StateProvinceFields.StateProvinceId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(StateProvinceFields.CountryRegionCode)))
                        stateProvinceobj.CountryRegionCode = rdr.GetString(rdr.GetOrdinal(StateProvinceFields.CountryRegionCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(StateProvinceFields.StateProvinceCode)))
                        stateProvinceobj.StateProvinceCode = rdr.GetString(rdr.GetOrdinal(StateProvinceFields.StateProvinceCode));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(StateProvinceFields.StateProvinceName)))
                        stateProvinceobj.StateName = rdr.GetString(rdr.GetOrdinal(StateProvinceFields.StateProvinceName));

                    lststateprovince.Add(stateProvinceobj);
                }
                rdr.Close();
                return lststateprovince;
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
        public List<LookUpDataEntity> GetLookUpData(int CompanyId)
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var lstlookup = new List<LookUpDataEntity>();
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_utilitytablesselect", ref executionState);
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
        public List<AlertSendType> GetAlertSendType()
        { 
                try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var alertSendTypeList = new List<AlertSendType>();
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_AlertSendTypeSelect", ref executionState);
                while (rdr.Read())
                {
                    var alertSendTypeObj = new AlertSendType();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("AlertSendTypeId")))
                        alertSendTypeObj.AlertSendTypeId = rdr.GetInt32(rdr.GetOrdinal("AlertSendTypeId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("AlertSendTypeName")))
                        alertSendTypeObj.AlertSendTypeName = rdr.GetString(rdr.GetOrdinal("AlertSendTypeName"));
                    alertSendTypeList.Add(alertSendTypeObj);
                }
                rdr.Close();
                return alertSendTypeList;
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
        public List<AlertSendCriteria> GetAlertSendCriteria() 
        {
            try
            {
                _oDatabaseHelper = new DatabaseHelper();
                bool executionState = false;
                var alertSendCriteriaList = new List<AlertSendCriteria>();
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("Utility.usp_AlertSendCriteriaSelect", ref executionState);
                while (rdr.Read())
                {
                    var alertSendCriteriaObj = new AlertSendCriteria();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("AlertSendCriteriaId")))
                        alertSendCriteriaObj.AlertSendCriteriaId = rdr.GetInt32(rdr.GetOrdinal("AlertSendCriteriaId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("AlertSendCriteriaName")))
                        alertSendCriteriaObj.AlertSendCriteriaName = rdr.GetString(rdr.GetOrdinal("AlertSendCriteriaName"));
                    alertSendCriteriaList.Add(alertSendCriteriaObj);
                }
                rdr.Close();
                return alertSendCriteriaList;
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
