using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advanced_CSharp_Project_3.ServiceReference1;

namespace Advanced_CSharp_Project_3
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (this.userInput.Value == "" || this.passwordInput.Value == "")
            {
                this.infoLbl.Text = "Please provide a username AND password!";
            }
            else
            {
                WebService1SoapClient web = new WebService1SoapClient();
                if (web.validateUser(this.userInput.Value, this.passwordInput.Value) == true)
                {
                    this.infoLbl.Text = "Successfully logged in!";
                    Response.Redirect("./Main.aspx?name="+this.userInput.Value);
                }
                else
                {
                    this.infoLbl.Text = "Login failed!";
                }
            }
        }
    }
}