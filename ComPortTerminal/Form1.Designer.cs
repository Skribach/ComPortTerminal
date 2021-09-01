﻿
using System.IO.Ports;

namespace ComPortTerminal
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            if (conn.IsConnected)
                conn.Disconnect();
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zLabel = new System.Windows.Forms.Label();
            this.setAnglesButton = new System.Windows.Forms.Button();
            this.leftTopTrackBar = new System.Windows.Forms.TrackBar();
            this.rightTopTrackBar = new System.Windows.Forms.TrackBar();
            this.leftBotTrackBar = new System.Windows.Forms.TrackBar();
            this.rightBotTrackBar = new System.Windows.Forms.TrackBar();
            this.connectButton = new System.Windows.Forms.Button();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.onlineCheckBox = new System.Windows.Forms.CheckBox();
            this.selectLogFolderbutton = new System.Windows.Forms.Button();
            this.startLogButton = new System.Windows.Forms.Button();
            this.startLogCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.LTNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RTNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.logFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBotTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBotTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LTNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(547, 283);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(17, 13);
            this.zLabel.TabIndex = 0;
            this.zLabel.Text = "Z:";
            // 
            // setAnglesButton
            // 
            this.setAnglesButton.Enabled = false;
            this.setAnglesButton.Location = new System.Drawing.Point(223, 248);
            this.setAnglesButton.Name = "setAnglesButton";
            this.setAnglesButton.Size = new System.Drawing.Size(135, 23);
            this.setAnglesButton.TabIndex = 7;
            this.setAnglesButton.Text = "Set Angles";
            this.setAnglesButton.UseVisualStyleBackColor = true;
            this.setAnglesButton.Click += new System.EventHandler(this.setAnglesButton_Click);
            // 
            // leftTopTrackBar
            // 
            this.leftTopTrackBar.LargeChange = 60;
            this.leftTopTrackBar.Location = new System.Drawing.Point(16, 23);
            this.leftTopTrackBar.Maximum = 180;
            this.leftTopTrackBar.Name = "leftTopTrackBar";
            this.leftTopTrackBar.Size = new System.Drawing.Size(201, 45);
            this.leftTopTrackBar.SmallChange = 10;
            this.leftTopTrackBar.TabIndex = 2;
            this.leftTopTrackBar.TabStop = false;
            this.leftTopTrackBar.TickFrequency = 18;
            this.leftTopTrackBar.Value = 90;
            this.leftTopTrackBar.Scroll += new System.EventHandler(this.leftTopTrackBar_Scroll);
            // 
            // rightTopTrackBar
            // 
            this.rightTopTrackBar.LargeChange = 60;
            this.rightTopTrackBar.Location = new System.Drawing.Point(429, 23);
            this.rightTopTrackBar.Maximum = 180;
            this.rightTopTrackBar.Name = "rightTopTrackBar";
            this.rightTopTrackBar.Size = new System.Drawing.Size(201, 45);
            this.rightTopTrackBar.SmallChange = 10;
            this.rightTopTrackBar.TabIndex = 7;
            this.rightTopTrackBar.TabStop = false;
            this.rightTopTrackBar.TickFrequency = 18;
            this.rightTopTrackBar.Value = 90;
            this.rightTopTrackBar.Scroll += new System.EventHandler(this.rightTopTrackBar_Scroll);
            // 
            // leftBotTrackBar
            // 
            this.leftBotTrackBar.LargeChange = 60;
            this.leftBotTrackBar.Location = new System.Drawing.Point(16, 148);
            this.leftBotTrackBar.Maximum = 180;
            this.leftBotTrackBar.Name = "leftBotTrackBar";
            this.leftBotTrackBar.Size = new System.Drawing.Size(201, 45);
            this.leftBotTrackBar.SmallChange = 10;
            this.leftBotTrackBar.TabIndex = 9;
            this.leftBotTrackBar.TabStop = false;
            this.leftBotTrackBar.TickFrequency = 18;
            this.leftBotTrackBar.Value = 90;
            this.leftBotTrackBar.Scroll += new System.EventHandler(this.leftBotTrackBar_Scroll);
            // 
            // rightBotTrackBar
            // 
            this.rightBotTrackBar.LargeChange = 60;
            this.rightBotTrackBar.Location = new System.Drawing.Point(428, 148);
            this.rightBotTrackBar.Maximum = 180;
            this.rightBotTrackBar.Name = "rightBotTrackBar";
            this.rightBotTrackBar.Size = new System.Drawing.Size(201, 45);
            this.rightBotTrackBar.SmallChange = 10;
            this.rightBotTrackBar.TabIndex = 11;
            this.rightBotTrackBar.TabStop = false;
            this.rightBotTrackBar.TickFrequency = 18;
            this.rightBotTrackBar.Value = 90;
            this.rightBotTrackBar.Scroll += new System.EventHandler(this.rightBotTrackBar_Scroll);
            // 
            // connectButton
            // 
            this.connectButton.Enabled = false;
            this.connectButton.Location = new System.Drawing.Point(148, 248);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(69, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(15, 249);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(127, 21);
            this.portsComboBox.TabIndex = 5;
            this.portsComboBox.Text = "Choose connection link...";
            this.portsComboBox.SelectedIndexChanged += new System.EventHandler(this.portsComboBox_SelectedIndexChanged);
            this.portsComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.portsComboBox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Angle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Angle";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(222, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 204);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 316);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 17);
            this.Status.Text = "Status";
            // 
            // onlineCheckBox
            // 
            this.onlineCheckBox.AutoSize = true;
            this.onlineCheckBox.Location = new System.Drawing.Point(364, 252);
            this.onlineCheckBox.Name = "onlineCheckBox";
            this.onlineCheckBox.Size = new System.Drawing.Size(56, 17);
            this.onlineCheckBox.TabIndex = 8;
            this.onlineCheckBox.Text = "Online";
            this.onlineCheckBox.UseVisualStyleBackColor = true;
            this.onlineCheckBox.CheckedChanged += new System.EventHandler(this.onlineCheckBox_CheckedChanged);
            // 
            // selectLogFolderbutton
            // 
            this.selectLogFolderbutton.Location = new System.Drawing.Point(111, 277);
            this.selectLogFolderbutton.Name = "selectLogFolderbutton";
            this.selectLogFolderbutton.Size = new System.Drawing.Size(106, 23);
            this.selectLogFolderbutton.TabIndex = 9;
            this.selectLogFolderbutton.Text = "Select Log Folder";
            this.selectLogFolderbutton.UseVisualStyleBackColor = true;
            this.selectLogFolderbutton.Click += new System.EventHandler(this.selectLogFolderbutton_Click);
            // 
            // startLogButton
            // 
            this.startLogButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.startLogButton.Enabled = false;
            this.startLogButton.Location = new System.Drawing.Point(223, 277);
            this.startLogButton.Name = "startLogButton";
            this.startLogButton.Size = new System.Drawing.Size(69, 23);
            this.startLogButton.TabIndex = 10;
            this.startLogButton.Text = "Start Log";
            this.startLogButton.UseVisualStyleBackColor = true;
            // 
            // startLogCheckBox
            // 
            this.startLogCheckBox.AutoSize = true;
            this.startLogCheckBox.Location = new System.Drawing.Point(298, 282);
            this.startLogCheckBox.Name = "startLogCheckBox";
            this.startLogCheckBox.Size = new System.Drawing.Size(136, 17);
            this.startLogCheckBox.TabIndex = 12;
            this.startLogCheckBox.Text = "Start log when connect";
            this.startLogCheckBox.UseVisualStyleBackColor = true;
            this.startLogCheckBox.CheckedChanged += new System.EventHandler(this.startLogCheckBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(469, 280);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "123";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(446, 284);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 13);
            this.yLabel.TabIndex = 29;
            this.yLabel.Text = "Y:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(470, 249);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 20);
            this.textBox2.TabIndex = 34;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "123";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "RPM:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(548, 252);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 13);
            this.xLabel.TabIndex = 31;
            this.xLabel.Text = "X:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(571, 248);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 20);
            this.textBox3.TabIndex = 36;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "123";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(570, 279);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(59, 20);
            this.textBox4.TabIndex = 35;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "123";
            // 
            // LTNumericUpDown
            // 
            this.LTNumericUpDown.Location = new System.Drawing.Point(148, 74);
            this.LTNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.LTNumericUpDown.Name = "LTNumericUpDown";
            this.LTNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.LTNumericUpDown.TabIndex = 1;
            this.LTNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.LTNumericUpDown.ValueChanged += new System.EventHandler(this.LTNumericUpDown_ValueChanged);
            // 
            // RTNumericUpDown
            // 
            this.RTNumericUpDown.Location = new System.Drawing.Point(428, 74);
            this.RTNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RTNumericUpDown.Name = "RTNumericUpDown";
            this.RTNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.RTNumericUpDown.TabIndex = 2;
            this.RTNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.RTNumericUpDown.ValueChanged += new System.EventHandler(this.RTNumericUpDown_ValueChanged);
            // 
            // LBNumericUpDown
            // 
            this.LBNumericUpDown.Location = new System.Drawing.Point(148, 198);
            this.LBNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.LBNumericUpDown.Name = "LBNumericUpDown";
            this.LBNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.LBNumericUpDown.TabIndex = 3;
            this.LBNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.LBNumericUpDown.ValueChanged += new System.EventHandler(this.LBNumericUpDown_ValueChanged);
            // 
            // RBNumericUpDown
            // 
            this.RBNumericUpDown.Location = new System.Drawing.Point(428, 199);
            this.RBNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RBNumericUpDown.Name = "RBNumericUpDown";
            this.RBNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.RBNumericUpDown.TabIndex = 4;
            this.RBNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.RBNumericUpDown.ValueChanged += new System.EventHandler(this.RBNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Angle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Angle";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(15, 278);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(90, 23);
            this.helpButton.TabIndex = 11;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 338);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RBNumericUpDown);
            this.Controls.Add(this.LBNumericUpDown);
            this.Controls.Add(this.RTNumericUpDown);
            this.Controls.Add(this.LTNumericUpDown);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.startLogCheckBox);
            this.Controls.Add(this.startLogButton);
            this.Controls.Add(this.selectLogFolderbutton);
            this.Controls.Add(this.onlineCheckBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portsComboBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.rightBotTrackBar);
            this.Controls.Add(this.leftBotTrackBar);
            this.Controls.Add(this.rightTopTrackBar);
            this.Controls.Add(this.leftTopTrackBar);
            this.Controls.Add(this.setAnglesButton);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "SpeedTest";
            ((System.ComponentModel.ISupportInitialize)(this.leftTopTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBotTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBotTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LTNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Button setAnglesButton;
        private System.Windows.Forms.TrackBar leftTopTrackBar;
        private System.Windows.Forms.TrackBar rightTopTrackBar;
        private System.Windows.Forms.TrackBar leftBotTrackBar;
        private System.Windows.Forms.TrackBar rightBotTrackBar;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.CheckBox onlineCheckBox;
        private System.Windows.Forms.Button selectLogFolderbutton;
        private System.Windows.Forms.Button startLogButton;
        private System.Windows.Forms.CheckBox startLogCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown LTNumericUpDown;
        private System.Windows.Forms.NumericUpDown RTNumericUpDown;
        private System.Windows.Forms.NumericUpDown LBNumericUpDown;
        private System.Windows.Forms.NumericUpDown RBNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.FolderBrowserDialog logFolderBrowserDialog;
    }
}

