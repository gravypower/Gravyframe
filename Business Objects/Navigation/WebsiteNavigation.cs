﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper.Configuration.Attributes;
using Glass.Sitecore.Mapper.Configuration;

namespace BusinessObjects.Navigation
{
    [SitecoreClass, Serializable]
    public class WebsiteNavigation
    {


        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [SitecoreField]
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the menu title.
        /// </summary>
        /// <value>The menu title.</value>
        [SitecoreField]
        public virtual string MenuTitle { get; set; }

        /// <summary>
        /// Gets or sets the navigate URL.
        /// </summary>
        /// <value>The navigate URL.</value>
        [SitecoreInfo(SitecoreInfoType.Url)]
        public virtual string NavigateUrl { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [SitecoreField]
        public virtual Glass.Sitecore.Mapper.FieldTypes.Image Icon { get; set; }

        /// <summary>
        /// Gets or sets the redirect.
        /// </summary>
        /// <value>The redirect.</value>
        [SitecoreField]
        public virtual Glass.Sitecore.Mapper.FieldTypes.Link Redirect { get; set; }

        /// <summary>
        /// Gets or sets the item class.
        /// </summary>
        /// <value>The item class.</value>
        [SitecoreField("Item Class")]
        public virtual string ItemClass { get; set; }
    }
}
