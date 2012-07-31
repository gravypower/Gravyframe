using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject.Web;
using WebsiteControls.Gateways.SiteConfiguration;
using BusinessObjects;
using Ninject;

namespace WebsiteControls.SocialMedia
{
    public partial class SocialMedia : WebsiteControlBase
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteConfiguration.Facebook != null)
            {
                liFacebook.Visible = true;
                hypFacebook.NavigateUrl = SiteConfiguration.Facebook.Url;
                LayoutUtils.MapImage(imgFacebook, SiteConfiguration.FacebookIcon);
            }

            if (SiteConfiguration.Rss != null)
            {
                liRSS.Visible = true;
                hypRSS.NavigateUrl = SiteConfiguration.Rss.Url;
                LayoutUtils.MapImage(imgRSS, SiteConfiguration.RssIcon);
            }
        }
    }
}