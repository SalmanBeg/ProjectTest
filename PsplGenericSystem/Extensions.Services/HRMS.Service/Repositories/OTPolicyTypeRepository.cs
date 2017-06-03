using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class OTPolicyTypeRepository : IOTPolicyTypeRepository
    {
        /// <summary>
        /// Returns All OTPolicyType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<OTPolicyType> SelectAllOTPolicyTypeDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_OTPolicyTypeSelectAll_Result> lstOTPolicyTypeResult = hrmsEntity.usp_OTPolicyTypeSelectAll(CompanyId).ToList();

                var otPayTypeList = lstOTPolicyTypeResult.Select(otPolicyTypeObj => new OTPolicyType
                {
                    OTPolicyTypeId = otPolicyTypeObj.OTPolicyTypeId,
                    Name = otPolicyTypeObj.Name,
                    Value = otPolicyTypeObj.Value,
                    Status = otPolicyTypeObj.Status,
                    CompanyId = otPolicyTypeObj.CompanyId
                }).ToList();
                return otPayTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                hrmsEntity.Dispose();
            }            
        }
    }
}
