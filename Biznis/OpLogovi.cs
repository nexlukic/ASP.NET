using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OpLogovi:Operation
    {
     
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<LogoviDto> logovi = from l in entiteti.logovanje1
                                            select new LogoviDto
                                            {
                                                datum = l.datum,
                                                email = l.email,
                                                radnja = l.radnja
                                            };
            ResultOperation res = new ResultOperation();
            res.items = logovi.ToArray();
            return res;
           
        }
    }
}