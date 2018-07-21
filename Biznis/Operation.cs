using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;

namespace Blog.Biznis
{
   public abstract class Operation
    {
        public abstract ResultOperation Execute(MojBlogEntities entiteti);
    }
}