using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    public partial class LookUpDataEntity
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public bool? Status { get; set; }
        public string TableName { get; set; }
        public int? primaryId { get; set; }
        public GeneralEnum.Status statusList { get; set; }       
    }
   
}
