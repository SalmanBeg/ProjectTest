using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(WorkAuthorizationDocumentationTypeMetaData))]
    public partial class WorkAuthorizationDocumentationType
    {
    }
    public partial class WorkAuthorizationDocumentationTypeMetaData
    {
        public WorkAuthorizationDocumentationTypeMetaData()
        {

        }
        public int Id { get; set; }
        public string Constant { get; set; }
        public bool ListA { get; set; }
        public bool ListB { get; set; }
    }
}
