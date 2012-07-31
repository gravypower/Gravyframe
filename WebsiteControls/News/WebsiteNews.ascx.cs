using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteControls.News
{
    public partial class WhiteLabelNews : WebsiteNewsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var news = WebsiteNewsGateway.GetCurrentNews();

            litTitle.Text = news.Title;
            litDate.Text = news.Date.ToString(SiteConfiguration.NewsDateFormat);
            litSummary.Text = news.Summary;
            litBody.Text = news.Body;

            LayoutUtils.MapImage(imgNewsImage, news.Image);
        }
    }
}