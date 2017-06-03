using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public class EmployeeW4FormRepository : IEmployeeW4FormRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class EmployeeW4FormFields
        {
            public const string Employeew4formId = "Employeew4formId";
            public const string CompanyId = "CompanyId";
            public const string UserId = "UserId";
            public const string PersonalAllowancesA = "PersonalAllowancesA";
            public const string PersonalAllowancesB = "PersonalAllowancesB";
            public const string PersonalAllowancesC = "PersonalAllowancesC";
            public const string PersonalAllowancesD = "PersonalAllowancesD";
            public const string PersonalAllowancesE = "PersonalAllowancesE";
            public const string PersonalAllowancesF = "PersonalAllowancesF";
            public const string PersonalAllowancesG = "PersonalAllowancesG";
            public const string PersonalAllowancesH = "PersonalAllowancesH";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string SSNNO = "SSNNO";
            public const string HomeAddress = "HomeAddress";
            public const string CityTownStateZip = "CityTownStateZip";
            public const string EmployeesWithHolding3 = "EmployeesWithHolding3";
            public const string EmployeesWithHolding4 = "EmployeesWithHolding4";
            public const string EmployeesWithHolding5 = "EmployeesWithHolding5";
            public const string EmployeesWithHolding6 = "EmployeesWithHolding6";
            public const string EmployeesWithHolding7 = "EmployeesWithHolding7";
            public const string EmployeeSignature = "EmployeeSignature";
            public const string SignDate = "SignDate";
            public const string EmployerAddress = "EmployerAddress";
            public const string EmployeeOfficeCode = "EmployeeOfficeCode";
            public const string IdentificationNo = "IdentificationNo";
            public const string Deductions1 = "Deductions1";
            public const string Deductions2 = "Deductions2";
            public const string Deductions3 = "Deductions3";
            public const string Deductions4 = "Deductions4";
            public const string Deductions5 = "Deductions5";
            public const string Deductions6 = "Deductions6";
            public const string Deductions7 = "Deductions7";
            public const string Deductions8 = "Deductions8";
            public const string Deductions9 = "Deductions9";
            public const string Deductions10 = "Deductions10";
            public const string Earnings1 = "Earnings1";
            public const string Earnings2 = "Earnings2";
            public const string Earnings3 = "Earnings3";
            public const string Earnings4 = "Earnings4";
            public const string Earnings5 = "Earnings5";
            public const string Earnings6 = "Earnings6";
            public const string Earnings7 = "Earnings7";
            public const string Earnings8 = "Earnings8";
            public const string Earnings9 = "Earnings9";
        }
        public bool AddEmployeeW4Form(EmployeeW4Form employeeW4formobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserId", employeeW4formobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyId", employeeW4formobj.CompanyId);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesA", employeeW4formobj.PersonalAllowancesA);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesB", employeeW4formobj.PersonalAllowancesB);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesC", employeeW4formobj.PersonalAllowancesC);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesD", employeeW4formobj.PersonalAllowancesD);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesE", employeeW4formobj.PersonalAllowancesE);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesF", employeeW4formobj.PersonalAllowancesF);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesG", employeeW4formobj.PersonalAllowancesG);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesH", employeeW4formobj.PersonalAllowancesH);
                _oDatabaseHelper.AddParameter("@FirstName", employeeW4formobj.FirstName);
                _oDatabaseHelper.AddParameter("@LastName", employeeW4formobj.LastName);
                _oDatabaseHelper.AddParameter("@SSNNO", employeeW4formobj.SSNNO);
                _oDatabaseHelper.AddParameter("@HomeAddress", employeeW4formobj.HomeAddress);
                _oDatabaseHelper.AddParameter("@CityTownStateZip", employeeW4formobj.CityTownStateZip);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding3", employeeW4formobj.EmployeesWithHolding3);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding4", employeeW4formobj.EmployeesWithHolding4);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding5", employeeW4formobj.EmployeesWithHolding5);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding6", employeeW4formobj.EmployeesWithHolding6);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding7", employeeW4formobj.EmployeesWithHolding7);
                _oDatabaseHelper.AddParameter("@EmployeeSignature", employeeW4formobj.EmployeeSignature);
                _oDatabaseHelper.AddParameter("@SignDate", employeeW4formobj.SignDate);
                _oDatabaseHelper.AddParameter("@EmployerAddress", employeeW4formobj.EmployerAddress);
                _oDatabaseHelper.AddParameter("@EmployeeOfficeCode", employeeW4formobj.EmployeeOfficeCode);
                _oDatabaseHelper.AddParameter("@IdentificationNo", employeeW4formobj.IdentificationNo);
                _oDatabaseHelper.AddParameter("@Deductions1", employeeW4formobj.Deductions1);
                _oDatabaseHelper.AddParameter("@Deductions2", employeeW4formobj.Deductions2);
                _oDatabaseHelper.AddParameter("@Deductions3", employeeW4formobj.Deductions3);
                _oDatabaseHelper.AddParameter("@Deductions4", employeeW4formobj.Deductions4);
                _oDatabaseHelper.AddParameter("@Deductions5", employeeW4formobj.Deductions5);
                _oDatabaseHelper.AddParameter("@Deductions6", employeeW4formobj.Deductions6);
                _oDatabaseHelper.AddParameter("@Deductions7", employeeW4formobj.Deductions7);
                _oDatabaseHelper.AddParameter("@Deductions8", employeeW4formobj.Deductions8);
                _oDatabaseHelper.AddParameter("@Deductions9", employeeW4formobj.Deductions9);
                _oDatabaseHelper.AddParameter("@Deductions10", employeeW4formobj.Deductions10);
                _oDatabaseHelper.AddParameter("@Earnings1", employeeW4formobj.Earnings1);
                _oDatabaseHelper.AddParameter("@Earnings2", employeeW4formobj.Earnings2);
                _oDatabaseHelper.AddParameter("@Earnings3", employeeW4formobj.Earnings3);
                _oDatabaseHelper.AddParameter("@Earnings4", employeeW4formobj.Earnings4);
                _oDatabaseHelper.AddParameter("@Earnings5", employeeW4formobj.Earnings5);
                _oDatabaseHelper.AddParameter("@Earnings6", employeeW4formobj.Earnings6);
                _oDatabaseHelper.AddParameter("@Earnings7", employeeW4formobj.Earnings7);
                _oDatabaseHelper.AddParameter("@Earnings8", employeeW4formobj.Earnings8);
                _oDatabaseHelper.AddParameter("@Earnings9", employeeW4formobj.Earnings9);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_Employeew4FormsInsert", ref executionState);
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public EmployeeW4Form SelectEmployeeW4FormDetailByUserId(int userId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                _oDatabaseHelper.AddParameter("@UserId", userId);
                IDataReader emergencyContactredr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_Employeew4FormsSelect", ref executionState);

                var employeew4formdetobj = new EmployeeW4Form();
                while (emergencyContactredr.Read())
                {
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Employeew4formId)))
                        employeew4formdetobj.Employeew4formId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Employeew4formId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.CompanyId)))
                        employeew4formdetobj.CompanyId = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.CompanyId));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesA)))
                        employeew4formdetobj.PersonalAllowancesA = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesA));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesB)))
                        employeew4formdetobj.PersonalAllowancesB = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesB));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesC)))
                        employeew4formdetobj.PersonalAllowancesC = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesC));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesD)))
                        employeew4formdetobj.PersonalAllowancesD = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesD));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesE)))
                        employeew4formdetobj.PersonalAllowancesE = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesE));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesF)))
                        employeew4formdetobj.PersonalAllowancesF = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesF));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesG)))
                        employeew4formdetobj.PersonalAllowancesG = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesG));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesH)))
                        employeew4formdetobj.PersonalAllowancesH = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.PersonalAllowancesH));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.LastName)))
                        employeew4formdetobj.LastName = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.LastName));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.FirstName)))
                        employeew4formdetobj.FirstName = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.FirstName));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.SSNNO)))
                        employeew4formdetobj.SSNNO = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.SSNNO));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.HomeAddress)))
                        employeew4formdetobj.HomeAddress = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.HomeAddress));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.CityTownStateZip)))
                        employeew4formdetobj.CityTownStateZip = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.CityTownStateZip));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding3)))
                        employeew4formdetobj.EmployeesWithHolding3 = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding3));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding4)))
                        employeew4formdetobj.EmployeesWithHolding4 = emergencyContactredr.GetBoolean(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding4));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding5)))
                        employeew4formdetobj.EmployeesWithHolding5 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding5));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding6)))
                        employeew4formdetobj.EmployeesWithHolding6 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding6));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding7)))
                        employeew4formdetobj.EmployeesWithHolding7 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeesWithHolding7));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeeSignature)))
                        employeew4formdetobj.EmployeeSignature = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeeSignature));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.SignDate)))
                        employeew4formdetobj.SignDate = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.SignDate));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployerAddress)))
                        employeew4formdetobj.EmployerAddress = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployerAddress));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeeOfficeCode)))
                        employeew4formdetobj.EmployeeOfficeCode = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.EmployeeOfficeCode));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.IdentificationNo)))
                        employeew4formdetobj.IdentificationNo = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.IdentificationNo));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions1)))
                        employeew4formdetobj.Deductions1 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions1));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions2)))
                        employeew4formdetobj.Deductions2 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions2));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions3)))
                        employeew4formdetobj.Deductions3 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions3));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions4)))
                        employeew4formdetobj.Deductions4 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions4));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions5)))
                        employeew4formdetobj.Deductions5 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions5));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions6)))
                        employeew4formdetobj.Deductions6 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions6));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions7)))
                        employeew4formdetobj.Deductions7 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions7));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions8)))
                        employeew4formdetobj.Deductions8 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions8));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions9)))
                        employeew4formdetobj.Deductions9 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions9));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions10)))
                        employeew4formdetobj.Deductions10 = emergencyContactredr.GetDouble(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Deductions10));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings1)))
                        employeew4formdetobj.Earnings1 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings1));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings2)))
                        employeew4formdetobj.Earnings2 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings2));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings3)))
                        employeew4formdetobj.Earnings3 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings3));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings4)))
                        employeew4formdetobj.Earnings4 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings4));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings5)))
                        employeew4formdetobj.Earnings5 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings5));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings6)))
                        employeew4formdetobj.Earnings6 = emergencyContactredr.GetString(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings6));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings7)))
                        employeew4formdetobj.Earnings7 = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings7));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings8)))
                        employeew4formdetobj.Earnings8 = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings8));
                    if (!emergencyContactredr.IsDBNull(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings9)))
                        employeew4formdetobj.Earnings9 = emergencyContactredr.GetInt32(emergencyContactredr.GetOrdinal(EmployeeW4FormFields.Earnings9));
                }

                emergencyContactredr.Close();
                return employeew4formdetobj;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }

        public bool UpdateEmployeeW4FormDetail(EmployeeW4Form employeeW4formobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@UserId", employeeW4formobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyId", employeeW4formobj.CompanyId);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesA", employeeW4formobj.PersonalAllowancesA);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesB", employeeW4formobj.PersonalAllowancesB);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesC", employeeW4formobj.PersonalAllowancesC);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesD", employeeW4formobj.PersonalAllowancesD);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesE", employeeW4formobj.PersonalAllowancesE);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesF", employeeW4formobj.PersonalAllowancesF);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesG", employeeW4formobj.PersonalAllowancesG);
                _oDatabaseHelper.AddParameter("@PersonalAllowancesH", employeeW4formobj.PersonalAllowancesH);
                _oDatabaseHelper.AddParameter("@FirstName", employeeW4formobj.FirstName);
                _oDatabaseHelper.AddParameter("@LastName", employeeW4formobj.LastName);
                _oDatabaseHelper.AddParameter("@SSNNO", employeeW4formobj.SSNNO);
                _oDatabaseHelper.AddParameter("@HomeAddress", employeeW4formobj.HomeAddress);
                _oDatabaseHelper.AddParameter("@CityTownStateZip", employeeW4formobj.CityTownStateZip);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding3", employeeW4formobj.EmployeesWithHolding3);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding4", employeeW4formobj.EmployeesWithHolding4);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding5", employeeW4formobj.EmployeesWithHolding5);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding6", employeeW4formobj.EmployeesWithHolding6);
                _oDatabaseHelper.AddParameter("@EmployeesWithHolding7", employeeW4formobj.EmployeesWithHolding7);
                _oDatabaseHelper.AddParameter("@EmployeeSignature", employeeW4formobj.EmployeeSignature);
                _oDatabaseHelper.AddParameter("@SignDate", employeeW4formobj.SignDate);
                _oDatabaseHelper.AddParameter("@EmployerAddress", employeeW4formobj.EmployerAddress);
                _oDatabaseHelper.AddParameter("@EmployeeOfficeCode", employeeW4formobj.EmployeeOfficeCode);
                _oDatabaseHelper.AddParameter("@IdentificationNo", employeeW4formobj.IdentificationNo);
                _oDatabaseHelper.AddParameter("@Deductions1", employeeW4formobj.Deductions1);
                _oDatabaseHelper.AddParameter("@Deductions2", employeeW4formobj.Deductions2);
                _oDatabaseHelper.AddParameter("@Deductions3", employeeW4formobj.Deductions3);
                _oDatabaseHelper.AddParameter("@Deductions4", employeeW4formobj.Deductions4);
                _oDatabaseHelper.AddParameter("@Deductions5", employeeW4formobj.Deductions5);
                _oDatabaseHelper.AddParameter("@Deductions6", employeeW4formobj.Deductions6);
                _oDatabaseHelper.AddParameter("@Deductions7", employeeW4formobj.Deductions7);
                _oDatabaseHelper.AddParameter("@Deductions8", employeeW4formobj.Deductions8);
                _oDatabaseHelper.AddParameter("@Deductions9", employeeW4formobj.Deductions9);
                _oDatabaseHelper.AddParameter("@Deductions10", employeeW4formobj.Deductions10);
                _oDatabaseHelper.AddParameter("@Earnings1", employeeW4formobj.Earnings1);
                _oDatabaseHelper.AddParameter("@Earnings2", employeeW4formobj.Earnings2);
                _oDatabaseHelper.AddParameter("@Earnings3", employeeW4formobj.Earnings3);
                _oDatabaseHelper.AddParameter("@Earnings4", employeeW4formobj.Earnings4);
                _oDatabaseHelper.AddParameter("@Earnings5", employeeW4formobj.Earnings5);
                _oDatabaseHelper.AddParameter("@Earnings6", employeeW4formobj.Earnings6);
                _oDatabaseHelper.AddParameter("@Earnings7", employeeW4formobj.Earnings7);
                _oDatabaseHelper.AddParameter("@Earnings8", employeeW4formobj.Earnings8);
                _oDatabaseHelper.AddParameter("@Earnings9", employeeW4formobj.Earnings9);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_Employeew4FormsUpdate", ref executionState);
                return executionState;

            }
            catch (Exception ex)
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
