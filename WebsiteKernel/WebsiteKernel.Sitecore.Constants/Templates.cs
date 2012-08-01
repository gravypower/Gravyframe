using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data;

namespace WebsiteKernel.Sitecore.Constants
{
    public class Templates
    {
        private static readonly TemplateID websiteSite = new TemplateID(new ID("{E1F87A87-109A-4C3A-83DF-1F34E9AE9D4B}"));
        public static TemplateID WebsiteSite
        {
            get { return websiteSite; }
        }

        public class News
        {
            private static readonly TemplateID websiteNews = new TemplateID(new ID("{53D907C1-9A95-44B7-99CE-82B1E78D9798}"));
            public static TemplateID WebsiteNews
            {
                get { return websiteNews; }
            }

            private static readonly TemplateID websiteNewsFolder = new TemplateID(new ID("{68EE130F-3561-4F20-97A0-016C543E9DCF}"));
            public static TemplateID WebsiteNewsFolder
            {
                get { return websiteNewsFolder; }
            }
        }

        public class Event
        {
            private static readonly TemplateID websiteEvent = new TemplateID(new ID("{55B49CFA-92C6-45BE-983B-241E7E8FF45C}"));
            public static TemplateID WebsiteEvent
            {
                get { return websiteEvent; }
            }

            private static readonly TemplateID websiteEventFolder = new TemplateID(new ID("{91210525-8501-4DB0-9936-E714B15500DD}"));
            public static TemplateID WebsiteEventFolder
            {
                get { return websiteEventFolder; }
            }
        }
    }
}
