<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="WebsiteControls.Content.Gallery" %>
<div id="container" class="photos">
    <asp:Repeater ID="galleryRepeater" runat="server" OnItemDataBound="galleryRepeater_ItemDataBound">
    <ItemTemplate>
        <asp:panel ID="photPanel" runat="server" CssClass="photo">
            <asp:Image ID="galleryImage" runat="server" />
        </asp:panel>
    </ItemTemplate>
    </asp:Repeater>
</div>