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

namespace CampingEntrance
{
    public partial class Form1 : Form
    {

        private RFID Rfid;
        MysqlDataHelper mdh;
        string rfid = "";
        Regestration regestration;

        public Form1()
        {
            InitializeComponent();
            lblStatus.Text = "";
            lblVisitorName.Text = "";
            lb_visitorStatus.Text = "";



        }


        public void AttachMethod(object sender, AttachEventArgs args)
        {
           lblStatus.Text = "successfully Attached";
        }



        public void VisitorCheckedStatus(object sender, RFIDTagEventArgs args)
        {
            rfid = args.Tag;
            mdh = new MysqlDataHelper();
            string firstName = mdh.GetUserNameWithRfid(rfid);

            if (firstName != "")
            {
                lblVisitorName.Text = firstName + " :";
                string status = mdh.GetCamping_StatusWithRfid(rfid);
                if (status == "in")
                {
                    lb_visitorStatus.Text = "The Visitor is in the capming terrain";
                }
                else if (status == "out")
                {
                    lb_visitorStatus.Text = "The Visitor is out of  the capming terrain";
                }
                else if (status == "The camp does not exist")
                {
                    lb_visitorStatus.Text = "No camping spot booked by the visitor";
                }
                else if (status == "somthing wrong happened!!!")
                {
                    lb_visitorStatus.Text = "somthing wrong happened!!!";
                }
                else
                {
                    lb_visitorStatus.Text = status;
                }
            }
            else
            {
                lb_visitorStatus.Text = "";
                lblStatus.Text = "There is no user assigned to this rfid";
            }
            Rfid.Close();
        }


       
        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            try
            {
                string status = mdh.VisitorCheckOut();
                if (status == "out")
                {
                    lblStatus.Text = "The visitor is out of the capming terrain";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "Checked")
                {
                    lblStatus.Text = "Checked Out !";
                    lblStatus.ForeColor = Color.Green;
                }
                else if (status == "somthing wrong happened!!!")
                {
                    lblStatus.Text = "Something wrong happened ! Try again !";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "The camp does not exist")
                {
                    lblStatus.Text = "This visitor did not book any camping spot!";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "There is no user found with that ID")
                {
                    lblStatus.Text = "Error !";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "The visitor is not at the event")
                {
                    lblStatus.Text = "This visitor is not at the event";
                    lblStatus.ForeColor = Color.Red;
                }
                lb_visitorStatus.Text = "";
                lblVisitorName.Text = "";
            }
            catch (NullReferenceException)
            {
                lblStatus.Text = "There is a problem with the connection!";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            lb_visitorStatus.Text = "";
            lblVisitorName.Text = "";


            try
            {
                Rfid = new RFID();

                Rfid.Attach += new AttachEventHandler(AttachMethod);
                Rfid.Tag += new RFIDTagEventHandler(VisitorCheckedStatus);

                Rfid.Open();
            }
            catch (DllNotFoundException ex)
            {

                MessageBox.Show("There is somthing wrong with the RFID !!!");

            }
        }

        private void btnEnter_Click_1(object sender, EventArgs e)
        {
            try
            {
                string status = mdh.VisitorChickIn();
                if (status == "in")
                {
                    lblStatus.Text = "The Visitor is in the capming terrein";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "Checked")
                {
                    lblStatus.Text = "Checked In!";
                    lblStatus.ForeColor = Color.Green;
                }
                else if (status == "somthing wrong happened!!!")
                {
                    lblStatus.Text = "Something wrong happened ! Try again !";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "The camp does not exist")
                {
                    lblStatus.Text = "This visitor did not book any camping spot !";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "There is no user found with that ID")
                {
                    lblStatus.Text = "Error !";
                    lblStatus.ForeColor = Color.Red;
                }
                else if (status == "The visitor is not at the event")
                {
                    lblStatus.Text = "This visitor is not at the event";
                    lblStatus.ForeColor = Color.Red;
                }
                lb_visitorStatus.Text = "";
                lblVisitorName.Text = "";
            }
            catch (NullReferenceException)
            {
                lblStatus.Text = "There is a problem with the connection!";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            regestration = new Regestration();
            regestration.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }




   


}


