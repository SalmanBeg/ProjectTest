using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Models
{
    public class AddMembersInGroupDto
    {
        public string nickname { get; set; }
        public string user_id { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string guid { get; set; }
    }
}
