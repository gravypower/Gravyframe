using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;
using BusinessObjects.Gallery;

namespace WebsiteControls.Content
{
    public partial class Gallery : System.Web.UI.UserControl
    {
        [Inject]
        public IWebsiteContentGateway WhiteLabelContentGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            galleryRepeater.DataSource = WhiteLabelContentGateway.GetImageGallery();
            galleryRepeater.DataBind();

        }

        protected void galleryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (GalleryImage)e.Item.DataItem;

                var galleryImage = (Image)e.Item.FindControl("galleryImage");

                galleryImage.ImageUrl = dataItem.Image.Src;
            }
        }
    }
}