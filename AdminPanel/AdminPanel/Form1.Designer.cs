namespace AdminPanel
{
    partial class Form1
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVisitorName = new System.Windows.Forms.Label();
            this.lbProductsSold = new System.Windows.Forms.Label();
            this.lbProfit = new System.Windows.Forms.Label();
            this.lbCampTaken = new System.Windows.Forms.Label();
            this.lbCurrVisitors = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVisitorsInfo = new System.Windows.Forms.Button();
            this.btnCampingInfo = new System.Windows.Forms.Button();
            this.btnFinanceInfo = new System.Windows.Forms.Button();
            this.btnProductsInfo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbCheckedin = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.lbCheckedOut = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.lbCheckedOut);
            this.groupBox1.Controls.Add(this.lb);
            this.groupBox1.Controls.Add(this.lbCheckedin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblVisitorName);
            this.groupBox1.Controls.Add(this.lbProductsSold);
            this.groupBox1.Controls.Add(this.lbProfit);
            this.groupBox1.Controls.Add(this.lbCampTaken);
            this.groupBox1.Controls.Add(this.lbCurrVisitors);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(575, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Overview";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Checked in";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(276, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rent and Sold Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(276, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Campings booked";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Currently Profit";
            // 
            // lblVisitorName
            // 
            this.lblVisitorName.AutoSize = true;
            this.lblVisitorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblVisitorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitorName.ForeColor = System.Drawing.Color.Black;
            this.lblVisitorName.Location = new System.Drawing.Point(8, 40);
            this.lblVisitorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVisitorName.Name = "lblVisitorName";
            this.lblVisitorName.Size = new System.Drawing.Size(138, 24);
            this.lblVisitorName.TabIndex = 12;
            this.lblVisitorName.Text = "Currently Users";
            this.lblVisitorName.Click += new System.EventHandler(this.lblVisitorName_Click);
            // 
            // lbProductsSold
            // 
            this.lbProductsSold.AutoSize = true;
            this.lbProductsSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductsSold.Location = new System.Drawing.Point(495, 79);
            this.lbProductsSold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProductsSold.Name = "lbProductsSold";
            this.lbProductsSold.Size = new System.Drawing.Size(57, 24);
            this.lbProductsSold.TabIndex = 7;
            this.lbProductsSold.Text = "status";
            // 
            // lbProfit
            // 
            this.lbProfit.AutoSize = true;
            this.lbProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProfit.Location = new System.Drawing.Point(183, 79);
            this.lbProfit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProfit.Name = "lbProfit";
            this.lbProfit.Size = new System.Drawing.Size(57, 24);
            this.lbProfit.TabIndex = 6;
            this.lbProfit.Text = "status";
            this.lbProfit.Click += new System.EventHandler(this.lbProfit_Click);
            // 
            // lbCampTaken
            // 
            this.lbCampTaken.AutoSize = true;
            this.lbCampTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCampTaken.Location = new System.Drawing.Point(495, 38);
            this.lbCampTaken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCampTaken.Name = "lbCampTaken";
            this.lbCampTaken.Size = new System.Drawing.Size(57, 24);
            this.lbCampTaken.TabIndex = 5;
            this.lbCampTaken.Text = "status";
            // 
            // lbCurrVisitors
            // 
            this.lbCurrVisitors.AutoSize = true;
            this.lbCurrVisitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrVisitors.Location = new System.Drawing.Point(183, 40);
            this.lbCurrVisitors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrVisitors.Name = "lbCurrVisitors";
            this.lbCurrVisitors.Size = new System.Drawing.Size(57, 24);
            this.lbCurrVisitors.TabIndex = 4;
            this.lbCurrVisitors.Text = "status";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btnVisitorsInfo);
            this.groupBox2.Controls.Add(this.btnCampingInfo);
            this.groupBox2.Controls.Add(this.btnFinanceInfo);
            this.groupBox2.Controls.Add(this.btnProductsInfo);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 165);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(575, 238);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Status Details";
            // 
            // btnVisitorsInfo
            // 
            this.btnVisitorsInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnVisitorsInfo.BackgroundImage = global::AdminPanel.Properties.Resources.button_visitors__3_;
            this.btnVisitorsInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVisitorsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisitorsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisitorsInfo.Location = new System.Drawing.Point(25, 156);
            this.btnVisitorsInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnVisitorsInfo.Name = "btnVisitorsInfo";
            this.btnVisitorsInfo.Size = new System.Drawing.Size(190, 55);
            this.btnVisitorsInfo.TabIndex = 1;
            this.btnVisitorsInfo.UseVisualStyleBackColor = false;
            this.btnVisitorsInfo.Click += new System.EventHandler(this.btnVisitorsInfo_Click);
            // 
            // btnCampingInfo
            // 
            this.btnCampingInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnCampingInfo.BackgroundImage = global::AdminPanel.Properties.Resources.button_camping_spots__2_;
            this.btnCampingInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCampingInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCampingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCampingInfo.Location = new System.Drawing.Point(25, 68);
            this.btnCampingInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCampingInfo.Name = "btnCampingInfo";
            this.btnCampingInfo.Size = new System.Drawing.Size(190, 55);
            this.btnCampingInfo.TabIndex = 2;
            this.btnCampingInfo.UseVisualStyleBackColor = false;
            this.btnCampingInfo.Click += new System.EventHandler(this.btnCampingInfo_Click);
            // 
            // btnFinanceInfo
            // 
            this.btnFinanceInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnFinanceInfo.BackgroundImage = global::AdminPanel.Properties.Resources.button_financial__1_;
            this.btnFinanceInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinanceInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinanceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceInfo.Location = new System.Drawing.Point(353, 68);
            this.btnFinanceInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinanceInfo.Name = "btnFinanceInfo";
            this.btnFinanceInfo.Size = new System.Drawing.Size(175, 55);
            this.btnFinanceInfo.TabIndex = 4;
            this.btnFinanceInfo.UseVisualStyleBackColor = false;
            this.btnFinanceInfo.Click += new System.EventHandler(this.btnFinanceInfo_Click);
            // 
            // btnProductsInfo
            // 
            this.btnProductsInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnProductsInfo.BackgroundImage = global::AdminPanel.Properties.Resources.button_items__2_;
            this.btnProductsInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductsInfo.Location = new System.Drawing.Point(353, 156);
            this.btnProductsInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductsInfo.Name = "btnProductsInfo";
            this.btnProductsInfo.Size = new System.Drawing.Size(175, 55);
            this.btnProductsInfo.TabIndex = 3;
            this.btnProductsInfo.UseVisualStyleBackColor = false;
            this.btnProductsInfo.Click += new System.EventHandler(this.btnProductsInfo_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbCheckedin
            // 
            this.lbCheckedin.AutoSize = true;
            this.lbCheckedin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckedin.Location = new System.Drawing.Point(183, 122);
            this.lbCheckedin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCheckedin.Name = "lbCheckedin";
            this.lbCheckedin.Size = new System.Drawing.Size(57, 24);
            this.lbCheckedin.TabIndex = 17;
            this.lbCheckedin.Text = "status";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.Color.Black;
            this.lb.Location = new System.Drawing.Point(276, 122);
            this.lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(117, 24);
            this.lb.TabIndex = 18;
            this.lb.Text = "Checked out";
            // 
            // lbCheckedOut
            // 
            this.lbCheckedOut.AutoSize = true;
            this.lbCheckedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckedOut.Location = new System.Drawing.Point(495, 122);
            this.lbCheckedOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCheckedOut.Name = "lbCheckedOut";
            this.lbCheckedOut.Size = new System.Drawing.Size(57, 24);
            this.lbCheckedOut.TabIndex = 19;
            this.lbCheckedOut.Text = "status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(581, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVisitorsInfo;
        private System.Windows.Forms.Button btnCampingInfo;
        private System.Windows.Forms.Button btnProductsInfo;
        private System.Windows.Forms.Button btnFinanceInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbProductsSold;
        private System.Windows.Forms.Label lbProfit;
        private System.Windows.Forms.Label lbCampTaken;
        private System.Windows.Forms.Label lbCurrVisitors;
        private System.Windows.Forms.Label lblVisitorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCheckedOut;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label lbCheckedin;
    }
}

