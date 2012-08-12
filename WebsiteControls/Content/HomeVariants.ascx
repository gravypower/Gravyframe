<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeVariants.ascx.cs" Inherits="WebsiteControls.Content.HomeVariants" %>
<asp:Repeater ID="rptHomeVariants" runat="server">
    <ItemTemplate>
        <div id="body_<%# Container.ItemIndex %>" class="display-none">
    	    <asp:Panel ID="panOne" runat="server" CssClass="panel">
            </asp:Panel>
		    <asp:Panel ID="panTwo" runat="server" CssClass="panel">
		    </asp:Panel>
		    <asp:Panel ID="panThree" runat="server" CssClass="panel">
		    </asp:Panel>
		    <asp:Panel ID="panFour" runat="server" CssClass="panel">
		    </asp:Panel>
		    <asp:Panel ID="panFive" runat="server" CssClass="panel">				
		    </asp:Panel>
		    <asp:Panel ID="panSix" runat="server" CssClass="panel">
		    </asp:Panel>
        </div>
    </ItemTemplate>
</asp:Repeater>
