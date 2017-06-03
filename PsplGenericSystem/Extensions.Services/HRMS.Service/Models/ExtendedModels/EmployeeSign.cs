using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{

    [MetadataType(typeof(EmployeeSignMetaData))]
    public partial class EmployeeSign
    {
        public Byte[] SignFileBytes { get; set; }
        public string SignString { get; set; }
        public bool IsDefault1
        {
            get
            {
                if (IsDefault != null)
                    return Convert.ToBoolean(IsDefault);
                else
                    return false;
            }
            set
            {
                IsDefault = value;
            }
        }
    }
    public partial class EmployeeSignMetaData
    {
        public EmployeeSignMetaData()
        { 
        }
        [Required(ErrorMessage = "Please enter sign name.")]
        public string Name { get; set; }
    }
}
