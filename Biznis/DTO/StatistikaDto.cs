using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class StatistikaDto:BaseDto
    {
        public int id { get; set; }
        public string radnja { get; set; }
        public string naziv { get; set; }
        public DateTime datum { get; set; }
        public string username { get; set; }
    }
}