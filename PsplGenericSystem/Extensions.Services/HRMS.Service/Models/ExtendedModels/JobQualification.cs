using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(JobQualificationMetaData))]
    public partial class JobQualification
    {
        
        public bool Mandatory1
        {
            get
            {
                return Mandatory.GetValueOrDefault();
            }
            set
            {
                Mandatory = value;
            }
        }
        
    }
    public partial class JobQualificationMetaData
    {
        public JobQualificationMetaData()
        {
           
        }
        [Required(ErrorMessage = "Please enter the Description.")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Please enter the Subject Area.")]
        [Display(Name = "Subject Area")]
        public string SubjectArea { get; set; }
        //[Required(ErrorMessage = "Please enter Proficiency.")]
        public string Proficiency { get; set; }
        //[Required(ErrorMessage = "Please enter the No of Years")]
        public decimal Years { get; set; }
        //[Required(ErrorMessage = "Please enter the  Last Used Date.")]
        [Display(Name = "Last Used")]
        public string LastUsed { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        [Required(ErrorMessage = "Please select the Type")]
        public int Type { get; set; }
        //[Required(ErrorMessage = "Please enter Yes/No.")]
        public bool Mandatory { get; set; }

        #region Date Properties
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        #endregion
        
        
        
    }
}
