using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Models
{
    public class CreateDirectMessageDto
    {
        public string source_guid { get; set; }
        public string recipient_id { get; set; }
        public string text { get; set; }
    }
}
