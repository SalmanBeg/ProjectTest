using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
namespace HRMS.Service.Repositories
{
    public class OTPayTypeRepository : IOTPayTypeRepository
    {
        /// <summary>
        /// Returns All OTPayType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<OTPayType> SelectAllOTPayTypeDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                //List<usp_OTPayTypeSelectAll_Result> lstOTPayTypeResult = hrmsEntity.usp_OTPayTypeSelectAll(CompanyId).ToList();

                //var otPayTypeList = lstOTPayTypeResult.Select(otPayTypeObj => new OTPayType
                //{
                //    OTPayTypeId = otPayTypeObj.OTPayTypeId,
                //    Name = otPayTypeObj.Name,
                //    Value = otPayTypeObj.Value,
                //    Status = otPayTypeObj.Status,
                //    CompanyId = otPayTypeObj.CompanyId
                //}).ToList();
                //return otPayTypeList;
                return null;
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
