using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;


namespace Blog.Biznis.Post
{
    public class OpPostInsert:OpPost
    {
        public PostDto dto = new PostDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            slika slika = new slika
            {
                putanja = this.dto.putanja,
                alt = "neki"

            };
            post post = new post();
            post.datum = this.dto.datum;
            post.id_kategorija = this.dto.id_kategorija;
            post.naslov = this.dto.naslov;
            post.tekst_posta = this.dto.tekst;
            post.id_korisnik = this.dto.id_korisnik;
            post.slika = slika;
            entiteti.posts.Add(post);
            entiteti.SaveChanges();

            return base.Execute(entiteti);
        }
    }
}