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
    public partial class FinanceOverview : Form
    {
       
        MySqlhelper msh;
        public FinanceOverview()
        {
            InitializeComponent();
            msh = new MySqlhelper();
            textBox3.Text = msh.GetTotalMoneySpent().ToString() + "$";
            textBox1.Text = msh.GetTotalBalance().ToString();
            textBox4.Text = msh.GetBookedCampings().ToString();
            textBox5.Text = msh.GetTotalAmountCampings().ToString() + "$";
            tbRentShop.Text = msh.GetRentShopMoneyEarned().ToString() + "$";
            tbFoodShop.Text = msh.GetFoodShopAmountEarned().ToString() + "$";
            tbSouvenirShop.Text = msh.GetSouvernirShopAmountEarned().ToString() + "$";

           
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = msh.GetTotalMoneySpent().ToString() + "$";
            textBox1.Text = msh.GetTotalBalance().ToString();
            textBox4.Text = msh.GetBookedCampings().ToString();
            textBox5.Text = msh.GetTotalAmountCampings().ToString() + "$";
            tbRentShop.Text = msh.GetRentShopMoneyEarned().ToString() + "$";
            tbFoodShop.Text = msh.GetFoodShopAmountEarned().ToString() + "$";
            tbSouvenirShop.Text = msh.GetSouvernirShopAmountEarned().ToString() + "$";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
