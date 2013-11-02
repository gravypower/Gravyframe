using System.Collections;
using System.Collections.Generic;
using Funq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Service;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;

namespace Gravyframe.ServiceStack.Umbraco.News
{
    public class NewsResponseHydrogenationTaskList : IResponseHydrogenationTaskList<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>
    {
        private readonly Container _container;

        public NewsResponseHydrogenationTaskList(Container container)
        {
            _container = container;
        }

        public IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>> GetEnumerator()
        {
            return GetTasks();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetTasks();
        }

        private IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<Models.Umbraco.UmbracoNews>>> GetTasks()
        {
            yield return new PopulateNewsByCategoryIdResponseHydrator<Models.Umbraco.UmbracoNews>(
                _container.Resolve<NewsDao<Models.Umbraco.UmbracoNews>>(),
                _container.Resolve<INewsConfiguration>());

            yield return new PopulateNewsByIdResponseHydrator<Models.Umbraco.UmbracoNews>(
                _container.Resolve<NewsDao<Models.Umbraco.UmbracoNews>>(),
                _container.Resolve<INewsConfiguration>());
        }
    }
}