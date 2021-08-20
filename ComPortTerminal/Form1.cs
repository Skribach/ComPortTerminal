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
        Qadcopter<int> angles;
        public Form1()
        {
            angles = new Qadcopter<int>(0, 10, 1);
            conn = new Connection();
            InitializeComponent();
        }

        public const int MaxValue = 10;
        #region Displaying dropdown list
        private void portsComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            portsComboBox.Items.Clear();
            foreach (string port in conn.ports)
                portsComboBox.Items.Add(port);
        }
        private void portsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.portNum = portsComboBox.SelectedIndex;
            Status.Text = conn.portNum.ToString();
            Status.ForeColor = Color.Black;
        }
        #endregion

        private void testButton_Click(object sender, EventArgs e)
        {
            bool isException = false;
            if (conn.portNum == null)
            {
                Status.Text = "COM-port need to be selected;";
                Status.ForeColor = Color.Red;
                return;
            }
            try
            {
                conn.Open();
                conn.Write("Connected to programm" + (char)13);
            }
            catch (Exception ex)
            {
                Status.Text = "ERROR: " + ex.ToString();
                Status.ForeColor = Color.Red;
                isException = true;
            }
            if (isException == false)
            {
                Status.Text = "Connection test successfull...";
                Status.ForeColor = Color.Green;
                isException = true;
            }
        }

        #region Inputs
        private void leftTopTrackBar_Scroll(object sender, EventArgs e) => angles.leftTop = ScrollAngle(leftTopTextBox, leftTopTrackBar);
        private void leftTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftTopTextBox_KeyUp(object sender, KeyEventArgs e) => angles.leftTop = EnterAngle(leftTopTextBox, leftTopTrackBar);

        private void rightTopTrackBar_Scroll(object sender, EventArgs e) => angles.righTop = ScrollAngle(rightTopTextBox, rightTopTrackBar);
        private void rightTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightTopTextBox_KeyUp(object sender, KeyEventArgs e) => angles.righTop = EnterAngle(rightTopTextBox, rightTopTrackBar);

        private void leftBotTrackBar_Scroll(object sender, EventArgs e) => angles.leftBot = ScrollAngle(leftBotTextBox, leftBotTrackBar);
        private void leftBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftBotTextBox_KeyUp(object sender, KeyEventArgs e) => angles.leftBot = EnterAngle(leftBotTextBox, leftBotTrackBar);

        private void rightBotTrackBar_Scroll(object sender, EventArgs e) => angles.rightBot = ScrollAngle(rightBotTextBox, rightBotTrackBar);
        private void rightBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightBotTextBox_KeyUp(object sender, KeyEventArgs e) => angles.rightBot = EnterAngle(rightBotTextBox, rightBotTrackBar);
        #endregion

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
            if(num < angles.MinValue)
            {
                trackBar.Value = angles.MaxValue;
                textBox.Text = angles.MaxValue.ToString();
                return angles.MaxValue;
            }
            else if (num > angles.MaxValue)
            {
                trackBar.Value = angles.MaxValue;
                textBox.Text = angles.MaxValue.ToString();
                return angles.MaxValue;
            }
            else
            {
                trackBar.Value = num;
                return num;
            }
        }
    }
}
