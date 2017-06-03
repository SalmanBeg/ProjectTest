using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRMS.BusinessLayer
{
    public class LookUpDataEntity
    {
        public int ID { get; set; }
        public int I9AcceptableDocuments1ID { get; set; }
        public int I9AcceptableDocuments2ID { get; set; }
        public int I9AcceptableDocuments3ID { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public bool Status { get; set; }
        public string TableName { get; set; }
        public GeneralEnum.Status statusList { get; set; }
    }
}
