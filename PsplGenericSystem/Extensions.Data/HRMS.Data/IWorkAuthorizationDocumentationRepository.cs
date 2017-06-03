using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;
using System.Globalization;

namespace HRMS.Data
{
    public class IWorkAuthorizationDocumentationRepository
    {       
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class WorkAuthorizationDocumentationfields
        {
                 
            public const string  Id = "Id";
            public const string WorkAuthorizationDocumentationTypeId = "WorkAuthorizationDocumentationTypeId";
            public const string WorkAuthorizationId = "WorkAuthorizationId";
            public const string DocumentTitle = "DocumentTitle";
            public const string DocumentIssuingAuthority = "DocumentIssuingAuthority";
            public const string DocumentNumber = "DocumentNumber";
            public const string ExpirationDate = "ExpirationDate";
            public const string UpdateBy = "UpdateBy";

        }
    }
}
