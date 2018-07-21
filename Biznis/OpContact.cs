using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OpContact:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<ContactDto> contact = from k in entiteti.contacts
                                              select new ContactDto
                                              {
                                                  email = k.email,
                                                  id = k.id,
                                                  naslov = k.naslov,
                                                  poruka = k.poruka
                                              };
            ResultOperation res = new ResultOperation();
            res.items = contact.ToArray();
            return res;
        }
    }
}