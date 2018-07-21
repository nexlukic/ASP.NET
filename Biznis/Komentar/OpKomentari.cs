using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Komentar
{
    public class OpKomentari:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<KomentarDto> komentari = from komentar in entiteti.komentars
                                                 select new KomentarDto
                                                 {
                                                     id = komentar.id,
                                                     datum = komentar.datum,
                                                     ime_korisnika = komentar.AspNetUser.UserName,
                                                     tekst_komentara = komentar.tekst_komentara,
                                                     post_naziv = komentar.post.naslov
                                                     
                                                 };
            ResultOperation result = new ResultOperation();
            result.items = komentari.ToArray();
            return result;
        }
    }
}