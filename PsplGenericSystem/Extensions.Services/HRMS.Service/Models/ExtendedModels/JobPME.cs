using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(JobPMEMetaData))]
    public partial class JobPME
    {
        public string FrequencyName { get; set; }

    }
    public partial class JobPMEMetaData
    {
        public JobPMEMetaData()
        {
       
        }
        public int PMEId { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Please enter the Description of the JobPME.")]
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        [Required(ErrorMessage = "Please enter the Category of the JobPME.")]
        public string Category { get; set; }
        #region Date Properties
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        #endregion
        #region DropDown Propreties
        
        public int Frequency { get; set; }
      
        public int Essential { get; set; }

        #endregion
    }
}
