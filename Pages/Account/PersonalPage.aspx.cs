using System;
using System.Collections;
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
        //Authenticate();
        pnlContent.Controls.Add(SetHeaders());
        GenerateOrderReview();
    }

    private void GenerateOrderReview()
    {
        ArrayList orderList = null;
        try {
            orderList = ConnectionClass.GetUserOrders(Session["email"].ToString());
            double price = 255.25;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append(Language.GetLang().PersPage_TableHeader());
            /*sb.Append("<h3>Ваші замовлення</h3>");
            sb.Append(@"<tr>
                                        <td width = '150px'>Поїзд</td>
                                        <td width = '150px'>Вагон</td>
                                        <td width = '150px'>Місце</td>
                                        <td width = '200px'>Ціна</td>
                                        <td width = '250px'>Дата покупки</td>
                                    </tr><hr>");*/

            /*foreach (Order order in orderList)
            {
                sb.Append(String.Format(@"<tr>
                                        <td width = '150px'>{0}</td>
                                        <td width = '150px'>{1}</td>
                                        <td width = '150px'>{2}</td>
                                        <td width = '200px'>{3} $</td>
                                        <td width = '250px'>{4}</td>
                                    </tr>",
                                        order.TrainNum, order.CarriageNum, order.PlaceNum, String.Format("{0:0.00}", price), order.Date));
            }

            pnlContent.Controls.Add(new Label { Text = sb.ToString() });*/
            foreach(Order order in orderList)
            {
                pnlContent.Controls.Add(BuilderDirector.GenerateOrdersOverviewPage(new OrdersOverviewBuilder(order)));
            }
        }
        catch (NullReferenceException)
        {
            HandlerBase hb = new LoginError();
            hb.Successor = new NoOrdersInDB();
            hb.ResolveProblem(this.Page, pnlContent, orderList);
        }
    }

    private Panel SetHeaders()
    {
        Label lblTrain = new Label { Text = "Потяг" };
        Label lblDep = new Label { Text = "Відправлення" };
        Label lblArr = new Label { Text = "Прибуття" };
        Label lblCarr = new Label { Text = "Вагон" };
        Label lblPlace = new Label { Text = "Місце" };
        Label lblPrice = new Label { Text = "Ціна" };
        Label lblDate = new Label { Text = "Дата покупки" };
        Literal l = new Literal { Text = "<br />" };
        Panel panel = new Panel();
        panel.Controls.Add(lblTrain);
        panel.Controls.Add(lblDep);
        panel.Controls.Add(lblArr);
        panel.Controls.Add(lblCarr);
        panel.Controls.Add(lblPlace);
        panel.Controls.Add(lblPrice);
        panel.Controls.Add(lblDate);
        panel.Controls.Add(l);

        return panel;
    }
}