using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper.Configuration.Attributes;

namespace BusinessObjects
{
    /// <summary>
    ///  this class is uses to hold site configuration defined in sites for @ /site root/configuration
    /// </summary>
    [SitecoreClass, Serializable]
    public class SiteConfiguration
    {
        public string SiteName { get; set; }

        #region Navigation
        /// <summary>
        /// Gets or sets the main navigation item.
        /// </summary>
        /// <value>The main navigation item.</value>
        [SitecoreField("Main Navigation Item")]
        public string MainNavigationItem { get; set; }

        /// <summary>
        /// Show the main navigation
        /// </summary>
        /// <value>true or false</value>
        [SitecoreField("Show Main Navigation")]
        public bool ShowMainNavigation { get; set; }

        /// <summary>
        /// Show the the bread crumbs
        /// </summary>
        /// <value>true or false</value>
        [SitecoreField("Show Breadcrumbs")]
        public bool ShowBreadcrumbs { get; set; }


        /// <summary>
        /// Gets or sets the side navigation item.
        /// </summary>
        /// <value>The side navigation item.</value>
        [SitecoreField("Side Navigation Item")]
        public string SideNavigationItem { get; set; }

        /// <summary>
        /// Gets or sets the show side navigation.
        /// </summary>
        /// <value>The show side navigation.</value>
        [SitecoreField("Show Side Navigation")]
        public bool ShowSideNavigation { get; set; }

        /// <summary>
        /// Gets or sets the footer navigation item.
        /// </summary>
        /// <value>The footer navigation item.</value>
        [SitecoreField("Footer Navigation Item")]
        public string FooterNavigationItem { get; set; }

        /// <summary>
        /// Gets or sets the show footer navigation.
        /// </summary>
        /// <value>The show footer navigation.</value>
        [SitecoreField("Show Footer Navigation")]
        public bool ShowFooterNavigation { get; set; }

        #endregion

        #region Layout
        /// <summary>
        /// Gets or sets the summary class.
        /// </summary>
        /// <value>The summary class.</value>
        [SitecoreField("Summary Class")]
        public string SummaryClass { get; set; }

        /// <summary>
        /// Gets or sets the body class.
        /// </summary>
        /// <value>The body class.</value>
        [SitecoreField("Body Class")]
        public string BodyClass { get; set; }
        #endregion

        #region Social Media

        /// <summary>
        /// Gets or sets the facebook.
        /// </summary>
        /// <value>The facebook.</value>
        [SitecoreField]
        public Glass.Sitecore.Mapper.FieldTypes.Link Facebook { get; set; }

        /// <summary>
        /// Gets or sets the facebook icon.
        /// </summary>
        /// <value>The facebook icon.</value>
        [SitecoreField("Facebook Icon")]
        public Glass.Sitecore.Mapper.FieldTypes.Image FacebookIcon { get; set; }

        /// <summary>
        /// Gets or sets the twitter.
        /// </summary>
        /// <value>The twitter.</value>
        [SitecoreField]
        public Glass.Sitecore.Mapper.FieldTypes.Link Twitter { get; set; }

        /// <summary>
        /// Gets or sets the twitter icon.
        /// </summary>
        /// <value>The twitter icon.</value>
        [SitecoreField("Twitter Icon")]
        public Glass.Sitecore.Mapper.FieldTypes.Image TwitterIcon { get; set; }

        /// <summary>
        /// Gets or sets the Rss.
        /// </summary>
        /// <value>The Rss.</value>
        [SitecoreField]
        public Glass.Sitecore.Mapper.FieldTypes.Link Rss { get; set; }

        /// <summary>
        /// Gets or sets the Rss icon.
        /// </summary>
        /// <value>The Rss icon.</value>
        [SitecoreField("RSS Icon")]
        public Glass.Sitecore.Mapper.FieldTypes.Image RssIcon { get; set; }

        #endregion

        #region News

        /// <summary>
        /// Gets or sets the news bucket.
        /// </summary>
        /// <value>The news bucket.</value>
        [SitecoreField("News Bucket")]
        public string NewsBucket { get; set; }

        /// <summary>
        /// Gets or sets the new folder template.
        /// </summary>
        /// <value>The new folder template.</value>
        [SitecoreField("New Folder Template")]
        public string NewsFolderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the default news image.
        /// </summary>
        /// <value>The default news image.</value>
        [SitecoreField("Default News Image")]
        public Glass.Sitecore.Mapper.FieldTypes.Image DefaultNewsImage { get; set; }

        /// <summary>
        /// Gets or sets the use default news image.
        /// </summary>
        /// <value>The use default news image.</value>
        [SitecoreField("Use Default News Image")]
        public bool UseDefaultNewsImage { get; set; }

        /// <summary>
        /// Gets or sets the news date format.
        /// </summary>
        /// <value>The news date format.</value>
        [SitecoreField("News Date Format")]
        public string NewsDateFormat { get; set; }

        /// <summary>
        /// Gets or sets the default news listing.
        /// </summary>
        /// <value>The default news listing.</value>
        [SitecoreField("Default News Listing")]
        public DefaultListing DefaultNewsListing { get; set; }

        #endregion

        #region News

        /// <summary>
        /// Gets or sets the news bucket.
        /// </summary>
        /// <value>The news bucket.</value>
        [SitecoreField("Event Bucket")]
        public string EventBucket { get; set; }

        /// <summary>
        /// Gets or sets the new folder template.
        /// </summary>
        /// <value>The new folder template.</value>
        [SitecoreField("Event Folder Template")]
        public string EventFolderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the default news image.
        /// </summary>
        /// <value>The default news image.</value>
        [SitecoreField("Default Event Image")]
        public Glass.Sitecore.Mapper.FieldTypes.Image DefaultEventImage { get; set; }

        /// <summary>
        /// Gets or sets the use default news image.
        /// </summary>
        /// <value>The use default news image.</value>
        [SitecoreField("Use Default Event Image")]
        public bool UseDefaultEventImage { get; set; }

        /// <summary>
        /// Gets or sets the news date format.
        /// </summary>
        /// <value>The news date format.</value>
        [SitecoreField("Event Date Format")]
        public string EventDateFormat { get; set; }

        /// <summary>
        /// Gets or sets the default news listing.
        /// </summary>
        /// <value>The default news listing.</value>
        [SitecoreField("Default Event Listing")]
        public DefaultListing DefaultEventListing { get; set; }

        #endregion

        #region GoogleanAlytics

        /// <summary>
        /// Gets or sets the Google Analytics Tracking Code.
        /// </summary>
        /// <value>The Google Analytics Tracking Code.</value>
        [SitecoreField("Google Analytics Tracking Code")]
        public string GoogleAnalyticsTrackingCode { get; set; }
        
        #endregion
    }

    [SitecoreClass]
    public class DefaultListing
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [SitecoreInfo(Glass.Sitecore.Mapper.Configuration.SitecoreInfoType.Url)]
        public virtual string Url { get; set; }
    }
}
