using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Biznis.DTO
{
    public class ContactDto:BaseDto
    {

        public int id { get; set; }
        public string email { get; set; }
        public string naslov { get; set; }
        public string poruka { get; set; }
    }
}