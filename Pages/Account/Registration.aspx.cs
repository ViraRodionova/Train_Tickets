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
        SetControlsNames();
    }

    private void SetControlsNames()
    {
        lblName.Text = Language.GetLang().Reg_NameLbl();
        lblSurname.Text = Language.GetLang().Reg_SurnameLbl();
        lblPass.Text = Language.GetLang().Reg_PasswordLbl();
        lblConfirmPass.Text = Language.GetLang().Reg_ConfirmPassLbl();
        lblPhone.Text = Language.GetLang().Reg_Phone();
        btnRegister.Text = Language.GetLang().Reg_RegBtn();
        CompareValidator1.ErrorMessage = Language.GetLang().Reg_CompareValidator();
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