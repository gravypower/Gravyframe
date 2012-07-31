using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.SiteConfiguration
{
    public interface ISiteConfigurationGateway
    {
        BusinessObjects.SiteConfiguration GetSiteConfiguration();
    }
}
