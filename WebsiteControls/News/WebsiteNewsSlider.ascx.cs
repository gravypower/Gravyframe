using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteKernel.Extensions;

namespace WebsiteControls.News
{
    public partial class WhiteLabelNewsSlider : WebsiteNewsBase
    {
        //set the default values of these variables
        protected int numberofItems = 10;
        protected int featuredquoteMaxLength = 200;
        protected int quoteMaxLength = 100;

        [Inject]
        public INewsSliderConfiguration NewsSliderConfiguration { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var articles = NewsSliderConfiguration.GetNewsArticles();
            var categories = NewsSliderConfiguration.GetNewsCategories();

            numberofItems = NewsSliderConfiguration.GetNumberOfItems();

            quoteMaxLength = NewsSliderConfiguration.GetQuoteMaxLength();

            featuredquoteMaxLength = NewsSliderConfiguration.GetFeaturedQuoteMaxLength();

            var numberOfItemsFromCategories = numberofItems - articles.Count;

            var news = new List<BusinessObjects.News.WebsiteNews>();

            foreach (var id in articles)
            {
                news.Add(WebsiteNewsGateway.GetNews(id));
            }

            if (numberOfItemsFromCategories > 0)
            {
                var addCount = 0;

                foreach (var cat in categories)
                {
                    foreach (var item in WebsiteNewsGateway.GetCategoryNews(cat))
                    {
                        addCount++;
                        news.Add(item);

                        //break out as we have as many articles as we need
                        if (addCount >= numberOfItemsFromCategories)
                        {
                            break;
                        }
                    }

                    //Need to break out here as well 
                    if (addCount >= numberOfItemsFromCategories)
                    {
                        break;
                    }
                }

            }

            if (news.Count > 0)
            {
                litArticleCount.Text = news.Count.ToString();
                var sliderPage = HttpContext.Current.Request.QueryString["SliderPage"];
                var page = 1;
                if (!string.IsNullOrEmpty(sliderPage))
                {
                    if (int.TryParse(sliderPage, out page))
                    {
                        news = news.Skip((page - 1) * 5).ToList();
                        litArticleNumber.Text = (((page - 1) * 5) + 1).ToString();
                    }
                    else
                    {
                        litArticleNumber.Text = "1";
                    }

                }

                var firstArticle = news.First();

                LayoutUtils.MapImage(imgNews, firstArticle.Image);

                litNewsTitle.Text = firstArticle.Title;
                hylNews.NavigateUrl = firstArticle.NewsUrl;

                var introductionText = firstArticle.Summary;
                if (quoteMaxLength > 0)
                {
                    introductionText = introductionText.TruncateAtWord(featuredquoteMaxLength);
                }

                litIntroduction.Text = introductionText;

                if (news.Count >= 2)
                {
                    repCarousel.DataSource = news.Skip(1);
                    repCarousel.DataBind();
                }

                var basePath = HttpContext.Current.Request.FilePath;
                if (news.Count > 4)
                {
                    hypNext.Visible = hypPrevious.Visible = true;
                    hypNext.NavigateUrl = String.Format("{0}?SliderPage={1}", basePath, page + 1);

                    var previousPage = page - 1;
                    if (previousPage < 1)
                    {
                        previousPage = 1;
                    }

                    hypPrevious.NavigateUrl = String.Format("{0}?SliderPage={1}", basePath, previousPage);
                }
                else
                {
                    if (!string.IsNullOrEmpty(sliderPage))
                    {
                        hypPrevious.Visible = true;
                        hypPrevious.NavigateUrl = String.Format("{0}?SliderPage={1}", basePath, page - 1);
                    }
                }
            }
        }

        // <summary>
        /// Reps the carousel on item databound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs" /> instance containing the event data.</param>
        protected void RepCarouselOnItemDatabound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (BusinessObjects.News.WebsiteNews)e.Item.DataItem;
                var hylNews = (HyperLink)e.Item.FindControl("hylNews");
                var litNewsTitle = (Literal)e.Item.FindControl("litNewsTitle");
                var litIntroduction = (Literal)e.Item.FindControl("litIntroduction");
                var imgNews = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgNews");


                LayoutUtils.MapImage(imgNews, dataItem.Image);

                imgNews.ImageUrl = String.Format("{0}?w=239&h=157&as=1", imgNews.ImageUrl);
                imgNews.Attributes.Add("data-fullsize", String.Format("{0}?w=599&h=393&as=1", imgNews.ImageUrl));

                litNewsTitle.Text = dataItem.Title;
                hylNews.NavigateUrl = dataItem.NewsUrl;

                var introductionText = dataItem.Summary;
                if (quoteMaxLength > 0)
                {
                    introductionText = introductionText.TruncateAtWord(quoteMaxLength);
                }

                litIntroduction.Text = introductionText;
            }
        }
    }
}