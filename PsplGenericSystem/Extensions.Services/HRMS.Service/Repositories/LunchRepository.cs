using System;
using System.Collections.Generic;
using System.Linq;

using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class LunchRepository:ILunchRepository
    {

        /// <summary>
        /// Returns All Lunch Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<Lunch> SelectAllLunchDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_LunchSelectAll_Result> lstLunchResult = hrmsEntity.usp_LunchSelectAll(CompanyId).ToList();

                var lunchList = lstLunchResult.Select(lunchObj => new Lunch
                {
                    LunchId = lunchObj.LunchId,
                    LunchCode = lunchObj.LunchCode,
                    LunchDescription = lunchObj.LunchDescription,
                    MinimumWorkTime = lunchObj.MinimumWorkTime,
                    LunchMinutes = lunchObj.LunchMinutes,
                    LunchTime = lunchObj.LunchTime,
                    CompanyId = lunchObj.CompanyId
                }).ToList();
                return lunchList;
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


        /// <summary>
        /// Returns Selected Lunch Details By LunchId and CompanyId
        /// </summary>
        /// <param name="LunchId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public Lunch SelectLunchDetailsByLunchId(int LunchId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_LunchSelect_Result> lstLunchResult = hrmsEntity.usp_LunchSelect(LunchId,CompanyId).ToList();

                var lunchList = lstLunchResult.Select(lunchObj => new Lunch
                {
                    LunchId = lunchObj.LunchId,
                    LunchCode = lunchObj.LunchCode,
                    LunchDescription = lunchObj.LunchDescription,
                    MinimumWorkTime = lunchObj.MinimumWorkTime,
                    LunchMinutes = lunchObj.LunchMinutes,
                    LunchTime = lunchObj.LunchTime,
                    CompanyId = lunchObj.CompanyId
                }).ToList();
                return lunchList.SingleOrDefault();
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


        /// <summary>
        /// Insert Lunch Information
        /// </summary>
        /// <param name="lunchInfoobj"></param>
        /// <returns></returns>
        public bool InsertLunch(Lunch lunchInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_LunchInsert(lunchInfoobj.LunchCode, lunchInfoobj.LunchDescription, lunchInfoobj.MinimumWorkTime, lunchInfoobj.LunchMinutes
                    , lunchInfoobj.LunchTime, lunchInfoobj.CompanyId);
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }

        }

        /// <summary>
        /// Update Lunch Infomation
        /// </summary>
        /// <param name="lunchInfoobj"></param>
        /// <returns></returns>
        public bool UpdateLunch(Lunch lunchInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_LunchUpdate(lunchInfoobj.LunchId, lunchInfoobj.CompanyId, lunchInfoobj.LunchDescription, lunchInfoobj.MinimumWorkTime, 
                    lunchInfoobj.LunchMinutes, lunchInfoobj.LunchTime);
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }

        }

        /// <summary>
        /// Delete Lunch Detail by LunchId and CompanyId
        /// </summary>
        /// <param name="lunchId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteLunchDetail(int lunchId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var result = hrmsEntity.usp_LunchDelete(lunchId, companyId);
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }
    }
}
