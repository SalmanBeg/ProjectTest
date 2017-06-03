using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(HireStepMasterMetaData))]
    public partial class HireStepMaster
    {
        public bool IsSelected { get; set; }
    }
    public partial class HireStepMasterMetaData
    {
        public HireStepMasterMetaData()
        {

        }
        public int StepId { get; set; }
        public string StepCode { get; set; }
        public string StepName { get; set; }
        public bool IsSelected { get; set; }
    }
}
