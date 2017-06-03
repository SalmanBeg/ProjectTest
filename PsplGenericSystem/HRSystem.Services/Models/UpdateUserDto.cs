using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Models
{
    public class UpdateUserDto
    {
        public string avatar_url { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string zip_code { get; set; }
    }
}
