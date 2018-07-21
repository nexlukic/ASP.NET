using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OpStatistikaInsert:OpStatistika
    {
        public StatistikaDto dto = new StatistikaDto();
        public override ResultOperation Execute(MojBlogEntities entiteti)
        {
            statistika statistika = new statistika
            {
                datum = DateTime.Now,
                Naziv = this.dto.naziv,
                username = this.dto.username,
                radnja = this.dto.radnja
            };
            entiteti.statistikas.Add(statistika);
            entiteti.SaveChanges();
            return base.Execute(entiteti);
        }
    }
}