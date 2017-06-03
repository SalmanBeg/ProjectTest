using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(I9AcceptableDocumentsMetaData))]
    public partial class I9AcceptableDocuments
    {
    }
    public partial class I9AcceptableDocumentsMetaData
    {
        public I9AcceptableDocumentsMetaData()
        {

        }
        public int I9AcceptableDocumentsID { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public int CompanyID { get; set; }
        public int Status { get; set; }
        public string TableName { get; set; }
    }
}
