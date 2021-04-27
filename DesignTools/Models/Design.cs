using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignTools.Models
{
    public class Design
    {
        public int Id { get; set; }

        
        [Display(Name = "page name")]
        public string page_name { get; set; }

        [Display(Name = "html design")]
        public string html_design { get; set; }

        public Design()
        {

        }
    }
}