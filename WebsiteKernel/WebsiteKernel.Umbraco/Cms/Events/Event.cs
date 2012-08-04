using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;

namespace WebsiteKernel.Umbraco.Cms.Events
{
    public abstract class Event : ApplicationStartupHandler
    {
        public Event()
        {
            //do injection
            WebsiteKernalNinjectKernelContainer.Inject(this);           
        }        
    }
}
