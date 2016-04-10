using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Builder
/// </summary>
public abstract class Builder
{
    private Train train;

    public Builder(Train train)
    {
        this.train = train;
    }

    public abstract Panel SetPanelRoute();
    public abstract Panel SetPanelDeparture();
    public abstract Panel SetPanelArrival();
    public abstract Panel SetPanelPlaces();
    public abstract Panel SetCarriage();
    public abstract Panel GetTrainInfo();
}