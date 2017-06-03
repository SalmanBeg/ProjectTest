using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Filters
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024; //1 MB
            string[] sAllowedExt = new string[] { ".csv" };  //,".xls", ".xlsx"

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your file of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your file is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}