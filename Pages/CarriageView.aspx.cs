using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CarriageView : System.Web.UI.Page
{
    private static List<Carriage> carriages = new List<Carriage>();
    private static List<string> order = new List<string>(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCarriages();
    }

    private void GetCarriages()
    {
        foreach(Carriage carr in ((Train)DataBase.trains[Convert.ToInt32(Request.QueryString["trainId"])])
            .carriages)
        {
            if(carr.type == Request.QueryString["carType"][0])
            {
                Label lbl = new Label { Text = "Вагон № " + carr.num };
                CarriagePrototype crp = PrototypeManager.GetCarriage(carr.type, carr);
                SetPlaceEvantHandlers(crp.buttons);
                pnlContent.Controls.Add(lbl);
                pnlContent.Controls.Add(new Literal { Text = "<br />" });
                pnlContent.Controls.Add(crp.panel);
                pnlContent.Controls.Add(new Literal { Text = "<br />" });
                pnlContent.Controls.Add(new Literal { Text = "<hr />" });
            }
        }
    }

    private void SetPlaceEvantHandlers(List<Button> list)
    {
        foreach(Button b in list)
            b.Click += B_Click;
    }

    private void B_Click(object sender, EventArgs e)
    {
        Button v = (Button)sender;
        if (v.CssClass == "waiting")
        {
            v.CssClass = "PlaceReservedA";
            order.Remove(v.ID);
        }
        else
        {
            v.CssClass = "waiting";
            order.Add(v.ID);
        }
    }

    private void GenerateReview()
    {
        /*double totalAmount = 0;
        ArrayList orderList = GetOrders();
        Session["orders"] = orderList;

        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        sb.Append("<h3>Please review your order</h3>");

        foreach (Order order in orderList)
        {
            double totalRow = order.Price * order.Amount;
            sb.Append(String.Format(@"<tr>
                                        <td width = '50px'>{0}</td>
                                        <td width = '200px'>{1} ({2})</td>
                                        <td>{3}</td><td>$</td>
                                    </tr>",
                                    order.Amount, order.Product, order.Price, String.Format("{0:0.00}", totalRow)));
            totalAmount += totalRow;
        }

        sb.Append(String.Format(@"<tr>
                                    <td><b>Total: </b></td>
                                    <td><b>{0} $</b></td>
                                </tr></table>", totalAmount));*/
    }
    }