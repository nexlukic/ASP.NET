using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis.Korisnici
{
    public class OpKorisnikDelete:OpKorisnici
    {
        public KorisniciDto dto = new KorisniciDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            AspNetUser user = new AspNetUser()
            {
                Id = this.dto.id
            };
            entiteti.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}