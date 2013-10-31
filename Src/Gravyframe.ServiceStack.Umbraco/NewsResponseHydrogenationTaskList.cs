using System;
using System.Collections.Generic;
using Funq;
using Gravyframe.Configuration;
using Gravyframe.Data.News;
using Gravyframe.Models.Umbraco;
using Gravyframe.Service;
using Gravyframe.Service.News;
using Gravyframe.Service.News.Tasks;

namespace Gravyframe.ServiceStack.Umbraco
{
    public class NewsResponseHydrogenationTaskList : IResponseHydrogenationTaskList<NewsRequest, NewsResponse<UmbracoNews>>
    {
        private readonly Container _container;

        public NewsResponseHydrogenationTaskList(Container container)
        {
            _container = container;
        }

        public IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<UmbracoNews>>> GetEnumerator()
        {
            return GetTasks();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetTasks();
        }


        private IEnumerator<ResponseHydrator<NewsRequest, NewsResponse<UmbracoNews>>> GetTasks()
        {
            yield return new PopulateNewsByCategoryIdResponseHydrator<UmbracoNews>(_container.Resolve<NewsDao<UmbracoNews>>(),
                _container.Resolve<INewsConfiguration>());

            yield return new PopulateNewsByIdResponseHydrator<UmbracoNews>(_container.Resolve<NewsDao<UmbracoNews>>(),
                _container.Resolve<INewsConfiguration>());
        }
    }
}