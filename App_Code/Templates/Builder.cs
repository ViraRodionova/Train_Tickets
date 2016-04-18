using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


public abstract class Builder
{
    protected Panel result;
    public Train train;
    //public List<Button> buttons = new List<Button>();

    public abstract void SetPanelRoute();
    public abstract void SetPanelDeparture();
    public abstract void SetPanelArrival();
    public abstract void SetPanelPlaces(List<object> places);
    public abstract Panel SetCarriage(string type, int freePlaces, string bId, List<Button> buttons);
    public virtual void SetPrice(List<double> price) { }
    public virtual void SetDate() { }
    public Panel GetResult()
    {
        return result;
    }
}

//Concrete Builder
public class TrainOverviewBuilder : Builder
{
    string stFrom;
    string stTo;

    public TrainOverviewBuilder(Train train, string stFrom, string stTo)
    {
        this.train = train;
        this.stFrom = stFrom;
        this.stTo = stTo;
        result = new Panel { CssClass = "PnlTrain", Width = 800 };
    }

    public override void SetPanelRoute()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 200 };

        ArrayList route = ConnectionClass.GerFullRouteByTrain(train.TrainNum);
        
        Label lblNum = new Label { Text = train.TrainNum, CssClass = "lbl_num" };
        Label lblRoute = new Label { Text = string.Format(route[0] + "-" + route[route.Count - 1]), CssClass = "lbl_route" };
        LinkButton linkFullRoute = new LinkButton
        {
            ID = string.Format("lbtn_" + train.TrainNum + "_" + train.Id),
            Text = Language.GetLang().Builder_ShowFullRouteLbtn(),
            CssClass = "lbtn_full_route"
        };
        Literal l1 = new Literal { Text = "<br />" };
        Literal l2 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblNum);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblRoute);
        panel.Controls.Add(l2);
        panel.Controls.Add(linkFullRoute);

        result.Controls.Add(panel);
    }

    public override void SetPanelDeparture()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 125 };
        Label lblTime = new Label
        {
            Text = train.DepartureDate.ToString("HH:mm")
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.ToString("ddd dd MMMM"),
            CssClass = "lbl_route"
        };
        Label lblCity = new Label
        {
            Text = this.stFrom,
            CssClass = "lbl_num"
        };
        Literal l1 = new Literal { Text = "<br />" };
        Literal l2 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblTime);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblDate);
        panel.Controls.Add(l2);
        panel.Controls.Add(lblCity);

        result.Controls.Add(panel);
    }

    public override void SetPanelArrival()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 125 };
        Label lblTime = new Label
        {
            Text = train.ArrivalDate.ToString("HH:mm")
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.ToString("ddd dd MMMM"),
            CssClass = "lbl_route"
        };
        Label lblCity = new Label
        {
            Text = this.stTo,
            CssClass = "lbl_num"
        };
        Literal l1 = new Literal { Text = "<br />" };
        Literal l2 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblTime);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblDate);
        panel.Controls.Add(l2);
        panel.Controls.Add(lblCity);

        result.Controls.Add(panel);
    }

    public override void SetPanelPlaces(List<object> places)
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 225 };

        foreach (Panel pnl in places)
        {
            panel.Controls.Add(pnl);
        }

        result.Controls.Add(panel);
    }

    public override Panel SetCarriage(string type, int freePlaces, string bId, List<Button> buttons)
    {
        Panel panel = new Panel();

        Label lblTypeFree = new Label
        {
            Text = type + ": " + freePlaces
        };

        Button btnChoose = new Button
        {
            ID = "btn_" + bId + "_" + train.TrainNum + "_" + train.Id,
            Text = Language.GetLang().Builder_ChooseBtn(),
            CssClass= "BtnChoose"
        };
        panel.Controls.Add(btnChoose);
        panel.Controls.Add(lblTypeFree);
        

        //panel.Controls.Add(new Literal { Text = "<br />" });
        buttons.Add(btnChoose);
        return panel;
    }
}

//Concrete Builder
public class OrdersOverviewBuilder : Builder
{
    Order order;

    public OrdersOverviewBuilder(Order order, int widthRoot)
    {
        this.train = ConnectionClass.GetTrainById(order.TrainId);
        this.train.carriages = ConnectionClass.GetCarriagiesByTrainId(order.TrainId);
        foreach (Carriage carr in this.train.carriages)
            carr.places = ConnectionClass.GetPlacesByCarriageId(carr.Id);
        //this.train = (Train)DataBase.trains[order.TrainId];
        this.order = order;
        result = new Panel { CssClass = "PnlTrain", Width = widthRoot };
    }

