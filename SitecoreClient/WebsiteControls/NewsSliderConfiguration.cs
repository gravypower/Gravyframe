using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteControls.News;

namespace SitecoreClient.WebsiteControls
{
    public class NewsSliderConfiguration : INewsSliderConfiguration
    {
        private Dictionary<String, String> parameters;

        public NewsSliderConfiguration()
        {

        }

        public IList<object> GetNewsCategories()
        {
            throw new NotImplementedException();
        }

        public IList<object> GetNewsArticles()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfItems()
        {
            throw new NotImplementedException();
        }

        public int GetQuoteMaxLength()
        {
            throw new NotImplementedException();
        }

        public int GetFeaturedQuoteMaxLength()
        {
            throw new NotImplementedException();
        }
    }
}