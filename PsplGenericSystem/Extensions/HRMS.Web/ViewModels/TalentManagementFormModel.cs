using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HRMS.Web.ViewModels
{
    public class TalentManagementFormModel
    {
        public TalentManagementFormModel()
        {

            LevelList = new List<LookUpDataEntity>();
            GraduatedList = new List<LookUpDataEntity>();
            HonoraryRecognitionList=new List<LookUpDataEntity>();
            TalentManagement = new TalentManagement();
           

        }
        public TalentManagement TalentManagement { get; set; }
        [Required(ErrorMessage = "Level Required")]
        public int Level { get; set; }
        public int Graduated { get; set; }
        [Display(Name = "Honorary Recognition")]
        public int HonoraryRecognition { get; set; }
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        public string Location { get; set; }
       // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Graduation Date")]
        public DateTime GraduatedDate { get; set; }
        [Display(Name = "Verification Date")]
        public DateTime? VerificationDate { get; set; }
        public int GPA { get; set; }
        public string Major { get; set; }
        [Display(Name = "Second Major")]
        public string SecondMajor { get; set; }
        public string Minor { get; set; }
        public List<LookUpDataEntity> LevelList { get; set; }
        public List<LookUpDataEntity> GraduatedList { get; set; }       
        public List<LookUpDataEntity> HonoraryRecognitionList { get; set; }  
   

    }
}