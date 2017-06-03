using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeDocumentMetaData))]
    public partial class EmployeeDocument
    {
        //For bool null value
        public bool Status1
        {
            get
            {
                return (Status != null);
            }
            set
            {
                Status = value;
            }
        }
    }

    public partial class EmployeeDocumentMetaData
    {
        public EmployeeDocumentMetaData()
        {

        }

        public int EmployeeDocumentId { get; set; }
        public int CompanyDocumentId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public bool Status { get; set; }
    }
}
