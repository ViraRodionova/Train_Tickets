using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CarriageView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarriagePrototype crp = PrototypeManager.GetCarriage(Request.QueryString["carType"], (Carriage)DataBase.trains[0].carriages[0]);
        GeneratePlaces(crp.buttons);

    }

    private void GeneratePlaces(List<Button> list)
    {
        foreach(Button b in list)
        {
            b.Click += B_Click;
            pnlContent.Controls.Add(b);
        }
    }

    private void B_Click(object sender, EventArgs e)
    {
        Button v = (Button)sender;
        v.CssClass = "waiting";
    }
}