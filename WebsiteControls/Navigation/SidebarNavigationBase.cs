using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteControls.News;

namespace WebsiteControls.Navigation
{
    public class SidebarNavigationBase : WebsiteControlBase
    {
        protected bool subNavVisible = true;
        public bool SubNavVisible
        {
            get
            {
                return subNavVisible;
            }
        }
    }
}