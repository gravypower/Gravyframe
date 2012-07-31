<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebsiteNews.ascx.cs" Inherits="WebsiteControls.News.WhiteLabelNews" %>
<div id="news_entry">
    <h2>
        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
    </h2>
    <p class="date">
        <asp:Literal ID="litDate" runat="server"></asp:Literal>
    </p>

    <p class="image">
        <asp:Image ID="imgNewsImage" runat="server" />
    </p>

    <p class="intro">
        <asp:Literal ID="litSummary" runat="server"></asp:Literal>
    </p>
    <asp:Panel ID="panBody" runat="server">
        <asp:Literal ID="litBody" runat="server"></asp:Literal>
    </asp:Panel>
</div>