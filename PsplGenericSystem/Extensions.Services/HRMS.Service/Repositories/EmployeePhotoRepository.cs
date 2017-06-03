using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;

namespace HRMS.Service.Repositories
{
    public class EmployeePhotoRepository : IEmployeePhotoRepository
    {
        public EmployeePhoto GetEmployeePhoto(int userId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstCompanyInfoResult = hrmsEntity.usp_EmployeePhotoSelect(userId).ToList();
                    return lstCompanyInfoResult.Select(employeesign => new EmployeePhoto
                    {
                        UserId = employeesign.UserId,
                        EmployeePhotoId = employeesign.EmployeePhotoId,
                        PhotoFileId = employeesign.PhotoFileId
                    }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertOrUpdateEmployeePhoto(int userId, int photoId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateEmployeePhoto(userId, photoId);
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
