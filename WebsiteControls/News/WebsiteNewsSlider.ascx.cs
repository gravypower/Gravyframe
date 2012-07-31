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
        private List<object> articles = null;
        public List<object> Articles
        {
            get
            {
                if (articles == null)
                {
                    articles = new List<object>();
                }
                return articles;
            }
            set
            {
                articles = value;
            }
        }

        private List<object> categories = null;
        public List<object> Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = new List<object>();
                }
                return categories;
            }
            set
            {
                categories = value;
            }
        }

        private int featuredquoteMaxLength = 200;
        public int FeaturedquoteMaxLength
        {
            get
            {
                return featuredquoteMaxLength;
            }
            set
            {
                featuredquoteMaxLength = value;
            }
        }

        private int numberofItems = 10;
        public int NumberofItems
        {
            get
            {
                return numberofItems;
            }
            set
            {
                numberofItems = value;
            }
        }

        private int quoteMaxLength = 100;
        public int QuoteMaxLength
        {
            get
            {
                return QuoteMaxLength;
            }
            set
            {
                QuoteMaxLength = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var numberOfItemsFromCategories = NumberofItems - articles.Count;

            var news = new List<BusinessObjects.News.WebsiteNews>();

            foreach (var id in Articles)
            {
                news.Add(WebsiteNewsGateway.GetNews(id));
            }

            if (numberOfItemsFromCategories > 0)
            {
                var addCount = 0;

                foreach (var cat in Categories)
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
                    introductionText = introductionText.TruncateAtWord(FeaturedquoteMaxLength);
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
                    introductionText = introductionText.TruncateAtWord(QuoteMaxLength);
                }

                litIntroduction.Text = introductionText;
            }
        }
    }
}