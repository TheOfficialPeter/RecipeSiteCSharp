<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipe.aspx.cs" Inherits="Advanced_CSharp_Project_3.ViewRecipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
        <asp:Label ID="recipeTitleLbl" runat="server" Text="Recipe Title here"></asp:Label>
            </h1>
        </div>
        <asp:Label ID="recipeIngredientsLbl" runat="server" Text="Recipe Ingredients"></asp:Label>
        <br />
        <br />
        <asp:Label ID="recipeMethodLbl" runat="server" TextMode="MultiLine" multiline="true" Text="Recipe Method here"></asp:Label>
        <p>
            <asp:TextBox ID="rateInput" runat="server"></asp:TextBox>
            <asp:Button ID="rateBtn" runat="server" CssClass="auto-style1" Text="Rate Recipe" OnClick="rateBtn_OnClick" />
        </p>
    </form>
</body>
</html>
