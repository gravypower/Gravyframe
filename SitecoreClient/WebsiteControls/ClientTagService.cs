using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteControls;

namespace SitecoreClient.WebsiteControls
{
    public class ClientTagService : IClientTagService
    {
        public string GetClientTag()
        {
            return Sitecore.Configuration.Settings.GetSetting("Website.ClientTag", String.Empty);
        }
    }
}