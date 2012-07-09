using System;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public interface ICommentDaoMapper<T>
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        ArticleComment Map(T entity);

        /// <summary>
        /// Maps the specified article comment.
        /// </summary>
        /// <param name="articleComment">The article comment.</param>
        /// <returns></returns>
        T Map(ArticleComment articleComment);
    }
}
