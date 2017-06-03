using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class TrainingTrackFormModel
    {
        public TrainingTrack TrainingTrack { get; set; }
        public List<TrainingClass> TrainingClassList { get; set; }
        public List<TrainingTrack> TrainingTrackList { get; set; }
        public List<TrainingTrackClass> TrainingTrackClassList { get; set; }
    }
}