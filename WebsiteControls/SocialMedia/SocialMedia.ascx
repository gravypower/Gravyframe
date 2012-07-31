<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialMedia.ascx.cs" Inherits="WebsiteControls.SocialMedia.SocialMedia" %>
<asp:Panel ID="panSocial" runat="server" CssClass="nav_social">
    <ul>
        <li id="liFacebook" runat="server" visible="false">
            <asp:HyperLink ID="hypFacebook" runat="server">
                <asp:Image ID="imgFacebook" runat="server" />
            </asp:HyperLink>
        </li>

        <li id="liRSS" runat="server" visible="false">
            <asp:HyperLink ID="hypRSS" runat="server">
                <asp:Image ID="imgRSS" runat="server" />
            </asp:HyperLink>
        </li>
    </ul>
</asp:Panel>