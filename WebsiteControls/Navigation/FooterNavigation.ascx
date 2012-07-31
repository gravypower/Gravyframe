<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterNavigation.ascx.cs" Inherits="WebsiteControls.Navigation.FooterNavigation" %>
<%@ Register TagPrefix="igl" TagName="CommonNavigation" Src="CommonNavigation.ascx" %>
<asp:PlaceHolder ID="plhFooterNavigation" runat="server">
    <ul id="footerNavigation">
        <igl:CommonNavigation ID="CommonNavigation" runat="Server"></igl:CommonNavigation>
    </ul>
</asp:PlaceHolder>