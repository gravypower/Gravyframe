using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Logging.Implementations;

namespace WebsiteKernel.Logging
{
    public class LoggerFactory
    {
        public static Logger Create()
        {
            return new SitrecoreLogging();
        }
    }
}
