namespace SerialConnectToArduinoCs
{
	partial class fmMain
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
            this.cbxShowArduinoSerialConnect = new System.Windows.Forms.CheckBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReturned = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbWriteCustom = new System.Windows.Forms.TextBox();
            this.lblSent = new System.Windows.Forms.Label();
            this.btnWriteDefault = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResetArduino = new System.Windows.Forms.Button();
            this.continuRead = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.GetOne = new System.Windows.Forms.Button();
            this.GetMulti = new System.Windows.Forms.Button();
            this.GetMultiTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbxShowArduinoSerialConnect
            // 
            this.cbxShowArduinoSerialConnect.AutoSize = true;
            this.cbxShowArduinoSerialConnect.Checked = true;
            this.cbxShowArduinoSerialConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowArduinoSerialConnect.Location = new System.Drawing.Point(96, 16);
            this.cbxShowArduinoSerialConnect.Name = "cbxShowArduinoSerialConnect";
            this.cbxShowArduinoSerialConnect.Size = new System.Drawing.Size(170, 17);
            this.cbxShowArduinoSerialConnect.TabIndex = 0;
            this.cbxShowArduinoSerialConnect.Text = "Arduino serial connect window";
            this.cbxShowArduinoSerialConnect.UseVisualStyleBackColor = true;
            this.cbxShowArduinoSerialConnect.CheckedChanged += new System.EventHandler(this.cbxShowArduinoSerialConnect_CheckedChanged);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(12, 41);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Returned:";
            // 
            // lblReturned
            // 
            this.lblReturned.AutoSize = true;
            this.lblReturned.Location = new System.Drawing.Point(153, 104);
            this.lblReturned.Name = "lblReturned";
            this.lblReturned.Size = new System.Drawing.Size(16, 13);
            this.lblReturned.TabIndex = 2;
            this.lblReturned.Text = "---";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 99);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Get Status";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sent:";
            // 
            // txbWriteCustom
            // 
            this.txbWriteCustom.Location = new System.Drawing.Point(156, 43);
            this.txbWriteCustom.Name = "txbWriteCustom";
            this.txbWriteCustom.Size = new System.Drawing.Size(110, 20);
            this.txbWriteCustom.TabIndex = 6;
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.Location = new System.Drawing.Point(153, 75);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(16, 13);
            this.lblSent.TabIndex = 5;
            this.lblSent.Text = "---";
            // 
            // btnWriteDefault
            // 
            this.btnWriteDefault.Location = new System.Drawing.Point(12, 70);
            this.btnWriteDefault.Name = "btnWriteDefault";
            this.btnWriteDefault.Size = new System.Drawing.Size(75, 23);
            this.btnWriteDefault.TabIndex = 7;
            this.btnWriteDefault.Text = "Write default";
            this.btnWriteDefault.UseVisualStyleBackColor = true;
            this.btnWriteDefault.Click += new System.EventHandler(this.btnWriteDefault_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "custom:";
            // 
            // btnResetArduino
            // 
            this.btnResetArduino.Location = new System.Drawing.Point(12, 12);
            this.btnResetArduino.Name = "btnResetArduino";
            this.btnResetArduino.Size = new System.Drawing.Size(75, 23);
            this.btnResetArduino.TabIndex = 9;
            this.btnResetArduino.Text = "Reset Arduino";
            this.btnResetArduino.UseVisualStyleBackColor = true;
            this.btnResetArduino.Click += new System.EventHandler(this.btnResetArduino_Click);
            // 
            // continuRead
            // 
            this.continuRead.AutoSize = true;
            this.continuRead.Location = new System.Drawing.Point(12, 187);
            this.continuRead.Name = "continuRead";
            this.continuRead.Size = new System.Drawing.Size(61, 17);
            this.continuRead.TabIndex = 10;
            this.continuRead.Text = "continu";
            this.continuRead.UseVisualStyleBackColor = true;
            this.continuRead.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // GetOne
            // 
            this.GetOne.Location = new System.Drawing.Point(13, 129);
            this.GetOne.Name = "GetOne";
            this.GetOne.Size = new System.Drawing.Size(75, 23);
            this.GetOne.TabIndex = 11;
            this.GetOne.Text = "Get One";
            this.GetOne.UseVisualStyleBackColor = true;
            this.GetOne.Click += new System.EventHandler(this.GetOne_Click);
            // 
            // GetMulti
            // 
            this.GetMulti.Location = new System.Drawing.Point(13, 159);
            this.GetMulti.Name = "GetMulti";
            this.GetMulti.Size = new System.Drawing.Size(75, 23);
            this.GetMulti.TabIndex = 12;
            this.GetMulti.Text = "Get multi";
            this.GetMulti.UseVisualStyleBackColor = true;
            this.GetMulti.Click += new System.EventHandler(this.GetMulti_Click);
            // 
            // GetMultiTxt
            // 
            this.GetMultiTxt.Location = new System.Drawing.Point(156, 159);
            this.GetMultiTxt.Name = "GetMultiTxt";
            this.GetMultiTxt.Size = new System.Drawing.Size(100, 20);
            this.GetMultiTxt.TabIndex = 13;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 314);
            this.Controls.Add(this.GetMultiTxt);
            this.Controls.Add(this.GetMulti);
            this.Controls.Add(this.GetOne);
            this.Controls.Add(this.continuRead);
            this.Controls.Add(this.btnResetArduino);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWriteDefault);
            this.Controls.Add(this.txbWriteCustom);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lblReturned);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.cbxShowArduinoSerialConnect);
            this.Name = "fmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbxShowArduinoSerialConnect;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblReturned;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txbWriteCustom;
		private System.Windows.Forms.Label lblSent;
		private System.Windows.Forms.Button btnWriteDefault;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnResetArduino;
        private System.Windows.Forms.CheckBox continuRead;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button GetOne;
        private System.Windows.Forms.Button GetMulti;
        private System.Windows.Forms.TextBox GetMultiTxt;
    }
}

