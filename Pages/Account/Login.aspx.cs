using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        User user = ConnectionClass.LogInUser(txtLogin.Text, txtPassword.Text);

        if (user != null)
        {
            //Store user variables in session
            Session["login"] = user.Name;
            Session["type"] = user.Type;
            Session["email"] = user.Email;

            Response.Redirect("~/Pages/Account/PersonalPage.aspx");
        }
        else
        {
            lblError.Text = "Login failed";
        }
    }
}