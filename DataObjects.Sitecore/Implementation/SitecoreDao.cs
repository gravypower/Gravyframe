using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper;

namespace DataObjects.Sitecore.Implementation
{
    public abstract class SitecoreDao
    {
        protected readonly ISitecoreContext context;

        public SitecoreDao()
        {
            context = new SitecoreContext();
        }
    }
}
