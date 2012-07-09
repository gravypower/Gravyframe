using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommentDao
    {
        /// <summary>
        /// Gets the article comments.
        /// </summary>
        /// <param name="articleID">The article ID.</param>
        /// <returns></returns>
        IEnumerable<ArticleComment> GetArticleComments(Guid articleID);
    }
}
