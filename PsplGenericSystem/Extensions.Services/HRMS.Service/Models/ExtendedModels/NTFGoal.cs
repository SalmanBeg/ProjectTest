using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(NTFGoalMetaData))]
    public partial class NTFGoal
    {
    }
    public partial class NTFGoalMetaData
    {
        public NTFGoalMetaData()
        {

        }
        public int NTFGoalId { get; set; }
        public string GoalDescription { get; set; }
        public System.Guid AssignedBy { get; set; }
        public System.Guid AssignedTo { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> AssignedDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<double> KeyIndicator { get; set; }
        public Nullable<double> Target { get; set; }
        public Nullable<double> Currentvalue { get; set; }
        public string Incentive { get; set; }
        public Nullable<bool> Prorated { get; set; }
        public Nullable<double> IncentiveEarned { get; set; }
        public string Status { get; set; }
    }
}
