using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;
using Blog.Biznis.DTO;

namespace Blog.Biznis
{
    public class OpStatistika:Operation
    {
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            IEnumerable<StatistikaDto> statistika = from s in entiteti.statistikas
                                                    select new StatistikaDto()
                                                    {
                                                        datum = s.datum,
                                                        id = s.id,
                                                        naziv = s.Naziv,
                                                        radnja = s.radnja,
                                                        username = s.username

                                                    };
            ResultOperation res = new ResultOperation();
            res.items = statistika.ToArray();
            return res;
        }
    }
}