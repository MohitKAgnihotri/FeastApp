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
    public partial class VisitorsOverview : Form
    {
       
        MySqlhelper msh;
        public VisitorsOverview()
        {
            InitializeComponent();
            
            msh = new MySqlhelper();
            label7.Text = msh.GetNumberOfVisitors().ToString();
            label8.Text = msh.GetVisitorsInTheEvent().ToString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "Visitor Status:  " + msh.GetVisitorStatus(textBox3.Text);
            List<string> resut = msh.GetVisitorHistory(textBox3.Text);
            for (int i = 0; i < resut.Count; i++)
            {
                this.listBox1.Items.Add(resut[i].ToString());
            } 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = msh.GetNumberOfVisitors().ToString();
            label8.Text = msh.GetVisitorsInTheEvent().ToString();
        }
    }
}
