using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Biznis.DTO;

namespace Blog.Models.Aplication
{
    public class PostViewModel
    {
        public List<PostDto> post { get; set; }
        public List<KategorijaDto> kategorija { get; set; }
        public int broj { get; set; }
        
    }
}