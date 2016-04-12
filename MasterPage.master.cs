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
            lblName.Text = Session["login"] + "Вітаємо на нашому порталі";
            lbtnLogout.Visible = true;
        }
        else
        {
            lblName.Text = "";
            lbtnLogout.Visible = false;
        }
    }

    protected void lbtnMyTicket_Click(object sender, EventArgs e)
    {
        ContentPlaceHolder1.Controls.Clear();
        if (Session["login"] != null)
        {
            Response.Redirect("~/Pages/Account/PersonalPage.aspx");
        }
        else
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session["login"] = null;
        Session["type"] = null;
        Response.Redirect("~/Pages/Home.aspx");
    }
}
