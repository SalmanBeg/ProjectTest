using System;
using System.Collections.Generic;
using System.Linq;

using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RoundMinuteRepository : IRoundMinuteRepository
    {

        /// <summary>
        /// Returns All RoundMinutes Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<RoundMinute> SelectAllRoundMinuteDetails(int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoundMinutesSelectAll_Result> lstRoundMinuteResult = hrmsEntity.usp_RoundMinutesSelectAll(CompanyId).ToList();

                    var roundMinuteList = lstRoundMinuteResult.Select(roundMinuteObj => new RoundMinute
                    {
                        RoundMinutesId = roundMinuteObj.RoundMinutesId,
                        Name = roundMinuteObj.Name,
                        Value = roundMinuteObj.Value,
                        CompanyId = roundMinuteObj.CompanyId,
                        Status = roundMinuteObj.Status,
                    }).ToList();
                    return roundMinuteList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
