using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OpLogInsert:OpLogovi
    {
        public LogoviDto dto = new LogoviDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            logovanje1 log = new logovanje1()
            {
                datum = this.dto.datum,
                email = this.dto.email,
                radnja = this.dto.radnja
            };
            entiteti.logovanje1.Add(log);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}