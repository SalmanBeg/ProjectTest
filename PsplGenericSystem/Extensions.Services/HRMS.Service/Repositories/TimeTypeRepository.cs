using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class TimeTypeRepository : ITimeTypeRepository
    {
        public List<TimeType> SelectAllTimeTypeDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_TimeTypeSelectAll_Result> lstTimeTypeInfoResult = hrmsEntity.usp_TimeTypeSelectAll(CompanyId).ToList();

                return lstTimeTypeInfoResult.Select(TimeTypeinfo => new TimeType
                {
                    TimeTypeId = TimeTypeinfo.TimeTypeId,
                    Name = TimeTypeinfo.Name,
                    Description = TimeTypeinfo.Description,
                    CompanyId = TimeTypeinfo.CompanyId,
                    Status = (bool)TimeTypeinfo.Status
                }).ToList();
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
