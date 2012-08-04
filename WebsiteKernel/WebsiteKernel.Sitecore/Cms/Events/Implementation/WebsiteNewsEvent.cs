using System;
using System.Linq;
using Sitecore.Data;
using BusinessObjects;
using WebsiteKernel.Sitecore.Extensions;

namespace WebsiteKernel.Sitecore.Cms.Events.Implementation
{
    public class WebsiteNewsEvent : FilingEvent
    {
        protected override void InnerInternalOnItemSave(BusinessObjects.SiteConfiguration siteConfiguration)
        {
            EventItem.OrganiseInFolder(
            new ID(siteConfiguration.NewsBucket),
            Constants.Templates.News.WebsiteNewsFolder,
            EventItem.Fields["Date"].ToDateTime(),
            WebsiteKernel.Constants.Enums.DateFiling.YearMonth);
        }

        protected override bool ExitEvent()
        {
            if (EventItem.IsDerived(Constants.Templates.News.WebsiteNews))
            {
                return false;
            }

            return true;
        }
    }
}
