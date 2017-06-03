using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(UserFilesMetaData))]
    public partial class UserFiles
    {
    }
    public partial class UserFilesMetaData
    {
        public UserFilesMetaData()
        {
           
        }
        public int UserFileId { get; set; }
        public string UserFileCode { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
