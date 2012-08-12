using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteControls.Gateways.WebsiteContent
{
    public interface IWebsiteHomeVariantGateway
    {
        IList<BusinessObjects.Content.HomeVariant> GetHomeVariants();
    }
}
