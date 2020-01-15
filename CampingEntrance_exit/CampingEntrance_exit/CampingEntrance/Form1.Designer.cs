namespace CampingEntrance
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVisitorName = new System.Windows.Forms.Label();
            this.lb_visitorStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btn_Close);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblVisitorName);
            this.groupBox2.Controls.Add(this.lb_visitorStatus);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnEnter);
            this.groupBox2.Controls.Add(this.btnScan);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 429);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = global::CampingEntrance.Properties.Resources.button_x;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Location = new System.Drawing.Point(500, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(68, 38);
            this.btn_Close.TabIndex = 56;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(504, 12);
            this.label2.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(427, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Check out";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(176, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Please Scan Rfid here!!";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Check IN";
            // 
            // lblVisitorName
            // 
            this.lblVisitorName.AutoSize = true;
            this.lblVisitorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblVisitorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitorName.ForeColor = System.Drawing.Color.Black;
            this.lblVisitorName.Location = new System.Drawing.Point(25, 28);
            this.lblVisitorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVisitorName.Name = "lblVisitorName";
            this.lblVisitorName.Size = new System.Drawing.Size(117, 24);
            this.lblVisitorName.TabIndex = 11;
            this.lblVisitorName.Text = "Visitor Name";
            // 
            // lb_visitorStatus
            // 
            this.lb_visitorStatus.AutoSize = true;
            this.lb_visitorStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lb_visitorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_visitorStatus.ForeColor = System.Drawing.Color.Black;
            this.lb_visitorStatus.Location = new System.Drawing.Point(26, 81);
            this.lb_visitorStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_visitorStatus.Name = "lb_visitorStatus";
            this.lb_visitorStatus.Size = new System.Drawing.Size(116, 24);
            this.lb_visitorStatus.TabIndex = 10;
            this.lb_visitorStatus.Text = "Visitor Status";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(3, 384);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(562, 42);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "check status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::CampingEntrance.Properties.Resources.logout;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(389, 181);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(162, 113);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnEnter
            // 
            this.btnEnter.BackgroundImage = global::CampingEntrance.Properties.Resources.login;
            this.btnEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnter.Location = new System.Drawing.Point(7, 188);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(162, 99);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click_1);
            // 
            // btnScan
            // 
            this.btnScan.BackgroundImage = global::CampingEntrance.Properties.Resources.Rfid__2_;
            this.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScan.Location = new System.Drawing.Point(194, 186);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(162, 102);
            this.btnScan.TabIndex = 2;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button8.BackgroundImage = global::CampingEntrance.Properties.Resources.button_book_a_camping_spot_if_you_dont_have_one;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.Location = new System.Drawing.Point(-1, 429);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(568, 50);
            this.button8.TabIndex = 57;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(562, 479);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVisitorName;
        private System.Windows.Forms.Label lb_visitorStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label2;
    }
}

