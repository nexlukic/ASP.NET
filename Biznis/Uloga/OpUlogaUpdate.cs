using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;


namespace Blog.Biznis.Uloga
{
    public class OpUlogaUpdate:OpUloga
    {
        public UlogaDto dto = new UlogaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            AspNetRole uloga = entiteti.AspNetRoles.Find(this.dto.id_uloga);
            uloga.Name = this.dto.naziv;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}