using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.web;

namespace DataObjects.Umbraco.Implementation
{
    public class UmbracoSiteConfigurationDao : ISiteConfigurationDao
    {
        public BusinessObjects.SiteConfiguration GetSiteConfiguration()
        {
            return ModelMapper.Mapper.MapSiteConfiguration(Utilities.Sites.GetConfigItem());
        }

        public BusinessObjects.SiteConfiguration GetSiteConfiguration(string siteId)
        {
            throw new NotImplementedException();
        }
    }
}
