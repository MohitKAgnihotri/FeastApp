using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace EventEntrance
{
    internal class Datahelper
    {
        public MySqlConnection connection;

        //Variable to keep the user's id
        public int userId = -1;

        public Datahelper()
        {
            var connectionInfo = "server=studmysql01.fhict.local;" +
                                 "database=dbi412627;" +
                                 "user id=dbi412627;" +
                                 "password=wolf2019;" +
                                 "connect timeout=45;";

            connection = new MySqlConnection(connectionInfo);
        }

        //Checking if a visitor is existing in the databse with the given barcode
        public string isVistorExsist(string visitor_barcode)

        {
            var name = "";
            try
            {
                //First setting the user's id by the methond
                userId = GetUserIdWithBarcode(visitor_barcode);
                var sql = $@"SELECT firstname FROM users WHERE barcode = '{visitor_barcode}' ;";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) return "reader error";
                while (reader.Read()) name = reader[0].ToString();

                if (name != "")
                    return "yes";
                else
                    return "no";
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

        //Getting the user's id with the given barcode
        public int GetUserIdWithBarcode(string user_barcode)
        {
            try
            {
                var sql = $@"SELECT user_id FROM users where barcode = '{user_barcode}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) userId = int.Parse(reader[0].ToString());
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

        //Getting the user's id with the RFID Code given
        public int GetUserIdWithRfid(string user_rfid)
        {
            try
            {
                var sql = $@"SELECT user_id FROM users where rfid = '{user_rfid}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) userId = int.Parse(reader[0].ToString());
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

        public string GetUserFirstNameWithRfid(string user_rfid)
        {
            try
            {
                var name = "";
                var sql = $@"SELECT firstname FROM users where rfid = '{user_rfid}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) name = reader[0].ToString();
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
            catch
            {
                return "error";
            }
            finally
            {
                connection.Close();
            }
        }

        // Set the RFID Code to the user
        public string GiveRfid(string RFID)
        {
            try
            {
                var name = "";
                var sql = $@"SELECT firstname FROM users where rfid = '{RFID}';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) name = reader[0].ToString();
                if (name != "")
                {
                    reader.Close();
                    return "There is already a user with that RFID";
                }
                else
                {
                    reader.Close();
                    sql = $@"UPDATE users SET rfid = '{RFID}' WHERE user_id = '{userId}' ;";

                    command = new MySqlCommand(sql, connection);
                    var number = 0;
                    number = Convert.ToInt32(command.ExecuteNonQuery());
                    if (number != 0)
                        return "Checked in !";
                    else
                        return "Error Assigning RFID";
                }
            }
            catch
            {
                return "Error!";
            }
            finally
            {
                connection.Close();
            }
        }

        public bool CheckIfUserExistInEventsAccount()
        {
            var status = false;
            try
            {
                //First we check if the user id is set
                if (userId != -1)
                {
                    // Then we check if the visitor is already in the event and if it is we stop
                    var sql = $@"SELECT User_ID FROM event_account WHERE User_ID= '{userId}' ; ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        if (reader.HasRows)
                            status = true;
                    reader.Close();
                }
                else
                {
                    status = false;
                }
            }
            catch
            {
                status = false;
            }
            finally
            {
                connection.Close();
            }

            return status;
        }

        public bool AddUserInEventsAccount(int user_id)
        {
            var status = false;
            try
            {
                var sql = $@"INSERT INTO event_account (User_Id,Balance)
                VALUES ('{user_id}','{0}')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                status = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                status = false;
            }

            return status;
        }

        //Checks in the visitor
        public string CheckInVisitor()
        {
            try
            {
                //First we check if the user id is set
                if (userId != -1)
                {
                    // Then we check if the visitor is already in the event and if it is we stop
                    var status = "";
                    var sql = $@"SELECT Visitor_Status FROM event_account WHERE User_ID= '{userId}' ; ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) status = reader[0].ToString();
                    if (status == "in") return "in";
                    reader.Close();
                    // Set the visitor's status to in
                    sql = $@"UPDATE event_account SET Visitor_Status = 'in' WHERE User_ID= '{userId}' ; ";
                    command = new MySqlCommand(sql, connection);

                    var number = 0;

                    number = Convert.ToInt32(command.ExecuteNonQuery());
                    if (number != 0)
                        return "Checked";
                    else
                        return "Erorr";
                }
                else
                {
                    return "nouser";
                }
            }
            catch
            {
                return "Erorr connection";
            }
            finally
            {
                connection.Close();
            }
        }

        //Cheks out the visitor
        public string CheckOutVisitor(string rfid)
        {
            try
            {
                //First we set the visitor's id
                userId = GetUserIdWithRfid(rfid);
                //Then we check if the visitor's id is set correctly
                if (userId != -1)
                {
                    var itemsLoaned = new List<string>();
                    var sql =
                        $@"SELECT Item_Name FROM rentshop_invoice WHERE User_ID = '{userId}' AND Returned <> Quantity ; ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) itemsLoaned.Add(reader[0].ToString());
                    reader.Close();
                    if (itemsLoaned.Count == 0)
                    {
                        //Then we check if the visitor is in the event
                        var status = "";
                        sql = $@"SELECT Visitor_Status FROM event_account WHERE User_ID = '{userId}' ; ";
                        command = new MySqlCommand(sql, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read()) status = reader[0].ToString();
                        reader.Close();
                        if (status == "in")
                        {
                            sql = $@"UPDATE event_account SET Visitor_Status = 'out' WHERE User_ID= '{userId}' ; ";
                            command = new MySqlCommand(sql, connection);

                            var number = 0;

                            number = Convert.ToInt32(command.ExecuteNonQuery());
                            if (number != 0)
                                return "out";
                            else
                                return "Erorr!";
                        }
                        else
                        {
                            return "notin";
                        }
                    }
                    else
                    {
                        var items = "";
                        foreach (var item in itemsLoaned) items += " " + item;
                        return items;
                    }
                }
                else
                {
                    return "nouser";
                }
            }
            catch
            {
                return "Erorr connection!";
            }
            finally
            {
                connection.Close();
            }
        }

        public string CheckOutVisitorInCaseOfLostRfid(int userID)
        {
            try
            {
                //Then we check if the visitor's id is set correctly
                if (userID != 0)
                {
                    //Then we check if the visitor is in the event
                    var status = "";
                    var sql = $@"SELECT Visitor_Status FROM event_account WHERE User_ID= '{userID}' ; ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) status = reader[0].ToString();
                    reader.Close();
                    if (status == "in")
                    {
                        sql = $@"UPDATE event_account SET Visitor_Status = 'out' WHERE User_ID= '{userID}' ; ";
                        command = new MySqlCommand(sql, connection);

                        var number = 0;

                        number = Convert.ToInt32(command.ExecuteNonQuery());
                        if (number != 0)
                            return "out";
                        else
                            return "Erorr!";
                    }
                    else
                    {
                        return "notin";
                    }
                }
                else
                {
                    return "nouser";
                }
            }
            catch
            {
                return "Erorr connection!";
            }
            finally
            {
                connection.Close();
            }
        }

        //Adding a visitor the the database 
        public string AddCustomer(string fname, string lastname, string password, string email, DateTime dob)
        {
            
            try
            {
                var newUserId = -1;
                var sql = @"SELECT MAX(user_id) FROM users ; ";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) newUserId = Convert.ToInt32(reader[0].ToString()) + 1;
                reader.Close();

                userId = newUserId;

                sql = $@"INSERT INTO users (user_id,firstname,lastname,password,email,dob)
                VALUES ('{newUserId}','{fname}', '{lastname}', '{password}', '{email}','{dob.Year+"-"+dob.Month+"-"+dob.Day}')";

                command = new MySqlCommand(sql, connection);

                int nrOfRecordsChanged = command.ExecuteNonQuery();
                if (nrOfRecordsChanged > 0)
                    return "added";
                else
                    return "Visitor not added";
            }
            catch (MySqlException ex)
            {
                return ex.Number.ToString();
            }
            finally
            {
                connection.Close();
            }
        }

        //Adding the new account to the event
        public string addEventAccToTheNewUser()
        {
            try
            {
                //First we add it to the eventacc table to make the relation
                var sql =
                    $@"INSERT INTO event_account (	User_ID,Balance,Money_Spent,Visitor_Status) VALUES ('{userId}', '0', '60' , 'in')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                if (nrOfRecordsChanged > 0)
                {
                    //Then we add it to the tickets table to make the relation
                    sql = $@"INSERT INTO ticket (userId ,ticketType) VALUES ('{userId}', 'Weekend Ticket')";
                    command = new MySqlCommand(sql, connection);
                    nrOfRecordsChanged = command.ExecuteNonQuery();
                    if (nrOfRecordsChanged > 0)
                        return "giverfid";
                    else
                        return "Error creating Event Account";
                }
                else
                {
                    return "Error Account Creating";
                }
            }
            catch (Exception e)
            {
                return " error";
            }
            finally
            {
                connection.Close();
            }
        }

        //public string ChargeUserForTheTombola(string rfid)
        //{
        //    try
        //    {
        //        userId = GetUserIdWithRfid(rfid);

        //        if (userId != 0)
        //        {
        //            int spentMoney = -1;
        //            string sql = $@"SELECT SpentMoney FROM eventacc WHERE User_userID = '{userId}' ; ";
        //            MySqlCommand command = new MySqlCommand(sql, connection);
        //            connection.Open();
        //            MySqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                spentMoney = Convert.ToInt32(reader[0].ToString()) + 2;
        //            }
        //            reader.Close();

        //            sql = $@"UPDATE eventacc SET SpentMoney = '{spentMoney}' WHERE User_userID= '{userId}' ; ";
        //            command = new MySqlCommand(sql, connection);

        //            int number = 0;

        //            number = Convert.ToInt32(command.ExecuteNonQuery());
        //            if (number != 0)
        //            {
        //                int EarnedMoneyFromTombola = -1;
        //                sql = $@"SELECT EarnedMoney FROM tombolawinner; ";
        //                command = new MySqlCommand(sql, connection);
        //                reader = command.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    EarnedMoneyFromTombola = Convert.ToInt32(reader[0].ToString()) + 2;
        //                }
        //                reader.Close();

        //                sql = $@"UPDATE tombolawinner SET EarnedMoney = '{EarnedMoneyFromTombola}'; ";
        //                command = new MySqlCommand(sql, connection);

        //                int num = 0;

        //                num = Convert.ToInt32(command.ExecuteNonQuery());
        //                if (num != 0)
        //                {
        //                    return "updated";
        //                }
        //                else
        //                {
        //                    return "Erorr!";
        //                }
        //            }
        //            else
        //            {
        //                return "Erorr!";
        //            }

        //        }
        //        else
        //        {
        //            return "nouser";
        //        }
        //    }
        //    catch
        //    {
        //        return "Erorr connection!";
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}


        public string ReturnBalanceToUser(string rfid)
        {
            try
            {
                userId = GetUserIdWithRfid(rfid);
                if (userId != 0)
                {
                    var balance = -1;
                    var sql = $@"SELECT Balance FROM event_account WHERE User_ID = '{userId}' ; ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) balance = Convert.ToInt32(reader[0].ToString());
                    reader.Close();
                    sql = $@"UPDATE event_account SET Balance = '0' WHERE User_ID = '{userId}' ; ";
                    command = new MySqlCommand(sql, connection);

                    var number = 0;

                    number = Convert.ToInt32(command.ExecuteNonQuery());
                    if (number != 0)
                    {
                        sql = $@"UPDATE users SET rfid  = NULL , barcode  = NULL WHERE user_id = '{userId}' ; ";
                        command = new MySqlCommand(sql, connection);

                        number = Convert.ToInt32(command.ExecuteNonQuery());
                        if (number != 0)
                        {
                            if (balance > 0)
                                return "Successfully returned " + balance + "$";
                            else
                                return "This user doesn't have any money left";
                        }
                        else
                        {
                            return "Erorr";
                        }
                    }
                    else
                    {
                        return "Erorr";
                    }
                }
                else
                {
                    return "nouser";
                }
            }
            catch
            {
                return "Erorr";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}