using System;
using System.Linq;
using scSearchContrib.Crawler.Crawlers;
using WebsiteKernel.Sitecore.Extensions;

namespace WebsiteKernel.Search.Sitecore
{
    public class WebsiteNewsCrawler : AdvancedDatabaseCrawler
    {
        public static string whiteLabelSiteTag = "_websitesite";
        public static string whiteLabelMonthYearTag = "_websitemonthyear";
        public static string whiteLabelNewsCategoriesTag = "_websitenewscategories";

        protected override void AddSpecialFields(Lucene.Net.Documents.Document document, global::Sitecore.Data.Items.Item item)
        {
            base.AddSpecialFields(document, item);

            //tags with the site name
            var siteItem = item.Axes.SelectSingleItem(String.Format("ancestor::*[@@templateid = '{0}']", WebsiteKernel.Sitecore.Constants.Templates.WebsiteSite.ToString()));
            document.Add(base.CreateTextField(whiteLabelSiteTag, siteItem.Name));
            document.Add(base.CreateDataField(whiteLabelSiteTag, siteItem.Name));

            //tags with the month and year
            var month = item.Fields["Date"].ConvertToDateField().DateTime.ToString("MMMMyyyy");
            document.Add(base.CreateTextField(whiteLabelMonthYearTag, month));
            document.Add(base.CreateDataField(whiteLabelMonthYearTag, month));

            //tags with the News Categories 
            var newsCategories = item.Fields["News Categories"].Value;
            document.Add(base.CreateTextField(whiteLabelNewsCategoriesTag, newsCategories));
            document.Add(base.CreateDataField(whiteLabelNewsCategoriesTag, newsCategories));
        }
    }
}
