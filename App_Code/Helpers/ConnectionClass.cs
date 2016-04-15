using System;
using System.Collections;
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

    public static ArrayList ListOfCarriagesID()
    {
        string query = "SELECT * FROM carriages";
        command.CommandText = query;
        ArrayList list = new ArrayList();

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

        if (list.Count == 0) return null;
        return list;
    }

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

    public static ArrayList GetTrainsNums(string st_from, string st_to)
    {
        ArrayList trains = new ArrayList();

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

    public static ArrayList GetTrainIDs(ArrayList train_nums, DateTime date)
    {
        ArrayList train_ids = new ArrayList();
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
                reader.Close();
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
        if (train_ids.Count == 0) return null;
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

    public static ArrayList GerFullRouteByTrain(string train_num)
    {
        string query = string.Format(@"SELECT station FROM routes
                                       WHERE train_num = '{0}'
                                       ORDER BY st_order", train_num);
        ArrayList stations = new ArrayList();

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                stations.Add(reader.GetString(0));
            }
        }
        finally
        {
            conn.Close();
        }
        return stations;
    }

    public static User LogInUser(string login, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", login);
        command.CommandText = query;
        //command.Parameters.Clear();

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if passwords match
                query = string.Format("SELECT password FROM users WHERE email = '{0}'", login);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    query = string.Format("SELECT name, surname, phone, type FROM users WHERE email = '{0}'", login);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string surname = reader.GetString(1);
                        string phone = reader.GetString(2);
                        string type = reader.GetString(3);

                        user = new User(login, password, name, surname, phone, type);
                        return user;
                    }
                }
            }
        }
        finally
        {
            conn.Close();
        }

        return null;
    }

    public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", user.Email);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User doesn't exists
                query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    user.Email, user.Password, user.Name, user.Surname, user.Phone, user.Type);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return Language.GetLang().ConnClass_RegisterUserOk();
            }
            else return Language.GetLang().ConnClass_RegisterUserFail();
        }
        finally
        {
            conn.Close();
        }
    }

    public static void AddOrders(List<Order> orders)
    {
        try
        {
            command.CommandText = "INSERT INTO orders VALUES (@client, @trainId, @trainNum, @carriage, @place, @date)";
            conn.Open();

            foreach (Order order in orders)
            {
                command.Parameters.Add(new SqlParameter("@client", order.UserEmail));
                command.Parameters.Add(new SqlParameter("@trainId", order.TrainId));
                command.Parameters.Add(new SqlParameter("@trainNum", order.TrainNum));
                command.Parameters.Add(new SqlParameter("@carriage", order.CarriageNum));
                command.Parameters.Add(new SqlParameter("@place", order.PlaceNum));
                command.Parameters.Add(new SqlParameter("@date", order.Date));

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static void UpdateFreePlaces(List<Order> orders)
    {
        try
        {
            command.CommandText = string.Format(@"
                                        UPDATE places
                                        SET is_free=@isFree
                                        WHERE carriage_id = (
	                                    SELECT id FROM carriages
	                                    WHERE train_id = @trainId
	                                    AND num = @carrNum)
                                        AND num = @placeNum");
            conn.Open();

            foreach (Order order in orders)
            {
                command.Parameters.Add(new SqlParameter("@isFree", false));
                command.Parameters.Add(new SqlParameter("@trainId", order.TrainId));
                command.Parameters.Add(new SqlParameter("@carrNum", order.CarriageNum));
                command.Parameters.Add(new SqlParameter("@placeNum", order.PlaceNum));
                
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static ArrayList GetUserOrders(string _client_email)
    {
        string query = string.Format(@"SELECT * FROM orders
                                        WHERE client_email='{0}'", _client_email);
        command.CommandText = query;
        ArrayList orderList = new ArrayList();

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string client_email = reader.GetString(1);
                int train_id = reader.GetInt32(2);
                string train_num = reader.GetString(3);
                int carr_num = reader.GetInt32(4);
                int place_num = reader.GetInt32(5);
                DateTime date = reader.GetDateTime(6);

                Order order = new Order(client_email, train_id, train_num, carr_num, place_num, date);
                orderList.Add(order);
            }

        }
        finally
        {
            conn.Close();
        }

        if (orderList.Count == 0) return null;
        return orderList;
    }
}