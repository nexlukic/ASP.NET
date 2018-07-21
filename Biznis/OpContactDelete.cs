using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OpContactDelete:OpContact
    {
        public ContactDto dto = new ContactDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            contact contact = new contact()
            {
                id = this.dto.id
            };
            entiteti.Entry(contact).State = System.Data.Entity.EntityState.Deleted;
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}