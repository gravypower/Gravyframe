using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Content;

namespace DataObjects
{
    public interface IWebsiteHomeVariantDao
    {
        IEnumerable<HomeVariant> GetHomeVariant();
    }
}
