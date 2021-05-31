<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="totalcalculationone.ForgotPassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
    <title>Forgot password ? Recover Password By Email Or User Name example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style="width:380px;">
    <legend>Recover Password By Email</legend>
    <table>
   <tr>
      
        <asp:TextBox ID="txtUserName" runat="server" Visible="false"></asp:TextBox>
       
    </tr>
   <%-- <tr>
    <td colspan="2">&nbsp;&nbsp;OR</td>
    </tr>--%>
    <tr>
    <td>Email Id : </td><td>
        <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled"></asp:TextBox><br />
        <asp:RegularExpressionValidator ID="revEmailId" runat="server"
            ErrorMessage="Please enter valid email address"
            ControlToValidate="txtEmail" Display="Dynamic"
            ForeColor="Red" SetFocusOnError="True"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
    <td>&nbsp;</td><td>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
            onclick="btnSubmit_Click" />
        </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </td>
        <td>
            
             <button> <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click" >Login</asp:LinkButton> </button>  
         
        </td>
    </tr>
        
    </table>
    </fieldset>
   
    </div>
    </form>
</body>
</html>
