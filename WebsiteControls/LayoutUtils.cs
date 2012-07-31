using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteControls
{
    public class LayoutUtils
    {

        /// <summary>
        /// Maps the image.
        /// </summary>
        /// <param name="aspImage">The ASP image.</param>
        /// <param name="image">The image.</param>
        public static void MapImage(System.Web.UI.WebControls.Image aspImage, Glass.Sitecore.Mapper.FieldTypes.Image image)
        {
            if (!String.IsNullOrEmpty(image.Src))
            {
                //pluming code to map an image object to a asp.net image
                aspImage.ImageUrl = image.Src;
                aspImage.AlternateText = image.Alt;
            }
            else
            {
                aspImage.Visible = false;
            }
        }

        /// <summary>
        /// Maps the link.
        /// </summary>
        /// <param name="aspLink">The ASP link.</param>
        /// <param name="link">The link.</param>
        public static void MapLink(System.Web.UI.WebControls.HyperLink aspLink, Glass.Sitecore.Mapper.FieldTypes.Link link)
        {
            //pluming code to map an link object to a asp.net hyperlink
            aspLink.NavigateUrl = link.Url;
            aspLink.Target = link.Target;
        }
    }
}