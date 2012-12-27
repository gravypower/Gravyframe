using System;
using System.Globalization;
using System.Web.UI.WebControls;
using Ninject;
using BusinessObjects.Gallery;
using WebsiteControls.Gateways.WebsiteGallery;

namespace WebsiteControls.Content
{
    public partial class Gallery : System.Web.UI.UserControl
    {

        [Inject]
        public IWebsiteGalleryGateway WebsiteGalleryGateway { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            galleryRepeater.DataSource = WebsiteGalleryGateway.GetCurrentGallery();
            galleryRepeater.DataBind();

        }

        protected void galleryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) 
                return;

            var dataItem = (GalleryImage)e.Item.DataItem;

            var galleryImage = (Image)e.Item.FindControl("galleryImage");
            var photPanel = (Panel) e.Item.FindControl("photPanel");

            galleryImage.ImageUrl = dataItem.Image.Src;
            photPanel.Style.Add("width", dataItem.Image.Width.ToString(CultureInfo.InvariantCulture) + "px");
            photPanel.Style.Add("height", dataItem.Image.Height.ToString(CultureInfo.InvariantCulture) + "px");
        }
    }
}