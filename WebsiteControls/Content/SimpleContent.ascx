<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleContent.ascx.cs" Inherits="WebsiteControls.Content.SimpleContent" %>

	<div>
    <asp:Image ID="imgfeatureImage" runat="server" />
	<div class="title">
		<h2>
			<asp:Literal ID="litTitle" runat="server"></asp:Literal>
		</h2>
	</div>
    <asp:Panel ID="panText" runat="server" class="body">
        <p id="pSummary" runat="server">
            <asp:Literal ID="litSummary" runat="server"></asp:Literal>
        </p>
        <asp:Literal ID="litText" runat="server"></asp:Literal>
    </asp:Panel>
	</div>
	

<nav class="feature-menu nav">
	<ul>
	 </ul>
</nav>

	<div class="clear"></div>