    public override Panel SetCarriage(string type, int freePlaces, string bId, List<Button> buttons)
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 100 };
        Label lblCarr = new Label { Text = order.CarriageNum.ToString() };
        panel.Controls.Add(lblCarr);
        result.Controls.Add(panel);
        return null;
    }

    public override void SetDate()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 100 };
        Label lblDate = new Label { Text = order.Date.ToString("dd/MM/yyyy \n\n HH:mm:ss") };
        panel.Controls.Add(lblDate);
        result.Controls.Add(panel);
    }

    public override void SetPanelArrival()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 125 };
        Label lblTime = new Label
        {
            Text = train.DepartureDate.ToString("HH:mm")
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.ToString("ddd dd MMMM"),
            CssClass = "lbl_route"
        };
        Label lblCity = new Label
        {
            Text = order.StTo,
            CssClass = "lbl_num"
        };
        Literal l1 = new Literal { Text = "<br />" };
        Literal l2 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblTime);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblDate);
        panel.Controls.Add(l2);
        panel.Controls.Add(lblCity);

        result.Controls.Add(panel);
    }

    public override void SetPanelDeparture()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 125 };
        Label lblTime = new Label
        {
            Text = train.DepartureDate.ToString("HH:mm")
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.ToString("ddd dd MMMM"),
            CssClass = "lbl_route"
        };
        Label lblCity = new Label
        {
            Text = order.StFrom,
            CssClass = "lbl_num"
        };
        Literal l1 = new Literal { Text = "<br />" };
        Literal l2 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblTime);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblDate);
        panel.Controls.Add(l2);
        panel.Controls.Add(lblCity);

        result.Controls.Add(panel);
    }

    public override void SetPanelPlaces(List<object> places)
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 100 };
        Label lblPlace = new Label { Text = order.PlaceNum.ToString() };
        panel.Controls.Add(lblPlace);
        result.Controls.Add(panel);
    }

    public override void SetPanelRoute()
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 200 };

        ArrayList route = ConnectionClass.GerFullRouteByTrain(train.TrainNum);

        Label lblNum = new Label { Text = train.TrainNum, CssClass = "lbl_num" };
        Label lblRoute = new Label { Text = string.Format(route[0] + "-" + route[route.Count - 1]), CssClass = "lbl_route" };

        Literal l1 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblNum);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblRoute);

        result.Controls.Add(panel);
    }

    public override void SetPrice(List<double> price)
    {
        Panel panel = new Panel { CssClass = "pnlCell", Width = 100 };
        double p = train.GetPlace(order.CarriageNum, order.PlaceNum).Price;
        Label lblPrice = new Label { Text = p.ToString() + " UAH", CssClass= "lbl_num" };
        if (price != null) price.Add(p);
        panel.Controls.Add(lblPrice);
        result.Controls.Add(panel);
    }
}

//Director
public static class BuilderDirector
{
    public static Panel GenerateTrainInfo(Builder builder, List<Button> buttons)
    {
        int freeP = 0, freeC = 0, freeL = 0;
        foreach(Carriage carr in builder.train.carriages)
        {
            if (carr.type == 'r') freeP += carr.CountFreePlaces();
            else if (carr.type == 'c') freeC += carr.CountFreePlaces();
            else if (carr.type == 'l') freeL += carr.CountFreePlaces();
        }

        List<object> freeCarr = new List<object>();
        string[] types = Language.GetLang().Builder_CarriageTypes();


        builder.SetPanelRoute();
        builder.SetPanelDeparture();
        builder.SetPanelArrival();

        if (freeP > 0) freeCarr.Add(builder.SetCarriage(types[0], freeP, "P", buttons));
        if (freeC > 0) freeCarr.Add(builder.SetCarriage(types[1], freeC, "C", buttons));
        if (freeL > 0) freeCarr.Add(builder.SetCarriage(types[2], freeL, "L", buttons));

        builder.SetPanelPlaces(freeCarr);

        return builder.GetResult();
    }

    public static Panel GenerateOrdersOverviewPage(Builder builder)
    {
        builder.SetPanelRoute();
        builder.SetPanelDeparture();
        builder.SetPanelArrival();
        builder.SetCarriage(null, 0, null, null);
        builder.SetPanelPlaces(null);
        builder.SetPrice(null);
        builder.SetDate();
        return builder.GetResult();
    }

    public static Panel GenerateCartPage(Builder builder, List<double> price)
    {
        builder.SetPanelRoute();
        builder.SetPanelDeparture();
        builder.SetPanelArrival();
        builder.SetCarriage(null, 0, null, null);
        builder.SetPanelPlaces(null);
        builder.SetPrice(price);
        //builder.SetCancelButton(buttons);
        return builder.GetResult();
    }
}