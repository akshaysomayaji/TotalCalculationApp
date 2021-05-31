<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotationNew.aspx.cs" Inherits="totalcalculationone.QuotationNew" %>

<!DOCTYPE html>

<html  
    xmlns="http://www.w3.org/1999/xhtml">  
    <head runat="server">  
        <title></title>  
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>  
        <script src="js/bootstrap.min.js"></script>  
        <link href="css/bootstrap.min.css" rel="stylesheet" />  
    </head>  
    <body>  
        <form id="form1" runat="server">  
            <div class="container">  
                <div class="row">  
                    <div class="col-lg-3"></div>  
                    <div class="col-lg-6">  
                        <form class="form-signin">  
                            <h2 class="form-signin-heading">Please sign in</h2>  
                            <label for="inputEmail" class="sr-only">Email address</label>  
                            <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus>  
                                <label for="inputPassword" class="sr-only">Password</label>  
                                <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>  
                                    <div class="checkbox">  
                                        <label>  
                                            <input type="checkbox" value="remember-me">    
                                                Remember me   
                                        </label>  
                                    </div>  
                                <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>  
                        </form>  
                    </div>  
                    <div class="col-lg-3"></div>  
                </div>  
            </div>  
        </form>  
    </body>  
</html>   
