using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(PayPeriodTypeMetaData))]
    public partial class PayPeriodType
    {
    }

    public partial class PayPeriodTypeMetaData
    {
        public PayPeriodTypeMetaData()
        {

        }

        public int PayPeriodTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Days { get; set; }
        public int CompanyId { get; set; }
        public Boolean Status { get; set; }
    }
}
