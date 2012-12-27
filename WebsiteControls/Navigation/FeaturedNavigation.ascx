<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedNavigation.ascx.cs" Inherits="WebsiteControls.Navigation.FeaturedNavigation" %>
<asp:PlaceHolder ID="plhNavigation" runat="server">
    <nav class="feature-menu nav">
        <ul>
            <asp:Repeater ID="rptFeaturedNavigation" runat="server" OnItemDataBound="rptFeaturedNavigation_ItemDataBound">
                <ItemTemplate>   
                    <li>
                        <asp:HyperLink ID="hypFeaturedNavigationItem" runat="server">
                            <div class="nav-image">
							    <asp:Panel id="panVisibleImage" runat="server" CssClass="visible-image" style="width:250px; height: 80px;  background-position: 0 0;">
							    </asp:Panel>
                                <div class="title">
                                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                </div>
							    <asp:Panel id="panAppearingImage" runat="server" class="appearing-image" style="display:none; width:250px; height: 80px; background-position: 250px 0; position:relative; top: -80px;">
							    </asp:Panel>
						    </div>
                        </asp:HyperLink>
			        </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </nav>
</asp:PlaceHolder>
