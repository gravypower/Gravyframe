using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using WebsiteControls.Gateways.WebsiteNews;

namespace WebsiteControls.News
{
    public class WebsiteNewsBase : WebsiteControlBase
    {
        /// <summary>
        /// Gets or sets the white label news gateway.
        /// </summary>
        /// <value>The white label news gateway.</value>
        [Inject]
        public IWebsiteNewsGateway WebsiteNewsGateway { get; set; }
    }
}