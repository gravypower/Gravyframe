using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;
using BusinessObjects.Content;

namespace WebsiteControls.Content
{
    public partial class Accordion : WebsiteControlBase
    {
        /// <summary>
        /// Gets or sets the white label content gateway.
        /// </summary>
        /// <value>The white label content gateway.</value>
        [Inject]
        public IWebsiteContentGateway WhiteLabelContentGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            accordionRepeater.DataSource = WhiteLabelContentGateway.CurrentPageChildren();
            accordionRepeater.DataBind();
        }

        protected void accordionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItemWebsiteContent = e.Item.DataItem as WebsiteContent;

                var accordionSectionHyperLink = e.Item.FindControl("accordionSectionHyperLink") as HyperLink;
                var accordionTextLiteral = e.Item.FindControl("accordionTextLiteral") as Literal;

                accordionSectionHyperLink.Text = dataItemWebsiteContent.Title;
                accordionTextLiteral.Text = dataItemWebsiteContent.Text;
            }
        }
    }
}