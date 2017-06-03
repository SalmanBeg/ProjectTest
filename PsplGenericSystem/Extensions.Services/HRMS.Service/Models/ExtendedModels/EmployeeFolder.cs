using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeFolderMetaData))]
    public partial class EmployeeFolder
    {
        //For bool null value
        
        public bool Shared1
        {
            get
            {
                return Shared.GetValueOrDefault();
            }
            set
            {
                Shared = value;
            }
        }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "File Name is required")]
        public string File { get; set; }
        [Display(Name = "Consent By")]
        public string ConsentBy { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        [Display(Name = "Consent Date")]
        public DateTime ConsentDate { get; set; }
        public string Attachment { get; set; }
    }

    public partial class EmployeeFolderMetaData
    {
        public EmployeeFolderMetaData()
        { 
        }

        public int EmployeeFolderId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage="Document Name is required")]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        [Required(ErrorMessage = "File Name is required")]
        [Display(Name = "Choose Document")]
        public int FilesDBId { get; set; }
        [Display(Name="Category")]
        public int? CategoryId { get; set; }
        public bool Shared { get; set; }
    }
}
