using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
using System.Data;

namespace HRMS.Service.Interfaces
{
    public interface II9WorkAuthorizationRepository
    {
        [Logger]
        [ExceptionLogger]
        WorkAuthorization GetI9AuthorizationInfo(int userId);

        [Logger]
        [ExceptionLogger]
        List<LookUpDataEntity> GetI9AcceptableDocumentsInfo(int companyId);

        //[Logger]
        //[ExceptionLogger]
        //bool AddI9WorkAuthorizationDetails(I9WorkAuthorization i9WorkAuthorizationobj, WorkAuthorizationDocumentation workAuthorizationDocobj, WorkAuthorizationDocumentationType workAuthorizationtypeobj, DataTable documentList, int optselect);
        [Logger]
        [ExceptionLogger]
        int AddI9WorkAuthorizationDetails(WorkAuthorization WorkAuthorizationobj, List<WorkAuthorizationDocumentation> workAuthorizationDocobj);


        [Logger]
        [ExceptionLogger]
        bool _AddI9WorkAuthorizationDetails(WorkAuthorization i9WorkAuthorizationobj, WorkAuthorizationDocumentation workAuthorizationDocobj, WorkAuthorizationDocumentationType workAuthorizationtypeobj, int optselect);

        [Logger]
        [ExceptionLogger]
        List<WorkAuthorization> GetI9WorkAuthorizationDetails(int userId, int companyId);

        [Logger]
        [ExceptionLogger]
        List<WorkAuthorizationDocumentation> GetI9DoumentationDetails(int workAuthorizationId);

        [Logger]
        [ExceptionLogger]
        WorkAuthorization SelectFileByWorkAuthorizationID(int workAuthorizationId);

        [Logger]
        [ExceptionLogger]
        bool DeleteFileByWorkAuthorizationID(int workAuthorizationId);

        //[Logger]
        //[ExceptionLogger]
        //EmployeeW4Form GetEmployeeW4FormDetails(int userId, int companyId);
    }
}
