using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Models
{
   public class NavigationMenuItems
    {
        public int Id { get; set; }
       [Required]
        public string Name { get; set; }
       [Required]
       [Url]
        public string URL { get; set; }
        public string Owner { get; set; }
        public string CssClass { get; set; }
    }
}
