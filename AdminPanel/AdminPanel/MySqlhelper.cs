using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AdminPanel
{
    class MySqlhelper
    {
        public MySqlConnection con;
        public MySqlConnection con1;
        public MySqlConnection con2;
        public MySqlhelper()
        {
            string connection_details = " server = studmysql01.fhict.local; " +
                             "database = dbi412627;" +
                             "userid  =dbi412627;" +
                             "password =wolf2019;" +
                             "connect timeout=45;";

            con = new MySqlConnection(connection_details);
            con1 = new MySqlConnection(connection_details);
            con2 = new MySqlConnection(connection_details);
        }
        public string GetVisitorStatus(string user_id)
        {

            string Visitor_Status = "";
            try
            {

                string sql = $@"SELECT Visitor_Status FROM event_account WHERE User_ID = '{user_id}' ;";
                MySqlCommand com = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    return "reader error";
                }
                reader.Read();

                Visitor_Status = reader[0].ToString();
                if (Visitor_Status == "in")
                {
                    return "In the Event ";
                }
                else
                {
                    return "Not in the Event";
                }

            }
            catch
            {
                return "error";

            }
            finally
            {


                con.Close();
            }

        }

        public List<string> GetVisitorHistory(string user_id)
        {
            List<string> shops = new List<string>();

            try
            {

                string sql = $@"SELECT Money_Spent,Balance FROM event_account WHERE User_ID = '{user_id}' ;";
                string sqlshop = $@"SELECT 	Item_Name, Quantity FROM shop_invoice where User_ID  = '{user_id}' ORDER BY  Item_Name ;";
                string sqlrent = $@"SELECT 	Item_Name, Quantity FROM rentshop_invoice where User_ID = '{user_id}' ORDER BY 	Item_Name;";

                MySqlCommand command1 = new MySqlCommand(sql, con);
                MySqlCommand command2 = new MySqlCommand(sqlshop, con);
                MySqlCommand command3 = new MySqlCommand(sqlrent, con);
                con.Open();
                MySqlDataReader reader1 = command1.ExecuteReader();
                con.Open();
                MySqlDataReader reader2 = command2.ExecuteReader();
                con.Open();
                MySqlDataReader reader3 = command3.ExecuteReader();



                if (reader1.HasRows & reader2.HasRows & reader3.HasRows)
                {
                    reader1.Read();


                    string SpentMoney = reader1[0].ToString();
                    string balance = reader1[1].ToString();

                    shops.Add("Money spent: " + SpentMoney + "$");
                    shops.Add("Balance: " + balance + "$");
                    shops.Add("---------------------");
                    shops.Add("Shop Products:");
                    string shopItemName = "";
                    int shopItemQuantity = 0;
                    int count = 0;
                    while (reader2.Read())
                    {
                        if (shopItemName == reader2[0].ToString())
                        {
                            shopItemQuantity += Convert.ToInt32(reader2[1].ToString());
                        }
                        else
                        {
                            if (count >= 1)
                            {
                                shops.Add(shopItemName + " -" + " Quantity " + shopItemQuantity);
                                count = 0;
                            }
                            shopItemName = reader2[0].ToString();
                            shopItemQuantity = Convert.ToInt32(reader2[1].ToString());
                            count++;
                        }
                    }
                    shops.Add(shopItemName + " -" + " Quantity " + shopItemQuantity);
                    shops.Add("---------------------");
                    shops.Add("Rent Products:");
                    string loanItemName = "";
                    int loanItemQuantity = 0;
                    int counter = 0;
                    while (reader3.Read())
                    {
                        if (loanItemName == reader3[0].ToString())
                        {
                            loanItemQuantity += Convert.ToInt32(reader3[1].ToString());
                        }
                        else
                        {
                            if (counter >= 1)
                            {
                                shops.Add(loanItemName + " -" + " Quantity " + loanItemQuantity);
                                counter = 0;
                            }
                            loanItemName = reader3[0].ToString();
                            loanItemQuantity = Convert.ToInt32(reader3[1].ToString());
                            counter++;
                        }
                    }
                    shops.Add(loanItemName + " -" + " Quantity " + loanItemQuantity);

                }

                return shops;
            }
            catch
            {
                return shops;
            }
            finally
            {
                con.Close();
                con1.Close();
                con2.Close();
            }
        }

        public int GetNumberOfVisitors()
        {

            int NrVisitors = 0;

            try
            {

                string sql = $@"SELECT count(*) FROM event_account ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                NrVisitors = int.Parse(reader[0].ToString());

                return NrVisitors;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetVisitorsInTheEvent()
        {
            int Nr_visitors_present = 0;
            try
            {

                string sql = $@"SELECT count(*) FROM event_account where Visitor_Status = 'in' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                Nr_visitors_present = int.Parse(reader[0].ToString());

                return Nr_visitors_present;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetSoldItems(String product_name)
        {

            int Nr_Items_sold = 0;

            try
            {

                string sql = $@"SELECT sum(Quantity) FROM shop_invoice where Item_Name ='{product_name}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                Nr_Items_sold = int.Parse(reader[0].ToString());



                return Nr_Items_sold;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
        public int GetItemPrice(String product_name)
        {

            int price = 0;

            try
            {

                string sql = $@"SELECT Item_Price FROM shop_items WHERE Item_Name  = '{product_name}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
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
                con.Close();
            }

        }

        public int GetNrRentedItems(String product_name)
        {

            int Quantity = 0;

            try
            {

                string sql = $@"SELECT sum(Quantity) FROM rentshop_invoice where Item_Name='{product_name}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
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
                con.Close();
            }
        }

        public int GetRentItem_Price(String product_name)
        {

            int price = 0;

            try
            {

                string sql = $@"SELECT Item_Price FROM loan_items WHERE Item_Name = '{product_name}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
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
                con.Close();
            }

        }
        public int GetBookedCampings()
        {
            int presentCOunt = 0;
            try
            {

                string sql = $@"SELECT count(*) FROM camping where booked = '1' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                presentCOunt = int.Parse(reader[0].ToString());

                return presentCOunt;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
        public int GetCampingsNotBooked()
        {
            int presentCOunt = 0;
            try
            {

                string sql = $@"SELECT count(*) FROM camping where booked = '0' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                presentCOunt = int.Parse(reader[0].ToString());

                return presentCOunt;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
        public int GetCampingStatus(int campingNo)
        {
            int status = -1;
            try
            {

                string sql = $@"SELECT booked FROM camping where Camping_Spot_ID= '{campingNo}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return -1;
                }
                reader.Read();
                status = int.Parse(reader[0].ToString());

                return status;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public List<string> GetCampingInfo(int campingNo)
        {
            List<string> names = new List<string>();
            try
            {

                string sql = $@"SELECT u.firstname FROM event_account e JOIN users u ON (e.User_ID = u.user_id) where e.Camping_Spot_ID = '{campingNo}' ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    names.Add(reader[0].ToString());
                }
                return names;
            }
            catch
            {
                return null;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetTotalProductsSoldAndRent()
        {
            int totalRent = 0;
            int totalSold = 0;
            try
            {

                string sql = $@"SELECT SUM(Quantity) FROM rentshop_invoice;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                totalRent = int.Parse(reader[0].ToString());
                reader.Close();

                sql = $@"SELECT SUM(Quantity) FROM shop_invoice;";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                totalSold = int.Parse(reader[0].ToString());

                return totalRent + totalSold;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
        public int GetTotalMoneySpent()
        {
            int total = 0;
            try
            {

                string sql = $@"SELECT SUM(Money_Spent) FROM event_account;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                total = int.Parse(reader[0].ToString());

                return total;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetTotalBalance()
        {
            int total = 0;
            try
            {

                string sql = $@"SELECT SUM(Balance) FROM event_account;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                total = int.Parse(reader[0].ToString());

                return total;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetTotalAmountCampings()
        {
            int total = 0;
            try
            {

                string sql = $@"SELECT SUM(booked*Price) FROM camping;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return 0;
                }
                reader.Read();
                total = int.Parse(reader[0].ToString());

                return total;
            }
            catch
            {
                return 0;

            }
            finally
            {
                con.Close();
            }
        }

        public int GetRentShopMoneyEarned()
        {
            int CameraEarned = 0;
            int BicycleEarned = 0;
            int ChargerEarned = 0;
            int GoogglesEarned = 0;

            try
            {
                string sql = $@"SELECT IFNULL(SUM(r.Quantity)*l.Item_Price,0) 
                             FROM loan_items l RIGHT JOIN rentshop_invoice r 
                             ON (l.Item_Name = r.Item_Name) WHERE l.Item_Name = 'Charger';";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChargerEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(r.Quantity)*l.Item_Price,0) 
                             FROM loan_items l RIGHT JOIN rentshop_invoice r 
                             ON (l.Item_Name = r.Item_Name) WHERE l.Item_Name = 'Camera';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CameraEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(r.Quantity)*l.Item_Price,0) 
                             FROM loan_items l RIGHT JOIN rentshop_invoice r 
                             ON (l.Item_Name = r.Item_Name) WHERE l.Item_Name = 'Bicycle';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BicycleEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(r.Quantity)*l.Item_Price,0) 
                             FROM loan_items l RIGHT JOIN rentshop_invoice r  
                             ON (l.Item_Name = r.Item_Name) WHERE l.Item_Name = 'Googgles';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GoogglesEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                int AmountEarned = ChargerEarned + BicycleEarned + CameraEarned + GoogglesEarned;
                return AmountEarned;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public int GetFoodShopAmountEarned()
        {
            int BeersEarned = 0;
            int BurgersEarned = 0;
            int CocaColaEarned = 0;
            int IceCreamEaned = 0;
            int PancakesEarned = 0;
            int IceTeaEarned = 0;
            try
            {
                string sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Beer';";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BeersEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si  
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Burger';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BurgersEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'SoftDrink';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CocaColaEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si  
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name= 'Ice Cream';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IceCreamEaned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Pet';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IceTeaEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Toaste';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PancakesEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                int amountEarned = BeersEarned + CocaColaEarned + IceCreamEaned + IceTeaEarned + PancakesEarned + BurgersEarned;
                return amountEarned;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetSouvernirShopAmountEarned()
        {
            int ChainTagEarned = 0;
            int MagnetEarned = 0;
            int TshirtEarned = 0; ;
            try
            {
                string sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Key_chain';";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChainTagEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'Wijn';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MagnetEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();

                sql = $@"SELECT IFNULL(SUM(si.Quantity)*s.Item_Price,0) 
                             FROM shop_items s RIGHT JOIN shop_invoice si 
                             ON (s.Item_Name = si.Item_Name) WHERE s.Item_Name = 'T-Shirt';";
                command = new MySqlCommand(sql, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TshirtEarned = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();


                int amountEarned = ChainTagEarned + MagnetEarned + TshirtEarned;
                return amountEarned;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<string> GetProductsForSelling()
        {
            List<string> products = new List<string>();
            try
            {
                string sql = $@"SELECT Item_Name
                             FROM shop_items ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(reader[0].ToString());
                }
                reader.Close();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<string> GetCampingId()
        {
            List<string> Spots = new List<string>();
            try
            {
                string sql = $@"SELECT Camping_Spot_ID
                             FROM camping ;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Spots.Add(reader[0].ToString());
                }
                reader.Close();
                return Spots;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<string> GetProductsForRenting()
        {
            List<string> products = new List<string>();
            try
            {
                string sql = $@"SELECT Item_Name
                             FROM loan_items;";
                MySqlCommand command = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(reader[0].ToString());
                }
                reader.Close();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public int AddNewItemToTheShop(string name ,double price)
        {
            try
            {
                string AddNewitem = "INSERT INTO shop_items (Item_Name,Item_Price )" +
               "values (@name,@price) ";

                MySqlCommand sqlCommand = new MySqlCommand(AddNewitem, con);
                con.Open();
                sqlCommand.Parameters.AddWithValue("Item_Name", name);
                sqlCommand.Parameters.AddWithValue("Item_Price", price);
               

                int final = sqlCommand.ExecuteNonQuery();

                return final;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }


        }
        public int AddNewItemToTheRentShop(string name, double price)
        {
            try
            {
                string AddNewitem = "INSERT INTO loan_items (Item_Name,Item_Price )" +
               "values (@name,@price) ";

                MySqlCommand sqlCommand = new MySqlCommand(AddNewitem, con);
                con.Open();
                sqlCommand.Parameters.AddWithValue("Item_Name", name);
                sqlCommand.Parameters.AddWithValue("Item_Price", price);


                int final = sqlCommand.ExecuteNonQuery();

                return final;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }


        }
        public int GetVisitorCheckedInEvent()
        {
            try
            {
                string SqlGetVisitorEventCheckedIn = "SELECT Count(User_ID) FROM event_account WHERE Visitor_Status ='in'; ";
                MySqlCommand GetEventCheckedInVisitors = new MySqlCommand(SqlGetVisitorEventCheckedIn, con);
                con.Open();
                int NumberOfEventCheckedInVisitors = Convert.ToInt32(GetEventCheckedInVisitors.ExecuteScalar());

                return NumberOfEventCheckedInVisitors;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }

        }

        public int GetVisitorCheckedOutEvent()
        {
            try
            {
                string SqlGetVisitorEventCheckedOut = "SELECT Count(User_ID) FROM event_account  WHERE Visitor_Status ='out'; ";
                MySqlCommand GetEventCheckedOutVisitors = new MySqlCommand(SqlGetVisitorEventCheckedOut, con);
                con.Open();
                int NumberOfEventCheckedOutVisitors = Convert.ToInt32(GetEventCheckedOutVisitors.ExecuteScalar());

                return NumberOfEventCheckedOutVisitors;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }


    }


}
