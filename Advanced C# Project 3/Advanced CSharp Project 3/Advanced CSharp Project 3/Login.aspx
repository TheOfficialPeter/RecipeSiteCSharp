<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Advanced_CSharp_Project_3.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial;
        }
        .newStyle2 {
            font-family: Arial;
        }
        .newStyle3 {
            font-family: Arial;
        }
        #Submit2 {
            margin-left: 30px;
        }
        #Password1 {
            width: 140px;
        }
        #Text1 {
            width: 138px;
        }
        .newStyle4 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .newStyle5 {
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: underline;
            color: #3399FF;
            cursor: pointer;
        }
        .newStyle6 {
            font-family: Arial, Helvetica, sans-serif;
        }
        #signupBtn {
            margin-left: 27px;
        }
        #loginBtn {
            width: 62px;
        }
        .newStyle7 {
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="newStyle6">
            Login</h1>
        <p>
            <asp:Label ID="infoLbl" runat="server" Text="" CssClass="newStyle7"></asp:Label>
        </p>
        <p>
            <input id="userInput" type="text" runat="server" placeholder="Username" /></p>
        <p>
            <input id="passwordInput" type="password" runat="server" placeholder="Password" /></p>
        <p>
            <asp:Button id="loginBtn" type="submit" runat="server" value="login"  Text="Login" OnClick="loginBtn_Click" />
        </p>
        <p>
            <a href="Register.aspx"><asp:Label ID="forgotPassword0" runat="server" CssClass="newStyle5" Text="New user? Register here"></asp:Label></a>
        </p>
        <p>
            <a href="Forgotpassword.aspx"><asp:Label ID="forgotPassword" runat="server" CssClass="newStyle5" Text="Forgot Password?"></asp:Label></a>
        </p>
        
    </form>
</body>
</html>
