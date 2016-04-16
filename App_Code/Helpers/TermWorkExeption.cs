using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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