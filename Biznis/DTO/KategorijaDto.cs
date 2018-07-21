using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class KategorijaDto:BaseDto
    {
        public int id { get; set; }
        public string naziv { get; set; }
    }
}