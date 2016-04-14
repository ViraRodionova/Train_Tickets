using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_PersonalPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Authenticate();
        GenerateOrderReview();
    }

    private void GenerateOrderReview()
    {
        List<Order> orderList = ConnectionClass.GetUserOrders(Session["email"].ToString());
        double price = 255.25;

        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        sb.Append("<h3>Ваші замовлення</h3>");
        sb.Append(@"<tr>
                                        <td width = '150px'>Поїзд</td>
                                        <td width = '150px'>Вагон</td>
                                        <td width = '150px'>Місце</td>
                                        <td width = '150px'>Ціна</td>
                                        <td width = '150px'>Дата покупки</td>
                                    </tr><hr>");

        foreach (Order order in orderList)
        {
            sb.Append(String.Format(@"<tr>
                                        <td width = '150px'>{0}</td>
                                        <td width = '150px'>{1}</td>
                                        <td width = '150px'>{2}</td>
                                        <td width = '150px'>{3} $</td>
                                        <td width = '150px'>{4}</td>
                                    </tr>",
                                    order.TrainNum, order.CarriageNum, order.PlaceNum, String.Format("{0:0.00}", price), order.Date));
        }

        pnlContent.Controls.Add(new Label { Text = sb.ToString() });
    }

    private void Authenticate()
    {
        if (Session["email"] == null)
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
}