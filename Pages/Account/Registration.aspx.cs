using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Create user
        User user = new User(txtEmail.Text, txtPassword.Text, txtName.Text, 
            txtSurname.Text, txtPhone.Text, "user");

        //Register the user and return a result message
        lblResult.Text = ConnectionClass.RegisterUser(user);
    }
}