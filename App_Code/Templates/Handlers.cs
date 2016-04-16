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

    public abstract void ResolveProblem(Page page, Control control);
}

public class LoginError : HandlerBase
{
    public LoginError()
    {
        _successor = new NoInCartError();
    }
    public override void ResolveProblem(Page page, Control control)
    {
        if (page.Session["email"] == null)
        {
            page.Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Сталася невідома помилка", ForeColor=System.Drawing.Color.Red });
        }
    }
}

public class NoInCartError : HandlerBase
{
    public NoInCartError()
    {
        //_successor = new NoTrainsError();
        _successor = new NoInDBError();
    }

    public override void ResolveProblem(Page page, Control control)
    {
        string[] str = page.Request.RawUrl.Split(new char[] { '/', '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        if(str[str.Count<string>() - 2] == "Cart")
        {
            control.Controls.Add(new Label { Text = Language.GetLang().Handler_NoClientOrders() });
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Сталася невідома помилка", ForeColor = System.Drawing.Color.Red });
        }
    }
}

public class NoTrainsError : HandlerBase
{
    public NoTrainsError()
    {
        _successor = new NoInDBError();
    }

    public override void ResolveProblem(Page page, Control control)
    {
        string[] str = page.Request.RawUrl.Split(new char[] { '/', '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        if (str[str.Count<string>() - 2] == "SearchResult")
        {
            control.Controls.Add(new Label { Text = Language.GetLang().SearchRes_NoTrains() });
        }
        else if (_successor != null)
        {
            _successor.ResolveProblem(page, control);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Сталася невідома помилка", ForeColor = System.Drawing.Color.Red });
        }
    }
}

public class NoInDBError : HandlerBase
{
    public NoInDBError()
    {
        _successor = null;
    }
    public override void ResolveProblem(Page page, Control control)
    {
        string[] str = page.Request.RawUrl.Split(new char[] { '/', '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        if (str[str.Count<string>() - 2] == "PersonalPage")
        {
            control.Controls.Add(new Label { Text = Language.GetLang().Handler_NoOrdersInDB() });
        }
        else if(_successor != null)
        {
            _successor.ResolveProblem(page, control);
        }
        else
        {
            control.Controls.Add(new Label { Text = "Сталася невідома помилка", ForeColor = System.Drawing.Color.Red });
        }
    }
}