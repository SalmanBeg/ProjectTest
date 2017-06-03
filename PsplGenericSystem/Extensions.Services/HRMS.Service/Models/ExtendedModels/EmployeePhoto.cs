using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeePhotoMetaData))]
    public partial class EmployeePhoto
    {

    }
    public partial class EmployeePhotoMetaData
    {
        public EmployeePhotoMetaData()
        {

        }
    }
}
