using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class Mail
    {
        public String To { get; set; }
        public String From { get; set; }
        public String Dear { get; set; }
        public String WelcomeToMsg { get; set; }
        public String Subject { get; set; }
        public String MessageBody { get; set; }
        public String LinkName { get; set; }
        public String LinkURL { get; set; }
        public String Cc { get; set; }
        public String Bcc { get; set; }
        public String WithRegards { get; set; }
        public Boolean Status { get; set; }
        public int EmailCount { get; set; }
    }
}
