using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;  

namespace HRMS.Service.Interfaces
{
   public interface IEmployeePhotoRepository
   {
       [Logger]
       [ExceptionLogger]
       EmployeePhoto GetEmployeePhoto(int userId);
       [Logger]
       [ExceptionLogger]
       bool InsertOrUpdateEmployeePhoto(int userId, int photoId);
    }
}
