using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CryptSharp;
using EventEntrance.Properties;
using Phidget22;
using Phidget22.Events;

namespace EventEntrance
{
    public partial class Form1 : Form
    {
        //Variable to keep the visitor's status
        private string CheckedIn = "no";
        private Point dragCursorPoint;
        private Point dragFormPoint;

        //private int giveTombolaNumber(int[] tombola,bool existNumber,int tombolaNumber)
        //{
        //    if (tombola.Count() != 0)
        //    {
        //        if (existNumber == true)
        //        {
        //            rnd = new Random();
        //            tombolaNumber = rnd.Next(1,1000);

        //            existNumber = BinarySearch(tombola, tombolaNumber);
        //            return giveTombolaNumber(tombola, existNumber, tombolaNumber);
        //        }
        //    }
        //    else
        //    {
        //        rnd = new Random();
        //        tombolaNumber = rnd.Next(1, 2);
        //    }
        //    return tombolaNumber;
        //}

        //private void btnTombola_Click(object sender, EventArgs e)
        //{
        //    Datahelper dh = new Datahelper();

        //    string status = dh.ChargeUserForTheTombola(rfidCode);
        //    if (status == "updated")
        //    {
        //        int tombolaNumber = giveTombolaNumber(tombola.Values.ToArray(),true,0);

        //        int userID = dh.GetUserIdWithRfid(rfidCode);
        //        if (userID != -1)
        //        {
        //            lbCheckStatus.ForeColor = Color.Green;
        //            lbCheckStatus.Text = lblRfidSt.Text + " is in the game with number " + tombolaNumber + "!";
        //            tombola.Add(userID, tombolaNumber);
        //            using (StreamWriter w = File.AppendText(logPath))
        //            {
        //                Log(tombolaNumber.ToString() + " " + userID.ToString(), w);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lbCheckStatus.ForeColor = Color.Red;
        //        lbCheckStatus.Text = "Something happened , please try again !";
        //    }
        //    lblRfidSt.Text = "";
        //}


        private bool dragging;

        private RFID myRfid;
        private string rfidCode = "";
        private Random rnd;

        private Dictionary<int, int> tombola;

        //Variable to keep thevisitor's ID when they need to get a RFID
        private int UserIdForSettingRfid = -1;

