<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Advanced_CSharp_Project_3.Register" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server" class="newStyle2">
            <h1>Register as a new user</h1>
        <p>
            <asp:Label ID="ResponseLbl" runat="server"></asp:Label>
        </p>
        <p>
            <input id="usernameInput" placeholder="Username" type="text" runat="server" /></p>
        <p>
            <input id="emailInput" placeholder="Email" type="text" runat="server" /></p>
        <p>
            <input id="passwordInput" placeholder="Password" type="password" runat="server" /></p>
        <asp:Label ID="Securitylbl" runat="server" Text="Security Question: Name of first pet"></asp:Label>
        <p>
        <input id="securityInput" placeholder="Pets name" type="text" runat="server" /></p>
        <p>
        <asp:Button id="registerBtn" runat="server" type="submit" value="Register" OnClick="registerBtn_Click" Text="Register" />
        </p>
    </form>
    </body>
</html>
