using System;
using System.Web;
using Glass.Sitecore.Mapper;
using Sitecore.Web;
using WebsiteKernel.Logging;

namespace SitecoreClient
{
    public class Global : HttpApplication
    {
        private const string WEBSITE = "everyonewins";

        protected void Application_Start(object sender, EventArgs e)
        {
            var loader = new Glass.Sitecore.Mapper.Configuration.Attributes.AttributeConfigurationLoader(
            "BusinessObjects, BusinessObjects");

            var context = new Context(loader);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

//#if DEBUG
//            return;
//#else

            //get the last exception that was thrown
            var exception = Server.GetLastError() as HttpException;

            //if we have an HttpException then we can continue
            if (exception != null)
            {
                var loggerInfo = LoggerFactory.Create().Error("Unhandled Exception", exception);
                //get the error code the error that was thrown
                var errorCode = exception.GetHttpCode();

                //handle 404 or 500 errors
                switch (errorCode)
                {
                    case 500:
                        HandleError500(loggerInfo.ErrorCode);
                        break;
                }
            }

//#endif
        }

        /// <summary>
        /// Handles 500 errors.
        /// </summary>
        private static void HandleError500(string errorCode)
        {
            switch (Sitecore.Context.Site.Name)
            {
                case WEBSITE:
                    WebUtil.Redirect(String.Format("/error?errorCode={0}", errorCode), false);
                    break;
                default:
                    WebUtil.Redirect("/sitecore/service/error.aspx",false);
                    break;
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}