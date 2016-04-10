using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for ControlsFinder
/// </summary>
public class ControlsFinder<T> where T : Control
{
    private readonly List<T> foundControls = new List<T>();
    public List<T> FoundControls
    {
        get { return foundControls; }
    }

    public void FindControlsRecursive(Control control)
    {
        foreach (Control childControl in control.Controls)
        {
            if (childControl.GetType() == typeof(T))
                foundControls.Add((T)childControl);
            else
                FindControlsRecursive(childControl);
        }
    }
}