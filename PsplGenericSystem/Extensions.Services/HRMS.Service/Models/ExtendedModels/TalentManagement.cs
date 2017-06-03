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
    [MetadataType(typeof(TalentManagementMetaData))]
    public partial class TalentManagement
    {
        public string LevelName { get; set; }

    }
    public partial class TalentManagementMetaData
    {

        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        public string Location { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Graduation Date")]
        public DateTime? GraduationDate { get; set; }
        public int GPA { get; set; }
        [Display(Name = "Verification Date")]
        public DateTime? VerificationDate { get; set; }
        public string Major { get; set; }
        [Display(Name = "Second Major")]
        public string SecondMajor { get; set; }
        public string Minor { get; set; }
       // [Display(Name = "State")]
      //  public int StateId { get; set; }

        #region dropdownproperties
        [Display(Name = "Honorary Recognition")]
        public int HonoraryRecognition { get; set; }
        [Required(ErrorMessage = "Level Required")]
        public int Level { get; set; }
        public string LevelName { get; set; }
        public int Graduated { get; set; }
        #endregion
    }
}
