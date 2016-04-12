using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int TrainId { get; set; }
    public int CarriageNum { get; set; }
    public int PlaceNum { get; set; }
    public DateTime Date { get; set; }

    public Order(int id, string userEmai, int trainId, int carriageNum, int placeNum, DateTime date)
    {
        Id = id;
        UserEmail = userEmai;
        TrainId = trainId;
        CarriageNum = carriageNum;
        PlaceNum = placeNum;
        Date = date;
    }

    public Order(string userEmai, int trainId, int carriageNum, int placeNum, DateTime date)
    {
        UserEmail = userEmai;
        TrainId = trainId;
        CarriageNum = carriageNum;
        PlaceNum = placeNum;
        Date = date;
    }
}