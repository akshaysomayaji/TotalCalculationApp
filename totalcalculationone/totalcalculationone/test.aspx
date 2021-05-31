<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="totalcalculationone.test" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="totalcalculationone.DMSDatabaseDataSet22TableAdapters.tblQuotationTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_QuotationId" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="QuotationNumber" Type="String" />
                <asp:Parameter Name="intCustomerId" Type="Int64" />
                <asp:Parameter Name="intShipperId" Type="Int64" />
                <asp:Parameter Name="intConsigneeId" Type="Int64" />
                <asp:Parameter Name="intDepartureId" Type="Int64" />
                <asp:Parameter Name="intDestinationId" Type="Int64" />
                <asp:Parameter Name="intDeliveryTo" Type="Int64" />
                <asp:Parameter Name="NoofPackages" Type="Int32" />
                <asp:Parameter Name="IncoTermsId" Type="Int64" />
                <asp:Parameter Name="Commodity" Type="String" />
                <asp:Parameter Name="ActualWeight" Type="Double" />
                <asp:Parameter Name="ChargeableWeight" Type="Double" />
                <asp:Parameter Name="QuotationDate" Type="DateTime" />
                <asp:Parameter Name="KWERefNo" Type="String" />
                <asp:Parameter Name="UserId" Type="String" />
                <asp:Parameter Name="Validity" Type="DateTime" />
                <asp:Parameter Name="POL" Type="Int64" />
                <asp:Parameter Name="POU" Type="Int64" />
                <asp:Parameter Name="ServiceType" Type="String" />
                <asp:Parameter Name="MovementTypeId" Type="Int64" />
                <asp:Parameter Name="DimensionId" Type="Int64" />
                <asp:Parameter Name="flgActive" Type="Boolean" />
                <asp:Parameter Name="dtAddedOn" Type="DateTime" />
                <asp:Parameter Name="intAddedBy" Type="Int64" />
                <asp:Parameter Name="dtModifiedOn" Type="DateTime" />
                <asp:Parameter Name="intModifiedBy" Type="Int64" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="QuotationNumber" Type="String" />
                <asp:Parameter Name="intCustomerId" Type="Int64" />
                <asp:Parameter Name="intShipperId" Type="Int64" />
                <asp:Parameter Name="intConsigneeId" Type="Int64" />
                <asp:Parameter Name="intDepartureId" Type="Int64" />
                <asp:Parameter Name="intDestinationId" Type="Int64" />
                <asp:Parameter Name="intDeliveryTo" Type="Int64" />
                <asp:Parameter Name="NoofPackages" Type="Int32" />
                <asp:Parameter Name="IncoTermsId" Type="Int64" />
                <asp:Parameter Name="Commodity" Type="String" />
                <asp:Parameter Name="ActualWeight" Type="Double" />
                <asp:Parameter Name="ChargeableWeight" Type="Double" />
                <asp:Parameter Name="QuotationDate" Type="DateTime" />
                <asp:Parameter Name="KWERefNo" Type="String" />
                <asp:Parameter Name="UserId" Type="String" />
                <asp:Parameter Name="Validity" Type="DateTime" />
                <asp:Parameter Name="POL" Type="Int64" />
                <asp:Parameter Name="POU" Type="Int64" />
                <asp:Parameter Name="ServiceType" Type="String" />
                <asp:Parameter Name="MovementTypeId" Type="Int64" />
                <asp:Parameter Name="DimensionId" Type="Int64" />
                <asp:Parameter Name="flgActive" Type="Boolean" />
                <asp:Parameter Name="dtAddedOn" Type="DateTime" />
                <asp:Parameter Name="intAddedBy" Type="Int64" />
                <asp:Parameter Name="dtModifiedOn" Type="DateTime" />
                <asp:Parameter Name="intModifiedBy" Type="Int64" />
                <asp:Parameter Name="Original_QuotationId" Type="Int64" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" OnInit="CrystalReportViewer1_Init" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Quotation.rpt">
            </Report>
        </CR:CrystalReportSource>
         
    </form>
</body>
</html>
