using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteControls;

namespace UmbracoClient.WebsiteControls
{
    public class ClientTagService : IClientTagService
    {
        public string GetClientTag()
        {
            return "{e9258bd2-e068-4158-8bf2-602696c6d268}";
        }
    }
}