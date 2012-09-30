<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Accordion.ascx.cs" Inherits="WebsiteControls.Content.Accordion" %>

<div id="accordion">
    <asp:Repeater ID="accordionRepeater" runat="server" OnItemDataBound="accordionRepeater_ItemDataBound">
        <ItemTemplate>
            <h3><asp:HyperLink ID="accordionSectionHyperLink" runat="server" NavigateUrl="#"></asp:HyperLink></h3>
	        <div>
		        <asp:Literal ID="accordionTextLiteral" runat="server"></asp:Literal>
	        </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

<script>
    $(function () {
        $("#accordion").accordion();
    });
</script>
