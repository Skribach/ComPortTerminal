#region lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
#endregion

namespace ComPortTerminal
{
    public partial class Form1 : Form
    {
        Connection conn;
        private string connName;
        Qadcopter<int> qadcopter;
        Packet packet;

        private int initialAngle = 1;
        private int MaxAngle = 10;
        private int MinAngle = 0;

        public Form1()
        {
            qadcopter = new Qadcopter<int>(
                initialAngle, initialAngle, initialAngle, initialAngle,
                MinAngle, MaxAngle);
            conn = new Connection();
            InitializeComponent();
        }

        #region Displaying dropdown list
        private void portsComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            portsComboBox.Items.Clear();
            foreach (string port in conn.AvailableConnections)
                portsComboBox.Items.Add(port);
        }
        private void portsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connName = conn.AvailableConnections[portsComboBox.SelectedIndex];
            Status.Text = connName + " is selected to connection...";
            Status.ForeColor = Color.Black;
        }
        #endregion

        #region Angle Inputs
        //Left Top Angle Inputs
        private void leftTopTrackBar_Scroll(object sender, EventArgs e) => qadcopter.LeftTop = ScrollAngle(leftTopTextBox, leftTopTrackBar);
        private void leftTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftTopTextBox_KeyUp(object sender, KeyEventArgs e) => qadcopter.LeftTop = EnterAngle(leftTopTextBox, leftTopTrackBar);

        //Right Top Angle Inputs
        private void rightTopTrackBar_Scroll(object sender, EventArgs e) => qadcopter.RightTop = ScrollAngle(rightTopTextBox, rightTopTrackBar);
        private void rightTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightTopTextBox_KeyUp(object sender, KeyEventArgs e) => qadcopter.RightTop = EnterAngle(rightTopTextBox, rightTopTrackBar);

        //Left Bottom Angle Inputs
        private void leftBotTrackBar_Scroll(object sender, EventArgs e) => qadcopter.LeftBot = ScrollAngle(leftBotTextBox, leftBotTrackBar);
        private void leftBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftBotTextBox_KeyUp(object sender, KeyEventArgs e) => qadcopter.LeftBot = EnterAngle(leftBotTextBox, leftBotTrackBar);

        //Right Bottom Angle Inputs
        private void rightBotTrackBar_Scroll(object sender, EventArgs e) => qadcopter.RightBot = ScrollAngle(rightBotTextBox, rightBotTrackBar);
        private void rightBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightBotTextBox_KeyUp(object sender, KeyEventArgs e) => qadcopter.RightBot = EnterAngle(rightBotTextBox, rightBotTrackBar);

        #region Support functions
        private void NumValidation(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
        private int ScrollAngle(TextBox textBox, TrackBar trackBar)
        {
            textBox.Text = trackBar.Value.ToString();
            return trackBar.Value;
        }
        private int EnterAngle(TextBox textBox, TrackBar trackBar)
        {
            int num = int.Parse(textBox.Text);
            if (num < qadcopter.MinValue)
            {
                trackBar.Value = qadcopter.MaxValue;
                textBox.Text = qadcopter.MaxValue.ToString();
                return qadcopter.MaxValue;
            }
            else if (num > qadcopter.MaxValue)
            {
                trackBar.Value = qadcopter.MaxValue;
                textBox.Text = qadcopter.MaxValue.ToString();
                return qadcopter.MaxValue;
            }
            else
            {
                trackBar.Value = num;
                return num;
            }
        }
        #endregion

        #endregion

        private void testButton_Click(object sender, EventArgs e)
        {
            bool isException = false;
            if (connName == null)
            {
                Status.Text = "COM-port need to be selected;";
                Status.ForeColor = Color.Red;
                return;
            }
            try
            {
                conn.Connect(connName);
                conn.Write("Connected to programm" + (char)13);
            }
            catch (Exception ex)
            {
                Status.Text = "ERROR: Another instance connected to " + conn.Name;
                Console.WriteLine(ex.Message);
                Status.ForeColor = Color.Red;
                isException = true;
            }
            if (isException == false)
            {
                Status.Text = "Connection test successfull to " + conn.Name;
                Status.ForeColor = Color.Green;
                isException = true;
            }
            conn.Disconnect();
        }
    }
}