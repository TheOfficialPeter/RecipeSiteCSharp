using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advanced_CSharp_Project_3.ServiceReference1;

namespace Advanced_CSharp_Project_3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (this.emailInput.Value == "" || this.passwordInput.Value == "" || this.securityInput.Value == "" || this.usernameInput.Value == "")
            {
                this.ResponseLbl.Text = "Please fill in all fields";
            }
            else
            {
                WebService1SoapClient web = new WebService1SoapClient();
                // Check for exisiting user
                if (web.checkIfUserExist(this.emailInput.Value) == true)
                {
                    this.ResponseLbl.Text = "User already exists";
                }
                else
                {
                    // Create new user
                    web.addUser(this.emailInput.Value, this.usernameInput.Value, this.passwordInput.Value, this.securityInput.Value);
                    this.ResponseLbl.Text = "Successfully created account!";
                    Response.Redirect("./Login.aspx");
                }
            }
        }
    }
}