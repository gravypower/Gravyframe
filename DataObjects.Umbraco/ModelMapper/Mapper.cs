using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using umbraco.interfaces;
using BusinessObjects.Content;
using BusinessObjects.Navigation;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.media;
using umbraco.cms.businesslogic;
using WebsiteKernel.Umbraco.Constants;

namespace DataObjects.Umbraco.ModelMapper
{
    public class Mapper
    {
        internal static SiteConfiguration MapSiteConfiguration(INode node)
        {
            return new SiteConfiguration
            {
                BodyClass = node.GetProperty("bodyClass").Value,
                //DefaultEventImage = node.GetProperty("defaultEventImage").Value,
                DefaultEventListing = new DefaultListing { Url = node.GetProperty("defaultEventListing").Value },
                //DefaultNewsImage = node.GetProperty("defaultNewsImage").Value,
                DefaultNewsListing = new DefaultListing { Url = node.GetProperty("defaultNewsListing").Value },
                EventBucket = node.GetProperty("eventBucket").Value,
                EventDateFormat = node.GetProperty("eventDateFormat").Value,
                //Facebook = node.GetProperty("facebook").Value,
                //FacebookIcon = node.GetProperty("facebookIcon").Value,
                FooterNavigationItem = node.GetProperty("footerNavigationItem").Value,
                MainNavigationItem = node.GetProperty("mainNavigationItem").Value,
                NewsBucket = node.GetProperty("newsBucket").Value,
                NewsDateFormat = node.GetProperty("newsDateFormat").Value,
                //Rss = node.GetProperty("rss").Value,
                //RssIcon = node.GetProperty("rssIcon").Value,
                ShowFooterNavigation = node.GetProperty("showFooterNavigation").Value == "1",
                ShowMainNavigation = node.GetProperty("showMainNavigation").Value == "1",
                ShowSideNavigation = node.GetProperty("showSubNavigation").Value == "1",
                SideNavigationItem = node.GetProperty("subNavigationItem").Value,
                //SiteName = node.GetProperty("siteName").Value,
                SummaryClass = node.GetProperty("summaryClass").Value,
                //Twitter = node.GetProperty("twitter").Value,
                //TwitterIcon = node.GetProperty("twitterIcon").Value,
                UseDefaultEventImage = node.GetProperty("useDefaultEventImage").Value== "1",
                UseDefaultNewsImage = node.GetProperty("useDefaultNewsImage").Value == "1"
            };
        }

        internal static WebsiteContent MapWebsiteContent(INode node)
        {
            var returnContent = new WebsiteContent
            {
                //Icon = new  node.GetProperty("icon").Value,
                ItemClass = node.GetProperty("itemClass").Value,
                MenuTitle = node.GetProperty("menuTitle").Value,
                Name = node.Name,
                NavigateUrl = node.NiceUrl,
                //Redirect = bool.Parse(node.GetProperty("redirect").Value),
                Summary = node.GetProperty("summary").Value,
                Text = node.GetProperty("text").Value,
                Title = node.GetProperty("title").Value            
            };


            var background = node.GetProperty("backgrounds").Value;

            int backgroundMediaId;
            if (!String.IsNullOrEmpty(background) && int.TryParse(background, out backgroundMediaId))
            {
                var backgroundMedia = new Media(backgroundMediaId);
                var backgroundList = new List<Glass.Sitecore.Mapper.FieldTypes.Image>();
                if (backgroundMedia.ContentType.Alias == DocumentTypeAlias.Folder)
                {
                    foreach (var child in backgroundMedia.Children)
                    {
                        backgroundList.Add(
                        new Glass.Sitecore.Mapper.FieldTypes.Image
                        {
                            Src = (string)child.getProperty("umbracoFile").Value
                        }
                    );
                    }
                }
                else if (backgroundMedia.ContentType.Alias == DocumentTypeAlias.Image)
                {
                    backgroundList.Add(
                        new Glass.Sitecore.Mapper.FieldTypes.Image
                        {
                            Src = (string)backgroundMedia.getProperty("umbracoFile").Value
                        }
                    );
                }

                returnContent.Backgrounds = backgroundList;
            }

            return returnContent;
        }

        internal static WebsiteNavigation MapWebsiteNavigation(INode node)
        {
            return new WebsiteNavigation
            {
                //Icon
                ItemClass = node.GetProperty("itemClass").Value,
                MenuTitle = node.GetProperty("menuTitle").Value,
                NavigateUrl = node.NiceUrl,
                //Redirect = node.GetProperty("itemClass").Value,
                Title = node.GetProperty("title").Value
            };
        }
    }
}
