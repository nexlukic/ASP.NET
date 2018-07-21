using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.DataLayer;

namespace Blog.Biznis
{
    public class OperationManager
    {
        private static volatile OperationManager singleton;

        private static object syncRoot = new object();

        public static OperationManager Singleton
        {
            get
            {
                if (singleton == null)
                {
                    lock (syncRoot)
                    {
                        if (singleton == null)
                        {
                            singleton = new OperationManager();
                        }
                    }
                }
                return singleton;
            }
        }
        MojBlogEntities entiteti = new MojBlogEntities();
        public ResultOperation ExecuteOperation(Operation op)
        {
            try
            {
                return op.Execute(entiteti);
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}