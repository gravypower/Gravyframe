using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data;

namespace WebsiteKernel.Sitecore.Constants
{
    public class Templates
    {
        private static readonly ID websiteSite = new ID("{E1F87A87-109A-4C3A-83DF-1F34E9AE9D4B}");
        public static ID WebsiteSite
        {
            get { return websiteSite; }
        }

        private static readonly ID websiteNews = new ID("{53D907C1-9A95-44B7-99CE-82B1E78D9798}");
        public static ID WebsiteNews
        {
            get { return websiteNews; }
        }

        private static readonly ID websiteEvent = new ID("{55B49CFA-92C6-45BE-983B-241E7E8FF45C}");
        public static ID WebsiteEvent
        {
            get { return websiteEvent; }
        }
    }
}
