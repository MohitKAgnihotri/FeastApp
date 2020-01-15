using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Phidget22;
using Phidget22.Events;

namespace FoodShop
{
    public partial class Form1 : Form
    {
        RFID rfid;
        Mysql mysql;
        string rfid_Code = "";
        int totalPrice = 0;
        int tShirt_Quantity = 0;
        int wijn_Quantity = 0; // magnet
        int keyChainQuantity = 0; // not changed
        int burger_Quantity = 0;
        int toaste_Quantity = 0;// pancake
        int iceCream_Quantity = 0;
        int softdrink_Quantity = 0; // cola
        int pet_Quantity = 0; // iceTea
        int beer_Quantity = 0;
        public Form1()
        {
            InitializeComponent();
            mysql = new Mysql();
            timer1.Start();

            lbBeerPrice.Text = "";
            lbBurgerPrice.Text = "";
            lbCokePrice.Text = "";
            lbIceCreamPrice.Text = "";
            lbIceTeaPrice.Text = "";
            lbKeyChainPrice.Text = "";
            lbMagnetPrice.Text = "";
            lbPancakesPrice.Text = "";
            lbTshirtPrice.Text = "";
            pbIceCream.Hide();
            pbBurger.Hide();
            pbPancakes.Hide();
            pbBeer.Hide();
            pbIceTea.Hide();
            pbCola.Hide();
            btnKeyChain.Hide();
            btnTShirt.Hide();
            btnMagnet.Hide();
            gbDrinks.Hide();
            gbSouvenirs.Hide();
            gbFood.Visible = true;
        }

        private void btnSouvenirs_Click(object sender, EventArgs e)
        {
            btnFood.BackgroundImage = Properties.Resources.button_food_bank__1_;
            btnSouvenirs.BackgroundImage = Properties.Resources.button_souvenirs__2_;
            btnDrinks.BackgroundImage = Properties.Resources.button_drinks__1_;

            btnFood.BackgroundImageLayout = ImageLayout.Stretch;
            btnSouvenirs.BackgroundImageLayout = ImageLayout.Stretch;
            btnDrinks.BackgroundImageLayout = ImageLayout.Stretch;

            gbDrinks.Hide();
            gbFood.Hide();
            gbSouvenirs.Show();
        }

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            btnFood.BackgroundImage = Properties.Resources.button_food_bank__1_;
            btnSouvenirs.BackgroundImage = Properties.Resources.button_souvenirs__1_;
            btnDrinks.BackgroundImage = Properties.Resources.button_drinks__2_;

            btnFood.BackgroundImageLayout = ImageLayout.Stretch;
            btnSouvenirs.BackgroundImageLayout = ImageLayout.Stretch;
            btnDrinks.BackgroundImageLayout = ImageLayout.Stretch;

            gbFood.Hide();
            gbSouvenirs.Hide();
            gbDrinks.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            btnFood.BackgroundImage = Properties.Resources.button_food_bank__2_;
            btnSouvenirs.BackgroundImage = Properties.Resources.button_souvenirs__1_;
            btnDrinks.BackgroundImage = Properties.Resources.button_drinks__1_;

            btnFood.BackgroundImageLayout = ImageLayout.Stretch;
            btnSouvenirs.BackgroundImageLayout = ImageLayout.Stretch;
            btnDrinks.BackgroundImageLayout = ImageLayout.Stretch;

            gbDrinks.Hide();
            gbSouvenirs.Hide();
            gbFood.Show();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                lbPurchaseStatus.Text = "";
                rfid = new RFID();

                rfid.Attach += new AttachEventHandler(myRfidAttachMethod);
                rfid.Tag += new RFIDTagEventHandler(CheckUserRfid);

