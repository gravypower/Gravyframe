<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeVariants.ascx.cs" Inherits="WebsiteControls.Content.HomeVariants" %>
<asp:Repeater ID="rptHomeVariants" runat="server" OnItemDataBound="rptHomeVariants_ItemDataBound">
    <ItemTemplate>
        <div id="body_<%# Container.ItemIndex %>" class="<%# Container.ItemIndex != 0 ? "display-none" : "" %>">
            <div runat="server" class="panel hidden">
    	        <asp:PlaceHolder ID="plhOne" runat="server" />
            </div>
            <div runat="server" class="panel hidden">
		        <asp:PlaceHolder ID="plhTwo" runat="server" />
            </div>
            <div runat="server" class="panel hidden">
		        <asp:PlaceHolder ID="plhThree" runat="server" />
		    </div>
            <div runat="server" class="panel hidden">
		        <asp:PlaceHolder ID="plhFour" runat="server" />
		    </div>
            <div runat="server" class="panel hidden">
		        <asp:PlaceHolder ID="plhFive" runat="server" />			
		    </div>
            <div runat="server" class="panel hidden">
		        <asp:PlaceHolder ID="plhSix" runat="server" />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<script>
    var numberOfvariants = <%=NumberOfvariants%>;
</script>
