using System.Collections.Generic;
using Gravyframe.Data.News;

namespace Gravyframe.Data.Umbraco.News
{
    public class UmbracoNewsDao:NewsDao
    {
        public override Models.News GetNews(string newsId)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Models.News> GetNewsByCategoryId(string categoryId, int listSize, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
