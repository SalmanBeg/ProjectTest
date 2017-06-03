using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(CompanyLinkMetaData))]
    public partial class CompanyLink
    {
    }

    public partial class CompanyLinkMetaData
    {
        public CompanyLinkMetaData()
        {

        }

        public int CompanyLinkId { get; set; }
        [Required(ErrorMessage="Link Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "URL is required")]
        [Display(Name="URL")]
        public string Url { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
