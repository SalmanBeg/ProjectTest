using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IAlertTemplateRepository
    {
        int AddAlertTemplate(AlertTemplate alertTemplateDetailobj);

        AlertTemplate SelectAlertTemplateById(int alertTemplateId, int companyId);

        bool UpdateAlertTemplate(AlertTemplate alertTemplateDetailobj);

        bool DeleteAlertTemplate(int alertTemplateId, int companyId);

        List<AlertTemplate> SelectAllAlertTemplate(int companyId);
        bool AddAlertEmployee(int alertTemplateId, int EmployeeId, bool status, string employeeName, string employeeEmail);
        bool SaveAlertCriteria(int alertSendCriteriaId,int alertTemplateId,int selectedId);
    }
}
