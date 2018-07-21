using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Post
{
    public class OpPostUpdate:OpPost
    {
        public PostDto dto = new PostDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            post post = entiteti.posts.Find(this.dto.id_posta);
            if(dto.putanja != null)
            {
                slika slika = new slika()
                {
                    putanja = this.dto.putanja,
                    alt = "neki"
                };
                post.slika = slika;
            }
            post.tekst_posta = this.dto.tekst;
            post.naslov = this.dto.naslov;
            post.id_kategorija = this.dto.id_kategorija;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}