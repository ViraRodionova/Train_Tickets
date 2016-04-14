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
        if (Session["login"] != null)
        {
            lblLogin.Text = "Welcome " + Session["login"].ToString();
            lblLogin.Visible = true;
            LinkButton1.Text = "Logout";
        }
        else
        {
            lblLogin.Visible = false;
            LinkButton1.Text = "Login";
        }
        SetCarriage();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
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

    private void SetCarriage()
    {
        if (Session["orders"] == null)
            lbtnCart.Text = string.Format("Корзина ({0})", 0);
        else {
            List<Order> orderList = (List<Order>)Session["orders"];
            lbtnCart.Text = string.Format("Корзина ({0})", orderList.Count);
        }
    }
}
