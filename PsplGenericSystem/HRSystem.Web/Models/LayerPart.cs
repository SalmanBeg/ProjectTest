using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRSystem.Web.Models
{
    public class LayerPart
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LayerRule { get; set; }
    }
}