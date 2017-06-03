using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(CompetencyMetaData))]
    public partial class Competency
    {
    }
    public partial class CompetencyMetaData
    {

        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Enter Category / Points")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Enter Category / Points")]
        public string Points { get; set; }
        [Required(ErrorMessage = "Please Enter Competency Name")]
        [Display(Name = "Competency Set Name")]
        public int CompetencySetName { get; set; }
       
       
    }
}
