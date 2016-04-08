using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectionClass
/// </summary>
public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectString = ConfigurationManager.ConnectionStrings["Tickets_DBConnectionString"].ToString();
        conn = new SqlConnection(connectString);
        command = new SqlCommand("", conn);
    }

    public static void InsertPlaces(int id, int p_num, int c_id)
    {
        string query = string.Format("INSERT INTO places VALUES ('{0}', '{1}', '{2}', '{3}')", id, c_id, p_num, true);
        command.CommandText = query;

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }
}