<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery.ascx.cs" Inherits="WebsiteControls.Content.Gallery" %>
<div id="container">
    <asp:Repeater ID="galleryRepeater" runat="server" OnItemDataBound="galleryRepeater_ItemDataBound">
    <ItemTemplate>
        <div class="galleryImage">
            <asp:Image ID="galleryImage" runat="server" />
        </div>
    </ItemTemplate>
    </asp:Repeater>
</div>