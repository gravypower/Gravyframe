using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using DataObjects.EntityFramework;
using DataObjects.EntityFramework.Implementation;
using DataObjects.EntityFramework.ModelMapper;
using DataObjects.Umbraco.Implementation;
using umbraco.NodeFactory;
using DataObjects.Umbraco.ModelMapper;

namespace DataObjects.Injection.Implementations
{
    public class Umbraco
    {
        /// <summary>
        /// Doing injection here so that i don't need a reference to sitecore anywhere else
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            //bind Article DAO and Mapper
            kernel.Bind<IArticleDao>().To<UmbracoArticleDao>().InSingletonScope();
            kernel.Bind<IArticleDaoMapper<Node>>().To<DataObjects.Umbraco.ModelMapper.Mapper>().InSingletonScope();

            //bind the comment DAO and Mapper
            kernel.Bind<ICommentDao>().To<EntityCommentDao>().InSingletonScope();
            kernel.Bind<ICommentDaoMapper<Comment>>().To<CommentDaoMapper>().InSingletonScope();
        }
    }
}
