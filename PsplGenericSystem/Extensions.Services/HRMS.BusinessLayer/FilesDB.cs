using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class FilesDB
    {
        public int FilesDBId { get; set; }
        public string FileId { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string FileType { get; set; }
    }
}