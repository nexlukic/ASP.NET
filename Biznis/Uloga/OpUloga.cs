using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.Biznis;
using Blog.DataLayer;

namespace Blog.Biznis.Uloga
{
    public class OpUloga:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<UlogaDto> uloge = from u in entiteti.AspNetRoles
                                          select new UlogaDto
                                          {
                                              id_uloga = u.Id,
                                              naziv = u.Name
                                          };
            ResultOperation res = new ResultOperation();
            res.items = uloge.ToArray();
            return res;
        }
    }
}