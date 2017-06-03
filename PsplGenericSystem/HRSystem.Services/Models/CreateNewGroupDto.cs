using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Models
{
    public class CreateNewGroupDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public Boolean share { get; set; }
    }
}
