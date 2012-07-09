using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.NHibernate.Implementation
{
    public class NHibernateArticleDao : IArticleDao
    {
        public IEnumerable<BusinessObjects.Article> GetArticles()
        {
            throw new NotImplementedException();
        }
    }
}
