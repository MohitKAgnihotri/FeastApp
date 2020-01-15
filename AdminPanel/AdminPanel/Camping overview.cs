using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    
    public partial class Camping_overview : Form
    {
        MySqlhelper msh;

        public Camping_overview()
        {
            msh = new MySqlhelper();
            InitializeComponent();
            lbFree.Text = msh.GetCampingsNotBooked().ToString();
            lbNoBooked.Text = msh.GetBookedCampings().ToString();
            foreach (string item in msh.GetCampingId())
            {
                cbProductsSold.Items.Add(item);
            }
            timer1.Start();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (msh.GetCampingInfo(Convert.ToInt32(cbProductsSold.SelectedItem)).Count > 0)
                {
                    foreach (string item in msh.GetCampingInfo(Convert.ToInt32(cbProductsSold.SelectedItem.ToString())))
                    {
                        listBox3.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("This Camping Spot is Free");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFree.Text = msh.GetCampingsNotBooked().ToString();
            lbNoBooked.Text = msh.GetBookedCampings().ToString();
        }
    }
}
