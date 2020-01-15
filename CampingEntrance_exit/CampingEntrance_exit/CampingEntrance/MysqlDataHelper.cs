using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CampingEntrance
{
    class MysqlDataHelper
    {
        public MySqlConnection connection;
        public int user_id = -1;
        public List<string> Camping_spots;

        public MysqlDataHelper()
        {
            string connection_details = " server = studmysql01.fhict.local; " +
                             "database = dbi412627;" +
                             "userid  =dbi412627;" +
                             "password =wolf2019;" +
                             "connect timeout=45;";

            connection = new MySqlConnection(connection_details);
        }
        public int GetUser_idWithRfid(string rfid)
        {
            try
            {

                string sql = $@"SELECT user_id FROM users where rfid = '{rfid}';";
                MySqlCommand comm = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    user_id = int.Parse(reader[0].ToString());
                }
                if (user_id != -1)
                {
                    reader.Close();
                    return user_id;
                }
                else
                {
                    reader.Close();
                    return -1;
                }

            }
            catch
            {
                return -1;

            }
            finally
            {

                connection.Close();

            }
        }
        public string GetUserNameWithRfid(string rfid)
        {
            try
            {
                string f_name = "";
                string sql = $@"SELECT firstname FROM users where rfid = '{rfid}';";
                MySqlCommand comm = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    f_name = reader[0].ToString();
                }
                if (f_name != "")
                {
                    reader.Close();
                    return f_name;
                }
                else
                {
                    reader.Close();
                    return "";
                }
            }
            catch
            {
                return "somthing wrong happened!!!";
            }
            finally
            {
                connection.Close();
            }
        }

        public string Getfirst_nameWithUserId(int user_id)
        {
            try
            {
                string first_name = "";
                string sql = $@"SELECT firstname FROM users where user_id = '{user_id}';";
                MySqlCommand comm = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    first_name = reader[0].ToString();
                }
                if (first_name != "")
                {
                    reader.Close();
                    return first_name;
                }
                else
                {
                    reader.Close();
                    return "";
                }

            }
            catch
            {
                return "somthing wrong happened!!!";

            }
            finally
            {

                connection.Close();

            }
        }

        public string GetCamping_StatusWithRfid(string rfid)
        {
            try
            {
                string Camping_status = "";
                string isExist = "";

                string sql = $@"SELECT Camping_Status,Camping_Spot_ID FROM event_account where  User_ID  = '{GetUser_idWithRfid(rfid)}';";
                MySqlCommand comm = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    isExist = reader[0].ToString();
                    Camping_status = reader[1].ToString();
                }
                if (isExist != "")
                {
                    if (Camping_status == "in")
                    {
                        reader.Close();
                        return "in";
                    }
                    else if (Camping_status == "out")
                    {
                        reader.Close();
                        return "out";
                    }
                    else
                    {
                        reader.Close();
                        return "camping spot booked " + isExist;
                    }
                }
                else
                {
                    reader.Close();
                    return "The camp does not exist";
                }
            }
            catch
            {
                return "somthing wrong happened!!!";

            }
            finally
            {

                connection.Close();

            }
        }

        public string VisitorChickIn()
        {
            try
            {

                if (user_id != -1)
                {

                    string Camping_status = "";
                    string isExist = "";
                    string ev_status = "";
                    string sql = $@"SELECT Camping_Status,Camping_Spot_ID,Visitor_Status FROM event_account WHERE User_ID ='{user_id}' ; ";
                    MySqlCommand comm = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        ev_status = reader[0].ToString();
                        isExist = reader[1].ToString();
                        Camping_status = reader[2].ToString();
                    }
                    if (ev_status == "in")
                    {
                        if (isExist != "")
                        {
                            if (Camping_status == "in")
                            {
                                return "in";
                            }
                        }
                        else
                        {
                            return "The camp does not exist";
                        }
                    }
                    else
                    {
                        return "The visitor is not at the event";
                    }
                    reader.Close();

                    sql = $@"UPDATE event_account SET Camping_Status = 'in' WHERE User_ID = '{user_id}' ; ";
                    comm = new MySqlCommand(sql, connection);

                    int Num = 0;

                    Num = Convert.ToInt32(comm.ExecuteNonQuery());
                    if (Num != 0)
                    {
                        return "Checked";
                    }
                    else
                    {
                        return "somthing wrong happened!!!";
                    }
                }
                else
                {
                    return "There is no user found with that ID";
                }

            }
            catch
            {
                return "somthing wrong happened!!!";

            }
            finally
            {

                connection.Close();

            }
        }
        public string VisitorCheckOut()
        {
            try
            {

                if (user_id != -1)
                {

                    string Camping_status = "";
                    string isExist = "";
                    string ev_status = "";
                    string sql = $@"SELECT Camping_Status,Camping_Spot_ID,Visitor_Status FROM event_account WHERE User_ID ='{user_id}' ; ";
                    MySqlCommand comm = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        ev_status = reader[0].ToString();
                        isExist = reader[1].ToString();
                        Camping_status = reader[2].ToString();
                    }
                    if (ev_status == "in")
                    {
                        if (isExist != "")
                        {
                            if (Camping_status == "out")
                            {
                                return "out";
                            }
                        }
                        else
                        {
                            return "The camp does not exist";
                        }
                    }
                    else
                    {
                        return "The visitor is not at the event";
                    }

                    reader.Close();
                    // change the status of the visitor to in 
                    sql = $@"UPDATE event_account SET Camping_Status = 'in' WHERE User_ID = '{user_id}' ; ";
                    comm = new MySqlCommand(sql, connection);

                    int number = 0;

                    number = Convert.ToInt32(comm.ExecuteNonQuery());
                    if (number != 0)
                    {
                        return "Checked";
                    }
                    else
                    {
                        return "somthing wrong happened!!!";
                    }
                }
                else
                {
                    return "There is no user found with that ID";
                }

            }
            catch
            {
                return "somthing wrong happened!!!";

            }
            finally
            {

                connection.Close();

            }
        }
        public void CampingSpotAvailability()
        {
            Camping_spots = new List<string>();
            try
            {

                string sql = $@"SELECT 	Camping_Spot_ID FROM camping WHERE booked = '0';";
                MySqlCommand comm = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {

                    Camping_spots.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch
            {
                string exception = "somthing wrong happened!!!";
            }
            finally
            {
                connection.Close();
            }
        }


        public string GroupUsersAssignedToTheCamping(int user_1, int user_2, int user_3, int user_4, int user_5, int user_6, int camping_spot_id)
        {
            try
            {
                List<int> users_id = new List<int>();
                users_id.Add(user_1);
                users_id.Add(user_2);
                users_id.Add(user_3);
                users_id.Add(user_4);
                users_id.Add(user_5);
                users_id.Add(user_6);

                string procedure = "";

                for (int i = 0; i < users_id.Count(); i++)
                {
                    int balance = 0;
                    string sql = $@"SELECT Balance FROM event_account WHERE User_ID = '{users_id[i]}';";
                    MySqlCommand comm = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0].ToString() != "")
                        {
                            balance = Convert.ToInt32(reader[0].ToString());
                        }
                    }
                    reader.Close();
                    if (balance >= 50)
                    {
                        balance = balance - 50;
                        int money_spent = 0;
                        sql = $@"SELECT Money_Spent FROM event_account WHERE User_ID = '{users_id[i]}';";
                        comm = new MySqlCommand(sql, connection);
                        reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader[0].ToString() != "")
                            {
                                money_spent = Convert.ToInt32(reader[0].ToString()) + 60;
                            }
                            else
                            {
                                money_spent = 50;
                            }
                        }
                        reader.Close();
                        sql = $@"UPDATE event_account SET Camping_Status ='in',Camping_SpotID = '{camping_spot_id}'
                             WHERE User_ID = '{users_id[i]}';";
                        comm = new MySqlCommand(sql, connection);

                        int Num = 0;

                        Num = Convert.ToInt32(comm.ExecuteNonQuery());
                        if (Num != 0)
                        {
                            sql = $@"UPDATE event_account SET Money_Spent = '{money_spent}',Balance = '{balance}' WHERE User_ID = '{users_id[i]}'; ";
                            comm = new MySqlCommand(sql, connection);

                           Num = 0;

                            Num = Convert.ToInt32(comm.ExecuteNonQuery());
                            if (Num != 0)
                            {
                                sql = $@"UPDATE camping SET booked = '1' WHERE 	Camping_Spot_ID  = '{camping_spot_id}'; ";
                                comm = new MySqlCommand(sql, connection);

                                Num = 0;

                                Num = Convert.ToInt32(comm.ExecuteNonQuery());
                                if (Num != 0)
                                {
                                    procedure = "ok";
                                }
                                else
                                {
                                    procedure = "somthing wrong happened!!!";
                                    break;
                                }
                            }
                            else
                            {
                                procedure = "somthing wrong happened!!!";
                                break;
                            }
                        }
                        else
                        {
                            procedure = "somthing wrong happened!!!";
                            break;
                        }
                    }
                    else
                    {
                        int count = 0;

                        for (int j = 0; j < i; j++)
                        {
                            if (users_id[j] == users_id[i])
                            {
                                count++;
                            }
                        }
                        connection.Close();
                        if (count == 0)
                        {
                            procedure += Getfirst_nameWithUserId(users_id[i]) + ",";
                        }
                    }
                }

                if (procedure == "ok")
                {
                    string sql = $@"UPDATE camping SET booked = '1' WHERE Camping_Spot_ID  = '{camping_spot_id}'; ";
                    MySqlCommand comm = new MySqlCommand(sql, connection);

                    int number = 0;

                    number = Convert.ToInt32(comm.ExecuteNonQuery());
                    if (number != 0)
                    {
                        return "Succefuly Registered";
                    }
                    else
                    {
                        return procedure;
                    }
                }
                else if (procedure == "somthing wrong happened!!!")
                {
                    return "somthing wrong happened!!!";
                }
                else
                {
                    int end = procedure.LastIndexOf(',');

                    return procedure.Substring(0, end).Replace(",", " and ") + " : not enough balance";
                }
            }
            catch
            {
                return "somthing wrong happened!!!";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

