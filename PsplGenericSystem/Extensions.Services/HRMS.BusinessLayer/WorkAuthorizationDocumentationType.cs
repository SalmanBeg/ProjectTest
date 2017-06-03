using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class WorkAuthorizationDocumentationType
    {
        public int Id {get;set;}
        public string Constant { get; set; }
        public bool ListA { get; set; }
        public bool ListB { get; set; }
    }
}
