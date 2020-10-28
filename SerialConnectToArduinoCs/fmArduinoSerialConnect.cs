using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//for the Arduino Serial project
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace SerialConnectToArduinoCs
{
	public partial class fmArduinoSerialConnect : Form
	{
		delegate void SafeCallDelegate();

		public String receivedString = "";
		String receivedStringLast = "";

		public fmArduinoSerialConnect()
		{
			InitializeComponent();
			initGraph();

		}

		private void initGraph()
        {
			ChartArea CA1 = chart1.ChartAreas[0];
			CA1.CursorX.IsUserSelectionEnabled = true;
			CA1.AxisX.ScaleView.Zoomable = true;
			CA1.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
			CA1.CursorX.AutoScroll = true;
			CA1.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

			ChartArea CA2 = chart2.ChartAreas[0];
			CA2.CursorX.IsUserSelectionEnabled = true;
			CA2.AxisX.ScaleView.Zoomable = true;
			CA2.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
			CA2.CursorX.AutoScroll = true;
			CA2.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

			ChartArea CA3 = chart3.ChartAreas[0];
			CA3.CursorX.IsUserSelectionEnabled = true;
			CA3.AxisX.ScaleView.Zoomable = true;
			CA3.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
			CA3.CursorX.AutoScroll = true;
			CA3.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
		}

		private void fmArduinoSerialConnect_Load(object sender, EventArgs e)
		{
			this.Left = 500;
			this.Top = 200;
		}
		public void PrintLn(string a_text, string a_color)
		{
			string m_color;

			m_color = a_color.ToUpper();//eliminate a possible problem of the letter casing

			switch (a_color)
			{
				case "R": rtbLogging.SelectionColor = Color.Red; break;
				case "G": rtbLogging.SelectionColor = Color.Lime; break;
				case "B": rtbLogging.SelectionColor = Color.Blue; break;
				case "Y": rtbLogging.SelectionColor = Color.Yellow; break;
				default: rtbLogging.SelectionColor = Color.White; break;
			}

			rtbLogging.AppendText(a_text + "\n");
			rtbLogging.ScrollToCaret();
		}


		private void btnClear_Click(object sender, EventArgs e)
		{
			rtbLogging.Clear();
			foreach (var series in chart1.Series)
			{
				series.Points.Clear();
			}
			foreach (var series in chart2.Series)
			{
				series.Points.Clear();
			}
			foreach (var series in chart3.Series)
			{
				series.Points.Clear();
			}
		}

		private void btnScanPortsDkal_Click(object sender, EventArgs e)
		{
			ScanComPortsDkal();

			btnSerialPortOpenDkal.Enabled = true;
		}

		private void ScanComPortsDkal()
		{
			String[] ports = SerialPort.GetPortNames();
			Array.Sort(ports);
			string m_portWithOutLastCharacter;

			if (serialPortArduinoConnection.IsOpen)
			{
				PrintLn("Connection was open. Closing..", "B");
				serialPortArduinoConnection.Close();
			}
			cbbSerialPortsDkal.Items.Clear();

			foreach (String port in ports)
			{
				if (cbSelectIfDangerShieldIsUsed.Checked == true)
				{
					m_portWithOutLastCharacter = port.Substring(0, port.Length - 1);
				}
				else
				{
					m_portWithOutLastCharacter = port;
				}

				cbbSerialPortsDkal.Items.Add(m_portWithOutLastCharacter);
				PrintLn("Found port:" + m_portWithOutLastCharacter.ToString(), "W");
			}

			if (cbbBaudRateDkal.Items.Count > 0)
			{
				cbbSerialPortsDkal.Text = "Select!";
				cbbSerialPortsDkal.Enabled = true;
			}
			else
			{
				cbbSerialPortsDkal.Text = "N.A.";
				cbbSerialPortsDkal.Enabled = false;

				PrintLn("ERROR: no ports found!", "R");
			}
		}

		private void btnSerialPortOpenDkal_Click(object sender, EventArgs e)
		{
			if (!serialPortArduinoConnection.IsOpen)
			{
				try
				{
					serialPortArduinoConnection.Open();

					Thread.Sleep(200); //wait 100 ms to open port

					if (serialPortArduinoConnection.IsOpen == true)
					{
						serialPortArduinoConnection.Write("");
						serialPortArduinoConnection.DiscardInBuffer();
						serialPortArduinoConnection.DiscardInBuffer();
					}
						
					this.Text = "Main - using com port: " + cbbSerialPortsDkal.Text;
					PrintLn("Using com port: " + cbbSerialPortsDkal.Text, "W");
				}
				catch
				{
					//MessageBox.Show("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "Serial port", MessageBoxButtons.OK, MessageBoxIcon.Error);
					PrintLn("ERROR: Please make sure that the correct port was selected, and the device, plugged in.", "R");
				}
			}
		}

		private void cbbSerialPortsDkal_SelectedIndexChanged(object sender, EventArgs e)
		{
			serialPortArduinoConnection.PortName = cbbSerialPortsDkal.Text;

			PrintLn("Port selected: " + serialPortArduinoConnection.PortName, "W");
			PrintLn("Default baudrate: " + serialPortArduinoConnection.BaudRate.ToString(), "W");

			btnSerialPortOpenDkal.Enabled = true;
		}

		private void cbbBaudRateDkal_SelectedIndexChanged(object sender, EventArgs e)
		{
			serialPortArduinoConnection.BaudRate = Convert.ToInt32(cbbBaudRateDkal.Text);
			PrintLn("Baudrate: " + serialPortArduinoConnection.BaudRate.ToString(), "W");
		}

		public void WriteArduino(string a_action)
		{
			int m_length = a_action.Length;
			char[] m_data = new char[m_length];

			for (int m_index = 0; m_index < m_length; m_index++)
			{
				m_data[m_index] = Convert.ToChar(a_action[m_index]);
			}

			if (serialPortArduinoConnection.IsOpen == true)
			{
				serialPortArduinoConnection.Write(m_data, 0, m_length);

				PrintLn("Transmitted message from Main: " + a_action, "Y");
			}
			else
			{
				//MessageBox.Show("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "Serial port", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PrintLn("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "R");
			}
		}
		private void serialPortArduinoConnection_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			//delegate void SafeCallDelegate(long prime);
			//if (PrimeListBox.InvokeRequired)
			//{
			//	var d = new SafeCallDelegate(SendToUI);
			//	PrimeListBox.Invoke(d, new object[] { prime });
			//}
			//else
			//{
			//	PrimeListBox.Items.Add(prime.ToString());
			//}
			HandleReceivedData();
		}

		private void HandleReceivedData()
		{ 
			if (serialPortArduinoConnection.IsOpen)
			{
				try
				{
					if (rtbLogging.InvokeRequired) //check if this is the same thread
					{
						var d = new SafeCallDelegate(HandleReceivedData);
						rtbLogging.Invoke(d, new object[] { });//allow changes in this thread from another thread
					}
					else
					{
						receivedString = serialPortArduinoConnection.ReadLine();
						PrintLn(receivedString, "G");
					}
				}
				catch
				{
					PrintLn("BtmDashboard ERROR: Data read failed", "R");
				}
			}
		}
		public string ReadArduino()
		{
			UpdateReceivedString();

			return receivedString;
		}

		private void OldUpdateReceivedString()
		{
			if (receivedString != "")
			{
				if (receivedString != receivedStringLast)
				{
					PrintLn(receivedString, "G");
				}


				receivedStringLast = receivedString;
			}
		}

		private void UpdateReceivedString()
		{
			if (receivedString != receivedStringLast)
			{
			//	PrintLn(receivedString, "G");
			}
			
			receivedStringLast = receivedString;
		}


		public void processSubString(string a_text)
        {

			String m_remainingString = "";
			int m_startIndexOfMessage = 0;
			int m_endIndexOfMessage = 0;
			float m_receivedFloat = 0.0f;
			int m_receivedInt = 0;
			
			subLogging.SelectionColor = Color.White; 
			subLogging.AppendText(a_text + "\n");
			subLogging.ScrollToCaret();
			if (a_text.IndexOf("FW") >= 0)                                                                  // set accelero X output on / off    
			
			{
				m_startIndexOfMessage = ("FW").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				//m_receivedFloat = Convert.ToSingle(m_remainingString);
				FWVersion.Text = m_remainingString;
			}
			if (a_text.IndexOf("BS") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("BS").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				//m_receivedFloat = Convert.ToSingle(m_remainingString);
				battStatus.Text = m_remainingString;
			}

			if (a_text.IndexOf("TE") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("TE").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				//m_receivedFloat = Convert.ToSingle(m_remainingString);
				tempTxt.Text = m_remainingString;
			}

			if (a_text.IndexOf("PE") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("PE").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				//m_receivedFloat = Convert.ToSingle(m_remainingString);
				pressTxt.Text = m_remainingString;
			}

			if (a_text.IndexOf("HE") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("HE").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				//m_receivedFloat = Convert.ToSingle(m_remainingString);
				heightTxt.Text = m_remainingString;
			}

			if (a_text.IndexOf("AX") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("AX").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartA(m_receivedFloat, "AX");
			}

			if (a_text.IndexOf("AY") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("AY").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartA(m_receivedFloat, "AY");
			}
			if (a_text.IndexOf("AZ") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("AZ").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartA(m_receivedFloat, "AZ");
			}

			if (a_text.IndexOf("MX") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("MX").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartM(m_receivedFloat, "MX");
			}

			if (a_text.IndexOf("MY") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("MY").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartM(m_receivedFloat, "MY");
			}
			if (a_text.IndexOf("MZ") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("MZ").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartM(m_receivedFloat, "MZ");
			}

			if (a_text.IndexOf("GX") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("GX").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartG(m_receivedFloat, "GX");
			}

			if (a_text.IndexOf("GY") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("GY").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartG(m_receivedFloat, "GY");
			}
			if (a_text.IndexOf("GZ") >= 0)                                                                  // set accelero X output on / off                                          
			{
				m_startIndexOfMessage = ("GZ").Length;
				m_endIndexOfMessage = a_text.Length - m_startIndexOfMessage;
				m_remainingString = a_text.Substring(m_startIndexOfMessage, m_endIndexOfMessage);
				m_remainingString = m_remainingString.Replace('.', ',');
				m_receivedFloat = Convert.ToSingle(m_remainingString);
				updateChartG(m_receivedFloat, "GZ");
			}
		}

		Random CreateRandomValue = new Random();
		public void updateChartA(float valueToAdd, String seriesToAdd)
        {
			chart1.Series[seriesToAdd].Points.Add(valueToAdd);
		}
		public void updateChartG(float valueToAdd, String seriesToAdd)
		{
			chart2.Series[seriesToAdd].Points.Add(valueToAdd);
		}

		public void updateChartM(float valueToAdd, String seriesToAdd)
		{
			chart3.Series[seriesToAdd].Points.Add(valueToAdd);
		}
		private void chart1_Click(object sender, EventArgs e)
        {
			
		}

        private void chart3_Click(object sender, EventArgs e)
        {
			
		}

        private void chart2_Click(object sender, EventArgs e)
        {
			
		}

        private void resetA_Click(object sender, EventArgs e)
        {
			chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
		}

        private void ResetM_Click(object sender, EventArgs e)
        {
			chart3.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
		}

        private void resetG_Click(object sender, EventArgs e)
        {
			chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
		}

        private void pressBox_Click(object sender, EventArgs e)
        {

        }
    }
}
