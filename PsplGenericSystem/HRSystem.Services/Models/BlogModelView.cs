using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace HRSystem.Services.Models
{
    public class BlogModelView
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Permalink")]
        public string permalink { get; set; }
        [Display(Name = "Set As Home Page")]
        public bool SetAsHomepage { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        [Url]
        public string FeedProxyUrl { get; set; }
        [Required]
        [Display(Name = "Posts Per Page")]
        public int postsperPage { get; set; }
        public string Post { get; set; }
        public string Owner { get; set; }
    }
}