        public Form1()
        {
            InitializeComponent();
            tombola = new Dictionary<int, int>();
            rnd = new Random();
            lblRfidSt.Text = "";
            tbpass.PasswordChar = '*';
            lbCheckStatus.Text = "";
            lbRegisterStatus.Text = "";
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("{0}", logMessage);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var dh = new Datahelper();
            string barcode = tbBarcode.Text;
            //We check if the barcode is not null
            if (barcode != "")
            {
                //Check if the visitor exists
                var exist = dh.isVistorExsist(barcode);
                if (exist == "yes")
                {
                    //Check the visitor's status

                    if (dh.CheckIfUserExistInEventsAccount())
                    {
                        var status = dh.CheckInVisitor();
                        if (status == "Checked")
                        {
                            CheckedIn = "yes";
                            //Set the visitor's id ready for the RFID Chip
                            UserIdForSettingRfid = dh.userId;
                            lbCheckStatus.Text = "Give RFID to the Visitor now !";
                            lbCheckStatus.ForeColor = Color.Green;
                        }
                        else if (status == "nouser")
                        {
                            lbCheckStatus.Text = "There is no user with that barcode !";
                            lbCheckStatus.ForeColor = Color.Red;
                        }
                        else if (status == "in")
                        {
                            lbCheckStatus.Text = "This user is at the event !";
                            lbCheckStatus.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (dh.AddUserInEventsAccount(dh.userId))
                        {
                            var status = dh.CheckInVisitor();
                            if (status == "Checked")
                            {
                                CheckedIn = "yes";
                                //Set the visitor's id ready for the RFID Chip
                                UserIdForSettingRfid = dh.userId;
                                lbCheckStatus.Text = "Give RFID to the Visitor now !";
                                lbCheckStatus.ForeColor = Color.Green;
                            }
                            else if (status == "nouser")
                            {
                                lbCheckStatus.Text = "There is no user with that barcode !";
                                lbCheckStatus.ForeColor = Color.Red;
                            }
                            else if (status == "in")
                            {
                                lbCheckStatus.Text = "This user is at the event !";
                                lbCheckStatus.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    lbCheckStatus.Text = "There is no user with that barcode !";
                    lbCheckStatus.ForeColor = Color.Red;
                }

                tbBarcode.Text = "";
            }
            //If the barcode is null try to check in with the rfid chip
            else if (rfidCode != "")
            {
                // Checks if there is a user with that RFID Chip
                if (dh.GetUserIdWithRfid(rfidCode) != -1)
                {
                    //Check the status of the visitor
                    var process = dh.CheckInVisitor();
                    if (process == "Checked")
                    {
                        lbCheckStatus.Text = "Cheked in !";
                        lbCheckStatus.ForeColor = Color.Green;
                    }
                    else if (process == "nouser")
                    {
                        lbCheckStatus.Text = "There is no user with that rfid code !";
                        lbCheckStatus.ForeColor = Color.Red;
                    }
                    else if (process == "in")
                    {
                        lbCheckStatus.Text = "This user is at the event !";
                        lbCheckStatus.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lbCheckStatus.Text = "There is no user with that rfid code !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                lbCheckStatus.Text = "Error Scanning !";
                lbCheckStatus.ForeColor = Color.Red;
            }

            //Clear the RFID Label
            lblRfidSt.Text = "";
        }

        //Checks out the visitor
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var dh = new Datahelper();
            //Checks if the RFID reader displayed correctly the chip 
            if (lblRfidSt.Text != "" && rfidCode != "")
            {
                //Checks the status of the visitor
                var process = dh.CheckOutVisitor(rfidCode);
                if (process == "notin")
                {
                    lbCheckStatus.Text = "This user is not at the event !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "nouser")
                {
                    lbCheckStatus.Text = "There is no user with that ID number !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "out")
                {
                    lbCheckStatus.Text = "Checked out !";
                    lbCheckStatus.ForeColor = Color.Green;
                }
                else if (process == "Erorr!")
                {
                    lbCheckStatus.Text = "Something happened please try again later !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "Erorr connection!!")
                {
                    lbCheckStatus.Text = "Connection Error !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else
                {
                    var itemsLoaned = process;
                    itemsLoaned.TrimStart(' ');
                    var items = itemsLoaned.Split(' ');
                    var output = "This visitor has not returned a ";
                    foreach (var item in items)
                        if (item != "")
                        {
                            if (item == items[items.Count() - 1])
                                output += item;
                            else
                                output += item + " and a ";
                        }

                    lbCheckStatus.Text = output;
                    lbCheckStatus.ForeColor = Color.Red;
                }

                lblRfidSt.Text = "";
            }
            else if (tbBarcode.Text != "")
            {
                var process = dh.CheckOutVisitorInCaseOfLostRfid(Convert.ToInt32(tbBarcode.Text));
                if (process == "notin")
                {
                    lbCheckStatus.Text = "This user is not at the event !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "nouser")
                {
                    lbCheckStatus.Text = "There is no user with that ID number !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "out")
                {
                    lbCheckStatus.Text = "Checked out !";
                    lbCheckStatus.ForeColor = Color.Green;
                }
                else if (process == "Erorr!")
                {
                    lbCheckStatus.Text = "Something happened please try again later !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
                else if (process == "Erorr connection!!")
                {
                    lbCheckStatus.Text = "Connection Error !";
                    lbCheckStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                lbCheckStatus.Text = "Erorr Scanning !";
                lbCheckStatus.ForeColor = Color.Red;
            }

            tbBarcode.Text = "";
        }

        //Register a new Visitor
        private void button4_Click(object sender, EventArgs e)
        {
            var dh = new Datahelper();
            //string patternPhone = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            var patternEmail = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
                               @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            //Regex phoneRegex = new Regex(patternPhone);
            Regex emailRegex = new Regex(patternEmail);
            string salt = Crypter.Blowfish.GenerateSalt();

            string first_name, lastname, password, email;
            //DateTime dob;
            first_name = tbfirstName.Text;
            lastname = tbNationality.Text;
            email = tbEmail.Text;
            password = tbpass.Text;
            DateTime dateOfBirth = dateTimePicker1.Value;
            string hashedPassword = Crypter.Blowfish.Crypt(password, salt);
            //dob = Convert.ToDateTime(tbphone.Text);
            //Check if the output is correct
            //TODO: Verify the correctness of the date of BIRTH
            if (first_name != "" && lastname != "" && emailRegex.IsMatch(email) == true && hashedPassword != "")
            {
                //Checks the output from the AddCustomer method and adds the Visitor to the databse
                var regStatus = dh.AddCustomer(first_name, lastname, hashedPassword, email, dateOfBirth);
                
                if (regStatus == "added")
                {
                    //We need timer to slow the process for updating the database
                    registerTimer.Start();
                    //Set the new visitor's id 
                    //Adds the new visitor to the Event and gives him a ticket
                    var st = dh.addEventAccToTheNewUser();
                    if (st == "giverfid")
                    {
                        lbRegisterStatus.Text = "Give RFID Chip to the new Visitor !";
                        lbRegisterStatus.ForeColor = Color.Green;
                        tbfirstName.Text = "";
                        tbNationality.Text = "";
                        tbEmail.Text = "";
                        //  tbphone.Text = "";
                        tbpass.Text = "";

                        UserIdForSettingRfid = dh.userId;
                        CheckedIn = "yes";
                    }
                    else
                    {
                        lbRegisterStatus.Text = "Something happened, please try again !";
                        lbRegisterStatus.ForeColor = Color.Red;
                        tbfirstName.Text = "";
                        tbNationality.Text = "";
                        tbEmail.Text = "";
                        //  tbphone.Text = "";
                        tbpass.Text = "";
                    }
                }
                else
                {
                    lbRegisterStatus.Text = " System error , try again !";
                    lbRegisterStatus.ForeColor = Color.Red;
                }

                lblRfidSt.Text = "";
            }
            else
            {
                lbRegisterStatus.Text = "Fill all information correctly, please";
                lbRegisterStatus.ForeColor = Color.Red;
            }
        }

        //Setting a RFID to a Visitor
        private void btnSetRfid_Click(object sender, EventArgs e)
        {
            try
            {
                lbCheckStatus.Text = "";
                //Checks if the visitor comes for the first time at the event
                if (CheckedIn == "yes")
                {
                    myRfid = new RFID();

                    myRfid.Attach += new AttachEventHandler(myRfidAttachMethod);
                    myRfid.Tag += new RFIDTagEventHandler(SetRfidToUser);

                    myRfid.Open();
                }
                //If the visitor has already received his rfid that's not his first time checking at the event
                else if (CheckedIn == "no")
                {
                    myRfid = new RFID();

                    myRfid.Attach += new AttachEventHandler(myRfidAttachMethod);
                    myRfid.Tag += new RFIDTagEventHandler(CheckUserRfid);

                    myRfid.Open();
                }
            }
            catch (PhidgetException ex)
            {
                throw ex;
            }
        }

        public void myRfidAttachMethod(object sender, AttachEventArgs args)
        {
            lblRfidSt.Text = " Attached";
        }

        //Setting the RFID to the new Visitor
        public void SetRfidToUser(object sender, RFIDTagEventArgs args)
        {
            rfidCode = args.Tag;
            myRfid.Close();
            var dh = new Datahelper();
            lblRfidSt.Text = dh.GetUserFirstNameWithRfid(rfidCode);
            //Setting the visitors id
            dh.userId = UserIdForSettingRfid;
            //Giving the rfid chip to the visitor
            var status = dh.GiveRfid(rfidCode);
            lbCheckStatus.Text = status;
            lblRfidSt.Text = "";
            if (status == "There is already a user with that RFID" || status == "Error Assigning RFID" ||
                status == "Error!")
            {
                lbCheckStatus.ForeColor = Color.Red;
                CheckedIn = "yes";
            }
            else
            {
                lbCheckStatus.ForeColor = Color.Green;
                lbRegisterStatus.Text = "";
                CheckedIn = "no";
            }
        }

        //Only displaying the chip
        public void CheckUserRfid(object sender, RFIDTagEventArgs args)
        {
            rfidCode = args.Tag;
            var dh = new Datahelper();
            var userName = dh.GetUserFirstNameWithRfid(rfidCode);
            if (userName != "")
                lblRfidSt.Text = userName;
            else
                lblRfidSt.Text = rfidCode;
            myRfid.Close();
        }

        private void registerTimer_Tick(object sender, EventArgs e)
        {
            registerTimer.Stop();
        }

        private bool BinarySearch(int[] data, int key)
        {
            var min = 0;
            var max = data.Length - 1;
            do
            {
                var mid = (min + max) / 2;

                if (data[mid] == key) return true;

                if (key > data[mid]) min = mid + 1;

                else max = mid - 1;
            } while (min <= max);

            return false;
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
            // btnClose.BackgroundImage = Properties.Resources.close_greenBTR;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.close_hover;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void HideLogo()
        //{
        //    pictureBox1.Hide();
        //}
        public void HideCloseBtn()
        {
            btnClose.Hide();
        }

        private void returnMoney_Click(object sender, EventArgs e)
        {
            var dh = new Datahelper();
            var status = dh.ReturnBalanceToUser(rfidCode);

            if (status == "Error")
            {
                lbCheckStatus.ForeColor = Color.Red;
                lbCheckStatus.Text = "Something happened , please try again !";
            }
            else if (status == "nouser")
            {
                lbCheckStatus.ForeColor = Color.Red;
                lbCheckStatus.Text = " Something went wrong,please try again !";
            }
            else
            {
                lbCheckStatus.ForeColor = Color.Green;
                lbCheckStatus.Text = status;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void tbpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}