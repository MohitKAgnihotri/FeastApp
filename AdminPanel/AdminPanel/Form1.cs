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
    public partial class Form1 : Form
    {
        VisitorsOverview visitorsOverview;
        Camping_overview campingOverview;
        ProductsOverview productsOverview;
        FinanceOverview financeOverview;

       
        MySqlhelper msh;

        public Form1()
        {
            InitializeComponent();
            
            msh = new MySqlhelper();

            visitorsOverview = new VisitorsOverview();
            campingOverview = new Camping_overview();
            productsOverview = new ProductsOverview();
            financeOverview = new FinanceOverview();

            lbCurrVisitors.Text = msh.GetVisitorsInTheEvent().ToString();
            lbProfit.Text = msh.GetTotalMoneySpent().ToString();
            lbProductsSold.Text = msh.GetTotalProductsSoldAndRent().ToString();
            lbCampTaken.Text = msh.GetBookedCampings().ToString();
            lbCheckedin.Text = msh.GetVisitorCheckedInEvent().ToString();
            lbCheckedOut.Text = msh.GetVisitorCheckedOutEvent().ToString();
            timer1.Start();
        }

        private void btnVisitorsInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (visitorsOverview.IsDisposed == true)
                {
                    visitorsOverview = new VisitorsOverview();

                }
                visitorsOverview.Show();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCampingInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (campingOverview.IsDisposed == true)
                {
                    campingOverview = new Camping_overview();

                }
                campingOverview.Show();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnProductsInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsOverview.IsDisposed == true)
                {
                    productsOverview = new ProductsOverview();

                }
                productsOverview.Show();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinanceInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (financeOverview.IsDisposed == true)
                {
                   financeOverview = new FinanceOverview();

                }
                financeOverview.Show();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbCurrVisitors.Text = msh.GetVisitorsInTheEvent().ToString();
            lbProfit.Text = msh.GetTotalMoneySpent().ToString();
            lbProductsSold.Text = msh.GetTotalProductsSoldAndRent().ToString();
            lbCampTaken.Text = msh.GetBookedCampings().ToString();
            lbCheckedin.Text = msh.GetVisitorCheckedInEvent().ToString();
            lbCheckedOut.Text = msh.GetVisitorCheckedOutEvent().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblVisitorName_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbProfit_Click(object sender, EventArgs e)
        {

        }

        //private void pr1_Click(object sender, EventArgs e)
        //{
        //    pr1.Value = msh.GetVisitorCheckedInEvent();
        //}
    }
}
