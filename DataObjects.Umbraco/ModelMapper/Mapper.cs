using System;
using System.Collections.Generic;
using BusinessObjects;
using DataObjects.Umbraco.Utilities;
using umbraco.interfaces;
using BusinessObjects.Content;
using BusinessObjects.Navigation;
using umbraco.NodeFactory;
using umbraco.cms.businesslogic.media;
using WebsiteKernel.Umbraco.Constants;
using Glass.Sitecore.Mapper.FieldTypes;

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
                UseDefaultNewsImage = node.GetProperty("useDefaultNewsImage").Value == "1",
                GoogleAnalyticsTrackingCode = node.GetProperty("googleAnalyticsTrackingCode").Value
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
                var backgroundList = new List<Image>();
                if (backgroundMedia.ContentType.Alias == DocumentTypeAlias.Folder)
                {
                    foreach (var child in backgroundMedia.Children)
                    {
                        backgroundList.Add(
                           NewImage(child)
                        );
                    }
                }
                else if (backgroundMedia.ContentType.Alias == DocumentTypeAlias.Image)
                {
                    backgroundList.Add(
                        NewImage(backgroundMedia)                        
                    );
                }

                returnContent.Backgrounds = backgroundList;
            }

            var featureImage = node.GetProperty("featureImage").Value;
            int featureImageMediaId;
            if (!String.IsNullOrEmpty(featureImage) && int.TryParse(featureImage, out featureImageMediaId))
            {
                var featureImageMedia = new Media(featureImageMediaId);

                returnContent.FeatureImage = new Image
                        {
                            Src = (string)featureImageMedia.getProperty("umbracoFile").Value
                        };
            }

            return returnContent;
        }

        internal static HomeVariant MapHomeVariant(INode node)
        {
            var homeVariant = new HomeVariant
            {
                Body = node.GetProperty("body").Value,
                Heading = node.GetProperty("heading").Value,
                ImageLocation = node.GetProperty("imageLocation").Value,
                TextLocation = node.GetProperty("textLocation").Value,
            };

            var pageImage = node.GetProperty("pageImage").Value;
            int pageImageMediaId;
            if (!String.IsNullOrEmpty(pageImage) && int.TryParse(pageImage, out pageImageMediaId))
            {
                homeVariant.PageImage = NewImage(new Media(pageImageMediaId));
            }

            var textFooterIcon = node.GetProperty("textFooterIcon").Value;
            int textFooterIconMediaId;
            if (!String.IsNullOrEmpty(textFooterIcon) && int.TryParse(textFooterIcon, out textFooterIconMediaId))
            {
                homeVariant.TextFooterIcon = NewImage(new Media(textFooterIconMediaId));
            }
            return homeVariant;
        }

        internal static WebsiteNavigation MapWebsiteNavigation(INode node)
        {
            var websiteNavigation = new WebsiteNavigation
            {
                //Icon
                ItemClass = node.GetProperty("itemClass").Value,
                MenuTitle = node.GetProperty("menuTitle").Value,
                NavigateUrl = node.NiceUrl,
                Title = node.GetProperty("title").Value,
            };

            var redirect = node.GetProperty("redirect").Value;

            if (!String.IsNullOrEmpty(redirect))
            {
                var redirectNode = new Node(int.Parse(redirect));
                var link = new Link
                {
                    Url = redirectNode.NiceUrl,
                    Text = node.GetProperty("menuTitle").Value
                };
                websiteNavigation.Redirect = link;
            }

            var featuredNavigationNode = node.GetProperty("featuredNavigationImage");
            if (featuredNavigationNode != null)
            {
                var featuredNavigationImage = featuredNavigationNode.Value;
                int featuredNavigationImageMediaId;
                if (!String.IsNullOrEmpty(featuredNavigationImage) && int.TryParse(featuredNavigationImage, out featuredNavigationImageMediaId))
                {
                    websiteNavigation.FeaturedImage = NewImage(new Media(featuredNavigationImageMediaId));
                }
            }

            var home = Sites.GetHomeItem();

            if (node.Id == home.Id)
            {
                websiteNavigation.NavigateUrl = websiteNavigation.NavigateUrl.Replace(
                    Sites.GetHomeItem().NiceUrl, "/");
            }
            else
            {
                websiteNavigation.NavigateUrl = websiteNavigation.NavigateUrl.Replace(
                    "/" + Sites.GetHomeItem().UrlName, "");
            }

            return websiteNavigation;
        }

        private static Image NewImage(Media child)
        {
            return new Image
            {
                Src = (string)child.getProperty("umbracoFile").Value,
                Width = int.Parse((string)child.getProperty("umbracoWidth").Value),
                Height = int.Parse((string)child.getProperty("umbracoHeight").Value)
                
            };
        }

        internal static BusinessObjects.Gallery.GalleryImage MapGalleryImage(Media child)
        {
            return new BusinessObjects.Gallery.GalleryImage { Image = NewImage(child) };
        }
    }
}
