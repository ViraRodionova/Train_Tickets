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
        Authenticate();
        GenerateOrderReview();
        SetButtons();
    }

    private void GenerateOrderReview()
    {
        if (Session["orders"] == null)
        {
            pnlContent.Controls.Add(new Label { Text = "Ваша корзина порожня" });
            return;
        }
        List<Order> orderList = (List<Order>)Session["orders"];
        double totalAmount = 0;
        double price = 255.25;

        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        sb.Append("<h3>Please review your order</h3>");
        sb.Append(@"<tr>
                                        <td width = '50px'>Поїзд</td>
                                        <td width = '50px'>Вагон</td>
                                        <td width = '50px'>Місце</td>
                                    </tr>");

        foreach (Order order in orderList)
        {
            double totalRow = price;
            sb.Append(String.Format(@"<tr>
                                        <td width = '50px'>{0}</td>
                                        <td width = '50px'>{1}</td>
                                        <td width = '50px'>{2}</td>
                                        <td>{3}</td><td>$</td>
                                    </tr>",
                                    order.TrainNum, order.CarriageNum, order.PlaceNum, String.Format("{0:0.00}", totalRow)));
            totalAmount += totalRow;
        }

        sb.Append(String.Format(@"<tr>
                                    <td><b>Total: </b></td>
                                    <td><b>{0} $</b></td>
                                </tr></table>", totalAmount));
        pnlContent.Controls.Add(new Label { Text = sb.ToString() });
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        List<Order> orderList = (List<Order>)Session["orders"];
        ConnectionClass.AddOrders(orderList);
        ConnectionClass.UpdateFreePlaces(orderList);
        Session["orders"] = null;
        //Response.Redirect("~/Pages/Home.aspx");
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(new Label { Text = "Ваша корзина порожня" });
        Page.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["orders"] = null;
        //orders_string.Clear();

        //lblResult.Visible = false;
        //Response.Redirect("~/Pages/Home.aspx");
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(new Label { Text = "Ваша корзина порожня" });
        Page.DataBind();
    }

    private void SetButtons()
    {
        if(Session["orders"] == null)
        {
            btnOK.Visible = false;
            btnCancel.Visible = false;
        }
        else
        {
            btnOK.Visible = true;
            btnCancel.Visible = true;
        }
    }

    private void Authenticate()
    {
        if (Session["email"] == null)
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
}