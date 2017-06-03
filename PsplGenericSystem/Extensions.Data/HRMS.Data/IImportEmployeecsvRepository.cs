using HRMS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Data
{
    public interface IImportEmployeecsvRepository
    {
        bool CreateEmployee(ImportEmployeecsvdata employeeobj);
        ImportEmployeecsvdata SelectEmployeeById(int userId, int companyId);
        bool Insertcsvfiledata(DataTable DocumentList);
        bool InsertImportdata(DataTable dt);
        bool InsertintoDummytable(DataTable dt); 
    }
}
