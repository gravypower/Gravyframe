using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;

namespace WebsiteControls.Content
{
    public partial class HomeVariants : WebsiteControlBase
    {
        [Inject]
        public IWebsiteHomeVariantGateway WebsiteHomeVariantGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptHomeVariants.DataSource = WebsiteHomeVariantGateway.GetHomeVariants();
            rptHomeVariants.DataBind();
        }

        protected void rptHomeVariants_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (BusinessObjects.Content.HomeVariant)e.Item.DataItem;

                var panOne = (Panel)e.Item.FindControl("panOne");
                var panTwo = (Panel)e.Item.FindControl("panTwo");
                var panThree = (Panel)e.Item.FindControl("panThree");
                var panFour = (Panel)e.Item.FindControl("panFour");
                var panFive = (Panel)e.Item.FindControl("panFive");
                var panSix = (Panel)e.Item.FindControl("panSix");


            }
        }
    }
}