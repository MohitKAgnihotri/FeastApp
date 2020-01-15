using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;

namespace LoanStandApp
{
    public partial class Form1 : Form
    {
        string rfid_Code = " ";
        string problems = "there is no problem";

        int total_Price = 0;
        bool Loaned_Items = false;
        int bicycle_quantity = 0;
        int camera_quantity = 0;
        int charger_quantity = 0;
        int googles_quantiy = 0;
        private RFID rfid;
        Mysql dataHelper;


        public Form1()
        {
            InitializeComponent();

            lbCameraQuantity.Text = "Synchronizing..";
            lbBicycleQuantity.Text = "Synchronizing..";
            lbchargrQuan.Text = "Synchronizing..";
            lbGogglesQuantity.Text = "Synchronizing..";

            pbBicycle.Hide();
            pbCap.Hide();
            pbCharger.Hide();
            pbCamera.Hide();

          
            gbProblemBox.Enabled = false;        
            this.rb_Issue_Loan.Checked = true;
            this.groupBox2.Visible = false;

            lbCameraPrice.Hide();
            lbBicyclePrice.Hide();
            lbChargerPrice.Hide();
            lbGogglesPrice.Hide();
            lbLoan_Status.Text = "";
            timer.Start();

        }

        private void btnScanRfid_Click(object sender, EventArgs e)
        {
            try
            {
                lbLoan_Status.Text = "";

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
            lbRfid_Status.Text = "Attached";

        }

        public void CheckUserRfid(object sender, RFIDTagEventArgs args)
        {
            rfid_Code = args.Tag;
            dataHelper = new Mysql();
            string userName = dataHelper.GetUserFirstNameWithRfid(rfid_Code);
        
            if (userName != "")
            {
                List<string> itemsLoaned = dataHelper.GetItemsLoanedByUser(rfid_Code);
                string items = "";
                if (itemsLoaned.Count() == 0)
                {
                    lbRfid_Status.Text = userName + " nothing loaned ";
                    lbRfid_Status.ForeColor = Color.White;
                    Loaned_Items = false;
                }
                else
                {
                    for (int i = 0; i < itemsLoaned.Count; i += 2)
                    {
                        items += itemsLoaned[i + 1] + " " + itemsLoaned[i] + "s ,";
                    }
                    int end = items.LastIndexOf(",");
                    string resultOfItemsLoaned = items.Substring(0, end);

                    lbRfid_Status.Text = userName + " has to return " + resultOfItemsLoaned;
                    lbRfid_Status.ForeColor = Color.Crimson;
                    Loaned_Items = true;
                }
            }
            else
            {
                lbRfid_Status.Text = rfid_Code;
            }
            rfid.Close();
        }

        private void pbCharger_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            lb_Receipt_info.Items.Add("Charger - " + dataHelper.GetPrdouctPrice("Charger") + "€");
            foreach (string item in lb_Receipt_info.Items)
            {
                temp.Add(item);
            }
            temp.Sort();
            lb_Receipt_info.Items.Clear();
            foreach (string item in temp)
            {
                lb_Receipt_info.Items.Add(item);
            }

            total_Price += dataHelper.GetPrdouctPrice("Charger");
            lbPrice.Text = total_Price.ToString() + "€";
            charger_quantity--;
            lbchargrQuan.Text = charger_quantity + "LEFT";


        }

        private void pbCamera_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            lb_Receipt_info.Items.Add("Camera - " + dataHelper.GetPrdouctPrice("Camera") + "€");
            foreach (string item in lb_Receipt_info.Items)
            {
                temp.Add(item);
            }
            temp.Sort();
            lb_Receipt_info.Items.Clear();
            foreach (string item in temp)
            {
                lb_Receipt_info.Items.Add(item);
            }
            total_Price += dataHelper.GetPrdouctPrice("Camera");
            lbPrice.Text = total_Price.ToString() + "€";
            camera_quantity--;
            lbCameraQuantity.Text = camera_quantity + "LEFT";

        }

