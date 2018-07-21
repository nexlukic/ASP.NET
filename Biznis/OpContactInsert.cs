using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis
{
    public class OpContactInsert:OpContact
    {
        public ContactDto dto = new ContactDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            contact contact = new contact
            {
                email = this.dto.email,
                naslov = this.dto.naslov,
                poruka = this.dto.poruka,

            };
            entiteti.contacts.Add(contact);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}