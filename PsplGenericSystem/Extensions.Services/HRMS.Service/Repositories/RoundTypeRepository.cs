using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RoundTypeRepository:IRoundTypeRepository
    {
         /// <summary>
        /// Returns All RoundType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<RoundType> SelectAllRoundTypeDetails(int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoundTypeSelectAll_Result> lstRoundTypeResult = hrmsEntity.usp_RoundTypeSelectAll(CompanyId).ToList();

                    var roundTypeList = lstRoundTypeResult.Select(roundTypeObj => new RoundType
                    {
                        RoundTypeId = roundTypeObj.RoundTypeId,
                        Name = roundTypeObj.Name,
                        Value = roundTypeObj.Value,
                        CompanyId = roundTypeObj.CompanyId,
                        Status = roundTypeObj.Status,
                    }).ToList();
                    return roundTypeList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

          /// <summary>
        /// Returns Selected RoundType Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //public TAMasterTableMetaData SelectRoundTypeDetail(int Id, int CompanyId)
        //{
        //    try
        //    {
        //        using(var hrmsEntity = new HRMSEntities1())
	    //      {
		//      List<usp_RoundTypeSelect_Result> lstRoundTypeResult = hrmsEntity.usp_RoundTypeSelect(Id,CompanyId).ToList();
        //        var roundTypeList = lstRoundTypeResult.Select(roundTypeObj => new TAMasterTableMetaData
        //        {
        //            Id = roundTypeObj.RoundTypeId,
        //            Name = roundTypeObj.Name,
        //            Value = roundTypeObj.Value,
        //            CompanyId = roundTypeObj.CompanyId,
        //            Status = roundTypeObj.Status,
        //        }).ToList();
        //        return roundTypeList.SingleOrDefault(); 
	//}
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


    }
}
