using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateControls();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }
    
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Language.ChangeLanguage(ddlLanguage.SelectedValue);
        UpdateControls();
    }

    private void UpdateControls()
    {
        lbtnHome.Text = Language.GetLang().Master_Home();
        SetCart();
        lbtnMyOrders.Text = Language.GetLang().Master_ClientOrders();
        lblLogin.Text = Language.GetLang().Master_Login();
        //SetLogin();
    }

    private void SetCart()
    {
        if (Session["orders"] == null)
            lbtnCart.Text = string.Format(Language.GetLang().Master_Cart() + " (0)");
        else {
            List<Order> orderList = (List<Order>)Session["orders"];
            lbtnCart.Text = string.Format(Language.GetLang().Master_Cart() + " ({0})", orderList.Count);
        }
    }

    private void SetLogin()
    {
        //User Logs in
        if (LinkButton1.Text == "Login")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
        {
            //User logs out
            Session.Clear();
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}
