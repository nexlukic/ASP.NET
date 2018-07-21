using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ContactViewModel
    {
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string poruka { get; set; }
    }
}