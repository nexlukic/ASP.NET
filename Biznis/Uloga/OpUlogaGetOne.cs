using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.Biznis;
using Blog.DataLayer;

namespace Blog.Biznis.Uloga
{
    public class OpUlogaGetOne:Operation
    {
        public UlogaDto dto = new UlogaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<UlogaDto> role = from r in entiteti.AspNetRoles where r.Id == this.dto.id_uloga
            select new UlogaDto()
            {
                id_uloga = r.Id,
                naziv = r.Name
            };
            ResultOperation res = new ResultOperation();
            res.items = role.ToArray();
            return res;
            
            throw new NotImplementedException();
        }
    }
}