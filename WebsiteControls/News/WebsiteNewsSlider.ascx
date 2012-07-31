<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebsiteNewsSlider.ascx.cs" Inherits="WebsiteControls.News.WhiteLabelNewsSlider" %>

<div class="carousel" id="content">
    <div id="hero">
        <asp:HyperLink ID="hylNews" runat="server" CssClass="featured clearfix">
            <div class="img">
                <asp:Image ID="imgNews" runat="server" CssClass="float-left" />
            </div>
            <ul class="detail no-list">
                <li class="pagination"><asp:Literal id="litArticleNumber" runat="server"></asp:Literal> of <asp:Literal id="litArticleCount" runat="server"></asp:Literal></li>
                <li class="title"><asp:Literal ID="litNewsTitle" runat="server"></asp:Literal></li>
                <li class="excerpt"><asp:Literal ID="litIntroduction" runat="server"></asp:Literal></li>
            </ul>
        </asp:HyperLink>
    </div>
    <div class="nav yui-carousel-visible yui-carousel-horizontal yui-carousel" id="yui-carousel">
        <ul class="thumbnails no-list clearfix">
            <asp:Repeater ID="repCarousel" runat="server" OnItemDataBound="RepCarouselOnItemDatabound">
                <ItemTemplate>
                    <li class="thumbnail">
                        <asp:HyperLink ID="hylNews" runat="server">
                            <span class="overlay"></span>
                            <asp:Image ID="imgNews" runat="server"/>
                            <p class="title visuallyhidden"><asp:Literal ID="litNewsTitle" runat="server" /></p>
                            <p class="description"><asp:Literal ID="litIntroduction" runat="server"></asp:Literal></p>
                        </asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <asp:HyperLink ID="hypPrevious" runat="server" CssClass="ir arrow arrow-left yui-carousel-first-button-disabled" Visible="false" >Previous</asp:HyperLink>
    <asp:HyperLink ID="hypNext" runat="server" CssClass="ir arrow arrow-right" Visible="false">Next</asp:HyperLink>
</div>