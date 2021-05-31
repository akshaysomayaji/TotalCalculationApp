<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="totalcalculationone.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
</head>
<body style="height: 249px">
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="ResetPwdPanel" runat="server" Visible="false" >
    <fieldset style="width:400px">
    <legend>Reset Password</legend>   
    <table>
    <tr>
    <td>New password: </td><td>
        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvNewPwd" runat="server"
            ControlToValidate="txtNewPwd" Display="Dynamic"
            ErrorMessage="Please enter new password" ForeColor="Red" SetFocusOnError="false"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td>Confirm Passsword: </td><td>
        <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvConfirmPwd" runat="server"
            ControlToValidate="txtConfirmPwd" Display="Static"
            ErrorMessage="Please re-enter password to confirm" ForeColor="Red"
            SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmvConfirmPwd" runat="server"
            ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPwd"
            Display="Dynamic" ErrorMessage="Password didn't match" ForeColor="Red"
            SetFocusOnError="True"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
    <td>
        &nbsp;</td><td>
        <asp:Button ID="btnChangePwd" runat="server" Text="Change Password"
                onclick="btnChangePwd_Click" /></td>
    </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </fieldset>       
    </asp:Panel>
    <asp:Label ID="lblExpired" runat="server" Text="" style="color: #FF0000"></asp:Label>
    </div>
      <table>
          <tr>
              <td>
                   <asp:HyperLink ID="lnkHome" NavigateUrl="~/Login.aspx" CssClass="text-primary btn-link"  runat="server">Login</asp:HyperLink>
              </td>
          </tr>
      </table>
        
    </form>
</body>
</html>
