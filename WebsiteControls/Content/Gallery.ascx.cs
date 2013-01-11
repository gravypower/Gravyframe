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

            var imageHeight = dataItem.Image.Height.ToString(CultureInfo.InvariantCulture);
            var imageWidth = dataItem.Image.Width.ToString(CultureInfo.InvariantCulture);

            galleryImage.ImageUrl = dataItem.Image.Src;
            galleryImage.Attributes.Add("height", imageHeight);
            galleryImage.Attributes.Add("width", imageWidth);

            photPanel.Style.Add("width", imageWidth + "px");
            photPanel.Style.Add("height", imageHeight + "px");
        }
    }
}