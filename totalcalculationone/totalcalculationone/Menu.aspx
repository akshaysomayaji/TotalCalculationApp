<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="totalcalculationone.DynamicPage" %>

<!DOCTYPE html>

 <html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    
    <style type="text/css">  
        body {  
            background-color: mediumaquamarine;  
            font-family: Arial;  
            font-size: 10pt;  
            color: #444;  
        }  
  
        .ParentMenu, .ParentMenu:hover {  
            width: 100px;  
            background-color: #fff;  
            color: #333;  
            text-align: center;  
            height: 30px;  
            line-height: 30px;  
            margin-right: 5px;  
        }  
  
            .ParentMenu:hover {  
                background-color: #ccc;  
            }  
  
        .ChildMenu, .ChildMenu:hover {  
            width: 110px;  
            background-color: #fff;  
            color: #333;  
            text-align: center;  
            height: 30px;  
            line-height: 30px;  
            margin-top: 5px;  
        }  
  
            .ChildMenu:hover {  
                background-color: #ccc;  
            }  
  
        .selected, .selected:hover {  
            background-color: #A6A6A6 !important;  
            color: #fff;  
        }  
  
        .level2 {  
            background-color: #fff;  
        }  
    </style> 
    <style>button {
    float: right;
    }
    </style>
</head>  
<body>  
    <form id="form1" runat="server">  
        <div>  
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px">  
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <LevelMenuItemStyles>  
                    <asp:MenuItemStyle CssClass="ParentMenu" />  
                    <asp:MenuItemStyle CssClass="ChildMenu" />  
                    <asp:MenuItemStyle CssClass="ChildMenu" />  
                </LevelMenuItemStyles>  
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle CssClass="selected" BackColor="#507CD1" />  
            </asp:Menu>  
          <button> <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click" >Logout</asp:LinkButton> </button>  
        </div>  
    </form>  
</body>  
</html>  
