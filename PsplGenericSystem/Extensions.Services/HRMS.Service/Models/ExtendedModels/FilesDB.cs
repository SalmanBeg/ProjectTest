using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(FilesDBMetaData))]
    public partial class FilesDB
    {
    }
    public partial class FilesDBMetaData
    {
        public FilesDBMetaData()
        {

        }
        public int FilesDBId { get; set; }
        public string FileId { get; set; }
        public int CompanyId { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string FileType { get; set; }

    }
}