        private void pbBackpack_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            lb_Receipt_info.Items.Add("Bicycle - " + dataHelper.GetPrdouctPrice("Bicycle") + "€");
            foreach (string item in lb_Receipt_info.Items)
            {
                temp.Add(item);
            }
            temp.Sort();
            lb_Receipt_info.Items.Clear();
            foreach (string item in temp)
            {
                lb_Receipt_info.Items.Add(item);
            }
            total_Price += dataHelper.GetPrdouctPrice("Bicycle");
            lbPrice.Text = total_Price.ToString() + "€";
            bicycle_quantity--;
            lbBicycleQuantity.Text = bicycle_quantity + "LEFT";
        }

        private void pbStick_Click(object sender, EventArgs e)
        {
            List<string> temper = new List<string>();
            lb_Receipt_info.Items.Add("Googgles - " + dataHelper.GetPrdouctPrice("Googgles") + "€");
            foreach (string recp in lb_Receipt_info.Items)
            {
                temper.Add(recp);
            }
            temper.Sort();
            lb_Receipt_info.Items.Clear();
            foreach (string item in temper)
            {
                lb_Receipt_info.Items.Add(item);
            }
            total_Price += dataHelper.GetPrdouctPrice("Googgles");
            lbPrice.Text = total_Price.ToString() + "€";
            googles_quantiy--;
            lbGogglesQuantity.Text = googles_quantiy + "LEFT";

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

                dataHelper = new Mysql();
                if (lb_Receipt_info.SelectedItem.ToString() == "Bicycle - 20€")
                {
                    lb_Receipt_info.Items.Remove(lb_Receipt_info.SelectedItem);
                    if (bicycle_quantity < 0)
                    {
                        bicycle_quantity = 1;
                    }
                    else
                    {
                        bicycle_quantity++;
                    }
                    lbBicycleQuantity.Text = bicycle_quantity + "LEFT";
                    total_Price -= dataHelper.GetPrdouctPrice("Bicycle");
                    lbPrice.Text = total_Price.ToString() + "€";
                }
                else if (lb_Receipt_info.SelectedItem.ToString() == "Googgles - 10€")
                {
                    lb_Receipt_info.Items.Remove(lb_Receipt_info.SelectedItem);
                    if (googles_quantiy < 0)
                    {
                        googles_quantiy = 1;
                    }
                    else
                    {
                        googles_quantiy++;
                    }
                    lbGogglesQuantity.Text = googles_quantiy + "LEFT";
                    total_Price -= dataHelper.GetPrdouctPrice("Googgles");
                    lbPrice.Text = total_Price.ToString() + "€";
                }
                else if (lb_Receipt_info.SelectedItem.ToString() == "Camera - 20€")
                {
                    lb_Receipt_info.Items.Remove(lb_Receipt_info.SelectedItem);
                    if (camera_quantity < 0)
                    {
                        camera_quantity = 1;
                    }
                    else
                    {
                        camera_quantity++;
                    }
                    lbCameraQuantity.Text = camera_quantity + "LEFT";
                    total_Price -= dataHelper.GetPrdouctPrice("Camera");
                    lbPrice.Text = total_Price.ToString() + "€";
                }
                else if (lb_Receipt_info.SelectedItem.ToString() == "Charger - 5€")
                {
                    lb_Receipt_info.Items.Remove(lb_Receipt_info.SelectedItem);
                    if (charger_quantity < 0)
                    {
                        charger_quantity = 1;
                    }
                    else
                    {
                        charger_quantity++;
                    }
                    lbchargrQuan.Text = charger_quantity + "LEFT";
                    total_Price -= dataHelper.GetPrdouctPrice("Charger");
                    lbPrice.Text = total_Price.ToString() + "€";
                }
            }
            catch (NullReferenceException)
            {
                lbLoan_Status.Text = "Please first select the item you want to remove !";
                lbLoan_Status.ForeColor = Color.Red;
            }
        }

        private void btnDamagedYes_Click(object sender, EventArgs e)
        {
            //  gbProblemBox.Enabled = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (Loaned_Items == true)
            {
                problems = tbProblem.Text;
                if (problems == "")
                {
                    problems = "no";
                }
                dataHelper = new Mysql();

                List<string> itemsToReturn = new List<string>();
                foreach (string item in lb_Receipt_info.Items)
                {
                    itemsToReturn.Add(item);
                }


                string status = dataHelper.ReturnItem(rfid_Code, problems, itemsToReturn);
                if (status == "no user")
                {
                    lbLoan_Status.Text = "Invalid User!";
                    lbLoan_Status.ForeColor = Color.Red;
                    lb_Receipt_info.Items.Clear();
                }
                else if (status == "returned")
                {
                    lbLoan_Status.Text = "Returned Successfully!";
                    lbLoan_Status.ForeColor = Color.Green;
                    List<string> items = new List<string>();
                    foreach (string item in lb_Receipt_info.Items)
                    {
                        items.Add(item);
                    }
                    foreach (string item in items)
                    {
                        lb_Receipt_info.SelectedItem = item;
                        if (item.Contains("Charger"))
                        {
                            charger_quantity++;
                        }
                        else if (item.Contains("Bicycle"))
                        {
                            bicycle_quantity++;
                        }
                        else if (item.Contains("Googgles"))
                        {
                            googles_quantiy++;
                        }
                        else if (item.Contains("Camera"))
                        {
                            camera_quantity++;
                        }
                        btnRemove.PerformClick();
                    }
                }

                tbProblem.Text = "";
                gbProblemBox.Enabled = false;
                lbPrice.Text = "";
                lbRfid_Status.Text = "";
                total_Price = 0;
            }
            else
            {
                lbLoan_Status.Text = "This user has nothing to return !";
                lbLoan_Status.ForeColor = Color.Red;
            }
        }

        private void CheckQty()
        {
            //if (charger_quantity < 0)
            //{
            //    lbLoan_Status.Text = "Excuse! this item is out of stock !";
            //    lbLoan_Status.ForeColor = Color.Red;
            //}
            //else if (camera_quantity < 0)
            //{
            //    lbLoan_Status.Text = " Excuse! this item is out of stock !";
            //    lbLoan_Status.ForeColor = Color.Red;
            //}
            //else if (googles_quantiy < 0)
            //{
            //    lbLoan_Status.Text = "Excuse! this item is out of stock !";
            //    lbLoan_Status.ForeColor = Color.Red;
            //}
            //else if (bicycle_quantity < 0)
            //{
            //    lbLoan_Status.Text = "Excuse! this item is out of stock !";
            //    lbLoan_Status.ForeColor = Color.Red;
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //first check if we have enough qty

            if (charger_quantity < 0)
            {
                lbLoan_Status.Text = "Excuse! this item is out of stock !";
                lbLoan_Status.ForeColor = Color.Red;
            }
            else if (camera_quantity < 0)
            {
                lbLoan_Status.Text = " Excuse! this item is out of stock !";
                lbLoan_Status.ForeColor = Color.Red;
            }
            else if (googles_quantiy < 0)
            {
                lbLoan_Status.Text = "Excuse! this item is out of stock !";
                lbLoan_Status.ForeColor = Color.Red;
            }
            else if (bicycle_quantity < 0)
            {
                lbLoan_Status.Text = "Excuse! this item is out of stock !";
                lbLoan_Status.ForeColor = Color.Red;
            }

            else
            {
               try
               {
                  if (lbRfid_Status.Text != "")
                  {

                    dataHelper = new Mysql();

                    List<string> itemsToLoan = new List<string>();
                    foreach (string item in lb_Receipt_info.Items)
                    {
                        itemsToLoan.Add(item);
                    }

                    string status = dataHelper.LoanItemToVisitor(rfid_Code, itemsToLoan, total_Price);

                    if (status == "Check your balance")
                    {
                        lbLoan_Status.Text = "Not enough balance !";
                        lbLoan_Status.ForeColor = Color.Red;
                        List<string> items = new List<string>();
                        foreach (string item in lb_Receipt_info.Items)
                        {
                            items.Add(item);
                        }
                        foreach (string item in items)
                        {
                            lb_Receipt_info.SelectedItem = item;
                            btnRemove.PerformClick();
                        }
                    }
                    else if (status == "There is no user")
                    {
                        lbLoan_Status.Text = "Invalid User !";
                        lbLoan_Status.ForeColor = Color.Red;
                        List<string> items = new List<string>();
                        foreach (string item in lb_Receipt_info.Items)
                        {
                            items.Add(item);
                        }
                        foreach (string item in items)
                        {
                            lb_Receipt_info.SelectedItem = item;
                            btnRemove.PerformClick();
                        }
                    }
                    else if (status == "added")
                    {
                       
                        lblLoanStatus.Text = "Successfully Loaned!";
                        //MessageBox.Show("Successfully Loaned!");
                        lblLoanStatus.ForeColor = Color.Green;
                        lb_Receipt_info.Items.Clear();
                        //MessageBox.Show(" sellected item has successfully loaned");
                    }
                    else
                    {
                        // string status = dataHelper.LoanItemToVisitor(rfid_Code, itemsToLoan, total_Price);
                        MessageBox.Show($"{status}");
                        lblLoanStatus.Text = "Something happened , please try again !";
                        lblLoanStatus.ForeColor = Color.Red;
                    }
                    lbRfid_Status.Text = "";
                    total_Price = 0;
                    lbPrice.Text = "";
                }
                else
                {
                    lblLoanStatus.Text = "Please Scan the Visitor's RFID Chip first !";
                    lblLoanStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {

                throw;
            }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbBicycle.Show();
            pbCap.Show();
            pbCharger.Show();
            pbCamera.Show();

            dataHelper = new Mysql();

            lbCameraPrice.Text = dataHelper.GetPrdouctPrice("Camera").ToString() + "€";
            lbBicyclePrice.Text = dataHelper.GetPrdouctPrice("Bicycle").ToString() + "€";
            lbChargerPrice.Text = dataHelper.GetPrdouctPrice("Charger").ToString() + "€";
            lbGogglesPrice.Text = dataHelper.GetPrdouctPrice("Googgles").ToString() + "€";

            lbCameraPrice.Show();
            lbBicyclePrice.Show();
            lbChargerPrice.Show();
            lbGogglesPrice.Show();

            bicycle_quantity = dataHelper.GetStockQuantityOfBicycle();
            camera_quantity = dataHelper.GetStockQuantityOfCamera();
            googles_quantiy = dataHelper.GetStockQuantityOfGooggles();
            charger_quantity = dataHelper.GetStockQuantityOfCharger();


            if (bicycle_quantity < 1)
            {
                lbBicycleQuantity.Text = " Currently out of the stock";
                bicycle_quantity = 0;
            }
            else
            {
                lbchargrQuan.Text = bicycle_quantity + "LEFT";
            }

            if (camera_quantity < 1)
            {
                lbCameraQuantity.Text = " Currently out od the stock";
                camera_quantity = 0;
            }
            else
            {
                lbCameraQuantity.Text = camera_quantity + " LEFT";
            }

            if (googles_quantiy < 1)
            {
                lbGogglesQuantity.Text = " Currently out of the stock";
                googles_quantiy = 0;
            }
            else
            {
                lbGogglesQuantity.Text = googles_quantiy + " LEFT";
            }

            if (charger_quantity < 1)
            {
                lbchargrQuan.Text = " Currently out of the stock";
                charger_quantity = 0;
            }
            else
            {
                lbBicycleQuantity.Text = charger_quantity + " LEFT";
            }
            timer.Stop();
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
            //btnClose.BackgroundImage = Properties.Resources.btnClose_Hover_tr;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.close_greenBTR;
        }
        public void HideLogo()
        {
            // pictureBox1.Hide();
        }
        public void HideCloseBtn()
        {
            this.btnClose.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cb_NotDefect_CheckedChanged(object sender, EventArgs e)
        {
            //gbProblemBox.Visible = false;
            gbProblemBox.Enabled = false;
            //gbReturn.Visible = false;

            cb_isDefect.Checked = false;
            //  cb_NotDefect.Checked = true;
        }

        private void cb_isDefect_CheckedChanged(object sender, EventArgs e)
        {
            //gbProblemBox.Visible = true;
            gbProblemBox.Enabled = true;
           // gbReturn.Visible = false;
            cb_NotDefect.Checked = false;
            // cb_isDefect.Checked = true;
        }

        private void rb_Return_Loan_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Return_Loan.Checked)
            {
                this.groupBox2.Visible = true;
              //  this.gbReturn.Visible = true;
                this.gbProblemBox.Visible = true;
                this.groupBox3.Visible = false;
                this.gbLoanItems.Visible = false;
                this.lb_Receipt_info.Visible = false;
                this.btnRemove.Visible = false;
                this.btnLoad.Visible = false;
                this.lbTotalPrice.Visible = false;
                this.lbPrice.Visible = false;

                this.Height = 400;
            }
            else if (rb_Issue_Loan.Checked)
            {
                this.groupBox3.Visible = true;
                this.gbLoanItems.Visible = true;
                this.lb_Receipt_info.Visible = true;
                this.btnRemove.Visible = true;
                this.btnLoad.Visible = true;
                this.lbTotalPrice.Visible = true;
                this.lbPrice.Visible = true;

                this.groupBox2.Visible = false;

                this.Height = 700;
            }
        }

        private void lbLoan_Status_Click(object sender, EventArgs e)
        {

        }
    }
}
