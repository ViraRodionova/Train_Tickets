using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchResults : System.Web.UI.Page
{
    private static List<Train> trains = new List<Train>();
    //private static bool flag = true;
    private static Panel trainsPanel = new Panel();
    private static List<Button> buttonsList = new List<Button>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["getTrains"])
        {
            trainsPanel.Controls.Clear();
            trains.Clear();

            SetTrains();
        }

        pnlTrains.Controls.Add(trainsPanel);
        SetButtonsEventHandlers();
    }

    private void GetTrains(string from, string to, string _date)
    {
        DateTime date = Convert.ToDateTime(_date);

        ArrayList routes_trains = ConnectionClass.GetTrainsNums(from, to);
        ArrayList required_trains = ConnectionClass.GetTrainIDs(routes_trains, date);

        try {
            if (required_trains == null || required_trains.Count == 0) throw new TermWorkExeption();

            foreach (int id in required_trains)
            {
                Train _train = ConnectionClass.GetTrainById(id);
                _train.carriages = ConnectionClass.GetCarriagiesByTrainId(id);

                foreach (Carriage _c in _train.carriages)
                {
                    _c.places = ConnectionClass.GetPlacesByCarriageId(_c.Id);
                }

                if (_train.CountFreePlaces() > 0)
                    trains.Add(_train);
            }
        }
        catch (TermWorkExeption)
        {
            //TermWorkExeptionCatched.Start(this.Page, pnlTrains);
            pnlTrains.Controls.Add(new Label { Text = Language.GetLang().SearchRes_NoTrains() });
        }
    }

    private void SetTrains()
    {
        //flag = false;
        Session["getTrains"] = false;
        GetTrains(Request.QueryString["stFrom"], Request.QueryString["stTo"], Request.QueryString["date"]);
        //BuilderDirector bd = new BuilderDirector(Request.QueryString["stFrom"], Request.QueryString["stTo"]);

        foreach (Train _train in trains)
        {
            trainsPanel.Controls.Add(BuilderDirector.GenerateTrainInfo(
                new TrainOverviewBuilder(_train, Request.QueryString["stFrom"], 
                Request.QueryString["stTo"]), buttonsList));
            SetButtonsEventHandlers();
            DataBase.trains[_train.Id] = _train;
        }

        //DataBase.trains = trains;

        pnlTrains.Controls.Add(SetHeaders());
        pnlTrains.Controls.Add(trainsPanel);
        Page.DataBind();
    }

    private Panel SetHeaders()
    {
        Label lblTrain = new Label { Text = "Потяг" };
        Label lblDep = new Label { Text = "Відправлення" };
        Label lblArr = new Label { Text = "Прибуття" };
        Label lblCarr = new Label { Text = "Оберіть вагон" };
        Literal l = new Literal { Text = "<br />" };
        Panel panel = new Panel();
        panel.Controls.Add(lblTrain);
        panel.Controls.Add(lblDep);
        panel.Controls.Add(lblArr);
        panel.Controls.Add(lblCarr);
        panel.Controls.Add(l);
        return panel;
    }

    private void SetButtonsEventHandlers()
    {
        foreach (Button but in buttonsList)
            but.Click += ButtonChooseIsClicked;
    }

    private void ButtonChooseIsClicked(object sender, EventArgs e)
    {
        Button but = (Button)sender;
        string par = but.ID;
        Array trainInfo = par.Split(new char[] { '_' }, 
            StringSplitOptions.RemoveEmptyEntries).ToArray();
        
        switch (but.ID[4])
        {
            case 'P':
                par = "r";
                break;
            case 'C':
                par = "c";
                break;
            case 'L':
                par = "l";
                break;
        }
        //flag = true;
        Response.Redirect("CarriageView.aspx?carType=" + par + "&trainId=" + trainInfo.GetValue(3).ToString()
            + "&trainNum=" + trainInfo.GetValue(2).ToString());
        //Response.Redirect("CarriageView.aspx?carType=" + but.ID[4] + "&trainId=" + trainId);
    }
}