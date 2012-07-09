using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Logging;

namespace WebsiteKernel.Notifications
{
    public class NotificationInformation
    {
        public NotificationType NotificationType { get; set; }
        public string NotificationText { get; set; }
        public LoggerInformation LoggerInformation { get; set; }
    }
}
