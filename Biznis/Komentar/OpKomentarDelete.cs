using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;

namespace Blog.Biznis.Komentar
{
    public class OpKomentarDelete:OpKomentari
    {
        public int id;
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            komentar komentar = new komentar
            {
                id = this.id
            };
            entiteti.Entry(komentar).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }

    }
}