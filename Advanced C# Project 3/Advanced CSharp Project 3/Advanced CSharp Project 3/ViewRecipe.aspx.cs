using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advanced_CSharp_Project_3.ServiceReference1;

namespace Advanced_CSharp_Project_3
{
    public partial class ViewRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1SoapClient web = new WebService1SoapClient();
            recipeTitleLbl.Text =  web.getRecipeTitle(Request.QueryString["id"]);
            recipeIngredientsLbl.Text = web.getRecipeIngredients(Request.QueryString["id"]);
            recipeMethodLbl.Text = web.getRecipeMethod(Request.QueryString["id"]);
        }

        protected void rateBtn_OnClick(object sender, EventArgs e)
        {
            WebService1SoapClient web = new WebService1SoapClient();
            web.rateRecipe(Request.QueryString["id"], Int32.Parse(rateInput.Text));
        }
    }
}