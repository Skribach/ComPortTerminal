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
using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Qadcopters.Realization.v1;
using ComPortTerminal.Controllers;
#endregion

namespace ComPortTerminal
{
    public partial class Form1 : Form
    {
        Controller _controller;

        Connection conn;

        Qadcopter qadcopter;

        public int initialAngle = 90;
        public int MaxAngle = 180;
        public int MinAngle = 0;

        private string _connName;

        public Form1()
        {
            _controller = new Controller();
            conn = new Connection();
            qadcopter = new Qadcopter(
                initialAngle, initialAngle, initialAngle, initialAngle,
                MinAngle, MaxAngle,
                conn);
            InitializeComponent();
        }

        #region Dropdown list with available links
        private void portsComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            portsComboBox.Items.Clear();
            foreach (string conns in _controller.DisplayAvailableConnections().Connections)
                portsComboBox.Items.Add(conns);
        }
        private void portsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectButton.Enabled = true;
            _connName = _controller.DisplayAvailableConnections().Connections[portsComboBox.SelectedIndex];
            Status.Text = _connName + " is selected to connection...";
            Status.ForeColor = Color.Black;
        }
        #endregion

        #region Angle Inputs
        //Left Top Angle Inputs
        private void leftTopTrackBar_Scroll(object sender, EventArgs e) => LTNumericUpDown.Value = leftTopTrackBar.Value;
        private void LTNumericUpDown_ValueChanged(object sender, EventArgs e) => leftTopTrackBar.Value = (int)LTNumericUpDown.Value;

        //Right Top Angle Inputs
        private void rightTopTrackBar_Scroll(object sender, EventArgs e) => RTNumericUpDown.Value = rightTopTrackBar.Value;
        private void RTNumericUpDown_ValueChanged(object sender, EventArgs e) => rightTopTrackBar.Value = (int)RTNumericUpDown.Value;

        //Left Bottom Angle Inputs
        private void leftBotTrackBar_Scroll(object sender, EventArgs e) => LBNumericUpDown.Value = leftBotTrackBar.Value;
        private void LBNumericUpDown_ValueChanged(object sender, EventArgs e) => leftBotTrackBar.Value = (int)LBNumericUpDown.Value;

        //Right Bottom Angle Inputs
        private void rightBotTrackBar_Scroll(object sender, EventArgs e) => RBNumericUpDown.Value = rightBotTrackBar.Value;
        private void RBNumericUpDown_ValueChanged(object sender, EventArgs e) => rightBotTrackBar.Value = (int)RBNumericUpDown.Value;

        #endregion

        private void connectButton_Click(object sender, EventArgs e)
        {
            var response = _controller.Connect(_connName);
            if(!response.isError)
                Status.ForeColor = Color.Green;
            else
                Status.ForeColor = Color.Red;
            Status.Text = response.Message;
        }

        private void onlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(onlineCheckBox.CheckState == CheckState.Checked)
                startButton.Enabled = false;
            else
                startButton.Enabled = true;
        }

        private void startLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startLogCheckBox.CheckState == CheckState.Checked)
                startLogButton.Enabled = false;
            else
                startLogButton.Enabled = true;
        }

        private void selectLogFolderbutton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = logFolderBrowserDialog)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Status.Text = dialog.SelectedPath;
                }
            }
        }
    }
}