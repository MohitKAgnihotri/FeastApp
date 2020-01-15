using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FoodShop
{
    class Mysql
    {
        public MySqlConnection cone;

        public Mysql()
        {
            string connections = "server = studmysql01.fhict.local; " +
                             "database = dbi412627;" +
                             "userid  = dbi412627;" +
                             "password = wolf2019;" +
                             "connect timeout= 45;";

            cone = new MySqlConnection(connections);
        }
        public string GetUserNameWithRfid(string rfid)
        {
            try
            {
                string f_name = "";
                string sql = $@"SELECT firstname  FROM users where rfid = '{rfid}';";
                MySqlCommand comm = new MySqlCommand(sql, cone);
                cone.Open();
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
                return "there is no rfid assigened to this name";
            }
            finally
            {
                cone.Close();
            }
        }
        public int GetItemPrice(String item_Name)
        {

            int price = 0;

            try
            {
                string sql = $@"SELECT Item_Price FROM shop_items WHERE Item_Name = '{item_Name}' ;";
                MySqlCommand command = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                price = int.Parse(reader[0].ToString());

                return price;
            }
            catch
            {
                return 0;
            }
            finally
            {
                cone.Close();
            }
        }
        public int GetSoldQuantity(String item_name)
        {


            int Quantity = 0;

            try
            {
                string sql = $@"SELECT Quantity FROM items_belongs_to_the_shop where Item_Name='{item_name}' ;";
                MySqlCommand comm = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                Quantity = int.Parse(reader[0].ToString());

                return Quantity;
            }
            catch
            {
                return 0;

            }
            finally
            {
                cone.Close();
            }
        }

        public string SellItemToClient(string RFID, List<string> items, int money_spent)
        {
            try
            {
                int Purchase_number = 0;
                int User_ID = 0;
                string sql = $@"SELECT user_id FROM users where rfid = '{RFID}';";
                MySqlCommand comm = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    User_ID = int.Parse(reader[0].ToString());
                }
                reader.Close();
                if (User_ID != -1)
                {
                    int UserBalanceStatus = 0;
                    sql = $@"SELECT Balance FROM event_account WHERE User_ID= '{User_ID}' ; ";
                    comm = new MySqlCommand(sql, cone);
                    reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        UserBalanceStatus = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                    if (UserBalanceStatus >= money_spent)
                    {
                        UserBalanceStatus -= money_spent;
                        string maxPurchaseNumber = "";
                        sql = $@"SELECT MAX(Purchase_number) FROM shop_invoice ; ";
                        comm = new MySqlCommand(sql, cone);
                        reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            maxPurchaseNumber = reader[0].ToString();
                        }
                        reader.Close();
                        if (maxPurchaseNumber != "")
                        {
                            Purchase_number = Convert.ToInt32(maxPurchaseNumber) + 1;
                        }
                        else
                        {
                            Purchase_number = 1;
                        }
                        string preview_Item = "";

                        foreach (string item in items)
                        {
                            if (preview_Item == item)
                            {

                            }
                            else
                            {
                                int shop_Id = 0;
                                int quan = 0;
                                preview_Item = item;
                                int end = item.LastIndexOf("-");
                                string item_Name = item.Substring(0, end).TrimEnd();
                                if (item_Name == "Key_chain" || item_Name == "Wijn" || item_Name == "T-Shirt")
                                {
                                    shop_Id = 2;
                                }
                                else
                                {
                                    shop_Id = 1;
                                }
                                foreach (string i in items)
                                {
                                    if (item == i)
                                    {
                                        quan++;
                                    }
                                }

                                sql = $@"INSERT INTO shop_invoice (Purchase_number,User_ID,Shop_ID,Item_Name,Quantity) 
                                VALUES ('{Purchase_number}', '{User_ID}', '{shop_Id}', '{item_Name}', '{quan}')";

                                comm = new MySqlCommand(sql, cone);
                                int nr_Changed = comm.ExecuteNonQuery();
                                if (nr_Changed > 0)
                                {
                                    int Quantity_status = 0;
                                    sql = $@"SELECT Quantity FROM items_belongs_to_the_shop WHERE Item_Name = '{item_Name}' ; ";
                                    comm = new MySqlCommand(sql, cone);
                                    reader = comm.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        Quantity_status = Convert.ToInt32(reader[0].ToString());
                                    }
                                    Quantity_status -= quan;
                                    reader.Close();

                                    sql = $@"UPDATE items_belongs_to_the_shop SET Quantity = '{Quantity_status}' WHERE Item_Name= '{item_Name}' ; ";
                                    comm = new MySqlCommand(sql, cone);

                                    int number = 0;

                                    number = Convert.ToInt32(comm.ExecuteNonQuery());
                                    if (number != 0)
                                    {

                                    }
                                    else
                                    {
                                        return "somthing wrong happened!";
                                    }
                                }
                                else
                                {
                                    return "Something wrong happened";
                                }
                            }

                        }
                        sql = $@"INSERT INTO shop_receipt (Purchase_number) 
                                VALUES ('{Purchase_number}')";

                        comm = new MySqlCommand(sql, cone);
                        int nrOfRowsChanged = comm.ExecuteNonQuery();
                        if (nrOfRowsChanged > 0)
                        {
                            int Money_Spent = 0;
                            sql = $@"SELECT Money_Spent FROM event_account WHERE User_ID= '{User_ID }' ; ";
                            comm = new MySqlCommand(sql, cone);
                            reader = comm.ExecuteReader();
                            while (reader.Read())
                            {
                                Money_Spent = Convert.ToInt32(reader[0].ToString());
                            }
                            reader.Close();
                            Money_Spent += money_spent;
                            sql = $@"UPDATE event_account SET Balance = '{UserBalanceStatus}' WHERE User_ID= '{User_ID }' ; ";
                            comm = new MySqlCommand(sql, cone);

                            int num = 0;

                            num = Convert.ToInt32(comm.ExecuteNonQuery());
                            if (num != 0)
                            {
                                sql = $@"UPDATE event_account SET Money_Spent = '{Money_Spent}' WHERE User_ID= '{User_ID }' ; ";
                                comm = new MySqlCommand(sql, cone);

                                num = 0;

                                num = Convert.ToInt32(comm.ExecuteNonQuery());
                                if (num != 0)
                                {
                                    return "added correctly";
                                }
                                else
                                {
                                    return "not Added correctly!";
                                }
                            }
                            else
                            {
                                return "not added correctly!";
                            }
                        }
                        else
                        {
                            return "not added correctly!";
                        }

                    }
                    else
                    {
                        return " no money or balance";
                    }
                }
                else
                {
                    return "there is no user ";
                }

            }
            catch
            {
                return "something wrong happened";

            }
            finally
            {

                cone.Close();

            }
        }


    }
}
