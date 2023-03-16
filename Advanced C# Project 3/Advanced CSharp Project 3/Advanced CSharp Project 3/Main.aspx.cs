using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advanced_CSharp_Project_3.ServiceReference1;

namespace Advanced_CSharp_Project_3
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                Response.Redirect("./Login.aspx");
            }
        }

        public bool validateUser()
        {
            return true;
        }

        protected void addRecipeBtn_Click(object sender, EventArgs e)
        {
            WebService1SoapClient web = new WebService1SoapClient();

            if (string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                ResponseLbl.Text = "Failed to validate user. Please log in again!";
            }
            else
            {
                if (recipeIngredientLbl.Text == "" || recipeMethodLbl.Text == "")
                {
                    ResponseLbl.Text = "Some fields are empty";
                }
                else
                {
                    ResponseLbl.Text = "";
                    if (web.addRecipe(recipeNameInput.Value, Request.QueryString["name"], recipeIngredientLbl.Text, recipeMethodLbl.Text) == true)
                    {
                        Response.Redirect("./Main.aspx?name=" + Request.QueryString["name"]);
                    }

                }
            }
        }

        protected void viewRecipe_OnClick(object sender, EventArgs e)
        {
            if (viewRecipeInput.Value == "")
            {
                ResponseLbl.Text = "Please provide the recipe number to view the recipe";
            }
            else
            {
                Response.Redirect("./ViewRecipe.aspx?id=" + viewRecipeInput.Value);
            }
        }
    }
}