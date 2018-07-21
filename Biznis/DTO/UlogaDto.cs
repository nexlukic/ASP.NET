using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class UlogaDto:BaseDto
    {
        public string id_uloga { get; set; }
        public string naziv { get; set; }
    }
}