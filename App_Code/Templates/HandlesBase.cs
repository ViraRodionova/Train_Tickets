using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for HandlesBase
/// </summary>
public abstract class HandlerBase
{
    protected static HandlerBase _successor;

    public HandlerBase Successor
    {
        set { _successor = value; }
    }

    public abstract void ResolveProblem(Page page, Control control, string message);
}

public class LoginError : HandlerBase
{
    static LoginError()
    {
        _successor = new NoOrdersError();
    }

    public override void ResolveProblem(Page page, Control control, string message)
    {
        if (page.Session["email"] == null)
        {
            page.Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control, message);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Ви не авторизувалися на сайті. Перейдіть на сторінку \"Увійти\" й увійдіть на сайт" });
        }
    }
}

public class NoOrdersError : HandlerBase
{
    static NoOrdersError()
    {
        _successor = null;
    }

    public override void ResolveProblem(Page page, Control control, string message)
    {
        if(page.Session["orders"] == null)
        {
            control.Controls.Add(new Label { Text = "Ваш кошик порожній" });
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control, message);
        }
    }
}