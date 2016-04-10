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

    protected void Page_Load(object sender, EventArgs e)
    {
        if(flag) SetTrains();
        pnlTrains.Controls.Add(trainsPanel);
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
        }

        pnlTrains.Controls.Add(trainsPanel);
        Page.DataBind();
    }
}