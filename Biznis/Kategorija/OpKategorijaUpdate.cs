using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Kategorija
{
    public class OpKategorijaUpdate:OpKategorija
    {
        public KategorijaDto dto = new KategorijaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            kategorija kategorija = entiteti.kategorijas.Find(this.dto.id);
            kategorija.naziv = this.dto.naziv;
            entiteti.SaveChanges();
                                    
            return base.Execute(entiteti);
        }
    }
}