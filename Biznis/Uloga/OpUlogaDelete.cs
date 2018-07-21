using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;
using Blog.Biznis;

namespace Blog.Biznis.Uloga
{
    public class OpUlogaDelete:OpUloga
    {
        public UlogaDto dto = new UlogaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            AspNetRole role = new AspNetRole()
            {
                Id = this.dto.id_uloga
            };
            entiteti.Entry(role).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}