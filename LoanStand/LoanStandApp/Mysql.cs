using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LoanStandApp
{
    class Mysql
    {

        private MySqlConnection cone;
        private MySqlConnection cone2;
        public Mysql()
        {
            string cone_details = " server = studmysql01.fhict.local; " +
                            "database = dbi412627;" +
                            "userid  = dbi412627;" +
                            "password = wolf2019;" +
                            "connect timeout=45;";

            cone = new MySqlConnection(cone_details);
            cone2 = new MySqlConnection(cone_details); // check the validation
        }

        public string GetUserFirstNameWithRfid(string user_rfid)
        {
            try
            {
                string User_name = "";
                string sql = $@"SELECT firstname FROM users where rfid = '{user_rfid}';";
                MySqlCommand Mysqlcommand = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader Mysqdatalreader = Mysqlcommand.ExecuteReader();
                while (Mysqdatalreader.Read())
                {
                    User_name = Mysqdatalreader[0].ToString();
                }
                if (User_name != "")
                {
                    Mysqdatalreader.Close();
                    return User_name;
                }
                else
                {
                    Mysqdatalreader.Close();
                    return "";
                }

            }
            catch
            {
                return "there is a problem in reader or command check your code!";

            }
            finally
            {

                cone.Close();

            }
        }
        public int GetPrdouctPrice(String product_name)
        {

            int Productprice = 0;

            try
            {
                string sql = $@"SELECT Item_Price FROM loan_items WHERE Item_Name = '{product_name}' ;";
                MySqlCommand Mysqlcommand = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader Mysqlreader = Mysqlcommand.ExecuteReader();
                if (!Mysqlreader.HasRows)
                {
                    return 0;
                }
                Mysqlreader.Read();
                Productprice = int.Parse(Mysqlreader[0].ToString());

                return Productprice;
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
        public int GetRetrunedItemCount(string items, int user_Id)
        {
            int returned_Items = 0;
            string sql = $@"SELECT SUM(Returned) FROM rentshop_invoice where Item_Name = '{items}' AND User_ID = '{user_Id}';";
            MySqlCommand Mysqlcommand = new MySqlCommand(sql, cone2);
            cone2.Open();
            MySqlDataReader Mysqlreader2 = Mysqlcommand.ExecuteReader();
            while (Mysqlreader2.Read())
            {
                returned_Items = Convert.ToInt32(Mysqlreader2[0].ToString());
            }
            Mysqlreader2.Close();
            return returned_Items;
        }
        public List<string> GetItemsLoanedByUser(string user_RFIDs)
        {
            try
            {
                List<string> temp = new List<string>();
                int user_Id = 0;
                string mysql = $@"SELECT user_id FROM users where rfid = '{user_RFIDs}';";
                MySqlCommand Mysqlcommand = new MySqlCommand(mysql, cone);
                cone.Open();
                MySqlDataReader Mysqlreader = Mysqlcommand.ExecuteReader();
                while (Mysqlreader.Read())
                {
                    user_Id = int.Parse(Mysqlreader[0].ToString());
                }
                Mysqlreader.Close();
                if (user_Id != -1)
                {
                    mysql = $@"SELECT Item_Name FROM rentshop_invoice where User_ID = '{user_Id}' ORDER BY Item_Name;";
                    Mysqlcommand = new MySqlCommand(mysql, cone);
                    Mysqlreader = Mysqlcommand.ExecuteReader();

                    while (Mysqlreader.Read())
                    {
                        temp.Add(Mysqlreader[0].ToString());
                    }
                    Mysqlreader.Close();
                    string prevItem = "";
                    List<string> itemsLoaned = new List<string>();
                    foreach (string item in temp)
                    {
                        int quantity = 0;
                        if (prevItem == item)
                        {

                        }
                        else
                        {
                            prevItem = item;
                            mysql = $@"SELECT SUM(Quantity) FROM rentshop_invoice WHERE Item_Name = '{item}' AND User_ID = '{user_Id}';";
                            Mysqlcommand = new MySqlCommand(mysql, cone);
                            Mysqlreader = Mysqlcommand.ExecuteReader();

                            while (Mysqlreader.Read())
                            {
                                quantity = Convert.ToInt32(Mysqlreader[0].ToString());
                            }
                            int returnedItems = GetRetrunedItemCount(item, user_Id);
                            cone2.Close();
                            if (quantity > returnedItems)
                            {
                                itemsLoaned.Add(item);
                                int itemsToReturn = quantity - returnedItems;
                                itemsLoaned.Add(itemsToReturn.ToString());
                            }
                        }
                        Mysqlreader.Close();
                    }
                    return itemsLoaned;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cone.Close();
            }
        }
        public int GetStockQuantityOfCamera()
        {
            try
            {
                string name = "Camera";
                int quantity = -1;
                string sql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop where Item_Name = '{name}';";
                MySqlCommand command = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quantity = Convert.ToInt32(reader[0].ToString());
                }
                return quantity;

            }
            catch
            {
                return -1;

            }
            finally
            {

                cone.Close();

            }
        }
        public int GetStockQuantityOfCharger()
        {
            try
            {
                string name = "Charger";
                int quantity = -1;
                string sql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop where Item_Name = '{name}';";
                MySqlCommand command = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quantity = Convert.ToInt32(reader[0].ToString());
                }
                return quantity;

            }
            catch
            {
                return -1;

            }
            finally
            {

                cone.Close();

            }
        }
        public int GetStockQuantityOfGooggles()
        {
            try
            {
                string name = "Googgles";
                int quantity = -1;
                string sql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop where Item_Name = '{name}';";
                MySqlCommand command = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quantity = Convert.ToInt32(reader[0].ToString());
                }
                return quantity;

            }
            catch
            {
                return -1;

            }
            finally
            {

                cone.Close();

            }
        }
        public int GetStockQuantityOfBicycle()
        {
            try
            {
                string bicycle_name = "Bicycle";
                int stock_quantity = -1;
                string mysql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop where Item_Name = '{bicycle_name}';";
                MySqlCommand mysqlcommand = new MySqlCommand(mysql, cone);
                cone.Open();
                MySqlDataReader mysqlreader = mysqlcommand.ExecuteReader();
                while (mysqlreader.Read())
                {
                    stock_quantity = Convert.ToInt32(mysqlreader[0].ToString());
                }
                return stock_quantity;

            }
            catch
            {
                return -1;

            }
            finally
            {

                cone.Close();

            }
        }

        public string LoanItemToVisitor(string user_RFIDs, List<string> items, int spentMoney)
        {
            try
            {
                Random random = new Random();
                int purchas_No = 0;
                int user_Id = 0;
                //check  if it is user
                string sql = $@"SELECT user_id FROM users where rfid = '{user_RFIDs}';"; //correct
                MySqlCommand mysqlcommand = new MySqlCommand(sql, cone);
                cone.Open();
                MySqlDataReader mysqlreader = mysqlcommand.ExecuteReader();
                while (mysqlreader.Read())
                {
                    user_Id = int.Parse(mysqlreader[0].ToString());
                }
                mysqlreader.Close();
                //  it is  user
                if (user_Id != -1)
                {
                    int currentUserBalance = 0;
                    sql = $@"SELECT Balance FROM event_account WHERE User_ID = '{user_Id}' ; "; //correct
                    mysqlcommand = new MySqlCommand(sql, cone);
                    mysqlreader = mysqlcommand.ExecuteReader();
                    //user current balance
                    while (mysqlreader.Read())
                    {
                        currentUserBalance = Convert.ToInt32(mysqlreader[0].ToString()); //problem
                    }
                    mysqlreader.Close();
                    // if user has enough balance
                    if (currentUserBalance >= spentMoney)
                    {
                        currentUserBalance -= spentMoney;
                        string maxPurchaseNo = "";
                        sql = $@"SELECT MAX(Purchase_number) FROM rentshop_invoice ; ";
                        mysqlcommand = new MySqlCommand(sql, cone);
                        mysqlreader = mysqlcommand.ExecuteReader();
                        while (mysqlreader.Read())
                        {
                            maxPurchaseNo = mysqlreader[0].ToString();
                        }
                        mysqlreader.Close();
                        if (maxPurchaseNo != "")
                        {
                            purchas_No = Convert.ToInt32(maxPurchaseNo) + 1;
                        }
                        else
                        {
                            purchas_No = 1;
                        }
                        string prevItem = "";

                        foreach (string item in items)
                        {
                            if (prevItem == item)
                            {

                            }
                            else
                            {
                                int quantity = 0;
                                prevItem = item;
                                int end = item.LastIndexOf("-");
                                string productName = item.Substring(0, end).TrimEnd();
                                foreach (string i in items)
                                {
                                    if (item == i)
                                    {
                                        quantity++;
                                    }
                                }

                                sql = $@"INSERT INTO rentshop_invoice (Purchase_number,User_ID,R_Shop_ID,Item_Name,Quantity,Returned) 
                                VALUES ('{purchas_No}', '{user_Id}', '1', '{productName}', '{quantity}','0' )";

                                mysqlcommand = new MySqlCommand(sql, cone);
                                int nrChanged = mysqlcommand.ExecuteNonQuery();
                                if (nrChanged > 0)
                                {
                                    int currentStockQuantity = 0;
                                    sql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop WHERE Item_Name= '{productName}' ; ";
                                    mysqlcommand = new MySqlCommand(sql, cone);
                                    mysqlreader = mysqlcommand.ExecuteReader();
                                    while (mysqlreader.Read())
                                    {
                                        currentStockQuantity = Convert.ToInt32(mysqlreader[0].ToString());
                                    }
                                    currentStockQuantity -= quantity;
                                    mysqlreader.Close();

                                    sql = $@"UPDATE items_belongs_to_the_rentshop SET Quantity = '{currentStockQuantity}' WHERE Item_Name = '{productName}' ; ";
                                    mysqlcommand = new MySqlCommand(sql, cone);

                                    int num = 0;

                                    num = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                    if (num != 0)
                                    {

                                    }
                                    else
                                    {
                                        return "There is an Erorr!";
                                    }
                                }
                                else
                                {
                                    return "Something wrong";
                                }
                            }

                        }
                        sql = $@"INSERT INTO rentshop_receipt (Purchase_number) 
                                VALUES ('{purchas_No}')";

                        mysqlcommand = new MySqlCommand(sql, cone);
                        int nrOfRecordsChanged = mysqlcommand.ExecuteNonQuery();
                        if (nrOfRecordsChanged > 0)
                        {
                            int currentSentMoney = 0;
                            sql = $@"SELECT Money_Spent  FROM event_account WHERE User_ID ='{user_Id}' ; ";
                            mysqlcommand = new MySqlCommand(sql, cone);
                            mysqlreader = mysqlcommand.ExecuteReader();
                            while (mysqlreader.Read())
                            {
                                currentSentMoney = Convert.ToInt32(mysqlreader[0].ToString());
                            }
                            mysqlreader.Close();
                            currentSentMoney += spentMoney;
                            sql = $@"UPDATE event_account SET Balance = '{currentUserBalance}' WHERE User_ID= '{user_Id}' ; ";
                            mysqlcommand = new MySqlCommand(sql, cone);

                            int number = 0;

                            number = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                            if (number != 0)
                            {
                                sql = $@"UPDATE event_account SET Money_Spent = '{currentSentMoney}' WHERE User_ID= '{user_Id}' ; ";
                                mysqlcommand = new MySqlCommand(sql, cone);

                                number = 0;

                                number = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                if (number != 0)
                                {
                                    return "added";
                                }
                                else
                                {
                                    return "Not added";
                                }
                            }
                            else
                            {
                                return "Something wrong";
                            }
                        }
                        else
                        {
                            return "Erorr!";
                        }

                    }
                    else
                    {
                        return "Check your balance";
                    }
                }
                else
                {
                    return "There is no user";
                }

            }
            catch(Exception e)
            {
                return e.ToString();

            }
            finally
            {

                cone.Close();

            }
        }

        public string ReturnItem(string user_rfid, string damaged_product, List<string> wolf_products)
        {

            try
            {
                int user_Id = 0;
                string mysql = $@"SELECT User_ID FROM users where rfid = '{user_rfid}';";
                MySqlCommand mysqlcommand = new MySqlCommand(mysql, cone);
                cone.Open();
                MySqlDataReader mysqlreader = mysqlcommand.ExecuteReader();
                while (mysqlreader.Read())
                {
                    user_Id = int.Parse(mysqlreader[0].ToString());
                }
                mysqlreader.Close();
                if (user_Id != -11)
                {
                    string item = "";

                    foreach (string wolf_product in wolf_products)
                    {
                        if (item == wolf_product)
                        {

                        }
                        else
                        {

                            int product_quantity = 0;

                            item = wolf_product;
                            int end = wolf_product.LastIndexOf("-");
                            string productName = wolf_product.Substring(0, end).TrimEnd();
                            foreach (string wolf_pro in wolf_products)
                            {
                                if (wolf_product == wolf_pro)
                                {
                                    product_quantity++;
                                }
                            }
                            int currentStockQuantity = 0;
                            int countQuantity = product_quantity;
                            List<int> purchaseNumbers = new List<int>();
                            mysql = $@"SELECT Purchase_number FROM rentshop_invoice WHERE User_ID = '{user_Id}' AND Item_Name = '{productName}'  ; ";
                            mysqlcommand = new MySqlCommand(mysql, cone);
                            mysqlreader = mysqlcommand.ExecuteReader();
                            while (mysqlreader.Read())
                            {
                                purchaseNumbers.Add(Convert.ToInt32(mysqlreader[0].ToString()));
                            }
                            mysqlreader.Close();
                            int itemsLeft = 0;
                            foreach (int purchNo in purchaseNumbers)
                            {

                                int quantityPurchased = 0;
                                mysql = $@"SELECT Quantity FROM rentshop_invoice WHERE User_ID = '{user_Id}' AND Purchase_number = '{purchNo}' AND Item_Name = '{productName}'; ";
                                mysqlcommand = new MySqlCommand(mysql, cone);
                                mysqlreader = mysqlcommand.ExecuteReader();
                                while (mysqlreader.Read())
                                {
                                    quantityPurchased = Convert.ToInt32(mysqlreader[0].ToString());
                                }
                                mysqlreader.Close();

                                int returnedItems = 0;
                                mysql = $@"SELECT Returned FROM rentshop_invoice WHERE User_ID = '{user_Id}' AND Purchase_number = '{purchNo}' AND Item_Name  = '{productName}'; ";
                                mysqlcommand = new MySqlCommand(mysql, cone);
                                mysqlreader = mysqlcommand.ExecuteReader();
                                while (mysqlreader.Read())
                                {
                                    returnedItems = Convert.ToInt32(mysqlreader[0].ToString());
                                }
                                mysqlreader.Close();
                                if (quantityPurchased != returnedItems)
                                {

                                    itemsLeft = product_quantity - quantityPurchased;

                                    if (itemsLeft > 0)
                                    {
                                        if (returnedItems == 0)
                                        {
                                            product_quantity -= quantityPurchased;
                                        }
                                        else
                                        {
                                            product_quantity = product_quantity - (quantityPurchased - returnedItems);
                                        }

                                        mysql = $@"UPDATE rentshop_invoice SET Returned = '{quantityPurchased}' WHERE Item_Name = '{productName}' AND Purchase_number = '{purchNo}'  ; ";
                                        mysqlcommand = new MySqlCommand(mysql, cone);

                                        int num = 0;

                                        num = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                        if (num != 0)
                                        {
                                        }
                                        else
                                        {
                                            return " There is an Erorr!";
                                        }
                                    }
                                    else if (itemsLeft == 0)
                                    {

                                        int addStockQ = product_quantity - returnedItems;
                                        if (returnedItems == product_quantity)
                                        {
                                            product_quantity = quantityPurchased - product_quantity;
                                        }
                                        if (addStockQ < 0)
                                        {
                                            product_quantity = 0;
                                            addStockQ = 1;
                                        }
                                        product_quantity -= addStockQ;

                                        mysql = $@"UPDATE rentshop_invoice SET Returned = '{quantityPurchased}' WHERE Item_Name = '{productName}' AND Purchase_number = '{purchNo}'  ; ";
                                        mysqlcommand = new MySqlCommand(mysql, cone);

                                        int numbr = 0;

                                        numbr = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                        if (numbr != 0)
                                        {

                                            mysql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop WHERE Item_Name= '{productName}' ; ";
                                            mysqlcommand = new MySqlCommand(mysql, cone);
                                            mysqlreader = mysqlcommand.ExecuteReader();
                                            while (mysqlreader.Read())
                                            {
                                                currentStockQuantity = Convert.ToInt32(mysqlreader[0].ToString());
                                            }

                                            mysqlreader.Close();

                                            mysql = $@"UPDATE rentshop_invoice SET Damaged = '{damaged_product}' WHERE Item_Name = '{productName}' AND Purchase_number = '{purchNo}'  ; ";
                                            mysqlcommand = new MySqlCommand(mysql, cone);

                                            numbr = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                            if (numbr != 0)
                                            {
                                                if (product_quantity == 0)
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                return " there is an Erorr! Check your input";
                                            }
                                        }
                                        else
                                        {
                                            return "Erorr! check your input";
                                        }
                                    }
                                    else
                                    {
                                        int returnedQuantity = 0;
                                        if (returnedItems > 0)
                                        {
                                            if (quantityPurchased - returnedItems == 1)
                                            {
                                                returnedQuantity = quantityPurchased;
                                                if (product_quantity + returnedItems == quantityPurchased)
                                                {
                                                    product_quantity = 0;
                                                }
                                                else
                                                {
                                                    product_quantity = 1;
                                                }
                                            }
                                            else
                                            {
                                                returnedQuantity = quantityPurchased;
                                                product_quantity = 0;
                                            }
                                        }
                                        else
                                        {
                                            returnedQuantity = product_quantity;
                                            product_quantity = 0;
                                        }
                                        mysql = $@"UPDATE rentshop_invoice SET Returned = '{returnedQuantity}' WHERE Item_Name = '{productName}' AND Purchase_number = '{purchNo}'  ; ";
                                        mysqlcommand = new MySqlCommand(mysql, cone);

                                        int numb = 0;

                                        numb = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                        if (numb != 0)
                                        {
                                            mysql = $@"SELECT Quantity FROM items_belongs_to_the_rentshop WHERE Item_Name= '{productName}' ; ";
                                            mysqlcommand = new MySqlCommand(mysql, cone);
                                            mysqlreader = mysqlcommand.ExecuteReader();
                                            while (mysqlreader.Read())
                                            {
                                                currentStockQuantity = Convert.ToInt32(mysqlreader[0].ToString());
                                            }
                                            mysqlreader.Close();

                                            mysql = $@"UPDATE rentshop_invoice SET Damaged = '{damaged_product}' WHERE Item_Name = '{productName}' AND Purchase_number = '{purchNo}'  ; ";
                                            mysqlcommand = new MySqlCommand(mysql, cone);

                                            numb = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                                            if (numb != 0)
                                            {
                                                if (product_quantity == 0)
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                return " there is an Erorr! check your input.";
                                            }

                                        }
                                        else
                                        {
                                            return "Erorr! check your input";
                                        }
                                    }
                                }
                                else
                                {

                                }
                            }

                            currentStockQuantity += countQuantity;
                            mysql = $@"UPDATE items_belongs_to_the_rentshop SET Quantity = '{currentStockQuantity}' WHERE Item_Name= '{productName}' ; ";
                            mysqlcommand = new MySqlCommand(mysql, cone);

                            int number = 0;

                            number = Convert.ToInt32(mysqlcommand.ExecuteNonQuery());
                            if (number != 0)
                            {

                            }
                        }
                    }
                    return "returned";
                }
                else
                {
                    return "no user";
                }
            }
            catch
            {
                return "error check the button";

            }
            finally
            {

                cone.Close();

            }

        }



    }
}
