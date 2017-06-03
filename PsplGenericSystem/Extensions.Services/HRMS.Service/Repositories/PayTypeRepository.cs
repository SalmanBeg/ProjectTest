using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class PayTypeRepository : IPayTypeRepository
    {
        public List<PayType> SelectAllPayTypeDetails(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstPayTypeInfoResult = hrmsEntity.usp_PayTypeSelectAll(companyId).ToList();

                    return lstPayTypeInfoResult.Select(PayTypeinfo => new PayType
                    {
                        PayTypeId = PayTypeinfo.PayTypeId,
                        PayCode = PayTypeinfo.PayCode,
                        PayTypeCode = PayTypeinfo.PayTypeCode,
                        Description = PayTypeinfo.Description,
                        PunchType = PayTypeinfo.PunchType,
                        TimeTypeId = PayTypeinfo.TimeTypeId,
                        AccrueToOT = PayTypeinfo.AccrueToOT,
                        MapToHR = PayTypeinfo.MapToHR,
                        MapToPayroll = PayTypeinfo.MapToPayroll,
                        Display = PayTypeinfo.Display,
                        RateFactor = PayTypeinfo.RateFactor.GetValueOrDefault(),
                        GLCode = PayTypeinfo.GLCode,
                        IsDefault = (bool)PayTypeinfo.IsDefault.GetValueOrDefault(),
                        PayrollCode = PayTypeinfo.PayrollCode,
                        //BypassBRM = PayTypeinfo.BypassBRM,
                        CompanyId = PayTypeinfo.CompanyId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PayType> SelectPayTypeDetailsByPayTypeId(int payTypeId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstPayTypeInfoResult = hrmsEntity.usp_PayTypeSelect(payTypeId, companyId).ToList();

                    return lstPayTypeInfoResult.Select(payTypeinfo => new PayType
                    {
                        PayTypeId = payTypeinfo.PayTypeId,
                        PayCode = payTypeinfo.PayCode,
                        PayTypeCode = payTypeinfo.PayTypeCode,
                        Description = payTypeinfo.Description,
                        PunchType = payTypeinfo.PunchType,
                        TimeTypeId = payTypeinfo.TimeTypeId,
                        AccrueToOT = payTypeinfo.AccrueToOT,
                        MapToHR = payTypeinfo.MapToHR,
                        MapToPayroll = payTypeinfo.MapToPayroll,
                        Display = payTypeinfo.Display,
                        RateFactor = payTypeinfo.RateFactor,
                        GLCode = payTypeinfo.GLCode,
                        //IsDefault = (bool)PayTypeinfo.IsDefault,
                        PayrollCode = payTypeinfo.PayrollCode,
                        //BypassBRM = PayTypeinfo.BypassBRM,
                        CompanyId = payTypeinfo.CompanyId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertPayType(PayType paytypeInfoobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayTypeInsert(paytypeInfoobj.PayCode, paytypeInfoobj.PayTypeCode, paytypeInfoobj.Description, paytypeInfoobj.PunchType, paytypeInfoobj.TimeTypeId,
                                                                    paytypeInfoobj.AccrueToOT, paytypeInfoobj.MapToHR, paytypeInfoobj.MapToPayroll, paytypeInfoobj.Display,
                                                                    paytypeInfoobj.RateFactor, paytypeInfoobj.GLCode, paytypeInfoobj.IsDefault, paytypeInfoobj.PayrollCode,
                                                                    paytypeInfoobj.BypassBRM, paytypeInfoobj.CompanyId);
                    hrmsEntity.Dispose();
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdatePayType(PayType paytypeInfoobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayTypeUpdate(paytypeInfoobj.PayTypeId, paytypeInfoobj.PayCode, paytypeInfoobj.PayTypeCode, paytypeInfoobj.Description, paytypeInfoobj.PunchType,
                               paytypeInfoobj.TimeTypeId, paytypeInfoobj.AccrueToOT, paytypeInfoobj.MapToHR, paytypeInfoobj.MapToPayroll, paytypeInfoobj.Display, paytypeInfoobj.RateFactor,
                               paytypeInfoobj.GLCode, paytypeInfoobj.IsDefault, paytypeInfoobj.PayrollCode, paytypeInfoobj.BypassBRM, paytypeInfoobj.CompanyId);
                    hrmsEntity.Dispose();
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeletePayTypeDetail(int payTypeId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayTypeDelete(payTypeId, companyId);
                    return result != 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
