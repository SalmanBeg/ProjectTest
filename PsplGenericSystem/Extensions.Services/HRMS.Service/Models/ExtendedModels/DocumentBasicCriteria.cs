using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(DocumentBasicCriteriaMetaData))]
    public partial class DocumentBasicCriteria
    {
    }

    public partial class DocumentBasicCriteriaMetaData
    {
        public DocumentBasicCriteriaMetaData()
        {

        }

        public int DocumentBasicCriteriaId { get; set; }
        public int CompanyDocumentId { get; set; }
        public int DocumentSendTypeId { get; set; }
        public int SelectedCriteriaListId { get; set; }
    }
}
