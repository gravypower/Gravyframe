using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using WebsiteControls.Gateways.WebsiteContent;
using WebsiteKernel.Constants;
using System.Web.UI.HtmlControls;

namespace WebsiteControls.Content
{
    public partial class HomeVariants : WebsiteControlBase
    {
        protected int NumberOfvariants
        {
            get
            {
                return WebsiteHomeVariantGateway.GetHomeVariants().Count;
            }
        }
        [Inject]
        public IContentLocation ContentLocation { get; set; }

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
                PlaceHolder panOne = null;
                PlaceHolder panTwo = null;
                PlaceHolder panThree = null;
                PlaceHolder panFour = null;
                PlaceHolder panFive = null;
                PlaceHolder panSix = null;

                var dataItem = (BusinessObjects.Content.HomeVariant)e.Item.DataItem;

                if(dataItem.TextLocation.Equals(ContentLocation.GetTopLeft(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panOne == null)
                    {
                        panOne = (PlaceHolder)e.Item.FindControl("plhOne");
                        ((HtmlGenericControl)panOne.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading;
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panOne.Controls.Add(text);
                }

                if (dataItem.TextLocation.Equals(ContentLocation.GetTopMiddle(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panTwo == null)
                    {
                        panTwo = (PlaceHolder)e.Item.FindControl("plhTwo");
                        ((HtmlGenericControl)panTwo.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading; 
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panTwo.Controls.Add(text);
                }

                if (dataItem.TextLocation.Equals(ContentLocation.GetTopRight(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panThree == null)
                    {
                        panThree = (PlaceHolder)e.Item.FindControl("plhThree");
                        ((HtmlGenericControl)panThree.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading;
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panThree.Controls.Add(text);
                }

                if (dataItem.TextLocation.Equals(ContentLocation.GetBottomLeft(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panFour == null)
                    {
                        panFour = (PlaceHolder)e.Item.FindControl("plhFour");
                        ((HtmlGenericControl)panFour.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading;
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panFour.Controls.Add(text);
                }

                if (dataItem.TextLocation.Equals(ContentLocation.GetBottomMiddle(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panFive == null)
                    {
                        panFive = (PlaceHolder)e.Item.FindControl("plhFive");
                        ((HtmlGenericControl)panFive.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading;
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panFive.Controls.Add(text);
                }

                if (dataItem.TextLocation.Equals(ContentLocation.GetBottomRight(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panSix == null)
                    {
                        panSix = (PlaceHolder)e.Item.FindControl("plhSix");
                        ((HtmlGenericControl)panSix.Parent).Attributes["class"] = "panel";
                    }
                    var heading = new Label();
                    heading.CssClass = "heading";
                    heading.Text = dataItem.Heading;
                    panSix.Controls.Add(heading);

                    var text = new Label();
                    text.Text = dataItem.Body;
                    panSix.Controls.Add(text);
                }

                //---------------------

                if (dataItem.ImageLocation.Equals(ContentLocation.GetTopLeft(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panOne == null)
                    {
                        panOne = (PlaceHolder)e.Item.FindControl("plhOne");
                        ((HtmlGenericControl)panOne.Parent).Attributes["class"] = "panel";
                    }

                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panOne.Controls.Add(image);
                }

                if (dataItem.ImageLocation.Equals(ContentLocation.GetTopMiddle(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panTwo == null)
                    {
                        panTwo = (PlaceHolder)e.Item.FindControl("plhTwo");
                        ((HtmlGenericControl)panTwo.Parent).Attributes["class"] = "panel";
                    }
                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panTwo.Controls.Add(image);
                }

                if (dataItem.ImageLocation.Equals(ContentLocation.GetTopRight(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panThree == null)
                    {
                        panThree = (PlaceHolder)e.Item.FindControl("plhThree");
                        ((HtmlGenericControl)panThree.Parent).Attributes["class"] = "panel";
                    }
                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panThree.Controls.Add(image);
                }

                if (dataItem.ImageLocation.Equals(ContentLocation.GetBottomLeft(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panFour == null)
                    {
                        panFour = (PlaceHolder)e.Item.FindControl("plhFour");
                        ((HtmlGenericControl)panFour.Parent).Attributes["class"] = "panel";
                    }
                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panFour.Controls.Add(image);
                }

                if (dataItem.ImageLocation.Equals(ContentLocation.GetBottomMiddle(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panFive == null)
                    {
                        panFive = (PlaceHolder)e.Item.FindControl("plhFive");
                        ((HtmlGenericControl)panFive.Parent).Attributes["class"] = "panel";
                    }
                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panFive.Controls.Add(image);
                }

                if (dataItem.ImageLocation.Equals(ContentLocation.GetBottomRight(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (panSix == null)
                    {
                        panSix = (PlaceHolder)e.Item.FindControl("plhSix");
                        ((HtmlGenericControl)panSix.Parent).Attributes["class"] = "panel";
                    }
                    var image = new Image();
                    image.ImageUrl = dataItem.PageImage.Src;
                    panSix.Controls.Add(image);
                }
            }
        }
    }
}