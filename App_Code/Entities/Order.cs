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
    public string TrainNum { get; set; }
    public int CarriageNum { get; set; }
    public int PlaceNum { get; set; }
    public DateTime Date { get; set; }

    public Order(string userEmail, int trainId, string trainNum, int carriageNum, int placeNum, DateTime date)
    {
        UserEmail = userEmail;
        TrainId = trainId;
        TrainNum = trainNum;
        CarriageNum = carriageNum;
        PlaceNum = placeNum;
        Date = date;
    }
}