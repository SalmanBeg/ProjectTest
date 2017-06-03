using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<UserLoginModel> SelectAllUserList(string username)
        {

            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstLoginResult = hrmsEntity.usp_SelectUsersByUsername(username).ToList();
                    return lstLoginResult.Select(UserModel => new UserLoginModel
                    {
                        UserId = UserModel.UserId,
                        UserCode = UserModel.UserCode,
                        UserName = UserModel.UserName,
                        IsApproved = UserModel.IsApproved,
                        LastLoginDate = UserModel.LastLoginDate,
                        Email = UserModel.Email,
                        
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
