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
    public virtual void SetPrice() { }
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
        result = new Panel { CssClass = "PnlTrain" };
    }

    public override void SetPanelRoute()
    {
        Panel panel = new Panel { CssClass = "left" };

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
        Panel panel = new Panel { CssClass = "left" };
        Label lblTime = new Label
        {
            Text = train.DepartureDate.Hour.ToString() + ":" 
                + train.DepartureDate.Minute.ToString()
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.DayOfWeek.ToString() 
                + train.DepartureDate.Day.ToString() 
                + train.DepartureDate.Month.ToString()
        };
        Label lblCity = new Label
        {
            Text = this.stFrom
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
        Panel panel = new Panel { CssClass = "left" };
        Label lblTime = new Label
        {
            Text = train.ArrivalDate.Hour.ToString() + ":" 
                + train.ArrivalDate.Minute.ToString()
        };
        Label lblDate = new Label
        {
            Text = train.ArrivalDate.DayOfWeek.ToString() 
                + train.ArrivalDate.Day.ToString() 
                + train.ArrivalDate.Month.ToString()
        };
        Label lblCity = new Label
        {
            Text = this.stTo
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
        Panel panel = new Panel { CssClass = "left" };

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
        };
        panel.Controls.Add(lblTypeFree);
        panel.Controls.Add(btnChoose);
        buttons.Add(btnChoose);
        return panel;
    }
}

//Concrete Builder
public class OrdersOverviewBuilder : Builder
{
    Order order;

    public OrdersOverviewBuilder(Order order)
    {
        this.train = ConnectionClass.GetTrainById(order.TrainId);
        this.train.carriages = ConnectionClass.GetCarriagiesByTrainId(order.TrainId);
        foreach (Carriage carr in this.train.carriages)
            carr.places = ConnectionClass.GetPlacesByCarriageId(carr.Id);
        //this.train = (Train)DataBase.trains[order.TrainId];
        this.order = order;
        result = new Panel { CssClass = "PnlTrain" };
    }

    public override Panel SetCarriage(string type, int freePlaces, string bId, List<Button> buttons)
    {
        Label lblCarr = new Label { Text = order.CarriageNum.ToString() };
        result.Controls.Add(lblCarr);
        return null;
    }

    public override void SetDate()
    {
        Label lblDate = new Label { Text = order.Date.ToString() };
        result.Controls.Add(lblDate);
    }

    public override void SetPanelArrival()
    {
        Panel panel = new Panel { CssClass = "left" };
        Label lblTime = new Label
        {
            Text = train.ArrivalDate.Hour.ToString() + ":"
                + train.ArrivalDate.Minute.ToString()
        };
        Label lblDate = new Label
        {
            Text = train.ArrivalDate.DayOfWeek.ToString()
                + train.ArrivalDate.Day.ToString()
                + train.ArrivalDate.Month.ToString()
        };
        Label lblCity = new Label
        {
            Text = order.StTo
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
        Panel panel = new Panel { CssClass = "left" };
        Label lblTime = new Label
        {
            Text = train.DepartureDate.Hour.ToString() + ":"
                + train.DepartureDate.Minute.ToString()
        };
        Label lblDate = new Label
        {
            Text = train.DepartureDate.DayOfWeek.ToString()
                + train.DepartureDate.Day.ToString()
                + train.DepartureDate.Month.ToString()
        };
        Label lblCity = new Label
        {
            Text = order.StFrom
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
        Label lblCarr = new Label { Text = order.PlaceNum.ToString() };
        result.Controls.Add(lblCarr);
    }

    public override void SetPanelRoute()
    {
        Panel panel = new Panel { CssClass = "left" };

        ArrayList route = ConnectionClass.GerFullRouteByTrain(train.TrainNum);

        Label lblNum = new Label { Text = train.TrainNum, CssClass = "lbl_num" };
        Label lblRoute = new Label { Text = string.Format(route[0] + "-" + route[route.Count - 1]), CssClass = "lbl_route" };

        Literal l1 = new Literal { Text = "<br />" };

        panel.Controls.Add(lblNum);
        panel.Controls.Add(l1);
        panel.Controls.Add(lblRoute);

        result.Controls.Add(panel);
    }

    public override void SetPrice()
    {
        Label lblCarr = new Label { Text = train.GetPlace(order.CarriageNum, order.PlaceNum).Price.ToString() + "UAH" };
        result.Controls.Add(lblCarr);
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
        builder.SetPrice();
        builder.SetDate();
        return builder.GetResult();
    }

    public static Panel GenerateCartPage(Builder builder)
    {
        builder.SetPanelRoute();
        builder.SetPanelDeparture();
        builder.SetPanelArrival();
        builder.SetCarriage(null, 0, null, null);
        builder.SetPanelPlaces(null);
        builder.SetPrice();
        return builder.GetResult();
    }
}