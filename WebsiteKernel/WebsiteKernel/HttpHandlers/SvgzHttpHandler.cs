using System.IO;
using System.Web;

namespace WebsiteKernel.HttpHandlers
{
    public class SvgzHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; } 
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Headers["Content-Encoding"] = "gzip";
            context.Response.BinaryWrite(ImageToByteArray(context.Server.MapPath(context.Request.FilePath)));
            context.Response.ContentType = "image/svg+xml";
        }


        private static byte[] ImageToByteArray(string imagePath)
        {
            byte[] imageByteArray;
                using (var fs = new FileStream( imagePath, FileMode.Open, FileAccess.Read))
                {
                    imageByteArray = new byte[fs.Length];
                    fs.Read(imageByteArray, 0, imageByteArray.Length);
                }

            return imageByteArray;
        }
    }
}
