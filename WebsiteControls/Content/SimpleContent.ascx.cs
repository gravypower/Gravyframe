using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject.Web;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;

namespace WebsiteControls.Content
{
    public partial class SimpleContent : WebsiteControlBase
    {
        /// <summary>
        /// Gets or sets the white label content gateway.
        /// </summary>
        /// <value>The white label content gateway.</value>
        [Inject]
        public IWebsiteContentGateway WhiteLabelContentGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the current page from the gateway
            var currentItem = WhiteLabelContentGateway.GetCurrentPage();

            //set the class that we are going to use on the summary block
            pSummary.Attributes.Add("class", SiteConfiguration.SummaryClass);

            //sets the summary block text
            litSummary.Text = currentItem.Summary;

            //set the body block class
            panText.CssClass = SiteConfiguration.BodyClass;

            //sets the body text
            litText.Text = currentItem.Text;

            litTitle.Text = currentItem.Title;
            if (currentItem.FeatureImage != null)
            {
                imgfeatureImage.ImageUrl = currentItem.FeatureImage.Src;
            }
        }
    }
}