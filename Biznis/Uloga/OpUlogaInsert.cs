using Blog.Biznis.DTO;
using Blog.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.Uloga
{
    public class OpUlogaInsert:OpUloga
    {
        public UlogaDto dto = new UlogaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            AspNetRole role = new AspNetRole()
            {
                Id = dto.id_uloga,
                Name = dto.naziv
            };
            entiteti.AspNetRoles.Add(role);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}