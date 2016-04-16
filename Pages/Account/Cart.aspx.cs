using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlContent.Controls.Add(SetHeaders());
        GenerateOrderReview();
        SetButtonsNames();
    }

    private void SetButtonsNames()
    {
        btnOK.Text = Language.GetLang().Cart_OkBtn();
        btnCancel.Text = Language.GetLang().Cart_CancelBtn();
    }

    private void GenerateOrderReview()
    {
        try {

            List<Order> orderList = (List<Order>)Session["orders"];

            if (orderList == null || orderList.Count == 0) throw new TermWorkExeption();

            foreach(Order order in orderList)
            {
                pnlContent.Controls.Add(BuilderDirector.GenerateCartPage(new OrdersOverviewBuilder(order)));
            }
            btnOK.Visible = true;
            btnCancel.Visible = true;

        }
        catch (TermWorkExeption)
        {
            TermWorkExeptionCatched.Start(this.Page, pnlContent);
            //HandlerBase hb = new LoginError();
            //hb.Successor = new NoInCartError();
            //hb.ResolveProblem(this.Page, pnlContent);
            btnOK.Visible = false;
            btnCancel.Visible = false;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        List<Order> orderList = (List<Order>)Session["orders"];
        ConnectionClass.AddOrders(orderList);
        ConnectionClass.UpdateFreePlaces(orderList);
        Session["orders"] = null;
        pnlContent.Controls.Add(new Label { Text = Language.GetLang().Cart_Congradulations() });
        Response.Redirect(Request.RawUrl);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["orders"] = null;
        pnlContent.Controls.Clear();
        Response.Redirect(Request.RawUrl);
    }

    private Panel SetHeaders()
    {
        Label lblTrain = new Label { Text = "Потяг" };
        Label lblDep = new Label { Text = "Відправлення" };
        Label lblArr = new Label { Text = "Прибуття" };
        Label lblCarr = new Label { Text = "Вагон" };
        Label lblPlace = new Label { Text = "Місце" };
        Label lblPrice = new Label { Text = "Ціна" };
        Literal l = new Literal { Text = "<br />" };
        Panel panel = new Panel();
        panel.Controls.Add(lblTrain);
        panel.Controls.Add(lblDep);
        panel.Controls.Add(lblArr);
        panel.Controls.Add(lblCarr);
        panel.Controls.Add(lblPlace);
        panel.Controls.Add(lblPrice);
        panel.Controls.Add(l);

        return panel;
    }

    protected override void OnError(EventArgs e)
    {
        base.OnError(e);
    }
}