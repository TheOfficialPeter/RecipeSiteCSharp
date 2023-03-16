<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgotpassword.aspx.cs" Inherits="Advanced_CSharp_Project_3.Forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .newStyle2 {
            font-family: Arial;
        }
        .newStyle3 {
            font-family: Arial;
        }
        .newStyle4 {
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="newStyle2">Change password</h1>
    <h4 class="newStyle3">Please provide your email and your security question answer so that we can verifiy that it is you</h4>
    <p>
        <asp:Label ID="responseMessage" runat="server" CssClass="newStyle4"></asp:Label>
        </p>
    <p>
        <input id="emailInput" placeholder="Email" type="text" runat="server" aria-required="True" /></p>
    <p>
        <input id="securityInput" placeholder="Name of first pet" runat="server" type="text" aria-required="True" /></p>
    <p>
        <input id="passwordInput" placeholder="New password" runat="server" type="password" aria-required="True" /></p>
    <p>
        <input id="repeatPasswordInput" runat="server" placeholder="Repeat password" type="password" aria-required="True" /></p>
        <p>
        <asp:Button id="verifyBtn" runat="server" type="submit" value="Change password" OnClick="verifyBtn_Click" Text="Change Password" />
        </p>
    </form>
</body>
</html>