                rfid.Open();
            }
            catch (PhidgetException ex)
            {
                throw ex;
            }
        }
        public void myRfidAttachMethod(object sender, AttachEventArgs args)
        {
            lbVisitorName.Text = "Attached";
        }
        public void CheckUserRfid(object sender, RFIDTagEventArgs args)
        {
            rfid_Code = args.Tag;
            Mysql dh = new Mysql();
            string userName = dh.GetUserNameWithRfid(rfid_Code);
            
            if (userName != "")
            {
                lbVisitorName.Text = userName;
            }
            else
            {
                lbVisitorName.Text = rfid_Code;
            }
            rfid.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tShirt_Quantity = mysql.GetSoldQuantity("T-Shirt");
            wijn_Quantity = mysql.GetSoldQuantity("Wijn");
            keyChainQuantity = mysql.GetSoldQuantity("Key_chain");
            burger_Quantity = mysql.GetSoldQuantity("Burger");
            toaste_Quantity = mysql.GetSoldQuantity("Toaste");
            iceCream_Quantity = mysql.GetSoldQuantity("Ice Cream");
            softdrink_Quantity = mysql.GetSoldQuantity("SoftDrink");
            pet_Quantity = mysql.GetSoldQuantity("Caps");
            beer_Quantity = mysql.GetSoldQuantity("Beer");

            lbBeerPrice.Text = mysql.GetItemPrice("Beer") + "€";
            lbBurgerPrice.Text = mysql.GetItemPrice("Burger") + "€";
            lbCokePrice.Text = mysql.GetItemPrice("SoftDrink") + "€";
            lbIceCreamPrice.Text = mysql.GetItemPrice("Caps") + "€";
            lbIceTeaPrice.Text = mysql.GetItemPrice("SoftDrink") + "€";
            lbKeyChainPrice.Text = mysql.GetItemPrice("Key_chain") + "€";
            lbMagnetPrice.Text = mysql.GetItemPrice("Wijn") + "€";
            lbPancakesPrice.Text = mysql.GetItemPrice("Toaste") + "€";
            lbTshirtPrice.Text = mysql.GetItemPrice("T-Shirt") + "€";

            if (tShirt_Quantity < 1)
            {
                lbTShirtStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbTShirtStockQuantity.Text = tShirt_Quantity + " LEFT";
            }

            if (wijn_Quantity < 1)
            {
                lbMagnetStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbMagnetStockQuantity.Text = wijn_Quantity + " LEFT";
            }

            if (keyChainQuantity < 1)
            {
                lbKeyChainStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbKeyChainStockQuantity.Text = keyChainQuantity + " LEFT";
            }

            if (burger_Quantity < 1)
            {
                lbBurgerQunatity.Text = "Out of the stock";
            }
            else
            {
                lbBurgerQunatity.Text = burger_Quantity + " LEFT";
            }

            if (toaste_Quantity < 1)
            {
                lbToasteStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbToasteStockQuantity.Text = toaste_Quantity + " LEFT";
            }

            if (pet_Quantity < 1)
            {
                lbIscreamQuantity.Text = "Out of the stock";
            }
            else
            {
                lbIscreamQuantity.Text = iceCream_Quantity + " LEFT";
            }

            if (softdrink_Quantity < 1)
            {
                lbColaStockQuantity.Text = "Out ofthe stock";
            }
            else
            {
                lbColaStockQuantity.Text = softdrink_Quantity + " LEFT";
            }

            if (pet_Quantity < 1)
            {
                lbIceTeaStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbIceTeaStockQuantity.Text = pet_Quantity + " LEFT";
            }

            if (beer_Quantity < 1)
            {
                lbBeerStockQuantity.Text = "Out of the stock";
            }
            else
            {
                lbBeerStockQuantity.Text = beer_Quantity + " LEFT";
            }
            pbIceCream.Show();
            pbBurger.Show();
            pbPancakes.Show();
            pbBeer.Show();
            pbIceTea.Show();
            pbCola.Show();
            btnKeyChain.Show();
            btnTShirt.Show();
            btnMagnet.Show();
            timer1.Stop();
        }
        private int GetProductPrice(string product)
        {
            int end = product.LastIndexOf("€");
            int productPrice =Convert.ToInt32(product.Substring(0, end).TrimEnd());
            return productPrice;
        }
        private void pbIceCream_Click(object sender, EventArgs e)
        {
            if (iceCream_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Sorry this item is out of stock !";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Ice Cream - " + lbIceCreamPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbIceCreamPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                iceCream_Quantity--;
                lbIscreamQuantity.Text = iceCream_Quantity + "LEFT";
            }
           
        }

        private void pbPancakes_Click(object sender, EventArgs e)
        {
            if (toaste_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Toaste - " + lbPancakesPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbPancakesPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                toaste_Quantity--;
                lbToasteStockQuantity.Text = toaste_Quantity + "LEFT";
            }
        }

        private void pbBurger_Click(object sender, EventArgs e)
        {
            if (burger_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Burger - " + lbBurgerPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbBurgerPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                burger_Quantity--;
                lbBurgerQunatity.Text = burger_Quantity + "LEFT";
            }
        }

        private void btnTShirt_Click(object sender, EventArgs e)
        {
            if (tShirt_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("T-Shirt - " + lbTshirtPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbTshirtPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                tShirt_Quantity--;
                lbTShirtStockQuantity.Text = tShirt_Quantity + "LEFT";
            }
        }

        private void btnMagnet_Click(object sender, EventArgs e)
        {
            if (wijn_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Wijn - "+lbMagnetPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbMagnetPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                wijn_Quantity--;
                lbMagnetStockQuantity.Text = wijn_Quantity + "LEFT";
            }
        }

        private void btnKeyChain_Click(object sender, EventArgs e)
        {
            if (keyChainQuantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Key-Chain - " + lbKeyChainPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbKeyChainPrice.Text); ;
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                keyChainQuantity--;
                lbKeyChainStockQuantity.Text = keyChainQuantity + "LEFT";
            }
        }

        private void pbBeer_Click(object sender, EventArgs e)
        {
            if (beer_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Beer - " + lbBeerPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbBeerPrice.Text);
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                beer_Quantity--;
                lbBeerStockQuantity.Text = beer_Quantity + "LEFT";
            }
        }

        private void pbCola_Click(object sender, EventArgs e)
        {
            if (softdrink_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Soft Drink - " + lbCokePrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbCokePrice.Text);
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                softdrink_Quantity--;
                lbColaStockQuantity.Text = softdrink_Quantity + "LEFT";
            }
        }

        private void pbIceTea_Click(object sender, EventArgs e)
        {
            if (pet_Quantity == 0)
            {
                lbPurchaseStatus.Text = "Out of the stock";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
            else
            {
                List<string> temp = new List<string>();
                lbReceipt.Items.Add("Caps - " + lbIceTeaPrice.Text);
                foreach (string item in lbReceipt.Items)
                {
                    temp.Add(item);
                }
                temp.Sort();
                lbReceipt.Items.Clear();
                foreach (string item in temp)
                {
                    lbReceipt.Items.Add(item);
                }
                totalPrice += GetProductPrice(lbIceTeaPrice.Text);
                lbTotalPrice.Text = totalPrice.ToString() + "€";
                pet_Quantity--;
                lbIceTeaStockQuantity.Text = pet_Quantity + "LEFT";
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {

            List<string> itemsToSell = new List<string>();
            foreach (string item in lbReceipt.Items)
            {
                itemsToSell.Add(item);
            }

            string status = mysql.SellItemToClient(rfid_Code, itemsToSell, totalPrice);
            if (status == "added correctly")
            {
                lbPurchaseStatus.Text = "Successfully Sold!";
                lbPurchaseStatus.ForeColor = Color.Green;
            }
            else if (status == "there is no user ")
            {
                lbPurchaseStatus.Text = "There is no user with that RFID !";
                lbPurchaseStatus.ForeColor = Color.Red;
                List<string> items = new List<string>();
                foreach (string item in lbReceipt.Items)
                {
                    items.Add(item);
                }
                foreach (string item in items)
                {
                    lbReceipt.SelectedItem = item;
                    btnRemove.PerformClick();
                }
            }
            else if (status == "no money or balance")
            {
                lbPurchaseStatus.Text = "Not enough balance !";
                lbPurchaseStatus.ForeColor = Color.Red;
                List<string> items = new List<string>();
                foreach (string item in lbReceipt.Items)
                {
                    items.Add(item);
                }
                foreach (string item in items)
                {
                    lbReceipt.SelectedItem = item;
                    btnRemove.PerformClick();
                }
            }
            else
            {
                MessageBox.Show(status);
            }
            totalPrice = 0;
            lbTotalPrice.Text = totalPrice.ToString();
            lbReceipt.Items.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbReceipt.SelectedItem.ToString() == "Caps - " + lbIceTeaPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    pet_Quantity++;
                    lbIceTeaStockQuantity.Text = pet_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbIceTeaPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Ice Cream - " + lbIceCreamPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    iceCream_Quantity++;
                    lbIscreamQuantity.Text = pet_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbIceCreamPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Burger - " + lbBurgerPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    burger_Quantity++;
                    lbBurgerQunatity.Text = burger_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbBurgerPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Beer - " + lbBeerPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    beer_Quantity++;
                    lbBeerStockQuantity.Text = beer_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbBeerPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "T-Shirt - " + lbTshirtPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    tShirt_Quantity++;
                    lbTShirtStockQuantity.Text = tShirt_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbTshirtPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Wijn - " + lbMagnetPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    wijn_Quantity++;
                    lbMagnetStockQuantity.Text = wijn_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbMagnetPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "SoftDrink- " + lbCokePrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    softdrink_Quantity++;
                    lbColaStockQuantity.Text = softdrink_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbCokePrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Key_chain - " + lbKeyChainPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    keyChainQuantity++;
                    lbKeyChainStockQuantity.Text = keyChainQuantity + "LEFT";
                    totalPrice -= GetProductPrice(lbKeyChainPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
                else if (lbReceipt.SelectedItem.ToString() == "Toaste - " + lbPancakesPrice.Text)
                {
                    lbReceipt.Items.Remove(lbReceipt.SelectedItem);
                    toaste_Quantity++;
                    lbToasteStockQuantity.Text = toaste_Quantity + "LEFT";
                    totalPrice -= GetProductPrice(lbPancakesPrice.Text);
                    lbTotalPrice.Text = totalPrice.ToString() + "€";
                }
            }
            catch (NullReferenceException)
            {
                lbPurchaseStatus.Text = "Please first select the item you want to remove !";
                lbPurchaseStatus.ForeColor = Color.Red;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
           // btnClose.BackgroundImage = Properties.Resources.btnClose_Hover_tr;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
         //   btnClose.BackgroundImage = Properties.Resources.close_greenBTR;
        }

       
        public void HideCloseBtn()
        {
            this.btnClose.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gbFood_Enter(object sender, EventArgs e)
        {

        }
    }
}
