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

        Qadcopter qadcopter;

        private int initialAngle = 1;
        private int MaxAngle = 10;
        private int MinAngle = 0;

        public Form1()
        {
            conn = new Connection();
            qadcopter = new Qadcopter(
                initialAngle, initialAngle, initialAngle, initialAngle,
                MinAngle, MaxAngle,
                conn);
            InitializeComponent();
        }

        #region Dropdown list
        private void portsComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            portsComboBox.Items.Clear();
            foreach (string port in conn.AvailableConnections)
                portsComboBox.Items.Add(port);
        }
        private void portsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Name = conn.AvailableConnections[portsComboBox.SelectedIndex];
            Status.Text = conn.Name + " is selected to connection...";
            Status.ForeColor = Color.Black;
        }
        #endregion

        #region Angle Inputs
        //Left Top Angle Inputs
        private void leftTopTrackBar_Scroll(object sender, EventArgs e) => leftTopTextBox.Text = qadcopter.SetLeftTop(leftTopTrackBar.Value).ToString();
        private void leftTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftTopTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int value = qadcopter.SetLeftTop(leftTopTextBox.Text);
            leftTopTrackBar.Value = value;
            leftTopTextBox.Text = value.ToString();
        }

        //Right Top Angle Inputs
        private void rightTopTrackBar_Scroll(object sender, EventArgs e) => rightTopTextBox.Text = qadcopter.SetRightTop(rightTopTrackBar.Value).ToString();
        private void rightTopTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightTopTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int value = qadcopter.SetRightTop(rightTopTextBox.Text);
            rightTopTrackBar.Value = value;
            rightTopTextBox.Text = value.ToString();
        }

        //Left Bottom Angle Inputs
        private void leftBotTrackBar_Scroll(object sender, EventArgs e) => leftBotTextBox.Text = qadcopter.SetLeftBot(leftBotTrackBar.Value).ToString();
        private void leftBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void leftBotTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int value = qadcopter.SetLeftBot(leftTopTextBox.Text);
            leftBotTrackBar.Value = value;
            leftBotTextBox.Text = value.ToString();
        }

        //Right Bottom Angle Inputs
        private void rightBotTrackBar_Scroll(object sender, EventArgs e) => rightBotTextBox.Text = qadcopter.SetRightBot(rightBotTrackBar.Value).ToString();
        private void rightBotTextBox_KeyPress(object sender, KeyPressEventArgs e) => NumValidation(sender, e);
        private void rightBotTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int value = qadcopter.SetRightBot(rightTopTextBox.Text);
            rightBotTrackBar.Value = value;
            rightBotTextBox.Text = value.ToString();
        }

        #region Support functions
        private void NumValidation(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }        
        #endregion

        #endregion

        private void connectButton_Click(object sender, EventArgs e)
        {
            Status.Text = qadcopter.Connect().Message; 
        }
    }
}