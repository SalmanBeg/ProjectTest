using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
   public class UserFiles
    {
        public int UserFileId { get; set; }
        public string UserFileCode { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
