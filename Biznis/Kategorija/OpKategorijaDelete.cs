using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis.Kategorija
{
    public class OpKategorijaDelete:OpKategorija
    {
        public KategorijaDto dto = new KategorijaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            kategorija k = new kategorija
            {
                id = this.dto.id
            };
            entiteti.Entry(k).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}