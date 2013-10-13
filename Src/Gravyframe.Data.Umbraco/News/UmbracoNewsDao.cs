using System.Collections.Generic;
using Gravyframe.Data.News;
using Gravyframe.Kernel.Umbraco;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.News
{
    public class UmbracoNewsDao:NewsDao
    {
        public readonly INodeFactoryFacade NodeFactoryFacade;
        protected readonly INode NewsConfigrationNode;

        public UmbracoNewsDao(INode newsConfigrationNode, INodeFactoryFacade nodeFactoryFacade)
        {
            NodeFactoryFacade = nodeFactoryFacade;
            NewsConfigrationNode = newsConfigrationNode;
        }

        public override Models.News GetNews(string newsId)
        {
            var node = NodeFactoryFacade.GetNode(int.Parse(newsId));
            return new Models.News
                {
                    Body = node.GetProperty("Body").Value,
                    Title = node.GetProperty("Title").Value,
                    Sequence = 0
                };
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
