<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OneColumn.aspx.cs" Inherits="SitecoreClient.Layouts.OneColumn" %>
<%@ Register Assembly="WebsiteControls" Namespace="WebsiteControls.Navigation" TagPrefix="Gravy" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="header">               
                <asp:Panel id="panMainNavigation" runat="server">
                    <Gravy:MainNavigation ID="mainNavigation" runat="server" />
                </asp:Panel>
            </div>
            <div id="page">
                <h2>
                     <asp:Literal ID="litPageTitle" runat="server"></asp:Literal>
                </h2>
                <div id="sidebar">
                    <Gravy:SidebarNavigation ID="sidebarNavigation" runat="server" />
                    <sc:placeholder ID="plaSidebarNavigation"  key="SidebarNavigation" runat="server" />
                </div>
                <sc:placeholder key="main" runat="server" />
            </div>
            <div id="footer">
                <sc:placeholder key="footer" runat="server" />
                 <asp:Panel id="panFooterNavigation" runat="server">
                    <Gravy:FooterNavigation ID="footerNavigation" runat="server" />
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
