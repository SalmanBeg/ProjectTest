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
    public class WorkAuthorizationDocumentationTypeRepository : IWorkAuthorizationDocumentationTypeRepository
    {       
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

        public class WorkAuthorizationDocumentationTypefields
        {
            public const string Id = "Id";
            public const string Constant = "Constant";
        }
           
    }
}
