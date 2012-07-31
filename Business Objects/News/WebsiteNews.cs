using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Mapper.Configuration.Attributes;
using Glass.Sitecore.Mapper.Configuration;

namespace BusinessObjects.News
{
    [SitecoreClass, Serializable]
    public class WebsiteNews
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [SitecoreField]
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the Summary.
        /// </summary>
        /// <value>The Summary.</value>
        [SitecoreField]
        public virtual string Summary { get; set; }

        /// <summary>
        /// Gets or sets the Body.
        /// </summary>
        /// <value>The Body.</value>
        [SitecoreField]
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets or sets the Summary.
        /// </summary>
        /// <value>The Date.</value>
        [SitecoreField]
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [SitecoreField]
        public virtual Glass.Sitecore.Mapper.FieldTypes.Image Image { get; set; }

        public string NewsUrl { get; set; }
    }
}
