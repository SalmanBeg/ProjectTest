using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface ILookUpDataRepository
    {
       List<LookUpDataEntity> SelectLookUpData(string TableName,int CompanyId);
       bool AddDepartment(LookUpDataEntity lookUpDataEntityObj, string TableName);
       LookUpDataEntity SelectLookUpDataById(string TableName, int CompanyId, int PrimaryId);
       bool UpdateLookUpData(LookUpDataEntity lookUpDataEntityObj,string TableName);
    }
}
