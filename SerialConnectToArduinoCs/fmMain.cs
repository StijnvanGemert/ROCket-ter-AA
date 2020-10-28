//created by Dick van Kalsbeek somewhere in 2012...
//
//add using SerialConnectToArduinoCs; in the main form
//add fmArduinoSerialConnect SerialConnect = new fmArduinoSerialConnect(); in main form class > public partial class ...bla bla bla
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using SerialConnectToArduinoCs;

namespace SerialConnectToArduinoCs
{
	public partial class fmMain : Form
	{
		string END = "!!";
		string START = "##";
		string SEPARATOR = "^";
		int MAXLOOP = 100;
		fmArduinoSerialConnect SerialConnect = new fmArduinoSerialConnect();
		String receivedStrLast = "";
		int timeoutCounter = 0;

		public fmMain()
		{
			InitializeComponent();
		}

		private void cbxShowArduinoSerialConnect_CheckedChanged(object sender, EventArgs e)
		{
			ShowArduinoSerialConnect();
		}

		private void ShowArduinoSerialConnect()
		{
			if (cbxShowArduinoSerialConnect.Checked == true)
			{
				SerialConnect.Visible = true;
			}
			else
			{
				SerialConnect.Visible = false;
			}
		}

		private void fmMain_Load(object sender, EventArgs e)
		{
			ShowArduinoSerialConnect();

			this.Text = "Main";
			this.Left = 200;
			this.Top = 200;
		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			SerialConnect.WriteArduino(txbWriteCustom.Text);
			processString();
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			SerialConnect.WriteArduino("##ST!!");
			//fmArduinoSerialConnect test = new fmArduinoSerialConnect();
			//test.receivedString; //
			lblReturned.Text =  SerialConnect.ReadArduino(); 
			processString();
		}

		private void btnWriteDefault_Click(object sender, EventArgs e)
		{
			String m_testText = "Test";

			SerialConnect.WriteArduino(m_testText);
			lblSent.Text = m_testText;
		}

		private void btnResetArduino_Click(object sender, EventArgs e)
		{
			SerialConnect.WriteArduino("Reset");
		}

		public void processString()
        {


			string m_remainingString = "";
			int m_startIndexOfMessage = 0;
			int m_endIndexOfMessage = 0;
			int m_inputStringLength = 0;
			int m_sanityCheck = 0;
			int m_startRemove = 0;
			string receivedString;
			receivedString = SerialConnect.ReadArduino();
			if (receivedString == "")
				return;


			if (receivedString == receivedStrLast)
			{
				timeoutCounter++;
				if (timeoutCounter > 20)
				{
					//timer2.Stop();
					return;
				}
			}
			else
			{
				receivedStrLast = receivedString;
			}
			m_inputStringLength = receivedString.Length;                                                                                               // get string lenght 
			m_endIndexOfMessage = END.Length;
			m_startRemove = receivedString.IndexOf(END);
			if (m_startRemove < 0)
				return;
			receivedString = receivedString.Remove(m_startRemove, m_endIndexOfMessage);                                                      // remove the END characters
			if (receivedString.IndexOf(START) >= 0)                                                                    // string START is ok
			{
				do
				{
					m_sanityCheck++;                                                                                                                                // sanity check
					if (m_startIndexOfMessage == 0)                                                                       // set start index (exeption for the 1st setting in string)
					{
						m_startIndexOfMessage = START.Length;                                                     // begin form START
					}
					else
					{
						m_startIndexOfMessage = receivedString.IndexOf(SEPARATOR, m_endIndexOfMessage) + 1;                  // begin form SEPARATOR
					}                                                                                                        //}

					m_endIndexOfMessage = receivedString.IndexOf(SEPARATOR, m_startIndexOfMessage);                        // get end char
					if (m_endIndexOfMessage > 0)
					{
						m_remainingString = receivedString.Substring(m_startIndexOfMessage, m_endIndexOfMessage - m_startIndexOfMessage);              // get substring
						SerialConnect.processSubString(m_remainingString);                                                                  // do something with the command
					}
				} while ((m_endIndexOfMessage > 0) && (m_sanityCheck < MAXLOOP));                                         // loop untill string is proccesed of code goes insane
			}

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
			if (continuRead.Checked)
			{
				timer2.Enabled = true;
			}
			else
			{ 
				timer2.Enabled = false; 
			}
		}

        private void timer2_Tick(object sender, EventArgs e)
        {
			SerialConnect.WriteArduino("##GO!!");
			processString();

		}

        private void GetOne_Click(object sender, EventArgs e)
        {
			SerialConnect.WriteArduino("##GO!!");
			processString();
		}

        private void GetMulti_Click(object sender, EventArgs e)
        {
			SerialConnect.WriteArduino("##GM"+ GetMultiTxt.Text + "!!");
			timer2.Enabled = true;
		}
    }
}
