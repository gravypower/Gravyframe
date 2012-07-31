using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace DataObjects
{
    public interface ISiteConfigurationDao
    {
        SiteConfiguration GetSiteConfiguration();
        SiteConfiguration GetSiteConfiguration(string siteId);
    }
}
