using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.Models.EDM;
namespace HRMS.Web.ViewModels
{
    public class ConsentFormsFormModel
    {
        public ConsentFormsFormModel()
        {
            ConsentFormList = new List<ConsentForms>();
            EmployeeSignList = new List<EmployeeSign>();
        }
        public int EmployeeSignId { get; set; }
        public int? AttachmentFileId { get; set; }
        public string DocumentName { get; set; }
        public int ConsentFormId { get; set; }
        public List<ConsentForms> ConsentFormList { get; set; }
        public List<EmployeeSign> EmployeeSignList { get; set; }
    }
}