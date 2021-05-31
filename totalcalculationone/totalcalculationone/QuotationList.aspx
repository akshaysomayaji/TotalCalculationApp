

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotationList.aspx.cs" Inherits="totalcalculationone.QuotationList" %>

 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="grdQuotationList" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdQuotationList_PageIndexChanging">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
           <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>
        <asp:BoundField ItemStyle-Width="150px" DataField="QuotationNumber" HeaderText="KWE Ref No." >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        
     <%--   <asp:BoundField ItemStyle-Width="150px" DataField="KWERefNo" HeaderText="KWE Ref No" >
       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>--%>
       
        <asp:BoundField ItemStyle-Width="150px" DataField="Validity" HeaderText="Validity" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="QuotationDate" HeaderText="Quotation Date" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="grandTotal" HeaderText="Grand Total" >
        
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:HyperLinkField
            DataNavigateUrlFields="QuotationNumber"
            DataNavigateUrlFormatString="~\FreightReportNew.aspx?QuotationNumber={0}"
            HeaderText="Quotation Report"
            Text="Report" />
         <asp:HyperLinkField
            DataNavigateUrlFields="QuotationNumber"
            DataNavigateUrlFormatString="~\EditQuotation.aspx?QuotationNumber={0}"
            HeaderText="Edit"
            Text="Edit" />
    </Columns>
                 <EditRowStyle BackColor="#999999" />
                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#E9E7E2" />
                 <SortedAscendingHeaderStyle BackColor="#506C8C" />
                 <SortedDescendingCellStyle BackColor="#FFFDF8" />
                 <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                 
</asp:GridView>
            <asp:HyperLink ID="lnkHome" NavigateUrl="~/Menu.aspx" CssClass="text-primary btn-link"  runat="server">Home</asp:HyperLink>
        </div>
        <%-- <asp:Button ID="btnShow" Text="Show in Report" runat="server" OnClick="btnShow_Click"  />--%>
    </form>
</body>
</html>
