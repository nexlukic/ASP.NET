using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class KomentarDto : BaseDto
    {
        public int id { get; set; }
        public string ime_korisnika { get; set; }
        public string id_korisnik { get; set; }
        public string post_naziv { get; set; }
        public int id_post { get; set; }
        public string tekst_komentara { get; set; }
        public DateTime datum { get; set; }
    }
}