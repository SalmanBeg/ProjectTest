using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeNoteMetaData))]
    public partial class EmployeeNote
    {
        [Display(Name = "Attachment")]
        public string File { get; set; }
    }
    public partial class EmployeeNoteMetaData
    {
        public EmployeeNoteMetaData()
        {

        }
        public int EmployeeNotesId { get; set; }
        public System.Guid EmployeeNotesCode { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        //[Display(Name = "Name/Description")]
        //[Required(ErrorMessage = "Please enter name/description.")]
        //public string Description { get; set; }
        [Display(Name = "Name/Description")]
        [Required(ErrorMessage = "Enter Name/Description")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        [Remote("IsTitleExists", "EmployeeNotes", AdditionalFields = "Description,CompanyId,EmployeeNotesId", ErrorMessage = "Name already exists")]
        public string Description { get; set; }
        public string NotesContent { get; set; }
         [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        public Nullable<int> DocumentId { get; set; }
        [Display(Name = "Attachment")]
        public Nullable<int> AttachmentFileId { get; set; }
         [Display(Name = "Created By")]
        public Nullable<int> CreatedBy { get; set; }
         [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
