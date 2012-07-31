<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonNavigation.ascx.cs" Inherits="WebsiteControls.Navigation.CommonNavigation" %>
<asp:Repeater ID="rptMianNavigation" runat="server" OnItemDataBound="RptMianNavigationItemDataBound">
    <ItemTemplate>
        <li id="liNavItem" runat="server">
            <asp:HyperLink ID="hypNavItem" runat="server">
                <asp:Image ID="imgNavItem" runat="server" />
            </asp:HyperLink>
        </li>
    </ItemTemplate>
</asp:Repeater>