using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Kategorija
{
     public abstract class OpKategorija:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<KategorijaDto> kategorije = from kategorija in entiteti.kategorijas
                                                    select new KategorijaDto
                                                    {
                                                        id = kategorija.id,
                                                        naziv = kategorija.naziv
                                                    };
            ResultOperation rezultat = new ResultOperation();
            rezultat.items = kategorije.ToArray();
            return rezultat;
        }
    }
}