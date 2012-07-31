using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteControls.News
{
    public partial class WhiteLabelNewsList : WebsiteNewsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var splitUrl = HttpContext.Current.Request.Url.AbsolutePath.Split('/');

            int year;
            int month;
            var getAllNews = true;

            if (splitUrl.Length == 4)
            {
                if (int.TryParse(splitUrl[3], out month) && int.TryParse(splitUrl[2], out year))
                {
                    getAllNews = false;
                    var fromDate = new DateTime(year, month, 1);

                    rptNewsListing.DataSource = WebsiteNewsGateway.GetAllNews(fromDate, fromDate.AddMonths(1).AddDays(-1));
                }
            }
            else if (splitUrl.Length == 3)
            {
                if (int.TryParse(splitUrl[2], out year))
                {
                    getAllNews = false;
                    var fromDate = new DateTime(year, 1, 1);

                    getAllNews = false;
                    rptNewsListing.DataSource = WebsiteNewsGateway.GetAllNews(fromDate, fromDate.AddYears(1).AddDays(-1));
                }
            }

            if (getAllNews)
            {
                rptNewsListing.DataSource = WebsiteNewsGateway.GetAllNews();
            }
            rptNewsListing.DataBind();
        }

        protected void RptNewsListingItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (BusinessObjects.News.WebsiteNews)e.Item.DataItem;

                var hypNewsTitle = (HyperLink)e.Item.FindControl("hypNewsTitle");
                var litNewsDate = (Literal)e.Item.FindControl("litNewsDate");
                var litSummary = (Literal)e.Item.FindControl("litSummary");
                var imgNewsImage = (Image)e.Item.FindControl("imgNewsImage");
                var hypMoreLink = (HyperLink)e.Item.FindControl("hypMoreLink");


                hypNewsTitle.Text = dataItem.Title;
                hypMoreLink.NavigateUrl = hypNewsTitle.NavigateUrl = dataItem.NewsUrl;

                litNewsDate.Text = dataItem.Date.ToString(SiteConfiguration.NewsDateFormat);

                litSummary.Text = dataItem.Summary;

                LayoutUtils.MapImage(imgNewsImage, dataItem.Image);
            }
        }
    }
}