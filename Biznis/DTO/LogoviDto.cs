using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class LogoviDto:BaseDto
    {
        public string email { get; set; }
        public int id { get; set; }
        public string radnja { get; set; }
        public DateTime datum { get; set; }
    }
}