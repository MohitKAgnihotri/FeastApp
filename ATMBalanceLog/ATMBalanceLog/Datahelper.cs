using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ATMBalanceLog
{
    class Datahelper
    {
        public MySqlConnection connection;
        public Datahelper()
        {
            string connectionInfo = "server=studmysql01.fhict.local;" +
                               "database=dbi412627;" +
                               "user id=dbi412627;" +
                               "password=wolf2019;" +
                               "connect timeout=45;";

            connection = new MySqlConnection(connectionInfo);
        }
        public string CheckUser(int userId)
        {
            try
            {
                string fn = "";
                string sql = $@"SELECT firstname FROM users where user_id = '{userId}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    fn =reader[0].ToString();
                }
                if (fn != "")
                {
                    reader.Close();
                    return "ok";
                }
                else
                {
                    reader.Close();
                    return "no";
                }

            }
            catch
            {
                return "no";

            }
            finally
            {
                connection.Close();
            }
        }

        public string AddBalanceToUser(int balance,int userId,int atmLogId,string date)
        {
            try
            {
                int visitorBalance = 0;
                string sql = $@"SELECT Balance FROM event_account WHERE User_ID = '{userId}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() != "")
                    {
                        visitorBalance = Convert.ToInt32(reader[0].ToString());
                    }
                }
                reader.Close();

                visitorBalance += balance;
                sql = $@"UPDATE event_account SET Balance = '{visitorBalance}' WHERE User_ID= '{userId}' ; ";
                command = new MySqlCommand(sql, connection);
                int number = 0;

                number = Convert.ToInt32(command.ExecuteNonQuery());
                if (number != 0)
                {
                    sql = $@"INSERT INTO atm_log (Log_ID,Date,Money_Transferred) VALUES ('{atmLogId}', '{date}', '{balance}')";
                    command = new MySqlCommand(sql, connection);
                    int num = 0;

                    num = Convert.ToInt32(command.ExecuteNonQuery());
                    if (num != 0)
                    {
                        return "added";
                    }
                    else
                    {
                        return "no";
                    }
                }
                else
                {
                    return "no";
                }
            }
            catch
            {
                return "Error";

            }
            finally
            {

                connection.Close();

            }
        }
    }
}
