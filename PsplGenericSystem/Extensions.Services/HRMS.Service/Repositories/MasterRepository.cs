using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        public List<Reviewee> SelectReviewNotification(int employeeId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstReviewMasterResult = hrmsEntity.usp_EmployeeSignReviewSelect(employeeId, companyId).ToList();
                    var userReviewMasterList = lstReviewMasterResult.Select(revieweeNotification => new Reviewee
                    {
                        ReviewId = revieweeNotification.ReviewId,
                        ReviewName = revieweeNotification.Name,
                    }).ToList();

                    return userReviewMasterList; 
                }
            }
            catch (Exception)
            {
               throw;
            }
        }

        public bool ResetAllData()
        {
            //var hrmsEntity = new HRMSEntities1();
            //try
            //{
            //    var result=hrmsEntity.usp_ResetDatabase();
            //    return result.Count()>0?true:false ;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{ }
            return true;
        }

    }
}
