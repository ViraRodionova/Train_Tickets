using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

//Concrete Builder
class Builder
{
    private Train train;
    private Panel result;

    public Builder(Train train)
    {
        this.train = train;
        result = new Panel { CssClass = "PnlTrain" };
    }

    public void SetPanelRoute()
    {
        Panel panel = new Panel { CssClass = "left" };

        List<string> route = ConnectionClass.GerFullRouteByTrain(train.TrainNum);
        
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

    public void SetPanelDeparture(string stFrom)
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
            Text = stFrom
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

    public void SetPanelArrival(string stTo)
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
            Text = stTo
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

    public void SetPanelPlaces(List<Panel> places)
    {
        Panel panel = new Panel { CssClass = "left" };

        foreach (Panel pnl in places)
        {
            panel.Controls.Add(pnl);
            //panel.Controls.Add(new Literal { Text = "<br />" });
        }

        result.Controls.Add(panel);
    }

    public Panel SetCarriage(string type, int freePlaces, string bId)
    {
        Panel panel = new Panel();

        Label lblTypeFree = new Label
        {
            Text = type + ": " + freePlaces
        };

        //Button btnChoose = new Button
        //{
        //    ID = "btn" + bId + "_" + train.TrainNum + "_" + train.Id,
            //OnClientClick = "Pages_SearchResults.ButtonChooseIsClicked",
        //    Text = "Вибрати",
        //};
        //btnChoose.Click += Pages_SearchResults.ButtonChooseIsClicked;
        panel.Controls.Add(lblTypeFree);
        //panel.Controls.Add(btnChoose);

        return panel;
    }

    public Panel GetTrainResult()
    {
        return result;
    }
}

//Director
public class TrainOverviewBuilder
{
    private string stFrom;
    private string stTo;

    public TrainOverviewBuilder(string stFrom, string stTo)
    {
        this.stFrom = stFrom;
        this.stTo = stTo;
    }

    public Panel GenerateTrainInfo(Train train)
    {
        Builder builder = new Builder(train);

        builder.SetPanelRoute();
        builder.SetPanelDeparture(stFrom);
        builder.SetPanelArrival(stTo);

        int freeP = 0, freeK = 0, freeL = 0;
        foreach(Carriage carr in train.carriages)
        {
            if (carr.type == 'П') freeP += carr.CountFreePlaces();
            else if (carr.type == 'К') freeK += carr.CountFreePlaces();
            else if (carr.type == 'Л') freeL += carr.CountFreePlaces();
        }

        List<Panel> freeCarr = new List<Panel>();

        //if (freeP > 0)
            freeCarr.Add(builder.SetCarriage("Плацкарт", freeP, "P"));
        //if (freeK > 0)
            freeCarr.Add(builder.SetCarriage("Купе", freeK, "K"));
        //if (freeL > 0)
            freeCarr.Add(builder.SetCarriage("Люкс", freeL, "L"));

        builder.SetPanelPlaces(freeCarr);

        return builder.GetTrainResult();
    }
}