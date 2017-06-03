using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
namespace HRMS.Service.Interfaces
{
   public interface IEmployeeNotesRepository
   {
       [Logger]
       [ExceptionLogger]
       int CreateEmployeeNotes(EmployeeNote employeeNoteobj);

       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeNotesById(EmployeeNote employeeNoteobj);

       [Logger]
       [ExceptionLogger]
       EmployeeNote GetEmployeeNotesById(int employeeNotesId);

       [Logger]
       [ExceptionLogger]
       List<EmployeeNote> GetAllEmployeeNotesByUserId(int userId);

       [Logger]
       [ExceptionLogger]
       bool DeleteEmployeeNotesById(int employeeNotesById);

       /// <summary>
       /// To check for duplication of employee notes on creation
       /// </summary>
       /// <param name="obj"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool IsTitleExists(EmployeeNote Obj);
    }
}
