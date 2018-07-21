using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis.Korisnici
{
    public class OpKorisnikUpdate:OpKorisnici
    {
        public KorisniciDto dto = new KorisniciDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            AspNetUser user = entiteti.AspNetUsers.Find(this.dto.id);
            user.Email = this.dto.email;
            user.UserName = this.dto.username;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}