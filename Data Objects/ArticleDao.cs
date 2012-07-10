using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public abstract class ArticleDao : IArticleDao
    {
        protected abstract IEnumerable<BusinessObjects.Article> InternalGetArticles();

        public IEnumerable<BusinessObjects.Article> GetArticles()
        {
            try
            {
                return InternalGetArticles();
            }
            catch(Exception ex)
            {
                //log some error
                //if we are trying to save back to the database maybe we can Serialise it to disk so the data is not lost?

                //need this to alert some other service to check the file and try and

                throw ex; //throw it again because we want the error to be handled by the client/service all 
            }
        }
    }
}
