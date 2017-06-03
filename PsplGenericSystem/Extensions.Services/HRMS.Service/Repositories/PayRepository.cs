using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Globalization;

namespace HRMS.Service.Repositories
{
    public class PayRepository : IPayRepository
    {
        public bool AddPay(EmployeePay employeePayobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeePayInsert(employeePayobj.UserId, employeePayobj.CompanyId, employeePayobj.Reason
                                  , employeePayobj.EffectiveDate, employeePayobj.PayType, employeePayobj.PayPeriodId, employeePayobj.AutoPay, employeePayobj.Compensation
                                  , employeePayobj.CompensationFrequency, employeePayobj.HourlyRate2, employeePayobj.HourlyRate3, employeePayobj.PayFrequency
                                  , employeePayobj.StandardHours, employeePayobj.PayPerCheck, employeePayobj.HourlyEquivalent, employeePayobj.Tipped
                                  , employeePayobj.PayStatus, employeePayobj.PayGrade, employeePayobj.PayCode, employeePayobj.PayPeriodStartDate
                                  , employeePayobj.PayPeriodEndDate, employeePayobj.PayrollEEId, employeePayobj.WeeklyAmount, employeePayobj.FirstPayDate
                                  , employeePayobj.ShiftType, employeePayobj.ShiftGroup, employeePayobj.Premium, employeePayobj.JobAssignment
                                  , employeePayobj.ContractStatus, employeePayobj.CreatedBy, employeePayobj.ModifiedBy).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdatePay(EmployeePay employeePayobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeePayUpdate(employeePayobj.UserId, employeePayobj.CompanyId, employeePayobj.EmployeePayId
                               , employeePayobj.Reason, employeePayobj.EffectiveDate, employeePayobj.PayType, employeePayobj.PayPeriodId, employeePayobj.AutoPay
                               , employeePayobj.Compensation, employeePayobj.CompensationFrequency, employeePayobj.HourlyRate2
                               , employeePayobj.HourlyRate3, employeePayobj.PayFrequency, employeePayobj.StandardHours, employeePayobj.PayPerCheck
                               , employeePayobj.HourlyEquivalent, employeePayobj.Tipped, employeePayobj.PayStatus, employeePayobj.PayGrade
                               , employeePayobj.PayCode, employeePayobj.PayPeriodStartDate, employeePayobj.PayPeriodEndDate, employeePayobj.PayrollEEId
                               , employeePayobj.WeeklyAmount, employeePayobj.FirstPayDate, employeePayobj.ShiftType, employeePayobj.ShiftGroup
                               , employeePayobj.Premium, employeePayobj.JobAssignment, employeePayobj.ContractStatus, employeePayobj.CreatedBy
                               , employeePayobj.ModifiedBy).ToList();

                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeletePay(EmployeePay employeePayobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeePayDelete(employeePayobj.UserId, employeePayobj.CompanyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public EmployeePay SelectPay(int companyId, int userId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeePayResult = hrmsEntity.usp_EmployeePaySelect(userId, companyId).ToList();
                    var employeepayList = lstEmployeePayResult.Select(employeepay => new EmployeePay
                    {
                        UserId = employeepay.UserId,
                        CompanyId = employeepay.CompanyId,
                        EmployeePayCode = employeepay.EmployeePayCode,
                        Reason = employeepay.Reason,
                        EffectiveDate = employeepay.EffectiveDate,
                        AutoPay = employeepay.AutoPay,
                        Compensation = employeepay.Compensation,
                        CompensationFrequency = employeepay.CompensationFrequency,
                        HourlyRate2 = employeepay.HourlyRate2,
                        HourlyRate3 = employeepay.HourlyRate3,
                        PayFrequency = employeepay.PayFrequency,
                        StandardHours = employeepay.StandardHours,
                        PayPerCheck = employeepay.PayPerCheck,
                        HourlyEquivalent = employeepay.HourlyEquivalent,
                        PayStatus = employeepay.PayStatus,
                        PayGrade = employeepay.PayGrade,
                        PayCode = employeepay.PayCode,
                        PayPeriodStartDate = employeepay.PayPeriodStartDate,
                        PayPeriodEndDate = employeepay.PayPeriodEndDate,
                        PayrollEEId = employeepay.PayrollEEId,
                        WeeklyAmount = employeepay.WeeklyAmount,
                        FirstPayDate = employeepay.FirstPayDate,
                        ShiftGroup = employeepay.ShiftGroup,
                        Premium = employeepay.Premium,
                        JobAssignment = employeepay.JobAssignment,
                        ContractStatus = employeepay.ContractStatus,
                        CreatedBy = employeepay.CreatedBy,
                        ModifiedBy = employeepay.ModifiedBy,
                        PayType = employeepay.PayType,
                        PayPeriodId = employeepay.PayPeriodId,
                        ShiftType = employeepay.ShiftType

                    }).ToList();
                    return employeepayList.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public PayPeriods GetEmployeePayPeriodDates(int companyId, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var objPayperiod = hrmsEntity.usp_GetEmployeePayPeriodDates(userId, companyId).ToList();
                    var employeepayList = objPayperiod.Select(employeepayperiod => new PayPeriods
                    {
                        StartDateTime = Convert.ToDateTime(employeepayperiod.StartDateTime.ToShortDateString()),
                        EndDateTime = Convert.ToDateTime(employeepayperiod.EndDateTime.ToShortDateString())

                    }).ToList();

                    return employeepayList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}