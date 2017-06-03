using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class TaxDetailRepository : ITaxDetailRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class CountryRegionFields
        {
            public const string CountryRegionId = "CountryRegionId";
            public const string CountryRegionCode = "CountryRegionCode";
            public const string CountryName = "Name";
        }
        public class StateProvinceFields
        {
            public const string StateProvinceId = "StateProvinceId";
            public const string CountryRegionCode = "CountryRegionCode";
            public const string StateProvinceCode = "StateProvinceCode";
            public const string StateProvinceName = "Name";
        }
        public class EmployeeTaxDetailFields
        {
            public const string UserId = "UserID";
            public const string CompanyId = "CompanyID";
            public const string EmployeeTaxDetailCode = "EmployeeTaxDetailCode";
            public const string FederalWithholdingStatus = "FederalWithholdingStatus";
            public const string FederalExemptions = "FederalExemptions";
            public const string FederalWithholdings = "FederalWithholdings";
            public const string FederalBlock = "FederalBlock";
            public const string FederalMedBlock = "FederalMedBlock";
            public const string StateTaxesLiveinCountryID = "StateTaxesLiveinCountryID";
            public const string StateTaxesLiveinStateID = "StateTaxesLiveinStateID";
            public const string StateTaxesWorkinCountryID = "StateTaxesWorkinCountryID";
            public const string StateTaxesWorkinStateID = "StateTaxesWorkinStateID";
            public const string StateTaxesWithholdingStatus = "StateTaxesWithholdingStatus";
            public const string StateTaxesExemptions = "StateTaxesExemptions";
            public const string StateTaxesAdditionalWithholding = "StateTaxesAdditionalWithholding";
            public const string StateTaxesTaxBlock = "StateTaxesTaxBlock";
            public const string StateTaxesSUISDIBlock = "StateTaxesSUISDIBlock";
            public const string StateTaxesSchoolDistrict = "StateTaxesSchoolDistrict";
            public const string StateTaxesSchoolBlock = "StateTaxesSchoolBlock";
            public const string LocalTaxesWithholdingStatus = "LocalTaxesWithholdingStatus";
            public const string LocalTaxesAllowancesorExemptions = "LocalTaxesAllowancesorExemptions";
            public const string LocalTaxesAdditionalWithholdingsAmount = "LocalTaxesAdditionalWithholdingsAmount";
            public const string LocalTaxesAdditionalWithholdingsPercentage = "LocalTaxesAdditionalWithholdingsPercentage";
            public const string IsLocalTaxExempted = "IsLocalTaxExempted";

        }
        public bool CreateEmployeeTaxDetails(EmployeeTaxDetail employeeTaxDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", employeeTaxDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeTaxDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@FederalWithholdingStatus", employeeTaxDetailobj.FederalWithholdingStatus);
                _oDatabaseHelper.AddParameter("@FederalExemptions", employeeTaxDetailobj.FederalExemptions);
                _oDatabaseHelper.AddParameter("@FederalWithholdings", employeeTaxDetailobj.FederalWithholdings);
                _oDatabaseHelper.AddParameter("@FederalBlock", employeeTaxDetailobj.FederalBlock);
                _oDatabaseHelper.AddParameter("@FederalMedBlock", employeeTaxDetailobj.FederalMedBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinCountryID", employeeTaxDetailobj.StateTaxesLiveinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinStateID", employeeTaxDetailobj.StateTaxesLiveinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinCountryID", employeeTaxDetailobj.StateTaxesWorkinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinStateID", employeeTaxDetailobj.StateTaxesWorkinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWithholdingStatus", employeeTaxDetailobj.StateTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@StateTaxesExemptions", employeeTaxDetailobj.StateTaxesExemptions);
                _oDatabaseHelper.AddParameter("@StateTaxesAdditionalWithholding", employeeTaxDetailobj.StateTaxesAdditionalWithholding);
                _oDatabaseHelper.AddParameter("@StateTaxesTaxBlock", employeeTaxDetailobj.StateTaxesTaxBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSUISDIBlock", employeeTaxDetailobj.StateTaxesSUISDIBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolDistrict", employeeTaxDetailobj.StateTaxesSchoolDistrict);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolBlock", employeeTaxDetailobj.StateTaxesSchoolBlock);
                _oDatabaseHelper.AddParameter("@LocalTaxesWithholdingStatus", employeeTaxDetailobj.LocalTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@LocalTaxesAllowancesorExemptions", employeeTaxDetailobj.LocalTaxesAllowancesorExemptions);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsAmount", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsAmount);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsPercentage", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsPercentage);
                _oDatabaseHelper.AddParameter("@IsLocalTaxExempted", employeeTaxDetailobj.IsLocalTaxExempted);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeTaxDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeTaxDetailobj.ModifiedBy);
               // _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeTaxDetailInsert", ref executionState);
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
        public bool DeleteEmployeeTaxDetails(EmployeeTaxDetail employeeTaxDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", employeeTaxDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeTaxDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@FederalWithholdingStatus", employeeTaxDetailobj.FederalWithholdings);
                _oDatabaseHelper.AddParameter("@FederalExemptions", employeeTaxDetailobj.FederalExemptions);
                _oDatabaseHelper.AddParameter("@FederalWithholdings", employeeTaxDetailobj.FederalWithholdings);
                _oDatabaseHelper.AddParameter("@FederalBlock", employeeTaxDetailobj.FederalBlock);
                _oDatabaseHelper.AddParameter("@FederalMedBlock", employeeTaxDetailobj.FederalMedBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinCountryID", employeeTaxDetailobj.StateTaxesLiveinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinStateID", employeeTaxDetailobj.StateTaxesLiveinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinCountryID", employeeTaxDetailobj.StateTaxesWorkinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinStateID", employeeTaxDetailobj.StateTaxesWorkinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWithholdingStatus", employeeTaxDetailobj.StateTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@StateTaxesExemptions", employeeTaxDetailobj.StateTaxesExemptions);
                _oDatabaseHelper.AddParameter("@StateTaxesAdditionalWithholding", employeeTaxDetailobj.StateTaxesAdditionalWithholding);
                _oDatabaseHelper.AddParameter("@StateTaxesTaxBlock", employeeTaxDetailobj.StateTaxesTaxBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSUISDIBlock", employeeTaxDetailobj.StateTaxesSUISDIBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolDistrict", employeeTaxDetailobj.StateTaxesSchoolDistrict);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolBlock", employeeTaxDetailobj.StateTaxesSchoolBlock);
                _oDatabaseHelper.AddParameter("@LocalTaxesWithholdingStatus", employeeTaxDetailobj.LocalTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@LocalTaxesAllowancesorExemtions", employeeTaxDetailobj.LocalTaxesAllowancesorExemptions);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsAmount", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsAmount);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsPercentage", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsPercentage);
                _oDatabaseHelper.AddParameter("@IsLocalTaxExempted", employeeTaxDetailobj.IsLocalTaxExempted);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeTaxDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeTaxDetailobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@CreatedOn", employeeTaxDetailobj.CreatedOn);
                _oDatabaseHelper.AddParameter("@ModifiedOn", employeeTaxDetailobj.ModifiedOn);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeTaxDetailDelete", ref executionState);
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
        public bool UpdateEmployeeTaxDetails(EmployeeTaxDetail employeeTaxDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserID", employeeTaxDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeeTaxDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@FederalWithholdingStatus", employeeTaxDetailobj.FederalWithholdingStatus);
                _oDatabaseHelper.AddParameter("@FederalExemptions", employeeTaxDetailobj.FederalExemptions);
                _oDatabaseHelper.AddParameter("@FederalWithholdings", employeeTaxDetailobj.FederalWithholdings);
                _oDatabaseHelper.AddParameter("@FederalBlock", employeeTaxDetailobj.FederalBlock);
                _oDatabaseHelper.AddParameter("@FederalMedBlock", employeeTaxDetailobj.FederalMedBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinCountryID", employeeTaxDetailobj.StateTaxesLiveinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesLiveinStateID", employeeTaxDetailobj.StateTaxesLiveinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinCountryID", employeeTaxDetailobj.StateTaxesWorkinCountry);
                _oDatabaseHelper.AddParameter("@StateTaxesWorkinStateID", employeeTaxDetailobj.StateTaxesWorkinState);
                _oDatabaseHelper.AddParameter("@StateTaxesWithholdingStatus", employeeTaxDetailobj.StateTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@StateTaxesExemptions", employeeTaxDetailobj.StateTaxesExemptions);
                _oDatabaseHelper.AddParameter("@StateTaxesAdditionalWithholding", employeeTaxDetailobj.StateTaxesAdditionalWithholding);
                _oDatabaseHelper.AddParameter("@StateTaxesTaxBlock", employeeTaxDetailobj.StateTaxesTaxBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSUISDIBlock", employeeTaxDetailobj.StateTaxesSUISDIBlock);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolDistrict", employeeTaxDetailobj.StateTaxesSchoolDistrict);
                _oDatabaseHelper.AddParameter("@StateTaxesSchoolBlock", employeeTaxDetailobj.StateTaxesSchoolBlock);
                _oDatabaseHelper.AddParameter("@LocalTaxesWithholdingStatus", employeeTaxDetailobj.LocalTaxesWithholdingStatus);
                _oDatabaseHelper.AddParameter("@LocalTaxesAllowancesorExemptions", employeeTaxDetailobj.LocalTaxesAllowancesorExemptions);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsAmount", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsAmount);
                _oDatabaseHelper.AddParameter("@LocalTaxesAdditionalWithholdingsPercentage", employeeTaxDetailobj.LocalTaxesAdditionalWithholdingsPercentage);
                _oDatabaseHelper.AddParameter("@IsLocalTaxExempted", employeeTaxDetailobj.IsLocalTaxExempted);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeeTaxDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeeTaxDetailobj.ModifiedBy);
               //_oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeTaxDetailUpdate", ref executionState);
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
        public EmployeeTaxDetail SelectEmployeeTaxDetails(int UserId, int CompanyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                EmployeeTaxDetail employeeTaxDetailObj = new EmployeeTaxDetail();
                _oDatabaseHelper.AddParameter("@UserID", UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);
                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeTaxDetailSelect", ref executionState);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.UserId)))
                        employeeTaxDetailObj.UserId = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.UserId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.CompanyId)))
                        employeeTaxDetailObj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.CompanyId));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.EmployeeTaxDetailCode)))
                        employeeTaxDetailObj.EmployeeTaxDetailCode = rdr.GetGuid(rdr.GetOrdinal(EmployeeTaxDetailFields.EmployeeTaxDetailCode)).ToString();
                   
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalWithholdingStatus)))
                        employeeTaxDetailObj.FederalWithholdingStatus = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalWithholdingStatus));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalExemptions)))
                        employeeTaxDetailObj.FederalExemptions = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalExemptions));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalWithholdings)))
                        employeeTaxDetailObj.FederalWithholdings = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalWithholdings));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalBlock)))
                        employeeTaxDetailObj.FederalBlock = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalBlock));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalMedBlock)))
                        employeeTaxDetailObj.FederalMedBlock = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.FederalMedBlock));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesLiveinCountryID)))
                        employeeTaxDetailObj.StateTaxesLiveinCountry = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesLiveinCountryID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesLiveinStateID)))
                        employeeTaxDetailObj.StateTaxesLiveinState = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesLiveinStateID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWorkinCountryID)))
                        employeeTaxDetailObj.StateTaxesWorkinCountry = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWorkinCountryID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWorkinStateID)))
                        employeeTaxDetailObj.StateTaxesWorkinState = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWorkinStateID));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWithholdingStatus)))
                        employeeTaxDetailObj.StateTaxesWithholdingStatus = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesWithholdingStatus));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesExemptions)))
                        employeeTaxDetailObj.StateTaxesExemptions = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesExemptions));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesAdditionalWithholding)))
                        employeeTaxDetailObj.StateTaxesAdditionalWithholding = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesAdditionalWithholding));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesTaxBlock)))
                        employeeTaxDetailObj.StateTaxesTaxBlock = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesTaxBlock));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSUISDIBlock)))
                        employeeTaxDetailObj.StateTaxesSUISDIBlock = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSUISDIBlock));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSchoolBlock)))
                        employeeTaxDetailObj.StateTaxesSchoolBlock = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSchoolBlock));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSchoolDistrict)))
                        employeeTaxDetailObj.StateTaxesSchoolDistrict = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.StateTaxesSchoolDistrict));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesWithholdingStatus)))
                        employeeTaxDetailObj.LocalTaxesWithholdingStatus = rdr.GetInt32(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesWithholdingStatus));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAllowancesorExemptions)))
                        employeeTaxDetailObj.LocalTaxesAllowancesorExemptions = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAllowancesorExemptions));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAdditionalWithholdingsAmount)))
                        employeeTaxDetailObj.LocalTaxesAdditionalWithholdingsAmount = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAdditionalWithholdingsAmount));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAdditionalWithholdingsPercentage)))
                        employeeTaxDetailObj.LocalTaxesAdditionalWithholdingsPercentage = rdr.GetString(rdr.GetOrdinal(EmployeeTaxDetailFields.LocalTaxesAdditionalWithholdingsPercentage));
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeeTaxDetailFields.IsLocalTaxExempted)))
                        employeeTaxDetailObj.IsLocalTaxExempted = rdr.GetBoolean(rdr.GetOrdinal(EmployeeTaxDetailFields.IsLocalTaxExempted));
                }
                rdr.Close();
                _oDatabaseHelper.Dispose();
                return employeeTaxDetailObj;
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
