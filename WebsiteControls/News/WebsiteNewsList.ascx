<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebsiteNewsList.ascx.cs" Inherits="WebsiteControls.News.WhiteLabelNewsList" %>
<div id="listing">
    <asp:Repeater ID="rptNewsListing" runat="server" OnItemDataBound="RptNewsListingItemDataBound">
        <ItemTemplate>
            <div class="item">
                <h2>
                    <asp:HyperLink ID="hypNewsTitle" runat="server"></asp:HyperLink>
                </h2>
                <p class="date">
                    <asp:Literal ID="litNewsDate" runat="server"></asp:Literal>
                </p>

                <p class="image">
                    <asp:Image ID="imgNewsImage" runat="server" />
                </p>

                <p class="intro">
                    <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                </p>

                <p class="more">
                    <asp:HyperLink ID="hypMoreLink" runat="server" Text="Read more"></asp:HyperLink>
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>