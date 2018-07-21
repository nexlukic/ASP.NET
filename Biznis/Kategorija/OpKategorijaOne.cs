using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis.Kategorija
{
    public class OpKategorijaOne:Operation
    {
        public KategorijaDto dto = new KategorijaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<KategorijaDto> kategorije = from kategorija in entiteti.kategorijas
                                                    where kategorija.id == this.dto.id
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