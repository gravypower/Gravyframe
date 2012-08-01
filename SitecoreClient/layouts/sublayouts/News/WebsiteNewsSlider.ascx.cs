using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteKernel.Sitecore;

namespace SitecoreClient.Layouts.Sublayouts.News
{
    public partial class WebsiteNewsSlider : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            whiteLabelNewsSlider.Categories = ParseStringListParameter("news categories").Cast<object>().ToList();
            whiteLabelNewsSlider.Articles = ParseStringListParameter("news articles").Cast<object>().ToList();

            if (Parameters.ContainsKey("number of items"))
            {
                var numberofItems = 0;
                if (int.TryParse(Parameters["number of items"], out numberofItems))
                {
                    whiteLabelNewsSlider.NumberofItems = numberofItems;
                }
            }

            if (Parameters.ContainsKey("quote max length"))
            {
                var quoteMaxLength = 0;
                if (int.TryParse(Parameters["quote max length"], out quoteMaxLength))
                {
                    whiteLabelNewsSlider.QuoteMaxLength = quoteMaxLength;
                }
            }

            if (Parameters.ContainsKey("featured quote max length"))
            {
                var featuredquoteMaxLength = 0;
                if (int.TryParse(Parameters["featured quote max length"], out featuredquoteMaxLength))
                {
                    whiteLabelNewsSlider.FeaturedquoteMaxLength = featuredquoteMaxLength;
                }
            }
        }
    }
}