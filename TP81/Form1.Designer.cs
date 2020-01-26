namespace License_Tems
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
            this.Gblc = new System.Windows.Forms.GroupBox();
            this.BtGenerate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.TxtCntV = new System.Windows.Forms.TextBox();
            this.LbCntV = new System.Windows.Forms.Label();
            this.TxtContID = new System.Windows.Forms.TextBox();
            this.LbContID = new System.Windows.Forms.Label();
            this.LbSystID = new System.Windows.Forms.Label();
            this.TxtSysID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txtcustomerid = new System.Windows.Forms.TextBox();
            this.Txtdeviceid = new System.Windows.Forms.TextBox();
            this.LbCid = new System.Windows.Forms.Label();
            this.LbImei = new System.Windows.Forms.Label();
            this.Txtcomment = new System.Windows.Forms.TextBox();
            this.Gblc.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gblc
            // 
            this.Gblc.Controls.Add(this.BtGenerate);
            this.Gblc.Controls.Add(this.groupBox4);
            this.Gblc.Controls.Add(this.label1);
            this.Gblc.Controls.Add(this.Txtcustomerid);
            this.Gblc.Controls.Add(this.Txtdeviceid);
            this.Gblc.Controls.Add(this.LbCid);
            this.Gblc.Controls.Add(this.LbImei);
            this.Gblc.Controls.Add(this.Txtcomment);
            this.Gblc.Location = new System.Drawing.Point(17, 19);
            this.Gblc.Name = "Gblc";
            this.Gblc.Size = new System.Drawing.Size(405, 313);
            this.Gblc.TabIndex = 7;
            this.Gblc.TabStop = false;
            // 
            // BtGenerate
            // 
            this.BtGenerate.Location = new System.Drawing.Point(12, 266);
            this.BtGenerate.Name = "BtGenerate";
            this.BtGenerate.Size = new System.Drawing.Size(387, 32);
            this.BtGenerate.TabIndex = 1;
            this.BtGenerate.Text = "Generate";
            this.BtGenerate.UseVisualStyleBackColor = true;
            this.BtGenerate.Click += new System.EventHandler(this.BtGenerate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.checkedListBox1);
            this.groupBox4.Controls.Add(this.TxtCntV);
            this.groupBox4.Controls.Add(this.LbCntV);
            this.groupBox4.Controls.Add(this.TxtContID);
            this.groupBox4.Controls.Add(this.LbContID);
            this.groupBox4.Controls.Add(this.LbSystID);
            this.groupBox4.Controls.Add(this.TxtSysID);
            this.groupBox4.Location = new System.Drawing.Point(12, 102);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 158);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(189, 20);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Valid:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(183, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(189, 82);
            this.checkedListBox1.TabIndex = 13;
            // 
            // TxtCntV
            // 
            this.TxtCntV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCntV.Location = new System.Drawing.Point(57, 64);
            this.TxtCntV.Multiline = true;
            this.TxtCntV.Name = "TxtCntV";
            this.TxtCntV.ReadOnly = true;
            this.TxtCntV.Size = new System.Drawing.Size(34, 17);
            this.TxtCntV.TabIndex = 12;
            this.TxtCntV.Text = "0";
            this.TxtCntV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbCntV
            // 
            this.LbCntV.AutoSize = true;
            this.LbCntV.Location = new System.Drawing.Point(6, 66);
            this.LbCntV.Name = "LbCntV";
            this.LbCntV.Size = new System.Drawing.Size(48, 13);
            this.LbCntV.TabIndex = 11;
            this.LbCntV.Text = "Version :";
            // 
            // TxtContID
            // 
            this.TxtContID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtContID.Location = new System.Drawing.Point(57, 21);
            this.TxtContID.Multiline = true;
            this.TxtContID.Name = "TxtContID";
            this.TxtContID.ReadOnly = true;
            this.TxtContID.Size = new System.Drawing.Size(34, 17);
            this.TxtContID.TabIndex = 5;
            this.TxtContID.Text = "4";
            this.TxtContID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbContID
            // 
            this.LbContID.AutoSize = true;
            this.LbContID.Location = new System.Drawing.Point(6, 21);
            this.LbContID.Name = "LbContID";
            this.LbContID.Size = new System.Drawing.Size(22, 13);
            this.LbContID.TabIndex = 6;
            this.LbContID.Text = "Id :";
            // 
            // LbSystID
            // 
            this.LbSystID.AutoSize = true;
            this.LbSystID.Location = new System.Drawing.Point(7, 44);
            this.LbSystID.Name = "LbSystID";
            this.LbSystID.Size = new System.Drawing.Size(47, 13);
            this.LbSystID.TabIndex = 7;
            this.LbSystID.Text = "System :";
            // 
            // TxtSysID
            // 
            this.TxtSysID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSysID.Location = new System.Drawing.Point(60, 41);
            this.TxtSysID.Multiline = true;
            this.TxtSysID.Name = "TxtSysID";
            this.TxtSysID.ReadOnly = true;
            this.TxtSysID.Size = new System.Drawing.Size(34, 17);
            this.TxtSysID.TabIndex = 8;
            this.TxtSysID.Text = "2797";
            this.TxtSysID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device ID :";
            // 
            // Txtcustomerid
            // 
            this.Txtcustomerid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txtcustomerid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcustomerid.Location = new System.Drawing.Point(80, 75);
            this.Txtcustomerid.Multiline = true;
            this.Txtcustomerid.Name = "Txtcustomerid";
            this.Txtcustomerid.Size = new System.Drawing.Size(319, 21);
            this.Txtcustomerid.TabIndex = 9;
            this.Txtcustomerid.Text = "1";
            this.Txtcustomerid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtcustomerid.TextChanged += new System.EventHandler(this.Txtcustomerid_TextChanged);
            // 
            // Txtdeviceid
            // 
            this.Txtdeviceid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txtdeviceid.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdeviceid.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Txtdeviceid.Location = new System.Drawing.Point(80, 18);
            this.Txtdeviceid.MaxLength = 50;
            this.Txtdeviceid.Name = "Txtdeviceid";
            this.Txtdeviceid.Size = new System.Drawing.Size(319, 25);
            this.Txtdeviceid.TabIndex = 2;
            this.Txtdeviceid.TextChanged += new System.EventHandler(this.Txtdeviceid_TextChanged);
            // 
            // LbCid
            // 
            this.LbCid.AutoSize = true;
            this.LbCid.Location = new System.Drawing.Point(6, 74);
            this.LbCid.Name = "LbCid";
            this.LbCid.Size = new System.Drawing.Size(68, 13);
            this.LbCid.TabIndex = 10;
            this.LbCid.Text = "CustomerID :";
            // 
            // LbImei
            // 
            this.LbImei.AutoSize = true;
            this.LbImei.Location = new System.Drawing.Point(6, 47);
            this.LbImei.Name = "LbImei";
            this.LbImei.Size = new System.Drawing.Size(57, 13);
            this.LbImei.TabIndex = 1;
            this.LbImei.Text = "Comment :";
            // 
            // Txtcomment
            // 
            this.Txtcomment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txtcomment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcomment.Location = new System.Drawing.Point(80, 46);
            this.Txtcomment.Multiline = true;
            this.Txtcomment.Name = "Txtcomment";
            this.Txtcomment.Size = new System.Drawing.Size(319, 25);
            this.Txtcomment.TabIndex = 0;
            this.Txtcomment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 343);
            this.Controls.Add(this.Gblc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "         Pocket 8.1 - Windows mobile 6";
            this.Gblc.ResumeLayout(false);
            this.Gblc.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gblc;
        private System.Windows.Forms.Button BtGenerate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtCntV;
        private System.Windows.Forms.Label LbCntV;
        private System.Windows.Forms.TextBox TxtContID;
        private System.Windows.Forms.Label LbContID;
        private System.Windows.Forms.Label LbSystID;
        private System.Windows.Forms.TextBox TxtSysID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtcustomerid;
        private System.Windows.Forms.TextBox Txtdeviceid;
        private System.Windows.Forms.Label LbCid;
        private System.Windows.Forms.Label LbImei;
        private System.Windows.Forms.TextBox Txtcomment;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

