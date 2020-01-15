using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ATM
{
    class Datahelper
    {
        public MySqlConnection connection;
        public int userId = -1;
        public Datahelper()
        {
            string connectionInfo = "server=studmysql01.fhict.local;" +
                               "database=dbi412627;" +
                               "user id=dbi412627;" +
                               "password=wolf2019;" +
                               "connect timeout=45;";

            connection = new MySqlConnection(connectionInfo);
        }

        public string GetUserFirstNameWithRfid(string user_rfid)
        {
            try
            {
                userId = GetUserIdWithRfid(user_rfid);
                if (userId != -1)
                {
                    string name = "";
                    string sql = $@"SELECT firstname FROM users where rfid  = '{user_rfid}';";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader[0].ToString();
                    }
                    if (name != "")
                    {
                        reader.Close();
                        return name;
                    }
                    else
                    {
                        reader.Close();
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch
            {
                return "error";
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetUserIdWithRfid(string user_rfid)
        {
            try
            {

                string sql = $@"SELECT user_id FROM users where rfid  = '{user_rfid}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userId = int.Parse(reader[0].ToString());
                }
                if (userId != -1)
                {
                    reader.Close();
                    return userId;
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
        public int GetOrAssignAtmLogId(string user_rfid)
        {
            try
            {
                userId = GetUserIdWithRfid(user_rfid);
                if (userId != -1)
                {
                    int atmID = -1;
                    string sql = $@"SELECT IFNULL(ATM_Log_ID,-1) FROM event_account where User_ID = '{userId}';";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        atmID = Convert.ToInt32(reader[0].ToString());
                    }
                    if (atmID != -1)
                    {
                        reader.Close();
                        return atmID;
                    }
                    else
                    {
                        reader.Close();
                        int maxAtmLogId = 0;
                        sql = $@"SELECT MAX(IFNULL(ATM_Log_ID,0)) FROM event_account;";
                        command = new MySqlCommand(sql, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            maxAtmLogId = Convert.ToInt32(reader[0].ToString());
                        }
                        maxAtmLogId++;
                        reader.Close();
                        sql = $@"UPDATE event_account SET ATM_Log_ID = '{maxAtmLogId}' WHERE User_ID= '{userId}' ; ";
                        command = new MySqlCommand(sql, connection);
                        int number = 0;

                        number = Convert.ToInt32(command.ExecuteNonQuery());
                        if (number != 0)
                        {
                            return maxAtmLogId;
                        }
                        else
                        {
                            return -1;
                        }
                     
                    }
                }
                else
                {
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
    }
}

