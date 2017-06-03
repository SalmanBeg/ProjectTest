using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IImportEmployeecsvRepository
    {
        [Logger]
        [ExceptionLogger]
        bool CreateEmployee(ImportEmployeedata importEmployeedataobj);

        [Logger]
        [ExceptionLogger]
        ImportEmployeedata SelectEmployeeById(int userId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool InsertCSVFileData(DataTable DocumentList);

        [Logger]
        [ExceptionLogger]
        bool InsertImportData(DataTable dt);

        [Logger]
        [ExceptionLogger]
        bool InsertIntoDummyTable(DataTable dt);
    }
}
