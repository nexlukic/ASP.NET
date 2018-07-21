using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Areas;
using Blog.Biznis;
namespace Blog.Biznis.DTO
{
    public class PictureDto:BaseDto
    {
        public int Id { get; set; }
        public string Putanja { get; set; }
        public string Alt { get; set; }
    }
}