<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNavigation.ascx.cs" Inherits="WebsiteControls.Navigation.MainNavigation" %>
<%@ Register TagPrefix="igl" TagName="CommonNavigation" Src="CommonNavigation.ascx" %>
<asp:PlaceHolder ID="plhMainNavigation" runat="server">
    <ul id="mainNavigation">
        <igl:CommonNavigation ID="CommonNavigation" runat="Server"></igl:CommonNavigation>
    </ul>
</asp:PlaceHolder>