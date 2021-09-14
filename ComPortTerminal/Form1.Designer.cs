
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
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zLabel = new System.Windows.Forms.Label();
            this.setAnglesButton = new System.Windows.Forms.Button();
            this.leftTopTrackBar = new System.Windows.Forms.TrackBar();
            this.rightTopTrackBar = new System.Windows.Forms.TrackBar();
            this.leftBotTrackBar = new System.Windows.Forms.TrackBar();
            this.rightBotTrackBar = new System.Windows.Forms.TrackBar();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectionStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.onlineCheckBox = new System.Windows.Forms.CheckBox();
            this.startLogButton = new System.Windows.Forms.Button();
            this.startLogCheckBox = new System.Windows.Forms.CheckBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.rpmTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.LTNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RTNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RBNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.logFileDialog = new System.Windows.Forms.SaveFileDialog();
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
            this.zLabel.Location = new System.Drawing.Point(529, 280);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(17, 13);
            this.zLabel.TabIndex = 0;
            this.zLabel.Text = "Z:";
            // 
            // setAnglesButton
            // 
            this.setAnglesButton.Enabled = false;
            this.setAnglesButton.Location = new System.Drawing.Point(223, 242);
            this.setAnglesButton.Name = "setAnglesButton";
            this.setAnglesButton.Size = new System.Drawing.Size(97, 23);
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
            this.leftBotTrackBar.Location = new System.Drawing.Point(16, 157);
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
            this.rightBotTrackBar.Location = new System.Drawing.Point(428, 157);
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
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(15, 243);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(200, 21);
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
            this.label5.Location = new System.Drawing.Point(108, 210);
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
            this.StatusStrip,
            this.ConnectionStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(39, 17);
            this.StatusStrip.Text = "Status";
            // 
            // ConnectionStrip
            // 
            this.ConnectionStrip.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConnectionStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ConnectionStrip.Name = "ConnectionStrip";
            this.ConnectionStrip.Size = new System.Drawing.Size(588, 17);
            this.ConnectionStrip.Spring = true;
            this.ConnectionStrip.Text = "No connection";
            this.ConnectionStrip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // onlineCheckBox
            // 
            this.onlineCheckBox.AutoSize = true;
            this.onlineCheckBox.Location = new System.Drawing.Point(429, 245);
            this.onlineCheckBox.Name = "onlineCheckBox";
            this.onlineCheckBox.Size = new System.Drawing.Size(56, 17);
            this.onlineCheckBox.TabIndex = 8;
            this.onlineCheckBox.Text = "Online";
            this.onlineCheckBox.UseVisualStyleBackColor = true;
            this.onlineCheckBox.CheckedChanged += new System.EventHandler(this.onlineCheckBox_CheckedChanged);
            // 
            // startLogButton
            // 
            this.startLogButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.startLogButton.Enabled = false;
            this.startLogButton.Location = new System.Drawing.Point(325, 242);
            this.startLogButton.Name = "startLogButton";
            this.startLogButton.Size = new System.Drawing.Size(97, 23);
            this.startLogButton.TabIndex = 10;
            this.startLogButton.Text = "Start Log";
            this.startLogButton.UseVisualStyleBackColor = true;
            this.startLogButton.Click += new System.EventHandler(this.startLogButton_Click);
            // 
            // startLogCheckBox
            // 
            this.startLogCheckBox.AutoSize = true;
            this.startLogCheckBox.Location = new System.Drawing.Point(494, 245);
            this.startLogCheckBox.Name = "startLogCheckBox";
            this.startLogCheckBox.Size = new System.Drawing.Size(136, 17);
            this.startLogCheckBox.TabIndex = 12;
            this.startLogCheckBox.Text = "Start log when connect";
            this.startLogCheckBox.UseVisualStyleBackColor = true;
            this.startLogCheckBox.CheckedChanged += new System.EventHandler(this.startLogCheckBox_CheckedChanged);
            // 
            // yTextBox
            // 
            this.yTextBox.Enabled = false;
            this.yTextBox.Location = new System.Drawing.Point(446, 277);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(80, 20);
            this.yTextBox.TabIndex = 30;
            this.yTextBox.TabStop = false;
            this.yTextBox.Text = "123";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(428, 280);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 13);
            this.yLabel.TabIndex = 29;
            this.yLabel.Text = "Y:";
            // 
            // rpmTextBox
            // 
            this.rpmTextBox.Enabled = false;
            this.rpmTextBox.Location = new System.Drawing.Point(135, 277);
            this.rpmTextBox.Name = "rpmTextBox";
            this.rpmTextBox.Size = new System.Drawing.Size(80, 20);
            this.rpmTextBox.TabIndex = 34;
            this.rpmTextBox.TabStop = false;
            this.rpmTextBox.Text = "123";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "RPM:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(322, 280);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 13);
            this.xLabel.TabIndex = 31;
            this.xLabel.Text = "X:";
            // 
            // xTextBox
            // 
            this.xTextBox.Enabled = false;
            this.xTextBox.Location = new System.Drawing.Point(342, 277);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(80, 20);
            this.xTextBox.TabIndex = 36;
            this.xTextBox.TabStop = false;
            this.xTextBox.Text = "123";
            // 
            // zTextBox
            // 
            this.zTextBox.Enabled = false;
            this.zTextBox.Location = new System.Drawing.Point(547, 277);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(80, 20);
            this.zTextBox.TabIndex = 35;
            this.zTextBox.TabStop = false;
            this.zTextBox.Text = "123";
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
            this.LBNumericUpDown.Location = new System.Drawing.Point(148, 207);
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
            this.RBNumericUpDown.Location = new System.Drawing.Point(428, 208);
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
            this.label1.Location = new System.Drawing.Point(502, 210);
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
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 200;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RBNumericUpDown);
            this.Controls.Add(this.LBNumericUpDown);
            this.Controls.Add(this.RTNumericUpDown);
            this.Controls.Add(this.LTNumericUpDown);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.zTextBox);
            this.Controls.Add(this.rpmTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.startLogCheckBox);
            this.Controls.Add(this.startLogButton);
            this.Controls.Add(this.onlineCheckBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portsComboBox);
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
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusStrip;
        private System.Windows.Forms.CheckBox onlineCheckBox;
        private System.Windows.Forms.Button startLogButton;
        private System.Windows.Forms.CheckBox startLogCheckBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox rpmTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.NumericUpDown LTNumericUpDown;
        private System.Windows.Forms.NumericUpDown RTNumericUpDown;
        private System.Windows.Forms.NumericUpDown LBNumericUpDown;
        private System.Windows.Forms.NumericUpDown RBNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.SaveFileDialog logFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStrip;
    }
}

