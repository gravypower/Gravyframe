<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SidebarNavigation.ascx.cs" Inherits="WebsiteControls.Navigation.SidebarNavigation" %>
<%@ Register TagPrefix="igl" TagName="CommonNavigation" Src="CommonNavigation.ascx" %>
<asp:PlaceHolder ID="plhNavSub" runat="server">
    <ul id="nav-sub">
        <igl:CommonNavigation ID="CommonNavigation" runat="Server"></igl:CommonNavigation>
    </ul>
</asp:PlaceHolder>