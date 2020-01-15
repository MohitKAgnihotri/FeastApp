namespace ATM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbVisitor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnAddOther = new System.Windows.Forms.Button();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd100 = new System.Windows.Forms.Button();
            this.btnAdd50 = new System.Windows.Forms.Button();
            this.btnAdd20 = new System.Windows.Forms.Button();
            this.btnAdd10 = new System.Windows.Forms.Button();
            this.lbAtmStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVisitor
            // 
            this.lbVisitor.BackColor = System.Drawing.Color.Violet;
            this.lbVisitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbVisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVisitor.ForeColor = System.Drawing.Color.White;
            this.lbVisitor.Location = new System.Drawing.Point(4, 31);
            this.lbVisitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVisitor.Name = "lbVisitor";
            this.lbVisitor.Size = new System.Drawing.Size(525, 30);
            this.lbVisitor.TabIndex = 0;
            this.lbVisitor.Text = "Visitor RFID";
            this.lbVisitor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbVisitor.Click += new System.EventHandler(this.lbVisitor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.lbVisitor);
            this.groupBox1.Controls.Add(this.btnAddOther);
            this.groupBox1.Controls.Add(this.tbAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAdd100);
            this.groupBox1.Controls.Add(this.btnAdd50);
            this.groupBox1.Controls.Add(this.btnAdd20);
            this.groupBox1.Controls.Add(this.btnAdd10);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(533, 326);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ATM";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "SCAN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnScan
            // 
            this.btnScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScan.BackgroundImage")));
            this.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScan.Location = new System.Drawing.Point(211, 158);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(100, 65);
            this.btnScan.TabIndex = 3;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnAddOther
            // 
            this.btnAddOther.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddOther.Image = global::ATM.Properties.Resources.button_add_now;
            this.btnAddOther.Location = new System.Drawing.Point(379, 277);
            this.btnAddOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddOther.Name = "btnAddOther";
            this.btnAddOther.Size = new System.Drawing.Size(132, 38);
            this.btnAddOther.TabIndex = 4;
            this.btnAddOther.UseVisualStyleBackColor = true;
            this.btnAddOther.Click += new System.EventHandler(this.btnAddOther_Click);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(195, 277);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(133, 34);
            this.tbAmount.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(3, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Other amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "How much you want to add in to your account?";
            // 
            // btnAdd100
            // 
            this.btnAdd100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd100.Image = global::ATM.Properties.Resources.button__16_2;
            this.btnAdd100.Location = new System.Drawing.Point(404, 199);
            this.btnAdd100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd100.Name = "btnAdd100";
            this.btnAdd100.Size = new System.Drawing.Size(107, 47);
            this.btnAdd100.TabIndex = 3;
            this.btnAdd100.UseVisualStyleBackColor = true;
            this.btnAdd100.Click += new System.EventHandler(this.btnAdd100_Click);
            // 
            // btnAdd50
            // 
            this.btnAdd50.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd50.Image = global::ATM.Properties.Resources.button__15_2;
            this.btnAdd50.Location = new System.Drawing.Point(31, 199);
            this.btnAdd50.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd50.Name = "btnAdd50";
            this.btnAdd50.Size = new System.Drawing.Size(108, 47);
            this.btnAdd50.TabIndex = 2;
            this.btnAdd50.UseVisualStyleBackColor = true;
            this.btnAdd50.Click += new System.EventHandler(this.btnAdd50_Click);
            // 
            // btnAdd20
            // 
            this.btnAdd20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd20.Image = global::ATM.Properties.Resources.button__12_2;
            this.btnAdd20.Location = new System.Drawing.Point(404, 129);
            this.btnAdd20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd20.Name = "btnAdd20";
            this.btnAdd20.Size = new System.Drawing.Size(107, 47);
            this.btnAdd20.TabIndex = 1;
            this.btnAdd20.UseVisualStyleBackColor = true;
            this.btnAdd20.Click += new System.EventHandler(this.btnAdd20_Click);
            // 
            // btnAdd10
            // 
            this.btnAdd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd10.ForeColor = System.Drawing.Color.White;
            this.btnAdd10.Image = global::ATM.Properties.Resources.button__11_4;
            this.btnAdd10.Location = new System.Drawing.Point(31, 129);
            this.btnAdd10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd10.Name = "btnAdd10";
            this.btnAdd10.Size = new System.Drawing.Size(108, 47);
            this.btnAdd10.TabIndex = 0;
            this.btnAdd10.UseVisualStyleBackColor = true;
            this.btnAdd10.Click += new System.EventHandler(this.btnAdd10_Click);
            // 
            // lbAtmStatus
            // 
            this.lbAtmStatus.BackColor = System.Drawing.Color.MintCream;
            this.lbAtmStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbAtmStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtmStatus.Location = new System.Drawing.Point(0, 331);
            this.lbAtmStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAtmStatus.Name = "lbAtmStatus";
            this.lbAtmStatus.Size = new System.Drawing.Size(537, 44);
            this.lbAtmStatus.TabIndex = 7;
            this.lbAtmStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 375);
            this.Controls.Add(this.lbAtmStatus);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbVisitor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddOther;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd100;
        private System.Windows.Forms.Button btnAdd50;
        private System.Windows.Forms.Button btnAdd20;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd10;
        private System.Windows.Forms.Label lbAtmStatus;
    }
}

