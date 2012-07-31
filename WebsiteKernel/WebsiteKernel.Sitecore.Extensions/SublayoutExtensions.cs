using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Web.UI.WebControls;
using SC = global::Sitecore;
using System.Web;
using System.Web.UI;

namespace WebsiteKernel.Sitecore.Extensions
{
    public static class SublayoutExtensions
    {
        public static Sublayout FindSublayout(this Control control)
        {
            if (control != null)
            {
                if (control is SC.Web.UI.WebControls.Sublayout)
                {
                    return control as SC.Web.UI.WebControls.Sublayout;
                }
                return FindSublayout(control.Parent);
            }

            return null;
        }


    }
}
