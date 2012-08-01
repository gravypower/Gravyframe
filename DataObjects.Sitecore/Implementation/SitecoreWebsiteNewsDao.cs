using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Sitecore.Mapper;
using Sitecore.Data.Items;
using Sitecore.Search;
using BusinessObjects;
using BusinessObjects.Content;
using BusinessObjects.News;
using scSearchContrib.Searcher.Parameters;
using scSearchContrib.Searcher;
using WebsiteKernel;
using Sitecore.Marketing.Wildcards;
using WebsiteKernel.Sitecore.Extensions;
using SC = global::Sitecore;
using Sitecore.Links;
using Sitecore.Data;
using System.Globalization;

namespace DataObjects.Sitecore.Implementation
{
    public class SitecoreWebsiteNewsDao : IWebsiteNewsDao, ISitecoreWebsiteNewsDao
    {
        private readonly ISitecoreContext context;
        private readonly ISiteConfigurationDao siteConfigurationDao;

        private SiteConfiguration siteconfig;
        protected SiteConfiguration Siteconfig
        {
            get
            {
                if (siteconfig == null)
                {
                    siteconfig = siteConfigurationDao.GetSiteConfiguration();
                }
                return siteconfig;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreSiteConfigurationDao" /> class.
        /// </summary>
        public SitecoreWebsiteNewsDao(ISiteConfigurationDao siteConfigurationDao)
        {
            Guard.IsNotNull(() => siteConfigurationDao);

            this.siteConfigurationDao = siteConfigurationDao;
            context = new SitecoreContext();
        }


        #region WebsiteNewsDao Members

        public IEnumerable<WebsiteContent> GetWebsiteArticleNavigation(string bucketId)
        {
            var newsBucket = SC.Context.Database.GetItem(new ID(Siteconfig.NewsBucket));

            var newsNavigation = new List<WebsiteContent>();
            foreach (Item item in newsBucket.Children)
            {
                if (item.Name != "1")
                {
                    foreach (Item childItem in item.Children)
                    {
                        int monthNumber;
                        if (int.TryParse(childItem.Name, out monthNumber))
                        {
                            newsNavigation.Add
                                (
                                    new WebsiteContent
                                    {
                                        Title = String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber), item.Name),
                                        NavigateUrl = String.Format("{0}/{1}/{2}", Siteconfig.DefaultNewsListing.Url, item.Name, childItem.Name)
                                    }
                                );
                        }
                    }
                }
            }


            return newsNavigation;
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInBucket(string bucketId)
        {
            var searchParam = new FieldSearchParam
            {
                Database = context.Database.Name,
                FieldName = WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag,
                FieldValue = Siteconfig.SiteName,
                TemplateIds = WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews.ToString(),
                Partial = true
            };

            var returnNewList = DoSearch(searchParam);

            return returnNewList.OrderBy(x => x.Date);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInBucket(string bucketId, int offset, int number)
        {
            var newsList = GetWebsiteArticleInBucket(bucketId);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public WebsiteNews GetCurrentWebsiteArticleInfomationInBucket(string bucketId)
        {
            throw new NotImplementedException();
        }

        public WebsiteNews GetCurrentWebsiteArticle()
        {
            WebsiteNews news = null;

            if (HttpContext.Current != null)
            {
                var itemList = (List<WildcardInformation>)HttpContext.Current.Items["WildCardInformationList"];
                if (itemList != null)
                {
                    var newsItem = itemList.FirstOrDefault(x => x.Item.IsDerived(WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews));

                    if (newsItem != null)
                    {
                        news = GetNewsFromGalss(newsItem.Item.ID.Guid);
                    }
                }
            }

            return news;
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to)
        {

            var refinements = new List<MultiFieldSearchParam.Refinement>
            {
                new MultiFieldSearchParam.Refinement(WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag, Siteconfig.SiteName),
            };

            var dateRanges = new List<DateRangeSearchParam.DateRange>
            {
                new DateRangeSearchParam.DateRange("date", from, to)
            };

            return DoDateRangeAndDoMultiFieldSearchSearch(dateRanges, refinements);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInBucket(string bucketId, DateTime from, DateTime to, int offset, int number)
        {
            var newsList = GetWebsiteArticleInBucket(bucketId, from, to);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategory(string categoryId)
        {
            var refinements = new List<MultiFieldSearchParam.Refinement>
            {
                new MultiFieldSearchParam.Refinement(WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag, Siteconfig.SiteName),
                new MultiFieldSearchParam.Refinement("NewsCategories", categoryId)
            };

            return DoMultiFieldSearchSearch(refinements);

        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategory(string categoryId, int offset, int number)
        {
            var newsList = GetWebsiteArticleInCategory(categoryId);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to)
        {
            var refinements = new List<MultiFieldSearchParam.Refinement>
            {
                new MultiFieldSearchParam.Refinement(WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag, Siteconfig.SiteName),
            };

            var dateRanges = new List<DateRangeSearchParam.DateRange>
            {
                new DateRangeSearchParam.DateRange("date", from, to)
            };

            return DoDateRangeAndDoMultiFieldSearchSearch(dateRanges, refinements);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategory(string categoryId, DateTime from, DateTime to, int offset, int number)
        {
            var newsList = GetWebsiteArticleInCategory(categoryId, from, to);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public WebsiteNews GetCurrentWebsiteArticleInfomationInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds)
        {
            var refinements = new List<MultiFieldSearchParam.Refinement>
            {
                new MultiFieldSearchParam.Refinement(WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag, Siteconfig.SiteName),
            };

            foreach (var categoryId in categoryIds)
            {
                refinements.Add(new MultiFieldSearchParam.Refinement("NewsCategories", categoryId));
            }

            return DoMultiFieldSearchSearch(refinements);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, int offset, int number)
        {
            var newsList = GetWebsiteArticleInCategories(categoryIds);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to)
        {
            var refinements = new List<MultiFieldSearchParam.Refinement>
            {
                new MultiFieldSearchParam.Refinement(WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag, Siteconfig.SiteName),
            };

            var dateRanges = new List<DateRangeSearchParam.DateRange>
            {
                new DateRangeSearchParam.DateRange("date", from, to)
            };

            return DoDateRangeAndDoMultiFieldSearchSearch(dateRanges, refinements);
        }

        public IEnumerable<WebsiteNews> GetWebsiteArticleInCategories(IEnumerable<string> categoryIds, DateTime from, DateTime to, int offset, int number)
        {
            var newsList = GetWebsiteArticleInCategories(categoryIds, from, to);
            return DoSkipAndOffset(newsList, offset, number);
        }

        public WebsiteNews GetCurrentWebsiteNewsInfomationInCategories(IEnumerable<string> categoryIds)
        {
            throw new NotImplementedException();
        }

        public WebsiteNews GetWebsiteArticle(string whiteLabelNewsId)
        {
            return GetNewsFromGalss(new Guid(whiteLabelNewsId));
        }


        public IEnumerable<WebsiteNews> SearchWebsiteArticle(string whiteLabelNewsName)
        {
            var tagSearchParam = new FieldSearchParam
            {
                Database = context.Database.Name,
                FieldName = WebsiteKernel.Search.Sitecore.WebsiteNewsCrawler.whiteLabelSiteTag,
                FieldValue = Siteconfig.SiteName,
                TemplateIds = WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews.ToString()
            };

            return DoSearch(tagSearchParam);
        }

        #endregion

        #region ISitecoreWebsiteNewsDao Members
        public IEnumerable<Item> SearchWebsiteNewsItems(string whiteLabelNewsName)
        {
            var tagSearchParam = new FieldSearchParam
            {
                Database = context.Database.Name,
                FieldName = BuiltinFields.Name,
                FieldValue = whiteLabelNewsName,
                TemplateIds = WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews.ToString(),
                Partial = true
            };

            var returnNewList = new List<Item>();
            using (var runner = new QueryRunner("WebsiteNews"))
            {
                foreach (var newsItem in runner.GetItems(tagSearchParam))
                {
                    returnNewList.Add(newsItem.GetItem());
                }
            }
            return returnNewList;
        }
        #endregion

        #region Private Members


        private List<WebsiteNews> DoDateRangeAndDoMultiFieldSearchSearch(List<DateRangeSearchParam.DateRange> dateRanges, List<MultiFieldSearchParam.Refinement> refinements)
        {
            return DoSearch(new List<SearchParam> { BuildDateRangeSearchParam(dateRanges), BuildMultiFieldSearchParam(refinements) });
        }

        private List<WebsiteNews> DoDateRangeSearch(List<DateRangeSearchParam.DateRange> dateRanges)
        {
            return DoSearch(BuildDateRangeSearchParam(dateRanges));
        }

        private List<WebsiteNews> DoMultiFieldSearchSearch(List<MultiFieldSearchParam.Refinement> refinements)
        {
            return DoSearch(BuildMultiFieldSearchParam(refinements));
        }

        private DateRangeSearchParam BuildDateRangeSearchParam(List<DateRangeSearchParam.DateRange> dateRanges)
        {
            return new DateRangeSearchParam
            {
                Database = context.Database.Name,
                TemplateIds = WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews.ToString(),
                Ranges = dateRanges
            };
        }

        private MultiFieldSearchParam BuildMultiFieldSearchParam(List<MultiFieldSearchParam.Refinement> refinements)
        {
            return new MultiFieldSearchParam
            {
                Database = context.Database.Name,
                TemplateIds = WebsiteKernel.Sitecore.Constants.Templates.News.WebsiteNews.ToString(),
                Refinements = refinements
            };
        }

        private List<WebsiteNews> DoSearch(SearchParam searchParam)
        {
            return DoSearch(new List<SearchParam> { searchParam });
        }

        private List<WebsiteNews> DoSearch(IEnumerable<SearchParam> searchParams)
        {
            var returnNewList = new List<WebsiteNews>();
            using (var runner = new QueryRunner("WebsiteNews"))
            {
                foreach (var newsItem in runner.GetItems(searchParams))
                {
                    returnNewList.Add(GetNewsFromGalss(newsItem.ItemID));
                }
            }
            return returnNewList;
        }

        private IEnumerable<WebsiteNews> DoSkipAndOffset(IEnumerable<WebsiteNews> newsList, int offset, int number)
        {
            return newsList.Skip(offset).Take(number);
        }

        private WebsiteNews GetNewsFromGalss(string guid)
        {
            return GetNewsFromGalss(new Guid(guid));
        }

        private WebsiteNews GetNewsFromGalss(Guid guid)
        {
            return NewsBussiness(context.GetItem<WebsiteNews>(guid));
        }

        //this should be pushed into the bussiness layer???
        private WebsiteNews NewsBussiness(WebsiteNews news)
        {
            //make sure we have an image.
            if (String.IsNullOrEmpty(news.Image.Src) && Siteconfig.UseDefaultNewsImage)
            {
                news.Image = Siteconfig.DefaultNewsImage;
            }

            news.NewsUrl = String.Format("{0}/{1}/{2}/{3}{4}", Siteconfig.DefaultNewsListing.Url, news.Date.Year, news.Date.Month, SC.MainUtil.EncodeName(news.Name), LinkManager.AddAspxExtension ? ".aspx" : "");
            return news;
        }


        #endregion
    }
}
