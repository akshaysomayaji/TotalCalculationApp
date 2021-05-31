<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreightReportNew.aspx.cs" Inherits="totalcalculationone.FreightReportNew" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="crystalreportviewers13/js/crviewer/crv.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <CR:CrystalReportViewer ID="FreightRep" runat="server" AutoDataBind="true" />
       <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal">
     <%--   <asp:ListItem Text="Word" Value="Word" Selected="True" />
        <asp:ListItem Text="Excel" Value="Excel" />--%>
        <asp:ListItem Text="PDF" Value="PDF" />
        <%--<asp:ListItem Text="CSV" Value="CSV" />--%>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btnExport" Text="Export" runat="server" OnClick="Export" />
    </form>
</body>
</html>
