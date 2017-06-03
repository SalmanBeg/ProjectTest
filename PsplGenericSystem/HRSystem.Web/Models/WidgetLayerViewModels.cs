using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRSystem.Web.Models
{
    public class WidgetLayerViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Zone { get; set; }
        public bool RenderTitle { get; set; }
        [Required]
        public string Position { get; set; }
        public string Name { get; set; }
        [Display(Name="Layer")]
        public int? LayerId { get; set; }
        public string CssClasses { get; set; }
        public string Owner { get; set; }
    }
}