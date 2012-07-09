using System.Collections.Generic;
using System.Web;
using System.Linq;
using WebsiteKernel.Logging;

namespace WebsiteKernel.Notifications
{
    public class Notification
    {
        public static NotificationInformation AddNotification(string notificationText, NotificationType notificationType)
        {
            var notificationInformationList = GetNotificationInformationList().ToList();

            var notificationInformation = new NotificationInformation
                                              {NotificationType = notificationType, NotificationText = notificationText};

            notificationInformationList.Add(notificationInformation);
            return notificationInformation;
        }

        public static NotificationInformation AddLoggerInformationNotification(string notificationText, LoggerInformation loggerInformation)
        {
            var notificationInformation = AddNotification(notificationText, NotificationType.ErrorCode);
            notificationInformation.LoggerInformation = loggerInformation;

            return notificationInformation;
        }
        
        public static IEnumerable<NotificationInformation> GetNotificationInformationList()
        {
            var notificationInformationList = (List<NotificationInformation>)HttpContext.Current.Items["NotificationInformationList"];

            if (notificationInformationList == null)
            {
                notificationInformationList = new List<NotificationInformation>();

                HttpContext.Current.Items.Add("LoggerInformationList", notificationInformationList);
            }

            return notificationInformationList;
        }

         public static IEnumerable<NotificationInformation> GetNotificationInformationList(NotificationType notificationType)
         {
             return GetNotificationInformationList().Where(x => x.NotificationType == notificationType);
         }
    }
}
