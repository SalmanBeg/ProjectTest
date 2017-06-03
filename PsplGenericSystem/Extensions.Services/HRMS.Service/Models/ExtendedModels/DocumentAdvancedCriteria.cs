using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(DocumentAdvancedCriteriaMetaData))]
    public partial class DocumentAdvancedCriteria
    {
    }

    public partial class DocumentAdvancedCriteriaMetaData
    {
        public DocumentAdvancedCriteriaMetaData()
        {

        }

        public int DocumentAdvancedCriteriaId { get; set; }
        public int CompanyDocumentId { get; set; }
        public int DocumentSendCriteriaId { get; set; }
        public int SelectedCriteriaListId { get; set; }
    }
}
