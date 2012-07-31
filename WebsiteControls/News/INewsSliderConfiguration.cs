using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.News
{
    public interface INewsSliderConfiguration
    {
        IList<object> GetNewsCategories();
        IList<object> GetNewsArticles();
        int GetNumberOfItems();
        int GetQuoteMaxLength();
        int GetFeaturedQuoteMaxLength();

    }
}
