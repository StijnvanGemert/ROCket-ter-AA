namespace SerialConnectToArduinoCs
{
	partial class fmArduinoSerialConnect
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSelectIfDangerShieldIsUsed = new System.Windows.Forms.CheckBox();
            this.lblArduinoConnectionSettingsHelpDkal = new System.Windows.Forms.Label();
            this.btnScanPortsDkal = new System.Windows.Forms.Button();
            this.cbbSerialPortsDkal = new System.Windows.Forms.ComboBox();
            this.cbbBaudRateDkal = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSerialPortOpenDkal = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.serialPortArduinoConnection = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.subLogging = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resetA = new System.Windows.Forms.Button();
            this.ResetM = new System.Windows.Forms.Button();
            this.resetG = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.GroupBox();
            this.heightTxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pressTxt = new System.Windows.Forms.Label();
            this.pressBox = new System.Windows.Forms.Label();
            this.tempTxt = new System.Windows.Forms.Label();
            this.tempBox = new System.Windows.Forms.Label();
            this.battStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FWVersion = new System.Windows.Forms.Label();
            this.Firmwaretxt = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.StatusBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cbSelectIfDangerShieldIsUsed);
            this.groupBox4.Controls.Add(this.lblArduinoConnectionSettingsHelpDkal);
            this.groupBox4.Controls.Add(this.btnScanPortsDkal);
            this.groupBox4.Controls.Add(this.cbbSerialPortsDkal);
            this.groupBox4.Controls.Add(this.cbbBaudRateDkal);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.btnSerialPortOpenDkal);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 174);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Arduino connection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Port:";
            // 
            // cbSelectIfDangerShieldIsUsed
            // 
            this.cbSelectIfDangerShieldIsUsed.AutoSize = true;
            this.cbSelectIfDangerShieldIsUsed.Location = new System.Drawing.Point(9, 48);
            this.cbSelectIfDangerShieldIsUsed.Name = "cbSelectIfDangerShieldIsUsed";
            this.cbSelectIfDangerShieldIsUsed.Size = new System.Drawing.Size(128, 17);
            this.cbSelectIfDangerShieldIsUsed.TabIndex = 11;
            this.cbSelectIfDangerShieldIsUsed.Text = "remove last character";
            this.cbSelectIfDangerShieldIsUsed.UseVisualStyleBackColor = true;
            // 
            // lblArduinoConnectionSettingsHelpDkal
            // 
            this.lblArduinoConnectionSettingsHelpDkal.AutoSize = true;
            this.lblArduinoConnectionSettingsHelpDkal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblArduinoConnectionSettingsHelpDkal.Location = new System.Drawing.Point(378, 0);
            this.lblArduinoConnectionSettingsHelpDkal.Name = "lblArduinoConnectionSettingsHelpDkal";
            this.lblArduinoConnectionSettingsHelpDkal.Size = new System.Drawing.Size(13, 13);
            this.lblArduinoConnectionSettingsHelpDkal.TabIndex = 10;
            this.lblArduinoConnectionSettingsHelpDkal.Text = "?";
            // 
            // btnScanPortsDkal
            // 
            this.btnScanPortsDkal.Location = new System.Drawing.Point(9, 19);
            this.btnScanPortsDkal.Name = "btnScanPortsDkal";
            this.btnScanPortsDkal.Size = new System.Drawing.Size(128, 23);
            this.btnScanPortsDkal.TabIndex = 3;
            this.btnScanPortsDkal.Text = "Scan USB ports";
            this.btnScanPortsDkal.UseVisualStyleBackColor = true;
            this.btnScanPortsDkal.Click += new System.EventHandler(this.btnScanPortsDkal_Click);
            // 
            // cbbSerialPortsDkal
            // 
            this.cbbSerialPortsDkal.FormattingEnabled = true;
            this.cbbSerialPortsDkal.Location = new System.Drawing.Point(41, 71);
            this.cbbSerialPortsDkal.Name = "cbbSerialPortsDkal";
            this.cbbSerialPortsDkal.Size = new System.Drawing.Size(93, 21);
            this.cbbSerialPortsDkal.TabIndex = 2;
            this.cbbSerialPortsDkal.SelectedIndexChanged += new System.EventHandler(this.cbbSerialPortsDkal_SelectedIndexChanged);
            // 
            // cbbBaudRateDkal
            // 
            this.cbbBaudRateDkal.FormattingEnabled = true;
            this.cbbBaudRateDkal.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200",
            "230400",
            "500000"});
            this.cbbBaudRateDkal.Location = new System.Drawing.Point(9, 111);
            this.cbbBaudRateDkal.Name = "cbbBaudRateDkal";
            this.cbbBaudRateDkal.Size = new System.Drawing.Size(125, 21);
            this.cbbBaudRateDkal.TabIndex = 4;
            this.cbbBaudRateDkal.SelectedIndexChanged += new System.EventHandler(this.cbbBaudRateDkal_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Location = new System.Drawing.Point(6, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(123, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "select Arduino Baudrate:";
            // 
            // btnSerialPortOpenDkal
            // 
            this.btnSerialPortOpenDkal.Enabled = false;
            this.btnSerialPortOpenDkal.Location = new System.Drawing.Point(9, 138);
            this.btnSerialPortOpenDkal.Name = "btnSerialPortOpenDkal";
            this.btnSerialPortOpenDkal.Size = new System.Drawing.Size(125, 23);
            this.btnSerialPortOpenDkal.TabIndex = 6;
            this.btnSerialPortOpenDkal.Text = "Open port";
            this.btnSerialPortOpenDkal.UseVisualStyleBackColor = true;
            this.btnSerialPortOpenDkal.Click += new System.EventHandler(this.btnSerialPortOpenDkal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.rtbLogging);
            this.groupBox1.Location = new System.Drawing.Point(161, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 174);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(380, 138);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbLogging.Location = new System.Drawing.Point(6, 19);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(449, 113);
            this.rtbLogging.TabIndex = 0;
            this.rtbLogging.Text = "";
            this.rtbLogging.WordWrap = false;
            // 
            // serialPortArduinoConnection
            // 
            this.serialPortArduinoConnection.BaudRate = 115200;
            this.serialPortArduinoConnection.DtrEnable = true;
            this.serialPortArduinoConnection.ReadBufferSize = 19200;
            this.serialPortArduinoConnection.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortArduinoConnection_DataReceived);
            // 
            // subLogging
            // 
            this.subLogging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.subLogging.Location = new System.Drawing.Point(628, 31);
            this.subLogging.Name = "subLogging";
            this.subLogging.Size = new System.Drawing.Size(213, 113);
            this.subLogging.TabIndex = 2;
            this.subLogging.Text = "";
            this.subLogging.WordWrap = false;
            // 
            // chart1
            // 
            chartArea7.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(53, 192);
            this.chart1.Name = "chart1";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Legend = "Legend1";
            series19.Name = "AX";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Legend = "Legend1";
            series20.Name = "AY";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Legend = "Legend1";
            series21.Name = "AZ";
            this.chart1.Series.Add(series19);
            this.chart1.Series.Add(series20);
            this.chart1.Series.Add(series21);
            this.chart1.Size = new System.Drawing.Size(919, 200);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chart2
            // 
            chartArea8.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(54, 604);
            this.chart2.Name = "chart2";
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Legend = "Legend1";
            series22.Name = "GX";
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Legend = "Legend1";
            series23.Name = "GY";
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series24.Legend = "Legend1";
            series24.Name = "GZ";
            this.chart2.Series.Add(series22);
            this.chart2.Series.Add(series23);
            this.chart2.Series.Add(series24);
            this.chart2.Size = new System.Drawing.Size(919, 200);
            this.chart2.TabIndex = 28;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // chart3
            // 
            chartArea9.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            chartArea9.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chart3.Legends.Add(legend9);
            this.chart3.Location = new System.Drawing.Point(54, 398);
            this.chart3.Name = "chart3";
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series25.Legend = "Legend1";
            series25.Name = "MX";
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series26.Legend = "Legend1";
            series26.Name = "MY";
            series27.ChartArea = "ChartArea1";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series27.Legend = "Legend1";
            series27.Name = "MZ";
            this.chart3.Series.Add(series25);
            this.chart3.Series.Add(series26);
            this.chart3.Series.Add(series27);
            this.chart3.Size = new System.Drawing.Size(919, 200);
            this.chart3.TabIndex = 29;
            this.chart3.Text = "chart3";
            this.chart3.Click += new System.EventHandler(this.chart3_Click);
            // 
            // resetA
            // 
            this.resetA.Location = new System.Drawing.Point(878, 356);
            this.resetA.Name = "resetA";
            this.resetA.Size = new System.Drawing.Size(75, 23);
            this.resetA.TabIndex = 30;
            this.resetA.Text = "Reset";
            this.resetA.UseVisualStyleBackColor = true;
            this.resetA.Click += new System.EventHandler(this.resetA_Click);
            // 
            // ResetM
            // 
            this.ResetM.Location = new System.Drawing.Point(878, 561);
            this.ResetM.Name = "ResetM";
            this.ResetM.Size = new System.Drawing.Size(75, 23);
            this.ResetM.TabIndex = 31;
            this.ResetM.Text = "Reset";
            this.ResetM.UseVisualStyleBackColor = true;
            this.ResetM.Click += new System.EventHandler(this.ResetM_Click);
            // 
            // resetG
            // 
            this.resetG.Location = new System.Drawing.Point(878, 767);
            this.resetG.Name = "resetG";
            this.resetG.Size = new System.Drawing.Size(75, 23);
            this.resetG.TabIndex = 32;
            this.resetG.Text = "Reset";
            this.resetG.UseVisualStyleBackColor = true;
            this.resetG.Click += new System.EventHandler(this.resetG_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.heightTxt);
            this.StatusBox.Controls.Add(this.label2);
            this.StatusBox.Controls.Add(this.pressTxt);
            this.StatusBox.Controls.Add(this.pressBox);
            this.StatusBox.Controls.Add(this.tempTxt);
            this.StatusBox.Controls.Add(this.tempBox);
            this.StatusBox.Controls.Add(this.battStatus);
            this.StatusBox.Controls.Add(this.label1);
            this.StatusBox.Controls.Add(this.FWVersion);
            this.StatusBox.Controls.Add(this.Firmwaretxt);
            this.StatusBox.Location = new System.Drawing.Point(848, 12);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(167, 161);
            this.StatusBox.TabIndex = 33;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Status";
            // 
            // heightTxt
            // 
            this.heightTxt.AutoSize = true;
            this.heightTxt.Location = new System.Drawing.Point(69, 119);
            this.heightTxt.Name = "heightTxt";
            this.heightTxt.Size = new System.Drawing.Size(13, 13);
            this.heightTxt.TabIndex = 9;
            this.heightTxt.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Height:";
            // 
            // pressTxt
            // 
            this.pressTxt.AutoSize = true;
            this.pressTxt.Location = new System.Drawing.Point(69, 95);
            this.pressTxt.Name = "pressTxt";
            this.pressTxt.Size = new System.Drawing.Size(13, 13);
            this.pressTxt.TabIndex = 7;
            this.pressTxt.Text = "0";
            // 
            // pressBox
            // 
            this.pressBox.AutoSize = true;
            this.pressBox.Location = new System.Drawing.Point(6, 95);
            this.pressBox.Name = "pressBox";
            this.pressBox.Size = new System.Drawing.Size(51, 13);
            this.pressBox.TabIndex = 6;
            this.pressBox.Text = "Pressure:";
            this.pressBox.Click += new System.EventHandler(this.pressBox_Click);
            // 
            // tempTxt
            // 
            this.tempTxt.AutoSize = true;
            this.tempTxt.Location = new System.Drawing.Point(69, 74);
            this.tempTxt.Name = "tempTxt";
            this.tempTxt.Size = new System.Drawing.Size(13, 13);
            this.tempTxt.TabIndex = 5;
            this.tempTxt.Text = "0";
            // 
            // tempBox
            // 
            this.tempBox.AutoSize = true;
            this.tempBox.Location = new System.Drawing.Point(6, 74);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(37, 13);
            this.tempBox.TabIndex = 4;
            this.tempBox.Text = "Temp:";
            // 
            // battStatus
            // 
            this.battStatus.AutoSize = true;
            this.battStatus.Location = new System.Drawing.Point(69, 49);
            this.battStatus.Name = "battStatus";
            this.battStatus.Size = new System.Drawing.Size(13, 13);
            this.battStatus.TabIndex = 3;
            this.battStatus.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Battery:";
            // 
            // FWVersion
            // 
            this.FWVersion.AutoSize = true;
            this.FWVersion.Location = new System.Drawing.Point(69, 28);
            this.FWVersion.Name = "FWVersion";
            this.FWVersion.Size = new System.Drawing.Size(13, 13);
            this.FWVersion.TabIndex = 1;
            this.FWVersion.Text = "0";
            // 
            // Firmwaretxt
            // 
            this.Firmwaretxt.AutoSize = true;
            this.Firmwaretxt.Location = new System.Drawing.Point(7, 28);
            this.Firmwaretxt.Name = "Firmwaretxt";
            this.Firmwaretxt.Size = new System.Drawing.Size(52, 13);
            this.Firmwaretxt.TabIndex = 0;
            this.Firmwaretxt.Text = "Firmware:";
            // 
            // fmArduinoSerialConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 843);
            this.ControlBox = false;
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.resetG);
            this.Controls.Add(this.ResetM);
            this.Controls.Add(this.resetA);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.subLogging);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "fmArduinoSerialConnect";
            this.Text = "Arduino Serial Connect";
            this.Load += new System.EventHandler(this.fmArduinoSerialConnect_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.StatusBox.ResumeLayout(false);
            this.StatusBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox cbSelectIfDangerShieldIsUsed;
		private System.Windows.Forms.Label lblArduinoConnectionSettingsHelpDkal;
		private System.Windows.Forms.Button btnScanPortsDkal;
		private System.Windows.Forms.ComboBox cbbSerialPortsDkal;
		private System.Windows.Forms.ComboBox cbbBaudRateDkal;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btnSerialPortOpenDkal;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.RichTextBox rtbLogging;
		private System.IO.Ports.SerialPort serialPortArduinoConnection;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox subLogging;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button resetA;
        private System.Windows.Forms.Button ResetM;
        private System.Windows.Forms.Button resetG;
        private System.Windows.Forms.GroupBox StatusBox;
        private System.Windows.Forms.Label battStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FWVersion;
        private System.Windows.Forms.Label Firmwaretxt;
        private System.Windows.Forms.Label pressTxt;
        private System.Windows.Forms.Label pressBox;
        private System.Windows.Forms.Label tempTxt;
        private System.Windows.Forms.Label tempBox;
        private System.Windows.Forms.Label heightTxt;
        private System.Windows.Forms.Label label2;
    }
}