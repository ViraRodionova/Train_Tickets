using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for TermWorkExeption
/// </summary>
public class TermWorkExeption : Exception
{
    public TermWorkExeption()
    {
    }

    public TermWorkExeption(string message)
        : base(message)
    {
    }

    public TermWorkExeption(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public static class TermWorkExeptionCatched
{
    static HandlerBase handler;
    static TermWorkExeptionCatched()
    {
        //handler = new LoginError();
        handler = new NoTrainsError();
    }

    public static void Start(Page page, Control control)
    {
        handler.ResolveProblem(page, control);
    }
}