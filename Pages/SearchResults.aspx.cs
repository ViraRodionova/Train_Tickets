using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchResults : System.Web.UI.Page
{
    private List<Train> trains;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetTrains(Request.QueryString["stFrom"], Request.QueryString["stTo"], Request.QueryString["date"]);
    }

    private void SetTrains(string from, string to, string _date)
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

            trains.Add(_train);
        }
    }
}