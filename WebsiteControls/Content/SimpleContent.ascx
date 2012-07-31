<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleContent.ascx.cs" Inherits="WebsiteControls.Content.SimpleContent" %>
<asp:Panel ID="panText" runat="server">
    <p id="pSummary" runat="server">
        <asp:Literal ID="litSummary" runat="server"></asp:Literal>
    </p>
    <asp:Literal ID="litText" runat="server"></asp:Literal>
</asp:Panel>