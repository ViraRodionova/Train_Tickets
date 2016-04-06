using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Train
/// </summary>
public abstract class Component
{
    protected bool isFree;
    public int number;

    protected Component(int number)
    {
        this.number = number;
        this.isFree = true;
    }

    public abstract void AddComponent(Component c);
    public abstract void RemoveComponent(Component c);
    public abstract int CountFreePlaces();
}

public class Train : Component
{
    public List<Component> carriages = new List<Component>();

    public Train(int number) : base(number) { }

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

        if (res == 0) isFree = false;
        return res;
    }

    public override void RemoveComponent(Component c)
    {
        carriages.Remove(c);
    }
}

class Carriage : Component
{
    List<Component> places = new List<Component>();
    public int type;
    //0 - плацкарт
    //1 - купе
    //2 - люкс

    public Carriage(int type, int number) : base(number)
    {
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

        if (res == 0) isFree = false;
        return res;
    }

    public override void RemoveComponent(Component c)
    {
        places.Remove(c);
    }
}

class Place : Component
{
    public Place(int number) : base(number) { }

    public override void AddComponent(Component c) { }

    public override int CountFreePlaces()
    {
        if (isFree) return 1;
        return 0;
    }

    public override void RemoveComponent(Component c) { }
}