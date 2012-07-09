using System;
using System.Web;
using Ninject.Web.Sitecore;
using WebsiteKernel.Logging;
using Sitecore.Configuration;

namespace SitecoreClient.Layouts.Framework
{
    public class LayoutBase : PageBase
    {
        public bool IsAuthenticated
        {
            get
            {
                return
                    Sitecore.Context.User.Identity.IsAuthenticated &&
                    Sitecore.Context.User.Domain.Name.Equals(Sitecore.Context.Site.Domain.Name);
            }
        }

        /// <summary>
        /// Gets the analytics account.
        /// </summary>
        public string AnalyticsAccount
        {
            get { return Settings.GetSetting("GoogleAnalytics.ProfileId"); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            var panNotification = FindControl("panNotification");
            if (panNotification != null)
            {
                var ctrl = LoadControl(typeof (sublayouts.Framework.Notification), null);
                panNotification.Controls.Add(ctrl);
            }
            else
            {
                LoggerFactory.Create().Warning(String.Format("Could not find plhNotification in layout: {0}.  This is needed if you want to display Notifications", ID));
            }

            SetPageTitle();
            base.OnPreRender(e);
        }

        /// <summary>
        /// Constructs the page title for the current page
        /// </summary>
        private void SetPageTitle()
        {
            var title = String.Empty;
            if (HttpContext.Current.Items.Contains("Title"))
            {
                title = HttpContext.Current.Items["Title"].ToString();
            }
            else
            {
                var currentItem = Sitecore.Context.Item;
                if (currentItem != null)
                {
                    title = currentItem["SEOTitle"];
                    if (String.IsNullOrEmpty(title))
                        title = currentItem["Title"];
                    if (String.IsNullOrEmpty(title))
                        title = currentItem.Name;
                }
            }

            Page.Title = title;
        }
    }
}