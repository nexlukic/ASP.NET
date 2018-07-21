using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Komentar
{
    public class OpKomentar:Operation
    {
        public KomentarDto komentar_prenos = new KomentarDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<KomentarDto> komentari = from komentar in entiteti.komentars
                                                 where komentar.id_post == komentar_prenos.id_post
                                                 select new KomentarDto
                                                 {
                                                     datum = komentar.datum,
                                                     ime_korisnika = komentar.AspNetUser.UserName,
                                                     tekst_komentara = komentar.tekst_komentara
                                                 };
            ResultOperation result = new ResultOperation();
            result.items = komentari.ToArray();
            return result;
        }
    }
}