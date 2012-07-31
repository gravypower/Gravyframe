using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Events;
using SC = global::Sitecore;
using Ninject;
using DataObjects;
using BusinessObjects;

namespace WebsiteKernel.Sitecore.Cms.Events.Implementation
{
    public abstract class FilingEvent : Event
    {
        [Inject]
        public ISiteConfigurationDao SiteConfigurationDao { get; set; }

        protected override void InternalOnItemSave(object sender, EventArgs args)
        {
            if (ExitEvent())
                return;

            SC.Configuration.Settings.GetSetting("Website.TitleSuffix", String.Empty);

            var siteItem = EventItem.Axes.SelectSingleItem(String.Format("ancestor::*[@@templateid = '{0}']", Constants.Templates.WhiteLabelSite.ToString()));

            InnerInternalOnItemSave(SiteConfigurationDao.GetSiteConfiguration(siteItem.ID.ToString()));
        }
        protected abstract void InnerInternalOnItemSave(SiteConfiguration siteConfiguration);
        protected abstract bool ExitEvent();


        protected override void InternalOnItemAdded(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

    }
}
