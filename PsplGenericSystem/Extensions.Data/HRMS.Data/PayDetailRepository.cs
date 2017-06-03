using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public class PayDetailRepository : IPayDetailRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class EmployeePayDetailFields
        {
            public const string UserId = "UserId";
            public const string CompanyId = "CompanyId";
            public const string EmployeePayDetailID = "EmployeePayDetailID";
            public const string EmployeePayDetailCode = "EmployeePayDetailCode";
            public const string Reason = "Reason";
            public const string EffectiveDate = "EffectiveDate";
            public const string PayType = "PayType";
            public const string AutoPay = "AutoPay";
            public const string Compensation = "Compensation";
            public const string CompensationFrequency = "CompensationFrequency";
            public const string HourlyRate2 = "HourlyRate2";
            public const string HourlyRate3 = "HourlyRate3";
            public const string PayFrequency = "PayFrequency";
            public const string StandardHours = "StandardHours";
            public const string HourlyEquivalent = "HourlyEquivalent";
            public const string Tipped = "Tipped";
            public const string PayStatus = "PayStatus";
            public const string PayGrade = "PayGrade";
            public const string PayCode = "PayCode";
            public const string PayPeriodStartDate = "PayPeriodStartDate";
            public const string PayPeriodEndDate = "PayPeriodEndDate";
            public const string PayrollEEID = "PayrollEEID";
            public const string PayPerCheck = "PayPerCheck";
            public const string WeeklyAmount = "WeeklyAmount";
            public const string FirstPayDate = "FirstPayDate";
            public const string ShiftType = "ShiftType";
            public const string ShiftGroup = "ShiftGroup";
            public const string Premium = "Premium";
            public const string JobAssignment = "JobAssignment";
            public const string ContractStatus = "ContractStatus";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";
        }
        public bool AddPayDetail(EmployeePayDetail employeePayDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();


                _oDatabaseHelper.AddParameter("@UserID", employeePayDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeePayDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@Reason", employeePayDetailobj.Reason);
                _oDatabaseHelper.AddParameter("@EffectiveDate", employeePayDetailobj.EffectiveDate);
                _oDatabaseHelper.AddParameter("@PayType", employeePayDetailobj.PayType);
                _oDatabaseHelper.AddParameter("@AutoPay", employeePayDetailobj.AutoPay);
                _oDatabaseHelper.AddParameter("@Compensation", employeePayDetailobj.Compensation);
                _oDatabaseHelper.AddParameter("@CompensationFrequency", employeePayDetailobj.CompensationFrequency);
                _oDatabaseHelper.AddParameter("@HourlyRate2", employeePayDetailobj.HourlyRate2);
                _oDatabaseHelper.AddParameter("@HourlyRate3", employeePayDetailobj.HourlyRate3);
                _oDatabaseHelper.AddParameter("@PayFrequency", employeePayDetailobj.PayFrequency);
                _oDatabaseHelper.AddParameter("@StandardHours", employeePayDetailobj.StandardHours);
                _oDatabaseHelper.AddParameter("@PayPerCheck", employeePayDetailobj.PayPerCheck);
                _oDatabaseHelper.AddParameter("@HourlyEquivalent", employeePayDetailobj.HourlyEquivalent);
                _oDatabaseHelper.AddParameter("@Tipped", employeePayDetailobj.Tipped);
                _oDatabaseHelper.AddParameter("@PayStatus", employeePayDetailobj.PayStatus);
                _oDatabaseHelper.AddParameter("@PayGrade", employeePayDetailobj.PayGrade);
                _oDatabaseHelper.AddParameter("@PayCode", employeePayDetailobj.PayCode);
                _oDatabaseHelper.AddParameter("@PayPeriodStartDate", employeePayDetailobj.PayPeriodStartDate);
                _oDatabaseHelper.AddParameter("@PayPeriodEndDate", employeePayDetailobj.PayPeriodEndDate);
                _oDatabaseHelper.AddParameter("@PayrollEEID", employeePayDetailobj.PayrollEEId);
                _oDatabaseHelper.AddParameter("@WeeklyAmount", employeePayDetailobj.WeeklyAmount);
                _oDatabaseHelper.AddParameter("@FirstPayDate", employeePayDetailobj.FirstPayDate);
                _oDatabaseHelper.AddParameter("@ShiftType", employeePayDetailobj.ShiftType);
                _oDatabaseHelper.AddParameter("@ShiftGroup", employeePayDetailobj.ShiftGroup);
                _oDatabaseHelper.AddParameter("@Premium", employeePayDetailobj.Premium);
                _oDatabaseHelper.AddParameter("@JobAssignment", employeePayDetailobj.JobAssignment);
                _oDatabaseHelper.AddParameter("@ContractStatus", employeePayDetailobj.ContractStatus);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeePayDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeePayDetailobj.ModifiedBy);

               // _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeePayDetailInsert", ref executionState);
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
        public bool UpdatePayDetail(EmployeePayDetail employeePayDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();


                _oDatabaseHelper.AddParameter("@UserID", employeePayDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeePayDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@EmployeePayDetailId", employeePayDetailobj.EmployeePayDetailId);
                _oDatabaseHelper.AddParameter("@Reason", employeePayDetailobj.Reason);
                _oDatabaseHelper.AddParameter("@EffectiveDate", employeePayDetailobj.EffectiveDate);
                _oDatabaseHelper.AddParameter("@PayType", employeePayDetailobj.PayType);
                _oDatabaseHelper.AddParameter("@AutoPay", employeePayDetailobj.AutoPay);
                _oDatabaseHelper.AddParameter("@Compensation", employeePayDetailobj.Compensation);
                _oDatabaseHelper.AddParameter("@CompensationFrequency", employeePayDetailobj.CompensationFrequency);
                _oDatabaseHelper.AddParameter("@HourlyRate2", employeePayDetailobj.HourlyRate2);
                _oDatabaseHelper.AddParameter("@HourlyRate3", employeePayDetailobj.HourlyRate3);
                _oDatabaseHelper.AddParameter("@PayFrequency", employeePayDetailobj.PayFrequency);
                _oDatabaseHelper.AddParameter("@StandardHours", employeePayDetailobj.StandardHours);
                _oDatabaseHelper.AddParameter("@PayPerCheck", employeePayDetailobj.PayPerCheck);
                _oDatabaseHelper.AddParameter("@HourlyEquivalent", employeePayDetailobj.HourlyEquivalent);
                _oDatabaseHelper.AddParameter("@Tipped", employeePayDetailobj.Tipped);
                _oDatabaseHelper.AddParameter("@PayStatus", employeePayDetailobj.PayStatus);
                _oDatabaseHelper.AddParameter("@PayGrade", employeePayDetailobj.PayGrade);
                _oDatabaseHelper.AddParameter("@PayCode", employeePayDetailobj.PayCode);
                _oDatabaseHelper.AddParameter("@PayPeriodStartDate", employeePayDetailobj.PayPeriodStartDate);
                _oDatabaseHelper.AddParameter("@PayPeriodEndDate", employeePayDetailobj.PayPeriodEndDate);
                _oDatabaseHelper.AddParameter("@PayrollEEID", employeePayDetailobj.PayrollEEId);
                _oDatabaseHelper.AddParameter("@WeeklyAmount", employeePayDetailobj.WeeklyAmount);
                _oDatabaseHelper.AddParameter("@FirstPayDate", employeePayDetailobj.FirstPayDate);
                _oDatabaseHelper.AddParameter("@ShiftType", employeePayDetailobj.ShiftType);
                _oDatabaseHelper.AddParameter("@ShiftGroup", employeePayDetailobj.ShiftGroup);
                _oDatabaseHelper.AddParameter("@Premium", employeePayDetailobj.Premium);
                _oDatabaseHelper.AddParameter("@JobAssignment", employeePayDetailobj.JobAssignment);
                _oDatabaseHelper.AddParameter("@ContractStatus", employeePayDetailobj.ContractStatus);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeePayDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeePayDetailobj.ModifiedBy);
               // _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeePayDetailUpdate", ref executionState);
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
        public bool DeletePayDetail(EmployeePayDetail employeePayDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();


                _oDatabaseHelper.AddParameter("@UserID", employeePayDetailobj.UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", employeePayDetailobj.CompanyId);

                _oDatabaseHelper.AddParameter("@Reason", employeePayDetailobj.Reason);
                _oDatabaseHelper.AddParameter("@EffectiveDate", employeePayDetailobj.EffectiveDate);
                _oDatabaseHelper.AddParameter("@PayType", employeePayDetailobj.PayType);
                _oDatabaseHelper.AddParameter("@AutoPay", employeePayDetailobj.AutoPay);
                _oDatabaseHelper.AddParameter("@Compensation", employeePayDetailobj.Compensation);
                _oDatabaseHelper.AddParameter("@CompensationFrequency", employeePayDetailobj.CompensationFrequency);
                _oDatabaseHelper.AddParameter("@HourlyRate2", employeePayDetailobj.HourlyRate2);
                _oDatabaseHelper.AddParameter("@HourlyRate3", employeePayDetailobj.HourlyRate3);
                _oDatabaseHelper.AddParameter("@PayFrequency", employeePayDetailobj.PayFrequency);
                _oDatabaseHelper.AddParameter("@StandardHours", employeePayDetailobj.StandardHours);
                _oDatabaseHelper.AddParameter("@PayPerCheck", employeePayDetailobj.PayPerCheck);
                _oDatabaseHelper.AddParameter("@HourlyEquivalent", employeePayDetailobj.HourlyEquivalent);
                _oDatabaseHelper.AddParameter("@Tipped", employeePayDetailobj.Tipped);
                _oDatabaseHelper.AddParameter("@PayStatus", employeePayDetailobj.PayStatus);
                _oDatabaseHelper.AddParameter("@PayGrade", employeePayDetailobj.PayGrade);
                _oDatabaseHelper.AddParameter("@PayCode", employeePayDetailobj.PayCode);
                _oDatabaseHelper.AddParameter("@PayPeriodStartDate", employeePayDetailobj.PayPeriodStartDate);
                _oDatabaseHelper.AddParameter("@PayPeriodEndDate", employeePayDetailobj.PayPeriodEndDate);
                _oDatabaseHelper.AddParameter("@PayrollEEID", employeePayDetailobj.PayrollEEId);
                _oDatabaseHelper.AddParameter("@WeeklyAmount", employeePayDetailobj.WeeklyAmount);
                _oDatabaseHelper.AddParameter("@FirstPayDate", employeePayDetailobj.FirstPayDate);
                _oDatabaseHelper.AddParameter("@ShiftType", employeePayDetailobj.ShiftType);
                _oDatabaseHelper.AddParameter("@ShiftGroup", employeePayDetailobj.ShiftGroup);
                _oDatabaseHelper.AddParameter("@Premium", employeePayDetailobj.Premium);
                _oDatabaseHelper.AddParameter("@JobAssignment", employeePayDetailobj.JobAssignment);
                _oDatabaseHelper.AddParameter("@ContractStatus", employeePayDetailobj.ContractStatus);
                _oDatabaseHelper.AddParameter("@CreatedBy", employeePayDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@ModifiedBy", employeePayDetailobj.ModifiedBy);

                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                _oDatabaseHelper.ExecuteScalar("usp_EmployeePayDetailDelete", ref executionState);
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
        public EmployeePayDetail SelectPayDetail(int CompanyId,int UserId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                EmployeePayDetail emppayobj = new EmployeePayDetail();

                _oDatabaseHelper.AddParameter("@UserID", UserId);
                _oDatabaseHelper.AddParameter("@CompanyID", CompanyId);

                IDataReader rdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeePayDetailSelect", ref executionState);
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.UserId)))
                        emppayobj.UserId = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.UserId));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.CompanyId)))
                        emppayobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.CompanyId));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.EmployeePayDetailCode)))
                        emppayobj.EmployeePayDetailCode = rdr.GetGuid(rdr.GetOrdinal(EmployeePayDetailFields.EmployeePayDetailCode)).ToString();

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.Reason)))
                        emppayobj.Reason = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.Reason));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.EffectiveDate)))
                        emppayobj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeePayDetailFields.EffectiveDate));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayType)))
                        emppayobj.PayType = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.PayType));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.AutoPay)))
                        emppayobj.AutoPay = rdr.GetBoolean(rdr.GetOrdinal(EmployeePayDetailFields.AutoPay));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.Compensation)))
                      emppayobj.Compensation = Convert.ToDouble( rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.Compensation)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.CompensationFrequency)))
                        emppayobj.CompensationFrequency = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.CompensationFrequency));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.HourlyRate2)))
                        emppayobj.HourlyRate2 = Convert.ToDouble( rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.HourlyRate2)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.HourlyRate3)))
                        emppayobj.HourlyRate3 = Convert.ToDouble(rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.HourlyRate3)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayFrequency)))
                        emppayobj.PayFrequency = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.PayFrequency));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.StandardHours)))
                        emppayobj.StandardHours =  rdr.GetDouble(rdr.GetOrdinal(EmployeePayDetailFields.StandardHours));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayPerCheck)))
                        emppayobj.PayPerCheck = Convert.ToDouble( rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.PayPerCheck)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.HourlyEquivalent)))
                        emppayobj.HourlyEquivalent = Convert.ToDouble(rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.HourlyEquivalent)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.Tipped)))
                        emppayobj.Tipped = rdr.GetBoolean(rdr.GetOrdinal(EmployeePayDetailFields.Tipped));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayStatus)))
                        emppayobj.PayStatus = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.PayStatus));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayGrade)))
                        emppayobj.PayGrade = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.PayGrade));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayCode)))
                        emppayobj.PayCode = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.PayCode));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayPeriodStartDate)))
                        emppayobj.PayPeriodStartDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeePayDetailFields.PayPeriodStartDate));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayPeriodEndDate)))
                        emppayobj.PayPeriodEndDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeePayDetailFields.PayPeriodEndDate));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.PayrollEEID)))
                        emppayobj.PayrollEEId = rdr.GetString(rdr.GetOrdinal(EmployeePayDetailFields.PayrollEEID));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.WeeklyAmount)))
                        emppayobj.WeeklyAmount = Convert.ToDouble( rdr.GetDecimal(rdr.GetOrdinal(EmployeePayDetailFields.WeeklyAmount)));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.FirstPayDate)))
                        emppayobj.FirstPayDate = rdr.GetDateTime(rdr.GetOrdinal(EmployeePayDetailFields.FirstPayDate));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.ShiftType)))
                        emppayobj.ShiftType = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.ShiftType));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.ShiftGroup)))
                        emppayobj.ShiftGroup = rdr.GetString(rdr.GetOrdinal(EmployeePayDetailFields.ShiftGroup));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.Premium)))
                        emppayobj.Premium = rdr.GetString(rdr.GetOrdinal(EmployeePayDetailFields.Premium));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.JobAssignment)))
                        emppayobj.JobAssignment = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.JobAssignment));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.ContractStatus)))
                        emppayobj.ContractStatus = rdr.GetInt32(rdr.GetOrdinal(EmployeePayDetailFields.ContractStatus));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.CreatedBy)))
                        emppayobj.CreatedBy = rdr.GetString(rdr.GetOrdinal(EmployeePayDetailFields.CreatedBy));

                    if (!rdr.IsDBNull(rdr.GetOrdinal(EmployeePayDetailFields.ModifiedBy)))
                        emppayobj.ModifiedBy = rdr.GetString(rdr.GetOrdinal(EmployeePayDetailFields.ModifiedBy));
                }
                rdr.Close();
                _oDatabaseHelper.Dispose();
                return emppayobj;
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
