<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Advanced_CSharp_Project_3.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial;
        }
        .newStyle2 {
            font-family: Calibri;
        }
        .newStyle3 {
            font-family: Calibri;
        }
        .newStyle4 {
            font-size: 20px;
        }
        .newStyle5 {
            font-family: Calibri;
            font-size: 20px;
        }
        .auto-style1 {
            margin-left: 21px;
        }
        #recipeMethodLbl {
            height: 79px;
            width: 231px;
        }
        #recipeIngredientLbl {
            height: 77px;
            width: 226px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="newStyle1">Recipes</h1>
        <p>
            <asp:Label ID="ResponseLbl" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" CssClass="newStyle5" Text="Add recipe form"></asp:Label>
        </p>
        <p>
            <input id="recipeNameInput" type="text" runat="server" placeholder="Recipe name" /></p>
        <p>
            <asp:TextBox id="recipeIngredientLbl" TextMode="MultiLine" runat="server" placeholder="Recipe Ingredients"/></p>
        <p>
            <asp:TextBox id="recipeMethodLbl" TextMode="MultiLine" runat="server" placeholder="Recipe Methods" /></p>
        <asp:Button runat="server" Text="Add recipe" id="addRecipeBtn" type="submit" value="Add Recipe" OnClick="addRecipeBtn_Click" />
        <p>
            <input ID="viewRecipeInput" placeholder="Recipe Number" runat="server"></input>
            <asp:Button runat="server" Text="View recipe" id="viewRecipeBtn" type="submit" value="View Recipe" OnClick="viewRecipe_OnClick" CssClass="auto-style1" />
        </p>
        <hr />
        <asp:GridView ID="recipeList" runat="server" AutoGenerateColumns="False" CellPadding="10" CssClass="newStyle2" GridLines="Vertical" DataKeyNames="recipeNum" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField HeaderText="recipeNum" DataField="recipeNum" ReadOnly="True" SortExpression="recipeNum" />
                <asp:BoundField HeaderText="recipeName" DataField="recipeName" SortExpression="recipeName" />
                <asp:BoundField DataField="recipeRating" HeaderText="recipeRating" SortExpression="recipeRating" />
                <asp:BoundField DataField="recipeOwner" HeaderText="recipeOwner" SortExpression="recipeOwner" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecipesConnectionString %>" SelectCommand="SELECT * FROM [Recipes]"></asp:SqlDataSource>
    </form>
</body>
</html>
