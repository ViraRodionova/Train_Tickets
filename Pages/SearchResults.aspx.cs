using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_SearchResults : System.Web.UI.Page
{
    private static List<Train> trains = new List<Train>();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetTrains(Request.QueryString["stFrom"], Request.QueryString["stTo"], Request.QueryString["date"]);
        SetTrains();
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
        foreach(Train train in trains)
        {
            List<string> route = ConnectionClass.GerFullRouteByTrain(train.TrainNum);

            Panel p_train = new Panel();
            Label lblNum = new Label { Text = train.TrainNum };
            Literal l1 = new Literal { Text = "<br />" };
            Label lblRoute = new Label { Text = string.Format(route[0] + "-" + route[route.Count - 1]) };
            Literal l2 = new Literal { Text = "<br />" };
            LinkButton linkFullRoute = new LinkButton
            {
                ID = string.Format("lb" + train.Id),
                Text = "Показати повний шлях"
            };

            Label dep_date = new Label
            {
                Text = string.Format(Convert.ToDateTime(train.DepartureDate).ToString()
                + Request.QueryString["stFrom"])
            };
            Label arr_date = new Label
            {
                Text = string.Format(Convert.ToDateTime(train.ArrivalDate).ToString()
                + Request.QueryString["stTo"])
            };
 
            int free_P = 0;
            int free_K = 0;
            int free_L = 0;

            foreach (Carriage carr in train.carriages)
            {
                if (carr.type == 'П') free_P += carr.CountFreePlaces();
                else if (carr.type == 'К') free_K += carr.CountFreePlaces();
                else if (carr.type == 'Л') free_L += carr.CountFreePlaces();
            }
            
            p_train.Controls.Add(lblNum);
            if(free_P > 0)
            {
                Label lblP = new Label { Text = string.Format("Плацкарт: {0}", free_P) };
                Button btnP = new Button
                {
                    ID = string.Format("btnP" + train.Id),
                    Text = "Вибрати"
                };
                p_train.Controls.Add(lblP);
                p_train.Controls.Add(btnP);
            }
            p_train.Controls.Add(l1);

            p_train.Controls.Add(lblRoute);
            p_train.Controls.Add(dep_date);
            p_train.Controls.Add(arr_date);
            if (free_K > 0)
            {
                Label lblK = new Label { Text = string.Format("Купе: {0}", free_K) };
                Button btnK = new Button
                {
                    ID = string.Format("btnK" + train.Id),
                    Text = "Вибрати"
                };
                p_train.Controls.Add(lblK);
                p_train.Controls.Add(btnK);
            }
            p_train.Controls.Add(l2);

            if (free_L > 0)
            {
                Label lblL = new Label { Text = string.Format("Купе: {0}", free_L) };
                Button btnL = new Button
                {
                    ID = string.Format("btnL" + train.Id),
                    Text = "Вибрати"
                };
                p_train.Controls.Add(lblL);
                p_train.Controls.Add(btnL);
            }

            pnlTrains.Controls.Add(p_train);
        }
        Page.DataBind();
    }
}