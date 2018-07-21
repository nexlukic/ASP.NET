using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Post
{
    public class OpPost:Operation
    {
        public PostDto Dto = new PostDto();
        public int broj { set; get; }
        public OpPostKriterijum kriterijum = new OpPostKriterijum();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IQueryable<post> posts = entiteti.posts;
            broj = posts.Count();
            if (kriterijum.id_kategorija != null)
            {
                posts = posts.Where(p => p.id_kategorija == kriterijum.id_kategorija);
                broj = posts.Count();
            }
            if (kriterijum.offset != 0)
            {
                posts = posts.OrderBy(p => p.id);
            }

            if (kriterijum.offset != 0)
            {
                posts = posts.Skip(kriterijum.offset);
            }
            
            posts = posts.Take(2);

            IEnumerable<PostDto> postovi = from post in posts
                                           join slika in entiteti.slikas on post.id_slika equals slika.id
                                           select new PostDto
                                           {
                                               id_posta = post.id,
                                               naslov = post.naslov,
                                               putanja = slika.putanja,
                                               datum = post.datum,
                                               tekst = post.tekst_posta,
                                               korisnik_ime = post.AspNetUser.UserName
                                               

                                           };
            ResultOperation result = new ResultOperation();
            result.items = postovi.ToArray();
            result.broj = broj;
            return result;
        }
    }
}