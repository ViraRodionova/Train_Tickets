using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DataBase
/// </summary>
public static class DataBase
{
    //public static List<Train> trains;
    public static Hashtable trains = new Hashtable();


    /*public static List<Button> placessButtons = new List<Button>();

    static DataBase()
    {
        for (int i = 1; i < 21; i++)
        {
            Button but = new Button
            {
                Text = i.ToString(),
                CssClass = "PlaceLux"
            };
            but.Click += But_Click;
            placessButtons.Add(but);
        }
    }

    private static void But_Click(object sender, EventArgs e)
    {
        int u = 0;
    }*/
}