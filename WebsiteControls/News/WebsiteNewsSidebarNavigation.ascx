<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebsiteNewsSidebarNavigation.ascx.cs" Inherits="WebsiteControls.News.WhiteLabelNewsSidebarNavigation" %>
<%@ Register TagPrefix="igl" TagName="CommonNavigation" Src="~/Navigation/CommonNavigation.ascx" %>
<asp:PlaceHolder ID="plhNavSub" runat="server">
    <ul id="nav-sub">
        <igl:CommonNavigation ID="CommonNavigation" runat="Server"></igl:CommonNavigation>
    </ul>
</asp:PlaceHolder>