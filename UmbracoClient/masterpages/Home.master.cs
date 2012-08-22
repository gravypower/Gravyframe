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
        

        protected override void Page_Load(object sender, EventArgs e)
        {
            
            
            base.Page_Load(sender, e);
        }

        
    }
}