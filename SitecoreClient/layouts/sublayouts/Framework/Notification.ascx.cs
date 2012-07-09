using System;
using System.Web.UI.WebControls;
using WebsiteKernel.Notifications;

namespace SitecoreClient.Layouts.sublayouts.Framework
{
    public partial class Notification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            rptNotifications.DataSource = Enum.GetNames(typeof(NotificationType));
            rptNotifications.DataBind();

        }

        protected void RptNotificationsItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var notificationType = e.Item.DataItem as string;

                var ulNotifications = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("ulNotifications");
                ulNotifications.Attributes.Add("class", notificationType);

                var rptNotificationsMessages = (Repeater) e.Item.FindControl("rptNotificationsMessages");
                if (notificationType != null)
                {
                    rptNotificationsMessages.DataSource =
                        WebsiteKernel.Notifications.Notification.GetNotificationInformationList(
                            (NotificationType) Enum.Parse(typeof (NotificationType), notificationType));

                    rptNotificationsMessages.DataBind();
                }
            }
        }

        protected void RptNotificationsMessagesItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var notificationInformation = (NotificationInformation) e.Item.DataItem;

                var litNotificationMessage = (Literal) e.Item.FindControl("litNotificationMessage");
                if(notificationInformation.NotificationType ==NotificationType.ErrorCode )
                {
                    litNotificationMessage.Text = String.Format("{0}- {1}",
                                                                notificationInformation.LoggerInformation.ErrorCode,
                                                                notificationInformation.NotificationText);
                }
                else
                {
                    litNotificationMessage.Text = String.Format("{0}",notificationInformation.NotificationText); 
                }
            }
        }
    }
}