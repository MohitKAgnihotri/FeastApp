namespace AdminPanel
{
    partial class Camping_overview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFree = new System.Windows.Forms.Label();
            this.lbNoBooked = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbProductsSold = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.lbFree);
            this.groupBox1.Controls.Add(this.lbNoBooked);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(596, 130);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campings Statistics";
            // 
            // lbFree
            // 
            this.lbFree.AutoSize = true;
            this.lbFree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFree.ForeColor = System.Drawing.Color.Black;
            this.lbFree.Location = new System.Drawing.Point(405, 88);
            this.lbFree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbFree.Name = "lbFree";
            this.lbFree.Size = new System.Drawing.Size(37, 24);
            this.lbFree.TabIndex = 7;
            this.lbFree.Text = "NR";
            // 
            // lbNoBooked
            // 
            this.lbNoBooked.AutoSize = true;
            this.lbNoBooked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbNoBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoBooked.ForeColor = System.Drawing.Color.Black;
            this.lbNoBooked.Location = new System.Drawing.Point(98, 88);
            this.lbNoBooked.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbNoBooked.Name = "lbNoBooked";
            this.lbNoBooked.Size = new System.Drawing.Size(37, 24);
            this.lbNoBooked.TabIndex = 6;
            this.lbNoBooked.Text = "NR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(312, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Number of Free camping Spots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of Campings Booked";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, -74);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Campings Overview";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.cbProductsSold);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnStatus);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(596, 428);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camping Information";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.listBox3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(63, 131);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Size = new System.Drawing.Size(449, 297);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 25;
            this.listBox3.Location = new System.Drawing.Point(0, 69);
            this.listBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(445, 229);
            this.listBox3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(153, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Camping Info";
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.Transparent;
            this.btnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Image = global::AdminPanel.Properties.Resources.button_status2;
            this.btnStatus.Location = new System.Drawing.Point(195, 94);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(159, 36);
            this.btnStatus.TabIndex = 3;
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(132, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Camping Number";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(177, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Campings Overview";
            // 
            // cbProductsSold
            // 
            this.cbProductsSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProductsSold.FormattingEnabled = true;
            this.cbProductsSold.Location = new System.Drawing.Point(357, 42);
            this.cbProductsSold.Margin = new System.Windows.Forms.Padding(4);
            this.cbProductsSold.Name = "cbProductsSold";
            this.cbProductsSold.Size = new System.Drawing.Size(155, 28);
            this.cbProductsSold.TabIndex = 12;
            this.cbProductsSold.Text = "Spot ID";
            // 
            // Camping_overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 613);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Camping_overview";
            this.Text = "Camping_overview";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFree;
        private System.Windows.Forms.Label lbNoBooked;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProductsSold;
    }
}