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

namespace CampingEntrance
{
    public partial class Regestration : Form
    {
        private RFID myRfid;
        MysqlDataHelper mdh;
        string rfid = "";

        int spotNumber = 0;
        int user1_id = 0;
        int user2_id = 0;
        int user3_id = 0;
        int user4_id = 0;
        int user5_id = 0;
        int user6_id = 0;

        Size pbSize = new Size(72, 55);
        public Regestration()
        {
            InitializeComponent();

            lblStatus.Text = "";

            lblUser1Name.Text = "";
            lblUser2Name.Text = "";
            lblUser3Name.Text = "";
            lblUser4Name.Text = "";
            lblUser5Name.Text = "";
            lblUser6Name.Text = "";
        }

        public void AttachMethod(object sender, AttachEventArgs args)
        {
            lblStatus.Text = "successfully Attached";
        }



        public void UserCheckingForRegistration(object sender, RFIDTagEventArgs args)
        {
            rfid = args.Tag;
            mdh = new MysqlDataHelper();
            string firstName = mdh.GetUserNameWithRfid(rfid);
            if (firstName != "")
            {
                if (lblUser1Name.Text != "")
                {
                    if (lblUser2Name.Text != "")
                    {
                        if (lblUser3Name.Text != "")
                        {
                            if (lblUser4Name.Text != "")
                            {
                                if (lblUser5Name.Text != "")
                                {
                                    if (lblUser6Name.Text != "")
                                    {
                                        lblStatus.Text = "All users are checked !";
                                        lblStatus.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        lblUser6Name.Text = firstName;
                                        user6_id = mdh.GetUser_idWithRfid(rfid);
                                    }
                                }
                                else
                                {
                                    lblUser5Name.Text = firstName;
                                    user5_id = mdh.GetUser_idWithRfid(rfid);
                                }
                            }
                            else
                            {
                                lblUser4Name.Text = firstName;
                                user4_id = mdh.GetUser_idWithRfid(rfid);
                            }
                        }
                        else
                        {
                            lblUser3Name.Text = firstName;
                            user3_id = mdh.GetUser_idWithRfid(rfid);
                        }
                    }
                    else
                    {
                        lblUser2Name.Text = firstName;
                        user2_id = mdh.GetUser_idWithRfid(rfid);
                    }
                }
                else
                {
                    lblUser1Name.Text = firstName;
                    user1_id = mdh.GetUser_idWithRfid(rfid);
                }
            }
            else
            {
                lblStatus.Text = "There is no user found with that RFID";
            }
            myRfid.Close();
        }







        

