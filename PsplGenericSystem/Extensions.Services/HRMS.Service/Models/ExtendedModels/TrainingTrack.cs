using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(TrainingTrackMetaData))]
    public partial class TrainingTrack
    {
        public string classIds { get; set; }
    }
    public partial class TrainingTrackMetaData
    {
        public TrainingTrackMetaData()
        {
            
        }
            
        [Display(Name="Track Name")]
        [Required(ErrorMessage="Enter track name.")]
        public string TrainingTrackName { get; set; }
        [Display(Name = "Track description")]
        public string TrainingTrackDescription { get; set; }

        
    }
}
