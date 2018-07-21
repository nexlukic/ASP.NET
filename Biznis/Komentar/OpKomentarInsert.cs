using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Komentar
{
    public class OpKomentarInsert:OpKomentar
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            komentar komentar = new komentar
            {
                id_post = komentar_prenos.id_post,
                datum = komentar_prenos.datum,
                id_korisnik = komentar_prenos.id_korisnik,
                tekst_komentara = komentar_prenos.tekst_komentara
            };
            entiteti.komentars.Add(komentar);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}