        private void pbSpot1_Click_1(object sender, EventArgs e)
        {
            spotNumber = 1;
             pbSpot1.Image = CampingEntrance.Properties.Resources.s1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot2_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.s2;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot3_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.s3;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot4_Click(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.s4;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot5_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.s5;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot6_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.s6;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot7_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.s7;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot8_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.s8;
            pbSpot9.Image = CampingEntrance.Properties.Resources.button__8_;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSpot9_Click_1(object sender, EventArgs e)
        {
            spotNumber = 2;
            pbSpot1.Image = CampingEntrance.Properties.Resources.button1;
            pbSpot2.Image = CampingEntrance.Properties.Resources.button__1_;
            pbSpot3.Image = CampingEntrance.Properties.Resources.button__2_;
            pbSpot4.Image = CampingEntrance.Properties.Resources.button__3_;
            pbSpot5.Image = CampingEntrance.Properties.Resources.button__4_;
            pbSpot6.Image = CampingEntrance.Properties.Resources.button__5_;
            pbSpot7.Image = CampingEntrance.Properties.Resources.button__6_;
            pbSpot8.Image = CampingEntrance.Properties.Resources.button__7_;
            pbSpot9.Image = CampingEntrance.Properties.Resources.s9;
            pbSpot1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot5.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot6.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot7.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot8.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSpot9.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void BtnEventRegistration_Click_1(object sender, EventArgs e)
        {
            if (user1_id != 0 && user2_id != 0 && user3_id != 0 && user4_id != 0 && user5_id != 0 && user6_id != 0 && spotNumber != 0)
            {
                string status = mdh.GroupUsersAssignedToTheCamping(user1_id, user2_id, user3_id, user4_id, user5_id, user6_id, spotNumber);
                if (status == "Succefuly Registered")
                {
                    lbRegestration.Text = "Succefuly Registered";
                    lbRegestration.ForeColor = Color.Green;
                }
                else if (status == "somthing wrong happened!!!")
                {
                    lbRegestration.Text = "somthing wrong happened!!!";
                    lbRegestration.ForeColor = Color.Red;

                }
                else
                {
                    lbRegestration.Text = status;
                    lbRegestration.ForeColor = Color.Red;
                }
                lblUser1Name.Text = "";
                lblUser2Name.Text = "";
                lblUser3Name.Text = "";
                lblUser4Name.Text = "";
                lblUser5Name.Text = "";
                lblUser6Name.Text = "";
            }
            else
            {
                if (spotNumber == 0)
                {
                    lbRegestration.Text = "Please select a camping spot!";
                    lbRegestration.ForeColor = Color.Red;
                }
                if (user1_id == 0 || user2_id == 0 || user3_id == 0 || user4_id == 0 || user5_id == 0 || user6_id == 0)
                {
                    lbRegestration.Text = "There is somthing wrong with the user data!";
                    lbRegestration.ForeColor = Color.Red;

                    lblUser1Name.Text = "";
                    lblUser2Name.Text = "";
                    lblUser3Name.Text = "";
                    lblUser4Name.Text = "";
                    lblUser5Name.Text = "";
                    lblUser6Name.Text = "";
                }
            }
        }

        private void btnCheckAvailability_Click_1(object sender, EventArgs e)
        {
            mdh = new MysqlDataHelper();
            mdh.CampingSpotAvailability();
            if (mdh.Camping_spots.Count == 0)
            {
                lbRegestration.Text = "camping spots are not available!";
                lbRegestration.ForeColor = Color.Red;
            }
            if (!mdh.Camping_spots.Contains("1"))
            {
                pbSpot1.Hide();
            }
            else
            {
                pbSpot1.Show();
            }

            if (!mdh.Camping_spots.Contains("2"))
            {
                pbSpot2.Hide();
            }
            else
            {
                pbSpot2.Show();
            }

            if (!mdh.Camping_spots.Contains("3"))
            {
                pbSpot3.Hide();
            }
            else
            {
                pbSpot3.Show();
            }

            if (!mdh.Camping_spots.Contains("4"))
            {
                pbSpot4.Hide();
            }
            else
            {
                pbSpot4.Show();
            }

            if (!mdh.Camping_spots.Contains("5"))
            {
                pbSpot5.Hide();
            }
            else
            {
                pbSpot5.Show();
            }

            if (!mdh.Camping_spots.Contains("6"))
            {
                pbSpot6.Hide();
            }
            else
            {
                pbSpot6.Show();
            }

            if (!mdh.Camping_spots.Contains("7"))
            {
                pbSpot7.Hide();
            }
            else
            {
                pbSpot7.Show();
            }

            if (!mdh.Camping_spots.Contains("8"))
            {
                pbSpot8.Hide();
            }
            else
            {
                pbSpot8.Show();
            }
            if (!mdh.Camping_spots.Contains("9"))
            {
                pbSpot9.Hide();
            }
            else
            {
                pbSpot9.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            try
            {
                myRfid = new RFID();
                myRfid.Attach += new AttachEventHandler(AttachMethod);
                myRfid.Tag += new RFIDTagEventHandler(UserCheckingForRegistration);

                myRfid.Open();
            }
            catch (DllNotFoundException ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}
