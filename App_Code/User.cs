using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Type { get; set; }

    public User(int id, string email, string password, string name, string surname, string phone, string type)
    {
        Id = id;
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        Phone = phone;
        Type = type;
    }

    public User(string email, string password, string name, string surname, string phone, string type)
    {
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        Phone = phone;
        Type = type;
    }
}