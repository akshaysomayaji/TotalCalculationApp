<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewWithTextBoxes.aspx.cs" Inherits="GridViewWithTextBoxes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
            <asp:TemplateField HeaderText="Header 1">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Header 2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Header 3">
                <ItemTemplate>
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />
                </FooterTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Header 3">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Click Me"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
        <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
