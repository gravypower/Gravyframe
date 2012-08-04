using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Umbraco.Extensions;
using WebsiteKernel.Umbraco.Constants;
using umbraco.cms.businesslogic.web;
using DataObjects;
using Ninject;

namespace WebsiteKernel.Umbraco.Cms.Events
{

    public class WebsiteNewsEvent : Event
    {
        [Inject]
        public ISiteConfigurationDao SiteConfigurationDao { get; set; }

        public WebsiteNewsEvent()
        {
            Document.BeforeSave+=new Document.SaveEventHandler(Document_BeforeSave);
        }

        public void Document_BeforeSave(Document sender, umbraco.cms.businesslogic.SaveEventArgs e)
        {
            if (sender.ContentType.Alias != Constants.DocumentTypeAlias.WebsiteNews)
                return;

            var siteConfiguration = SiteConfigurationDao.GetSiteConfiguration(sender.Id.ToString());

            sender.OrganiseInFolder(
                int.Parse(siteConfiguration.NewsBucket),
                DocumentType.GetByAlias(WebsiteKernel.Umbraco.Constants.DocumentTypeAlias.WebsiteNewsFolder),
                sender.getProperty("date").ToDateTime(),
                WebsiteKernel.Constants.Enums.DateFiling.YearMonth);
        }
    }
}
