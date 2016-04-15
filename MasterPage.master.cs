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
        if(Session["email"] == null)
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
        {
            Session.Clear();
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
    
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["lang"] = true;
        Session["getTrains"] = true;
        Language.ChangeLanguage(ddlLanguage.SelectedValue);
        UpdateControls();
        Response.Redirect(Request.RawUrl);
    }

    private void UpdateControls()
    {
        lbtnHome.Text = Language.GetLang().Master_Home();
        SetCart();
        lbtnMyOrders.Text = Language.GetLang().Master_ClientOrders();
        SetLogin();
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
        if (Session["login"] != null)
        {
            lblLogin.Text = Language.GetLang().Master_Greeting() + Session["login"].ToString();
            lblLogin.Visible = true;
            LinkButton1.Text = Language.GetLang().Master_LogOut();
        }
        else
        {
            lblLogin.Visible = false;
            LinkButton1.Text = Language.GetLang().Master_Login();
        }
    }
}
