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
    public partial class ProductsOverview : Form
    {
        
        MySqlhelper msh;
        public ProductsOverview()
        {
            InitializeComponent();
            msh = new MySqlhelper();

            foreach (string item in msh.GetProductsForSelling())
            {
                cbProductsSold.Items.Add(item);
            }
            foreach (string item in msh.GetProductsForRenting())
            {
                cbProductsLoaned.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string quantity = msh.GetSoldItems(cbProductsSold.SelectedItem.ToString()).ToString();
                label10.Text = quantity;
                int product_price = msh.GetItemPrice(cbProductsSold.SelectedItem.ToString());
                int prdouct_quantity = int.Parse(label10.Text);
                label11.Text = (prdouct_quantity * product_price).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string quantity = msh.GetNrRentedItems(cbProductsLoaned.SelectedItem.ToString()).ToString();
                label8.Text = quantity;
                int product_price = msh.GetRentItem_Price(cbProductsLoaned.SelectedItem.ToString());
                int prdouct_quantity = int.Parse(label8.Text);
                label9.Text = (prdouct_quantity * product_price).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
