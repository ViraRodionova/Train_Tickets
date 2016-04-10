using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for CarriagePrototype
/// </summary>
public abstract class CarriagePrototype
{
    //Carriage carriage;
    public Panel panel;

    public CarriagePrototype()
    {
        //this.carriage = carriage;
        this.panel = new Panel();
    }

    public void CheckFreePlaces(Carriage carriage)
    {
        foreach (Place place in carriage.places)
        {
            if (!place.IsFree)
            {
                FindPlace(place.num, panel);
            }
        }
    }

    private void FindPlace(int num, Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c.GetType() == typeof(Button))
            {
                if (c.ID[c.ID.Length - 1] == num)
                {
                    ((Button)c).CssClass = "closed";
                    ((Button)c).Enabled = false;
                }
            }
            else
                FindPlace(num, c);
        }
    }

    public CarriagePrototype Clone()
    {
        return (CarriagePrototype)this.MemberwiseClone();
    }
}

class CarriageReserved : CarriagePrototype
{
    public CarriageReserved()
    {
        for(int i = 1; i < 55; i++)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceReservedA",
                //ID = "place_" + i.ToString()
            };
            panel.Controls.Add(place);
        }
    }    
}

class CarriageCoupe : CarriagePrototype
{
    public CarriageCoupe()
    {
        for (int i = 1; i < 37; i++)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceCoupe",
                //ID = "place_" + i.ToString()
            };
            panel.Controls.Add(place);
        }
    }
}

class CarriageLux : CarriagePrototype
{
    public CarriageLux()
    {
        for (int i = 1; i < 21; i++)
        {
            Button place = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceLux",
                //ID = "place_" + i.ToString()
            };
            panel.Controls.Add(place);
        }
    }
}

public class PrototypeManager
{
    private static Hashtable carriagesMap = new Hashtable();

    public static CarriagePrototype GetCarriage(string carrCode, Carriage current)
    {
        CarriagePrototype carr = (CarriagePrototype)carriagesMap[carrCode];
        carr.CheckFreePlaces(current);
        return carr.Clone();
    }

    static PrototypeManager()
    {
        CarriageReserved cr = new CarriageReserved();
        carriagesMap["reserved"] = cr;
        CarriageCoupe cc = new CarriageCoupe();
        carriagesMap["coupe"] = cc;
        CarriageLux cl = new CarriageLux();
        carriagesMap["lux"] = cl;
    }
}