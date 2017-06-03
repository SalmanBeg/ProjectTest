using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HRMS.Web.Filters;


namespace HRMS.Web.ViewModels
{
    public class UploadFile
    {
        [Required(ErrorMessage = "Please select file to import")]
        [NotMapped]
        [ValidateFile]
        public HttpPostedFileBase ImportFile { get; set; }
        public string File { get; set; }
        public string Columns { get; set; }
    }
}