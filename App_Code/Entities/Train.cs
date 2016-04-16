using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Train
/// </summary>
public abstract class Component
{
    public int Id { get; set; }
    public bool IsFree { get; set; }

    public Component(int id)
    {
        this.Id = id;
        this.IsFree = true;
    }

    public Component(int id, bool free)
    {
        this.Id = id;
        this.IsFree = free;
    }

    public abstract void AddComponent(Component c);
    public abstract void RemoveComponent(Component c);
    public abstract int CountFreePlaces();
    public abstract Place GetPlace(int carrNum, int placeNum);
}

//Composit
public class Train : Component
{
    public string TrainNum { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    
    public List<Component> carriages = new List<Component>();

    public Train(int Id, string trainNum, DateTime departureDate, DateTime arrivalDate) :base(Id)
    {
        TrainNum = trainNum;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
    }

    public override void AddComponent(Component c)
    {
        carriages.Add(c);
    }

    public override int CountFreePlaces()
    {
        int res = 0;

        foreach (Component c in carriages)
        {
            res += c.CountFreePlaces();
        }

        if (res == 0) IsFree = false;
        return res;
    }

    public override void RemoveComponent(Component c)
    {
        carriages.Remove(c);
    }

    public override Place GetPlace(int carrNum, int placeNum)
    {
        Place res = null;

        foreach(Component p in carriages)
        {
            res = p.GetPlace(carrNum, placeNum);
            if (res != null) return res;
        }

        return res;
    }
}

//Composit
public class Carriage : Component
{
    public int num { get; set; }
    public char type { get; set; }

    public List<Component> places = new List<Component>();
    
    //П - плацкарт
    //К - купе
    //Л - люкс
    
    public Carriage(int Id, int num, char type) : base(Id)
    {
        this.num = num;
        this.type = type;
    }

    public override void AddComponent(Component c)
    {
        places.Add(c);
    }

    public override int CountFreePlaces()
    {
        int res = 0;

        foreach (Component c in places)
        {
            res += c.CountFreePlaces();
        }

        if (res == 0) IsFree = false;
        return res;
    }

    public override void RemoveComponent(Component c)
    {
        places.Remove(c);
    }

    public override Place GetPlace(int carrNum, int placeNum)
    {
        Place res = null;

        foreach (Component p in places)
        {
            if (this.num == carrNum)
            {
                res = p.GetPlace(carrNum, placeNum);
                if (res != null) return res;
            }
        }

        return res;
    }
}

//Leaf
public class Place : Component
{
    public int num { get; set; }
    public double Price { get; set; }

    public Place(int Id, int num, double price) : base(Id)
    {
        this.num = num;
        this.Price = price;
    }

    public Place(int Id, int num, double price, bool free) : base(Id, free)
    {
        this.num = num;
        this.Price = price;
    }

    public override void AddComponent(Component c) { }

    public override int CountFreePlaces()
    {
        if (IsFree) return 1;
        return 0;
    }

    public override void RemoveComponent(Component c) { }

    public override Place GetPlace(int carrNum, int placeNum)
    {
        if (this.num == placeNum) return this;
        return null;
    }
}