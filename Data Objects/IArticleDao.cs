using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public interface IArticleDao
    {
        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetArticles();
    }
}
