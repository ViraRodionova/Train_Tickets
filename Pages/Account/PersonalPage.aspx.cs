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

            if (Session["email"] == null) throw new TermWorkExeption();

            orderList = ConnectionClass.GetUserOrders(Session["email"].ToString());

            if (orderList == null || orderList.Count == 0) throw new TermWorkExeption();

            foreach(Order order in orderList)
            {
                pnlContent.Controls.Add(BuilderDirector.GenerateOrdersOverviewPage(new OrdersOverviewBuilder(order)));
            }
        }
        catch (TermWorkExeption)
        {
            TermWorkExeptionCatched.Start(this.Page, pnlContent);
            //HandlerBase hb = new LoginError();
            //hb.Successor = new NoOrdersInDB();
            //hb.ResolveProblem(this.Page, pnlContent);
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