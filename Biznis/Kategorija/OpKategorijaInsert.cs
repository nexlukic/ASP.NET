using Blog.Biznis.DTO;
using Blog.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.Kategorija
{
    
    public class OpKategorijaInsert:OpKategorija
    {
        public KategorijaDto dto = new KategorijaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            kategorija k = new kategorija()
            {
                naziv = this.dto.naziv
            };
            entiteti.kategorijas.Add(k);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}