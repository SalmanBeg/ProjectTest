using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(DocumentCategoryMetaData))]
    public partial class DocumentCategory
    {
        public bool Status1
        {
            get
            {
                return (Status != null);
            }
            set
            {
                Status = value;
            }
        }
    }

    public partial class DocumentCategoryMetaData
    {
        public DocumentCategoryMetaData()
        {

        }

        public int DocumentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
    }
}
