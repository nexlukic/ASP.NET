using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
namespace Blog.Models.Admin
{
    public class PostViewModel
    {
        [Required]
        public string naslov { get; set; }
        [Required]
        public string tekst { get; set; }
        public string korisnik_ime { get; set; }
        public DateTime datum { get; set; }
        [Required]
        public HttpPostedFileBase slika { get; set; }
        public string putanja { get; set; }
        public string id_slika { get; set; }
        public int id_kategorija { get; set; }
        public PictureDto slika1 { get; set; }
        public int id { get; set; }
    }
}