using System;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public interface IArticleDaoMapper<T>
    {
        Article Map(T item);

        T Map(Article article);
    }
}
