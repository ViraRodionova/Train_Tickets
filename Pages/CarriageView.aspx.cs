using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CarriageView : System.Web.UI.Page
{
    //private static List<Carriage> carriages = new List<Carriage>();
    private static List<string> orders_string = new List<string>();
    //private static List<Order> orders = new List<Order>();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCarriages();
        btnOrder.Text = Language.GetLang().CarrView_ToCartBtn();
    }

    private void GetCarriages()
    {
        foreach(Carriage carr in ((Train)DataBase.trains[Convert.ToInt32(Request.QueryString["trainId"])])
            .carriages)
        {
            if(carr.type == Request.QueryString["carType"][0])
            {
                Label lbl = new Label { Text = Language.GetLang().CarrView_CarrName() + " № " + carr.num };
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
            orders_string.Remove(v.ID);
        }
        else
        {
            v.CssClass = "waiting";
            orders_string.Add(v.ID);
        }
    }

    private void GenerateReview()
    {
        List<Order> orderList = GetOrders();
        if (Session["orders"] == null) Session["orders"] = orderList;
        else ((List<Order>)Session["orders"]).AddRange(orderList);
    }

    private List<Order> GetOrders()
    {
        List<Order> orderList = new List<Order>();
        int trainId = Convert.ToInt32(Request.QueryString["trainId"]);
        string trainNum = Request.QueryString["trainNum"];

        foreach(string place in orders_string)
        {
            Array placeInfo = place.Split(new char[] { '_' },
            StringSplitOptions.RemoveEmptyEntries).ToArray();
            DateTime date = DateTime.Now;
            Order order = new Order(Session["email"].ToString(), trainId, trainNum,
                Convert.ToInt32(placeInfo.GetValue(2)), Convert.ToInt32(placeInfo.GetValue(1)), date);
            orderList.Add(order);
        }
        return orderList;
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Authenticate();
        GenerateReview();
        orders_string.Clear();
        Response.Redirect(Request.RawUrl);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        List<Order> orderList = (List<Order>)Session["orders"];
        ConnectionClass.AddOrders(orderList);
        ConnectionClass.UpdateFreePlaces(orderList);
        Session["orders"] = null;
        orders_string.Clear();
        Response.Redirect("~/Pages/Home.aspx");
    }

    /*protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Session["orders"] = null;
        //orders_string.Clear();
        btnOK.Visible = false;
        btnCancel.Visible = false;
        lblResult.Visible = false;
        pnlContent.Visible = true;
        //Response.Redirect("~/Pages/Home.aspx");
    }*/

    private void Authenticate()
    {
        if (Session["email"] == null)
        {
            Session["orders"] = null;
            orders_string.Clear();
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
}