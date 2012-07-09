using System;
using System.Linq;
using Ninject;
using Sitecore.Data.Items;
using DataObjects.Sitecore.ModelMapper;
using DataObjects.Sitecore.Implementation;
using DataObjects.EntityFramework.Implementation;
using DataObjects.EntityFramework;
using DataObjects.EntityFramework.ModelMapper;

namespace DataObjects.Injection.Implementations
{
    public class Sitecore
    {
        /// <summary>
        /// Doing injection here so that i don't need a reference to sitecore anywhere else
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            //bind Article DAO and Mapper
            kernel.Bind<IArticleDao>().To<SitecoreArticleDao>().InSingletonScope();
            kernel.Bind<IArticleDaoMapper<Item>>().To<DataObjects.Sitecore.ModelMapper.Mapper>().InSingletonScope();

            //bind the comment DAO and Mapper
            kernel.Bind<ICommentDao>().To<EntityCommentDao>().InSingletonScope();
            kernel.Bind<ICommentDaoMapper<Comment>>().To<CommentDaoMapper>().InSingletonScope();
        }
    }
}
