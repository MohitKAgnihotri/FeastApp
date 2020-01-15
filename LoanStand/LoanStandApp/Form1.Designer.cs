namespace LoanStandApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbGogglesQuantity = new System.Windows.Forms.Label();
            this.lbchargrQuan = new System.Windows.Forms.Label();
            this.lbCameraQuantity = new System.Windows.Forms.Label();
            this.lbBicycleQuantity = new System.Windows.Forms.Label();
            this.lbGogglesPrice = new System.Windows.Forms.Label();
            this.lbChargerPrice = new System.Windows.Forms.Label();
            this.lbCameraPrice = new System.Windows.Forms.Label();
            this.lbBicyclePrice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.cb_NotDefect = new System.Windows.Forms.CheckBox();
            this.gbProblemBox = new System.Windows.Forms.GroupBox();
            this.tbProblem = new System.Windows.Forms.TextBox();
            this.cb_isDefect = new System.Windows.Forms.CheckBox();
            this.lbLoan_Status = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lb_Receipt_info = new System.Windows.Forms.ListBox();
            this.lbRfid_Status = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbLoanItems = new System.Windows.Forms.GroupBox();
            this.pbBicycle = new System.Windows.Forms.PictureBox();
            this.pbCap = new System.Windows.Forms.PictureBox();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.pbCharger = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnScan_Rfid = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.gbLoanApp = new System.Windows.Forms.GroupBox();
            this.rb_Return_Loan = new System.Windows.Forms.RadioButton();
            this.rb_Issue_Loan = new System.Windows.Forms.RadioButton();
            this.lblLoanStatus = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gbProblemBox.SuspendLayout();
            this.gbLoanItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBicycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharger)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.gbLoanApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGogglesQuantity
            // 
            resources.ApplyResources(this.lbGogglesQuantity, "lbGogglesQuantity");
            this.lbGogglesQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbGogglesQuantity.Name = "lbGogglesQuantity";
            // 
            // lbchargrQuan
            // 
            resources.ApplyResources(this.lbchargrQuan, "lbchargrQuan");
            this.lbchargrQuan.Name = "lbchargrQuan";
            // 
            // lbCameraQuantity
            // 
            resources.ApplyResources(this.lbCameraQuantity, "lbCameraQuantity");
            this.lbCameraQuantity.Name = "lbCameraQuantity";
            // 
            // lbBicycleQuantity
            // 
            resources.ApplyResources(this.lbBicycleQuantity, "lbBicycleQuantity");
            this.lbBicycleQuantity.Name = "lbBicycleQuantity";
            // 
            // lbGogglesPrice
            // 
            resources.ApplyResources(this.lbGogglesPrice, "lbGogglesPrice");
            this.lbGogglesPrice.Name = "lbGogglesPrice";
            // 
            // lbChargerPrice
            // 
            resources.ApplyResources(this.lbChargerPrice, "lbChargerPrice");
            this.lbChargerPrice.Name = "lbChargerPrice";
            // 
            // lbCameraPrice
            // 
            resources.ApplyResources(this.lbCameraPrice, "lbCameraPrice");
            this.lbCameraPrice.Name = "lbCameraPrice";
            // 
            // lbBicyclePrice
            // 
            resources.ApplyResources(this.lbBicyclePrice, "lbBicyclePrice");
            this.lbBicyclePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbBicyclePrice.Name = "lbBicyclePrice";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.btnReturn);
            this.groupBox2.Controls.Add(this.cb_NotDefect);
            this.groupBox2.Controls.Add(this.gbProblemBox);
            this.groupBox2.Controls.Add(this.cb_isDefect);
            this.groupBox2.Controls.Add(this.lbLoan_Status);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.BackgroundImage = global::LoanStandApp.Properties.Resources.button_return1;
            resources.ApplyResources(this.btnReturn, "btnReturn");
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // cb_NotDefect
            // 
            resources.ApplyResources(this.cb_NotDefect, "cb_NotDefect");
            this.cb_NotDefect.ForeColor = System.Drawing.Color.Black;
            this.cb_NotDefect.Name = "cb_NotDefect";
            this.cb_NotDefect.UseVisualStyleBackColor = true;
            this.cb_NotDefect.CheckedChanged += new System.EventHandler(this.cb_NotDefect_CheckedChanged);
            // 
            // gbProblemBox
            // 
            this.gbProblemBox.Controls.Add(this.tbProblem);
            resources.ApplyResources(this.gbProblemBox, "gbProblemBox");
            this.gbProblemBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbProblemBox.ForeColor = System.Drawing.Color.White;
            this.gbProblemBox.Name = "gbProblemBox";
            this.gbProblemBox.TabStop = false;
            // 
            // tbProblem
            // 
            this.tbProblem.BackColor = System.Drawing.SystemColors.Menu;
            resources.ApplyResources(this.tbProblem, "tbProblem");
            this.tbProblem.Name = "tbProblem";
            // 
            // cb_isDefect
            // 
            resources.ApplyResources(this.cb_isDefect, "cb_isDefect");
            this.cb_isDefect.ForeColor = System.Drawing.Color.Black;
            this.cb_isDefect.Name = "cb_isDefect";
            this.cb_isDefect.UseVisualStyleBackColor = true;
            this.cb_isDefect.CheckedChanged += new System.EventHandler(this.cb_isDefect_CheckedChanged);
            // 
            // lbLoan_Status
            // 
            this.lbLoan_Status.BackColor = System.Drawing.SystemColors.Menu;
            resources.ApplyResources(this.lbLoan_Status, "lbLoan_Status");
            this.lbLoan_Status.ForeColor = System.Drawing.Color.Black;
            this.lbLoan_Status.Name = "lbLoan_Status";
            this.lbLoan_Status.Click += new System.EventHandler(this.lbLoan_Status_Click);
            // 
            // lbTotalPrice
            // 
            resources.ApplyResources(this.lbTotalPrice, "lbTotalPrice");
            this.lbTotalPrice.Name = "lbTotalPrice";
            // 
            // lbPrice
            // 
            resources.ApplyResources(this.lbPrice, "lbPrice");
            this.lbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbPrice.ForeColor = System.Drawing.Color.Transparent;
            this.lbPrice.Name = "lbPrice";
            // 
            // lb_Receipt_info
            // 
            this.lb_Receipt_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_Receipt_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Receipt_info.ForeColor = System.Drawing.Color.Black;
            this.lb_Receipt_info.FormattingEnabled = true;
            resources.ApplyResources(this.lb_Receipt_info, "lb_Receipt_info");
            this.lb_Receipt_info.Name = "lb_Receipt_info";
            // 
            // lbRfid_Status
            // 
            resources.ApplyResources(this.lbRfid_Status, "lbRfid_Status");
            this.lbRfid_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbRfid_Status.ForeColor = System.Drawing.Color.White;
            this.lbRfid_Status.Name = "lbRfid_Status";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbLoanItems
            // 
            this.gbLoanItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gbLoanItems.Controls.Add(this.pbBicycle);
            this.gbLoanItems.Controls.Add(this.lbGogglesQuantity);
            this.gbLoanItems.Controls.Add(this.lbBicyclePrice);
            this.gbLoanItems.Controls.Add(this.lbGogglesPrice);
            this.gbLoanItems.Controls.Add(this.lbchargrQuan);
            this.gbLoanItems.Controls.Add(this.pbCap);
            this.gbLoanItems.Controls.Add(this.lbBicycleQuantity);
            this.gbLoanItems.Controls.Add(this.lbCameraQuantity);
            this.gbLoanItems.Controls.Add(this.lbChargerPrice);
            this.gbLoanItems.Controls.Add(this.pbCamera);
            this.gbLoanItems.Controls.Add(this.pbCharger);
            this.gbLoanItems.Controls.Add(this.lbCameraPrice);
            resources.ApplyResources(this.gbLoanItems, "gbLoanItems");
            this.gbLoanItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbLoanItems.Name = "gbLoanItems";
            this.gbLoanItems.TabStop = false;
            // 
            // pbBicycle
            // 
            this.pbBicycle.BackgroundImage = global::LoanStandApp.Properties.Resources.download__2_;
            resources.ApplyResources(this.pbBicycle, "pbBicycle");
            this.pbBicycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBicycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBicycle.Name = "pbBicycle";
            this.pbBicycle.TabStop = false;
            this.pbBicycle.Click += new System.EventHandler(this.pbBackpack_Click);
            // 
            // pbCap
            // 
            this.pbCap.BackgroundImage = global::LoanStandApp.Properties.Resources.Chief_Goggles_front2_c5ebced4_d838_41ac_9375_a77b87a820af_630x900;
            resources.ApplyResources(this.pbCap, "pbCap");
            this.pbCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCap.Name = "pbCap";
            this.pbCap.TabStop = false;
            this.pbCap.Click += new System.EventHandler(this.pbStick_Click);
            // 
            // pbCamera
            // 
            this.pbCamera.BackgroundImage = global::LoanStandApp.Properties.Resources.download__1_;
            resources.ApplyResources(this.pbCamera, "pbCamera");
            this.pbCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.TabStop = false;
            this.pbCamera.Click += new System.EventHandler(this.pbCamera_Click);
            // 
            // pbCharger
            // 
            this.pbCharger.BackgroundImage = global::LoanStandApp.Properties.Resources.kisspng_battery_charger_samsung_galaxy_s8_usb_c_quick_char_usb_5ad6933119bb09_7135566015240118251054;
            resources.ApplyResources(this.pbCharger, "pbCharger");
            this.pbCharger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCharger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCharger.Name = "pbCharger";
            this.pbCharger.TabStop = false;
            this.pbCharger.Click += new System.EventHandler(this.pbCharger_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.btnScan_Rfid);
            this.groupBox3.Controls.Add(this.lbRfid_Status);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btnScan_Rfid
            // 
            this.btnScan_Rfid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnScan_Rfid.BackgroundImage = global::LoanStandApp.Properties.Resources.rfidbutten;
            resources.ApplyResources(this.btnScan_Rfid, "btnScan_Rfid");
            this.btnScan_Rfid.Name = "btnScan_Rfid";
            this.btnScan_Rfid.UseVisualStyleBackColor = false;
            this.btnScan_Rfid.Click += new System.EventHandler(this.btnScanRfid_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRemove.BackgroundImage = global::LoanStandApp.Properties.Resources.button_remove1;
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLoad.BackgroundImage = global::LoanStandApp.Properties.Resources.button_loan1;
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::LoanStandApp.Properties.Resources.button_x;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // gbLoanApp
            // 
            resources.ApplyResources(this.gbLoanApp, "gbLoanApp");
            this.gbLoanApp.Controls.Add(this.rb_Return_Loan);
            this.gbLoanApp.Controls.Add(this.groupBox2);
            this.gbLoanApp.Controls.Add(this.rb_Issue_Loan);
            this.gbLoanApp.Controls.Add(this.groupBox3);
            this.gbLoanApp.Controls.Add(this.lb_Receipt_info);
            this.gbLoanApp.Controls.Add(this.gbLoanItems);
            this.gbLoanApp.Controls.Add(this.btnRemove);
            this.gbLoanApp.Controls.Add(this.btnLoad);
            this.gbLoanApp.Controls.Add(this.lbTotalPrice);
            this.gbLoanApp.Controls.Add(this.lbPrice);
            this.gbLoanApp.Name = "gbLoanApp";
            this.gbLoanApp.TabStop = false;
            // 
            // rb_Return_Loan
            // 
            resources.ApplyResources(this.rb_Return_Loan, "rb_Return_Loan");
            this.rb_Return_Loan.Name = "rb_Return_Loan";
            this.rb_Return_Loan.TabStop = true;
            this.rb_Return_Loan.UseVisualStyleBackColor = true;
            this.rb_Return_Loan.CheckedChanged += new System.EventHandler(this.rb_Return_Loan_CheckedChanged);
            // 
            // rb_Issue_Loan
            // 
            resources.ApplyResources(this.rb_Issue_Loan, "rb_Issue_Loan");
            this.rb_Issue_Loan.Name = "rb_Issue_Loan";
            this.rb_Issue_Loan.TabStop = true;
            this.rb_Issue_Loan.UseVisualStyleBackColor = true;
            this.rb_Issue_Loan.CheckedChanged += new System.EventHandler(this.rb_Return_Loan_CheckedChanged);
            // 
            // lblLoanStatus
            // 
            this.lblLoanStatus.BackColor = System.Drawing.SystemColors.Menu;
            resources.ApplyResources(this.lblLoanStatus, "lblLoanStatus");
            this.lblLoanStatus.ForeColor = System.Drawing.Color.Black;
            this.lblLoanStatus.Name = "lblLoanStatus";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblLoanStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbLoanApp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbProblemBox.ResumeLayout(false);
            this.gbProblemBox.PerformLayout();
            this.gbLoanItems.ResumeLayout(false);
            this.gbLoanItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBicycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharger)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.gbLoanApp.ResumeLayout(false);
            this.gbLoanApp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.ListBox lb_Receipt_info;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox pbCharger;
        private System.Windows.Forms.PictureBox pbBicycle;
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.PictureBox pbCap;
        private System.Windows.Forms.Label lbGogglesPrice;
        private System.Windows.Forms.Label lbChargerPrice;
        private System.Windows.Forms.Label lbCameraPrice;
        private System.Windows.Forms.Label lbBicyclePrice;
        private System.Windows.Forms.TextBox tbProblem;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnScan_Rfid;
        private System.Windows.Forms.Label lbRfid_Status;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbGogglesQuantity;
        private System.Windows.Forms.Label lbchargrQuan;
        private System.Windows.Forms.Label lbCameraQuantity;
        private System.Windows.Forms.Label lbBicycleQuantity;
        private System.Windows.Forms.Label lbLoan_Status;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.GroupBox gbLoanItems;
        private System.Windows.Forms.CheckBox cb_NotDefect;
        private System.Windows.Forms.CheckBox cb_isDefect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbLoanApp;
        private System.Windows.Forms.GroupBox gbProblemBox;
        private System.Windows.Forms.RadioButton rb_Return_Loan;
        private System.Windows.Forms.RadioButton rb_Issue_Loan;
        private System.Windows.Forms.Label lblLoanStatus;
    }
}

