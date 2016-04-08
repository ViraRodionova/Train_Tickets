﻿using System;
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

    public static void InsertPlaces(int p_num, int c_id)
    {
        string query = string.Format("INSERT INTO places VALUES ('{0}', '{1}', '{2}')", c_id, p_num, true);
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

    public static List<Carriage> ListOfCarriagesID()
    {
        string query = "SELECT * FROM carriages";
        command.CommandText = query;
        List<Carriage> list = new List<Carriage>();

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int train_id = reader.GetInt32(1);
                int num = reader.GetInt32(2);
                string type = reader.GetString(3);

                Carriage car = new Carriage(id, num, type[0]);
                list.Add(car);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    [System.Web.Script.Services.ScriptMethod()]
    public static string[] GetStations(string st_name)
    {
        List<string> stations = new List<string>();
        string query = string.Format("SELECT DISTINCT station FROM routes WHERE station LIKE '{0}%'", st_name);
        command.CommandText = query;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            //int i = 0;
            while (reader.Read())
            {
                string station = reader.GetString(0);
                //i++;
                stations.Add(station);
                //stations.Add(reader.ToString());
            }
        }
        finally
        {
            conn.Close();
        }
        return stations.ToArray();
    }



    public static List<string> GetTrainsNums(string st_from, string st_to)
    {
        List<string> trains = new List<string>();

        string query = string.Format(@"SELECT train_num
                                        FROM routes
                                        WHERE station = '{0}'
                                        AND train_num in (
                                            select train_num from routes
                                            where station = '{1}')", st_from, st_to);
        command.CommandText = query;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                trains.Add(reader.GetString(0));
            }

        }
        finally
        {
            conn.Close();
        }
        return trains;
    }

    public static List<int> GetTrainIDs(List<string> train_nums, DateTime date)
    {
        List<int> train_ids = new List<int>();
        string query;
        //string query = string.Format(@"SELECT id FROM trains
        //                                WHERE train_num IN ({0}
        //                                AND departure_date = @date)", help1);
        try
        {
            conn.Open();
            //command.Parameters.Add(new SqlParameter("@date", date));
            foreach (string train in train_nums)
            {
                query = string.Format(@"SELECT id FROM trains
                                        WHERE train_num='{0}' AND departure_date=@date", train);
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@date", date));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    train_ids.Add(reader.GetInt32(0));
                }
                command.Parameters.Clear();
            }

            //command.CommandText = query;
            
            //SqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    train_ids.Add(reader.GetInt32(0));
            //}

        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
        return train_ids;
    }

    public static List<Component> GetCarriagiesByTrainId(int train_id)
    {
        List<Component> carriges = new List<Component>();
        string query = string.Format(@"SELECT * FROM carriages
                                        WHERE train_id='{0}'", train_id);
        command.CommandText = query;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int tr_id = reader.GetInt32(1);
                int num = reader.GetInt32(2);
                string type = reader.GetString(3);

                Carriage car = new Carriage(id, num, type[0]);
                carriges.Add(car);
            }
        }
        finally
        {
            conn.Close();
        }
        
        return carriges;
    }

    public static List<Component> GetPlacesByCarriageId(int c_id)
    {
        List<Component> places = new List<Component>();
        string query = string.Format(@"SELECT * FROM places
                                        WHERE carriage_id='{0}'", c_id);
        command.CommandText = query;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int car_id = reader.GetInt32(1);
                int num = reader.GetInt32(2);
                bool isFree = reader.GetBoolean(3);

                Place place = new Place(id, num, isFree);
                places.Add(place);
            }
        }
        finally
        {
            conn.Close();
        }

        return places;
    }

    public static Train GetTrainById(int _id)
    {
        string query = string.Format("SELECT * FROM trains WHERE id='{0}'", _id);
        Train train = null;

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string train_num = reader.GetString(1);
                DateTime d_d = reader.GetDateTime(2);
                DateTime a_d = reader.GetDateTime(3);

                train = new Train(id, train_num, d_d, a_d);
            }
        }
        finally
        {
            conn.Close();
        }
        return train;
    }
}