using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteContent
{
    public interface IWebsiteContentGateway
    {
        BusinessObjects.Content.WebsiteContent GetCurrentPage();
        BusinessObjects.Content.WebsiteContent CurrentPageChildren();
    }
}
