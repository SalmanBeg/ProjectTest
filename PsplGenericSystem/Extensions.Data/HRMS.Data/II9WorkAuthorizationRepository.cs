using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public interface II9WorkAuthorizationRepository
    {
        I9WorkAuthorization GetI9AuthorizationInfo(int userId);
        List<LookUpDataEntity> GetI9AcceptableDocumentsInfo(int CompanyId);
        bool AddI9WorkAuthorizationDetails(I9WorkAuthorization I9WorkAuthorizationobj, WorkAuthorizationDocumentation WorkAuthorizationDocobj, WorkAuthorizationDocumentationType WorkAuthorizationtypeobj, DataTable DocumentList, int optselect);
        bool _AddI9WorkAuthorizationDetails(I9WorkAuthorization I9WorkAuthorizationobj, WorkAuthorizationDocumentation WorkAuthorizationDocobj, WorkAuthorizationDocumentationType WorkAuthorizationtypeobj, int optselect);
    }
}
