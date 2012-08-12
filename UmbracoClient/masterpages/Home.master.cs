using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteKernel.Umbraco;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;
using BusinessObjects.Content;

namespace UmbracoClient.masterpages
{
    public partial class Home : UmbracoMasterPageBase
    {
        [Inject]
        public IWebsiteContentGateway WhiteLabelContentGateway { get; set; }
        

        protected int BackgroundCount
        {
            get
            {
                return Content.Backgrounds.Count();
            }
        }

        protected WebsiteContent Content
        {
            get
            {
                return WhiteLabelContentGateway.GetCurrentPage();
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            rptBackground.DataSource = Content.Backgrounds;
            rptBackground.DataBind();
            
            base.Page_Load(sender, e);
        }

        protected void rptBackground_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (Glass.Sitecore.Mapper.FieldTypes.Image)e.Item.DataItem;
                var imgBackground = (Image)e.Item.FindControl("imgBackground");

                if ((e.Item.ItemIndex + 1) == BackgroundCount)
                {
                    imgBackground.ImageUrl = dataItem.Src;
                    imgBackground.Attributes.Add("data-count", "1");
                }
                else
                {
                    imgBackground.ImageUrl = "~/Content/Images/onePixelpng.png";
                    imgBackground.Attributes.Add("data-count", (BackgroundCount - e.Item.ItemIndex).ToString());
                }

                imgBackground.Attributes.Add("data-original", dataItem.Src);
                
                
            }
        }
    }
}