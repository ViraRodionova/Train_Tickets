﻿using System;
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
            double totalAmount = 0;
            double price = 255.25;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append(Language.GetLang().Cart_TableHeader());
            /*sb.Append("<h3>Please review your order</h3>");
            sb.Append(@"<tr>
                                        <td width = '50px'>Поїзд</td>
                                        <td width = '50px'>Вагон</td>
                                        <td width = '50px'>Місце</td>
                                    </tr>");*/

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

            btnOK.Visible = true;
            btnCancel.Visible = true;
        }
        catch(NullReferenceException)
        {
            HandlerBase hb = new LoginError();
            hb.Successor = new NoOrdersError();
            hb.ResolveProblem(this.Page, pnlContent, null);
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
}