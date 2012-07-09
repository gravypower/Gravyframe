<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Articles.ascx.cs" Inherits="UmbracoClient.usercontrols.Articles" %>
<ul>
<asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="RptArticlesItemDataBound">
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="hypArticle" runat="server"></asp:HyperLink>
        </li>
    </ItemTemplate>
</asp:Repeater>


</ul>