<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="totalcalculationone.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("[id*=txtDate]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'images/calendar.png'
        });
    });
</script>
    <script type="text/javascript">
    $(function () {
        $("[id*=textdatevalidity]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'images/calendar.png'
        });
    });
</script>--%>
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
        .auto-style1 {
            width: 1015px;
            height: 31px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

         <div></div>
    <div>
        <label style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: large; font-weight: bold">QUOTATION </label>
    </div>
    <div></div>
    
             <table class="auto-style1">
                 <tr>
                     <td>
                           
            <asp:Panel ID="Panel1" runat="server" Height="24px">

                <asp:Label ID="Label2" runat="server" Text="Customer"></asp:Label>

                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" style="text-align: center" Width="274px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true">
                </asp:TextBox>
                <img src="images/calendar.png" />
            
              
            </asp:Panel>  
                     </td>
                 </tr>
             </table>
          
            <div style="float:right"></div>
            
             <table>

            <tr>
                <td>
                     <asp:Panel ID="Panel2" runat="server">

                <asp:Label ID="Label3" runat="server" Text="Shipper"></asp:Label>

                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:DropDownList ID="DropDownList2" runat="server" Height="21px" style="text-align: center" Width="281px">
                         </asp:DropDownList>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Login User&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="TextBox12" runat="server" ReadOnly="true"></asp:TextBox>
             </asp:Panel>
                </td>
            </tr>
           
               

                  </table>
             <table>
                 <tr>
                     <td>
                            <asp:Panel ID="Panel3" runat="server">

                <asp:Label ID="Label4" runat="server" Text="Consignee"></asp:Label>

                                &nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList3" runat="server" Height="23px" style="text-align: center" Width="279px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="Label13" runat="server" Text=" KWE Ref No"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                      <asp:TextBox ID="TextBox9" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            
            </asp:Panel>
                     </td>
                 </tr>
             </table>
               
       
         <table>
             <tr>
                 <td>
                 <asp:Panel ID="Panel4" runat="server">

                <asp:Label ID="Label5" runat="server" Text="Departure"></asp:Label>

                     &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" style="text-align: center" Width="283px">
                     </asp:DropDownList>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" Text="Validity"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      <asp:TextBox ID="textdatevalidity" runat="server" ReadOnly = "true"></asp:TextBox>
                    <img src="images/calendar.png" />
            
            </asp:Panel>
                 </td>
             </tr>
         </table>
            <table>
                <tr>
                    <td>
             <asp:Panel ID="Panel5" runat="server">

                <asp:Label ID="Label6" runat="server" Text="Destination"></asp:Label>

            &nbsp;
                 <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="282px">
                 </asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label15" runat="server" Text="POL"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList11" runat="server" Height="16px" Width="195px">
                    </asp:DropDownList>
            
            </asp:Panel>
                    </td>
                </tr>
            </table>
              <table>
                  <tr>
                      <td>
                             <asp:Panel ID="Panel6" runat="server">

                <asp:Label ID="Label7" runat="server" Text="Delivery To"></asp:Label>

                                 &nbsp;&nbsp;
                                 <asp:DropDownList ID="DropDownList6" runat="server" Height="19px" Width="283px">
                                 </asp:DropDownList>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" Text="POU"></asp:Label>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:DropDownList ID="DropDownList12" runat="server" Height="16px" Width="199px">
                      </asp:DropDownList>
                      &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</asp:Panel>
                      </td>
                  </tr>
              </table>
               <table>
                   <tr>
                       <td>
                             <asp:Panel ID="Panel7" runat="server">

                <asp:Label ID="Label1" runat="server" Text="No of Packages" ></asp:Label>
                       &nbsp;&nbsp;<asp:TextBox ID="txtnoofpackages" AutoCompleteType="Disabled"  runat="server"></asp:TextBox>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Text="Service Type"></asp:Label>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox10" runat="server" Height="17px" AutoCompleteType="Disabled" Width="172px"></asp:TextBox>
           
            </asp:Panel>
                       </td>
                   </tr>
               </table>
                 <table>
                     <tr>
                         <td class="auto-style1">
 <asp:Panel ID="Panel8" runat="server" Height="27px" Width="1024px">

                <asp:Label ID="Label8" runat="server" Text="Inco Terms"></asp:Label>
                       &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList10" runat="server" Height="19px" Width="260px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label18" runat="server" Text="Movement Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:DropDownList ID="DropDownList13" runat="server" Height="22px" Width="199px"></asp:DropDownList>
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            </asp:Panel>
                         </td>
                     </tr>
                 </table>
                 <table>
                     <tr>
                         <td>
    <asp:Panel ID="Panel9" runat="server" Height="37px">

                <asp:Label ID="Label9" runat="server" Text="Commodity"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="139px"></asp:TextBox>
           
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Actual Weight"></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Panel ID="Panel10" runat="server" style="margin-top: 38px">
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</asp:Panel>
           
            </asp:Panel>
                 <asp:Panel ID="Panel11" runat="server">

                <asp:Label ID="Label11" runat="server" Text="Chargeable Weight"></asp:Label>
                        <asp:TextBox ID="TextBox3" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
           
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Label ID="Label20" runat="server" Text="Dimension (UOM)"></asp:Label>
           
                     &nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="DropDownList14" runat="server" Height="22px" Width="199px">
                     </asp:DropDownList>
           
            </asp:Panel>
                         </td>
                     </tr>
                 </table>
           
            
      
    
       <div></div>
             <div></div>
             <div></div>
         <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="True" OnRowDataBound="Gridview1_RowDataBound"  EnableViewState="true">
        <Columns>
            <%--<asp:BoundField DataField="Item" HeaderText="Item" />--%>
            <asp:BoundField DataField="SlNo" HeaderText="Sl No." />
            <asp:TemplateField HeaderText="Charges Description">
                <ItemTemplate>
                   <asp:DropDownList ID="DropDownList7" runat="server" Height="17px" Width="220px"></asp:DropDownList>
                </ItemTemplate>
                
            </asp:TemplateField>
       
                      <asp:TemplateField HeaderText="UOM">
                <ItemTemplate>
                   <asp:DropDownList ID="DropDownList8" runat="server" Height="17px" Width="90px"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Currency">
                <ItemTemplate>
                     <asp:DropDownList ID="DropDownList9" runat="server" Height="17px" Width="145px"></asp:DropDownList>
                </ItemTemplate>
              
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cost">
                <ItemTemplate>
                    <asp:TextBox ID="txtcost" AutoCompleteType="Disabled" Width="90px"  runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
              <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice"  AutoCompleteType="Disabled"  runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity"  AutoCompleteType="Disabled"  runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="lblTotal" runat="server"  Text='<%#Eval("Total")%>'></asp:Label>                     
                   <%-- <asp:TextBox ID="txttotal"  AutoCompleteType="Disabled"  runat="server"></asp:TextBox>--%>
                </ItemTemplate>
               <FooterTemplate>
                            <asp:Label ID="Label19" Width="90px" runat="server" Text="Grand Total"></asp:Label>
                             <asp:Label ID="lblGrandTotal" runat="server" Text="0"></asp:Label>
                  <%-- <asp:TextBox ID="txtgrandtotal"  AutoCompleteType="Disabled"  runat="server"></asp:TextBox>--%>
                        
                        </FooterTemplate>
            </asp:TemplateField>

                      <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox7" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                          <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row"
                              OnClick="ButtonAdd_Click" />
                      </FooterTemplate>
            </asp:TemplateField>
                    
        </Columns>
    </asp:GridView>
    <br />
      <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />
                <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" />

 <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
          <script type="text/javascript">
              $(function () {
                   //$("[id*=txtQuantity").val("0");
                });
                $(document).on("change keyup", "[id*=txtPrice]", function () {
                  if (isNaN(parseInt($(this).val()))) {
                    $(this).val('0');
                  } else {
                    $(this).val(parseInt($(this).val()).toString());
                  }
                });
                $(document).on("keyup mouseup", "[id*=txtQuantity]", function () {
                  if (!jQuery.trim($(this).val()) == '') {
                    if (!isNaN(parseFloat($(this).val()))) {
                      var row = $(this).closest("tr");
                      $("[id*=lblTotal]", row).html(parseFloat($("[id*=txtPrice]", row).val()) * parseFloat($(this).val()));
                    }
                  } else {
                    $(this).val('');
                  }
                  var grandTotal = 0;
                  $("[id*=lblTotal]").each(function () {
                    var value = $(this).html();
                    if(value != "")
                      grandTotal = grandTotal + parseFloat(value);
                  });
                  $("[id*=lblGrandTotal]").html(grandTotal.toString());
                });
    </script>

             
        <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=textdatevalidity.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d-%m-%y",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>

             <script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d-%m-%y",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>
             </div>
    </form>
</body>
</html>

