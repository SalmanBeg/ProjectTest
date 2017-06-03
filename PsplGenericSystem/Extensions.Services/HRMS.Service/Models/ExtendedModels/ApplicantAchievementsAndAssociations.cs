using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ApplicantAchievementsAndAssociationsMetaData))]
    public partial class ApplicantAchievementsAndAssociations
    {
       public List<ApplicantAchievementsAndAssociations> ApplicantAchievementsAndAssociationsList { set; get; }
    }
    public partial class ApplicantAchievementsAndAssociationsMetaData
    {
        public ApplicantAchievementsAndAssociationsMetaData()
        {

        }
        public int ApplicantAchievementsAndAssociationsId { get; set; }
        public Nullable<int> Type { get; set; }
        public string Description { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> JobId { get; set; }
    }
}
