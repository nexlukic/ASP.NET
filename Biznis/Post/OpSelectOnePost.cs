using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Post
{
    public class OpSelectOnePost:Operation
    {
        public int id;
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<KomentarDto> komentari = from komentar in entiteti.komentars
                                                 join postovi in entiteti.posts on komentar.id_post equals postovi.id
                                                 where komentar.id_post == this.id
                                                 select new KomentarDto
                                                 {
                                                     tekst_komentara = komentar.tekst_komentara,
                                                     datum = komentar.datum,
                                                     ime_korisnika = postovi.AspNetUser.UserName

                                                 };
            IEnumerable<PostDto> postOne = from post in entiteti.posts join slika in entiteti.slikas on post.id_slika equals slika.id where post.id == this.id
                                           select new PostDto
                                           {
                                               id_posta = post.id,
                                               datum = post.datum,
                                               korisnik_ime = post.AspNetUser.UserName,
                                               naslov = post.naslov,
                                               putanja = slika.putanja,
                                               tekst = post.tekst_posta,
                                               komentari = komentari.ToList(),
                                               id_kategorija = post.id_kategorija
                                           };
            ResultOperation result = new ResultOperation();
            result.items = postOne.ToArray();
            return result;
        }

                                                 
        }
    }
