using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Collections;

/// <summary>
/// Summary description for HandlesBase
/// </summary>
public abstract class HandlerBase
{
    protected HandlerBase _successor;

    public HandlerBase Successor
    {
        set { _successor = value; }
    }

    public abstract void ResolveProblem(Page page, Control control, ArrayList list);
}

public class LoginError : HandlerBase
{
    public override void ResolveProblem(Page page, Control control, ArrayList list)
    {
        if (page.Session["email"] == null)
        {
            page.Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control, list);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Ви не авторизувалися на сайті. Перейдіть на сторінку \"Увійти\" й увійдіть на сайт" });
        }
    }
}

public class NoOrdersError : HandlerBase
{
    public override void ResolveProblem(Page page, Control control, ArrayList list)
    {
        if(page.Session["orders"] == null)
        {
            control.Controls.Add(new Label { Text = "Ваш кошик порожній" });
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control, list);
        }
    }
}

public class NoOrdersInDB : HandlerBase
{
    public override void ResolveProblem(Page page, Control control, ArrayList list)
    {
        if(list == null)
        {
            control.Controls.Add(new Label { Text = "У Вас ще не біло замовлень на нашому сайті" });
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control, list);
        }
    }
}