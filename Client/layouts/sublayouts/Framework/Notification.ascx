<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notification.ascx.cs" Inherits="SitecoreClient.Layouts.sublayouts.Framework.Notification" %>
<asp:Repeater ID="rptNotifications" runat="server" OnItemDataBound="RptNotificationsItemDataBound">
    <ItemTemplate>
        <ul id="ulNotifications" runat="server">
            <asp:Repeater ID="rptNotificationsMessages" runat="server" OnItemDataBound="RptNotificationsMessagesItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:Literal ID="litNotificationMessage" runat="server"></asp:Literal>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </ItemTemplate>
</asp:Repeater>
