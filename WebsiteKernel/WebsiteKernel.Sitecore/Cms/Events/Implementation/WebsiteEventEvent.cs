using System;
using System.Linq;
using Sitecore.Data;
using BusinessObjects;
using WebsiteKernel.Sitecore.Extensions;

namespace WebsiteKernel.Sitecore.Cms.Events.Implementation
{
    public class WebsiteEventEvent : FilingEvent
    {
        protected override void InnerInternalOnItemSave(SiteConfiguration siteConfiguration)
        {
            EventItem.OrganiseInFolder(
            new ID(siteConfiguration.EventBucket),
            Constants.Templates.Event.WebsiteEventFolder,
            EventItem.Fields["Date From"].ToDateTime(),
            WebsiteKernel.Constants.Enums.DateFiling.YearMonth);
        }

        protected override bool ExitEvent()
        {
            if (EventItem.IsDerived(Constants.Templates.Event.WebsiteEvent))
            {
                return false;
            }

            return true;
        }
    }
}
