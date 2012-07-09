<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitecoreClient.Layouts.Default" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Google Analytics -->
	<script type="text/javascript">	    
	    var _gaq = [['_setAccount', '<%= AnalyticsAccount %>'], ['_trackPageview']];
	    (function(d, t) {
	        var g = d.createElement(t), s = d.getElementsByTagName(t)[0];
	        g.src = '//www.google-analytics.com/ga.js';
	        s.parentNode.insertBefore(g, s);
	    }(document, 'script')
	    );
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="panNotification" runat="server"></asp:Panel>
        <sc:placeholder ID="Placeholder1" key="main" runat="server" />
    </div>
    </form>
</body>
</html>
