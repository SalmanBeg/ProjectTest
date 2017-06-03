using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class I9AcceptableDocuments
    {
        public int I9AcceptableDocumentsID { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public int CompanyID { get; set; }
        public int Status { get; set; }
        public string TableName { get; set; }
    }
}
