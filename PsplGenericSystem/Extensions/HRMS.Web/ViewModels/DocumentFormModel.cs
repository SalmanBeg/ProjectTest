using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class DocumentFormModel
    {
        public DocumentFormModel()
        {

        }

        public EmployeeFolder EmployeeFolder { get; set; }
    }
}