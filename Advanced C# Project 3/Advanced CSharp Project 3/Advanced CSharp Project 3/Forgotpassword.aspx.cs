using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advanced_CSharp_Project_3.ServiceReference1;

namespace Advanced_CSharp_Project_3
{
    public partial class Forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void verifyBtn_Click(object sender, EventArgs e)
        {
            if (passwordInput.Value == "" || repeatPasswordInput.Value == "" || emailInput.Value == "" || securityInput.Value == "")
            {
                responseMessage.Text = "Please fill in all fields";
            }
            else
            {
                if (passwordInput.Value != repeatPasswordInput.Value)
                {
                    responseMessage.Text = "The given passwords do not match!";
                }
                else
                {
                    // Check for info in database then give response
                    WebService1SoapClient web = new WebService1SoapClient();
                    if (web.validateUserWithSecurity(emailInput.Value, securityInput.Value) == true)
                    {
                        web.resetPassword(emailInput.Value, securityInput.Value, passwordInput.Value);
                        Response.Redirect("./Login.aspx");
                    }
                    else
                    {
                        responseMessage.Text = "Failed to reset password!";
                    }
                }
            }
        }
    }
}