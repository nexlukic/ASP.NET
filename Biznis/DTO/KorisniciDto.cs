using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class KorisniciDto:BaseDto
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string id_uloga { get; set; }
    }
}