using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class CompetencyFormModel
    {
        public CompetencyFormModel()
        {
           
        }
        public Competency Competency { get; set; }
       
        
    }
}