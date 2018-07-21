using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis;
using Blog.DataLayer;


namespace Blog.Biznis.Post
{
    public class OpPostDelete:OpPost
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            post post_obrisi = new post
            {
                id = this.Dto.id_posta
            };
            entiteti.Entry(post_obrisi).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}