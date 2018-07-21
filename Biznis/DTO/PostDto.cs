using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class PostDto:BaseDto
    {
        public int id_posta { get; set; }
        public string id_korisnik { get; set; }
        public int id_kategorija { get; set; }
        public string naslov { get; set; }
        public string tekst { get; set; }
        public string korisnik_ime { get; set; }
        public DateTime datum { get; set; }
        public string putanja { get; set; }
        public int id_slika { get; set; }
        public List<KomentarDto> komentari { get; set; }

    }
}