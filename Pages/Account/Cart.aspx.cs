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

            List<double> price = new List<double>();

            foreach (Order order in orderList)
            {
                Button but = new Button
                {
                    ID = "but_" + order.TrainId + "_" + order.CarriageNum + "_" + order.PlaceNum,
                    Text = "[Видалити]",
                    CssClass = "cancelBtn",
                };
                but.Click += RemoveOrderFromCart_Click;
                pnlContent.Controls.Add(but);

                pnlContent.Controls.Add(BuilderDirector.GenerateCartPage(new OrdersOverviewBuilder(order, 940), price));
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

    private void RemoveOrderFromCart_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        string[] _id = b.ID.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        int[] id = new int[]
        {
            Convert.ToInt32(_id[1]),
            Convert.ToInt32(_id[2]),
            Convert.ToInt32(_id[3])
        };

        List<Order> orderList = (List<Order>)Session["orders"];
        foreach(Order o in orderList)
        {
            if(o.TrainId == id[0] && o.CarriageNum == id[1] && o.PlaceNum == id[2])
            {
                orderList.Remove(o);
                Session["orders"] = null;
                Session["orders"] = orderList;
                break;
            }
        }

        Response.Redirect(Request.RawUrl);
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
        Label lblTrain = new Label { Text = "Потяг", CssClass = "header", Width = 210, Height = 20 };
        Label lblDep = new Label { Text = "Відправлення", CssClass = "header", Width = 135, Height = 20 };
        Label lblArr = new Label { Text = "Прибуття", CssClass = "header", Width = 135, Height = 20 };
        Label lblCarr = new Label { Text = "Вагон", CssClass = "header", Width = 110, Height = 20 };
        Label lblPlace = new Label { Text = "Місце", CssClass = "header", Width = 110, Height = 20 };
        Label lblPrice = new Label { Text = "Ціна", CssClass= "header", Width=110, Height=20 };
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
}