using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis.Korisnici
{
    public class OpKorisnici:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
         
            IEnumerable<KorisniciDto> korisnici = from k in entiteti.AspNetUsers
                                                  select new KorisniciDto()
                                                  {
                                                      email = k.Email,
                                                      id = k.Id,
                                                      username = k.UserName,

                                                  };
            ResultOperation res = new ResultOperation();
            res.items = korisnici.ToArray();
            return res;
        }
    }
}