﻿using System;
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
            Text = "Показати повний шлях",
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
            //panel.Controls.Add(new Literal { Text = "<br />" });
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
            //OnClientClick = "Pages_SearchResults.ButtonChooseIsClicked",
            Text = "Вибрати",
        };
        //btnChoose.Click += Pages_SearchResults.ButtonChooseIsClicked;
        panel.Controls.Add(lblTypeFree);
        panel.Controls.Add(btnChoose);
        buttons.Add(btnChoose);
        return panel;
    }
}

//Concrete Builder
public class CarriageOverviewBuilder : Builder
{
    public override Panel SetCarriage(string type, int freePlaces, string bId, List<Button> buttons)
    {
        throw new NotImplementedException();
    }

    public override void SetPanelArrival()
    {
        throw new NotImplementedException();
    }

    public override void SetPanelDeparture()
    {
        throw new NotImplementedException();
    }

    public override void SetPanelPlaces(List<object> _places)
    {
        //object = Place
        List<Place> places = new List<Place>();
        foreach (object obj in _places)
            places.Add((Place)obj);

        
    }

    public override void SetPanelRoute()
    {
        throw new NotImplementedException();
    }
}

//Director
public static class BuilderDirector
{
    public static Panel GenerateTrainInfo(Builder builder, List<Button> buttons)
    {
        //TrainOverviewBuilder builder = new TrainOverviewBuilder(train);

        builder.SetPanelRoute();
        builder.SetPanelDeparture();
        builder.SetPanelArrival();

        int freeP = 0, freeC = 0, freeL = 0;
        foreach(Carriage carr in builder.train.carriages)
        {
            if (carr.type == 'r') freeP += carr.CountFreePlaces();
            else if (carr.type == 'c') freeC += carr.CountFreePlaces();
            else if (carr.type == 'l') freeL += carr.CountFreePlaces();
        }

        List<object> freeCarr = new List<object>();

        //if (freeP > 0)
            freeCarr.Add(builder.SetCarriage("Плацкарт", freeP, "P", buttons));
        //if (freeK > 0)
            freeCarr.Add(builder.SetCarriage("Купе", freeC, "C", buttons));
        //if (freeL > 0)
            freeCarr.Add(builder.SetCarriage("Люкс", freeL, "L", buttons));

        builder.SetPanelPlaces(freeCarr);

        return builder.GetResult();
    }
}