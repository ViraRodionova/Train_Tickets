using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchResults : System.Web.UI.Page
{
    private static List<Train> trains = new List<Train>();
    private static bool flag = true;
    private static Panel trainsPanel = new Panel();
    private static List<Button> buttonsList = new List<Button>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(flag) SetTrains();
        pnlTrains.Controls.Add(trainsPanel);
        SetButtons();
    }

    private void GetTrains(string from, string to, string _date)
    {
        DateTime date = Convert.ToDateTime(_date);

        List<string> routes_trains = ConnectionClass.GetTrainsNums(from, to);
        List<int> required_trains = ConnectionClass.GetTrainIDs(routes_trains, date);

        foreach(int id in required_trains)
        {
            Train _train = ConnectionClass.GetTrainById(id);
            _train.carriages = ConnectionClass.GetCarriagiesByTrainId(id);
            
            foreach(Carriage _c in _train.carriages)
            {
                _c.places = ConnectionClass.GetPlacesByCarriageId(_c.Id);
            }

            if(_train.CountFreePlaces() > 0)
                trains.Add(_train);
        }
    }

    private void SetTrains()
    {
        flag = false;
        GetTrains(Request.QueryString["stFrom"], Request.QueryString["stTo"], Request.QueryString["date"]);
        TrainOverviewBuilder bd = new TrainOverviewBuilder(Request.QueryString["stFrom"], Request.QueryString["stTo"]);

        foreach(Train _train in trains)
        {
            trainsPanel.Controls.Add(bd.GenerateTrainInfo(_train));
            SetButtonsEventHandlers(_train.TrainNum, _train.Id);
        }

        DataBase.trains = trains;

        pnlTrains.Controls.Add(trainsPanel);
        Page.DataBind();
    }

    private void SetButtonsEventHandlers(string trainNum, int id)
    {
        Button btnP = new Button
        {
            ID = "btn_P_" + trainNum + "_" + id,
            Text = "Вибрати",
            CausesValidation = false
        };
        Button btnK = new Button
        {
            ID = "btn_K_" + trainNum + "_" + id,
            Text = "Вибрати",
            CausesValidation = false
        };
        Button btnL = new Button
        {
            ID = "btn_L_" + trainNum + "_" + id,
            Text = "Вибрати",
            CausesValidation = false
        };

        buttonsList.Add(btnP);
        buttonsList.Add(btnK);
        buttonsList.Add(btnL);
    }

    private void SetButtons()
    {
        for(int i = 0, p = 0; i < buttonsList.Count;)
        {
            buttonsList[i].Click += ButtonChooseIsClicked;
            trainsPanel.Controls[p].Controls.Add(buttonsList[i]);
            i++;
            if (i % 3 != 0) trainsPanel.Controls[p].Controls.Add(new Literal { Text = "<br />" });
            else p++;
        }
    }


    private void ButtonChooseIsClicked(object sender, EventArgs e)
    {
        lblTest.Text = "HELLO";
        Page.DataBind();
    }

    protected void ButtonIsClicked(object sender, EventArgs e)
    {
        Button but = (Button)sender;
        string par = "";

        switch(but.ID[but.ID.Length - 1])
        {
            case '1':
                par = "reserved";
                break;
            case '2':
                par = "coupe";
                break;
            case '3':
                par = "lux";
                break;
        }

        Response.Redirect("CarriageView.aspx?carType=" + par);
    }
}

