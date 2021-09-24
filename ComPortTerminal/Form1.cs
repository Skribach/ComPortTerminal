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
using QuadcopterConfigurator.Domain.Connections.Realization.Com;
using QuadcopterConfigurator.Controllers;
using static QuadcopterConfigurator.Domain.Protocols.Realization.v1.Protocol;
using static QuadcopterConfigurator.Global;
#endregion

namespace QuadcopterConfigurator
{
    public partial class Form1 : Form
    {
        private Controller _controller;
        private string _connName;

        public Form1()
        {
            _controller = new Controller();

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
            if (portsComboBox.SelectedIndex == -1)
                return;
            _connName = _controller.DisplayAvailableConnections().Connections[portsComboBox.SelectedIndex];

            StatusStrip.Text = "Connecting to quadcopter...";
            StatusStrip.ForeColor = Color.Black;
            var response = _controller.Connect(_connName);
            if (!response.isCanceled)
            {
                if (!response.isError)
                {
                    if (startLogCheckBox.Checked)
                    {
                        _controller.StartLog();
                        startLogButton.Text = "Stop Log";
                        startLogCheckBox.Enabled = false;
                    }
                }
                ShowResponse(response);
            }
        }
        #endregion

        #region Angle Inputs
        //Left Top Angle Inputs
        private async void leftTopTrackBar_Scroll(object sender, EventArgs e)
        {
            LTNumericUpDown.Value = leftTopTrackBar.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }
        private async void LTNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            leftTopTrackBar.Value = (int)LTNumericUpDown.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }

        //Right Top Angle Inputs
        private async void rightTopTrackBar_Scroll(object sender, EventArgs e)
        {
            RTNumericUpDown.Value = rightTopTrackBar.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }
        private async void RTNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rightTopTrackBar.Value = (int)RTNumericUpDown.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }

        //Left Bottom Angle Inputs
        private async void leftBotTrackBar_Scroll(object sender, EventArgs e)
        {
            LBNumericUpDown.Value = leftBotTrackBar.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }
        private async void LBNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            leftBotTrackBar.Value = (int)LBNumericUpDown.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }

        //Right Bottom Angle Inputs
        private async void rightBotTrackBar_Scroll(object sender, EventArgs e)
        {
            RBNumericUpDown.Value = rightBotTrackBar.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }
        private async void RBNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rightBotTrackBar.Value = (int)RBNumericUpDown.Value;
            if (onlineCheckBox.Checked)
            {
                await SendAnglesAsync();
            }
        }

        //Button "Set angles"
        private async void setAnglesButton_Click(object sender, EventArgs e)
        {
            await SendAnglesAsync();
        }

        #region Supporting methods
        private async Task SendAnglesAsync()
        {
            StatusStrip.ForeColor = Color.Black;
            StatusStrip.Text = "Sending angle values...";
            var response = await _controller.SetAngles(new BladeAngles
            {
                A = rightTopTrackBar.Value,
                B = leftBotTrackBar.Value,
                C = leftTopTrackBar.Value,
                D = rightBotTrackBar.Value
            });
            if (!response.isCanceled)
            {                
                ShowResponse(response);
            }
        }
        #endregion

        #endregion

        private async void onlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onlineCheckBox.CheckState == CheckState.Checked)
            {
                setAnglesButton.Enabled = false;
                await SendAnglesAsync();
            }
            else
            {
                setAnglesButton.Enabled = true;
            }
        }

        private void startLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startLogCheckBox.CheckState == CheckState.Checked)
                startLogButton.Enabled = false;
            else
                startLogButton.Enabled = true;
        }

        private void startLogButton_Click(object sender, EventArgs e)
        {
            if (startLogButton.Text == "Start Log")
            {
                var resp = _controller.StartLog();
                startLogButton.Text = "Stop Log";
                ShowResponse(resp);
            }
            else if (startLogButton.Text == "Stop Log")
            {
                string path = "";
                using (SaveFileDialog dialog = logFileDialog)
                {
                    dialog.Title = "Save Log file to...";
                    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    dialog.DefaultExt = "csv";
                    dialog.FileName = DateTime.Now.ToString().Replace(':', '-').Replace(' ', '(') + ')';
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.FileName;
                    }
                }
                var resp = _controller.StopLog(path);
                ShowResponse(resp);
                startLogButton.Text = "Start Log";
            }
        }

        /// <summary>
        /// Method to show response message in Status-bar with/without errors
        /// </summary>
        /// <param name="resp">Response, must contains Message and isError</param>
        private void ShowResponse(Global.Response resp)
        {
            /*if (resp.isError)
            {
                StatusStrip.ForeColor = Color.Red;
            }
            else if (!resp.isError)
            {
                StatusStrip.ForeColor = Color.Green;
            }
            StatusStrip.Text = resp.Message;*/
            StatusStrip.Text = ((resp.isError ? "ERROR: " : "OK: ") + resp.Message + "...");
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            var status = _controller.GetStatus();
            if ((status == Statuses.connected)||(status == Statuses.updating))
            {
                ConnectionStrip.Text = '\u25CF' + "Connected";
                ConnectionStrip.ForeColor = Color.Green;

                rpmTextBox.Text = _controller.parameters.Rpm.ToString();
                xTextBox.Text = _controller.parameters.Gyro.x.ToString();
                yTextBox.Text = _controller.parameters.Gyro.y.ToString();
                zTextBox.Text = _controller.parameters.Gyro.z.ToString();

                setAnglesButton.Enabled = true;
                startLogButton.Enabled = true;
                onlineCheckBox.Enabled = true;
                startLogCheckBox.Enabled = false;
            }
            else if (status == Statuses.disconnected)
            {
                ConnectionStrip.Text = '\u25CF' + " Disconnected";
                ConnectionStrip.ForeColor = Color.DarkOrange;

                rpmTextBox.Text = '\u2014'.ToString();
                xTextBox.Text = '\u2014'.ToString();
                yTextBox.Text = '\u2014'.ToString();
                zTextBox.Text = '\u2014'.ToString();


                setAnglesButton.Enabled = false;
                startLogButton.Enabled = false;
                onlineCheckBox.Enabled = false;
                startLogCheckBox.Enabled = true;
            }
        }

        private async void autoConnectButton_Click(object sender, EventArgs e)
        {
            StatusStrip.Text = "Finding correct link...";
            var response = await _controller.AutoConnectAsync();
            ShowResponse(response);
            portsComboBox.Text = response.ConnectionName;
        }
    }
}