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
        pnlContent.Controls.Add(PrototypeManager.GetCarriage(
            Request.QueryString["carType"], (Carriage)DataBase.trains[0].carriages[0]).panel);
        pnlContent.Controls.Add(PrototypeManager.GetCarriage(
            "coupe", (Carriage)DataBase.trains[0].carriages[0]).panel);
        pnlContent.Controls.Add(PrototypeManager.GetCarriage(
            "lux", (Carriage)DataBase.trains[0].carriages[0]).panel);
    }
}