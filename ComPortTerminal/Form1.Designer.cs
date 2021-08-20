
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
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.leftTopTrackBar = new System.Windows.Forms.TrackBar();
            this.leftTopTextBox = new System.Windows.Forms.TextBox();
            this.rightTopTextBox = new System.Windows.Forms.TextBox();
            this.rightTopTrackBar = new System.Windows.Forms.TrackBar();
            this.leftBotTextBox = new System.Windows.Forms.TextBox();
            this.leftBotTrackBar = new System.Windows.Forms.TrackBar();
            this.rightBotTextBox = new System.Windows.Forms.TextBox();
            this.rightBotTrackBar = new System.Windows.Forms.TrackBar();
            this.testButton = new System.Windows.Forms.Button();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBotTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBotTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(220, 238);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // leftTopTrackBar
            // 
            this.leftTopTrackBar.Location = new System.Drawing.Point(13, 14);
            this.leftTopTrackBar.Name = "leftTopTrackBar";
            this.leftTopTrackBar.Size = new System.Drawing.Size(201, 45);
            this.leftTopTrackBar.TabIndex = 2;
            this.leftTopTrackBar.Value = 1;
            this.leftTopTrackBar.Scroll += new System.EventHandler(this.leftTopTrackBar_Scroll);
            // 
            // leftTopTextBox
            // 
            this.leftTopTextBox.Location = new System.Drawing.Point(114, 65);
            this.leftTopTextBox.Name = "leftTopTextBox";
            this.leftTopTextBox.Size = new System.Drawing.Size(100, 20);
            this.leftTopTextBox.TabIndex = 6;
            this.leftTopTextBox.Text = "1";
            this.leftTopTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftTopTextBox_KeyPress);
            this.leftTopTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.leftTopTextBox_KeyUp);
            // 
            // rightTopTextBox
            // 
            this.rightTopTextBox.Location = new System.Drawing.Point(426, 65);
            this.rightTopTextBox.Name = "rightTopTextBox";
            this.rightTopTextBox.Size = new System.Drawing.Size(100, 20);
            this.rightTopTextBox.TabIndex = 8;
            this.rightTopTextBox.Text = "1";
            this.rightTopTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightTopTextBox_KeyPress);
            this.rightTopTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rightTopTextBox_KeyUp);
            // 
            // rightTopTrackBar
            // 
            this.rightTopTrackBar.Location = new System.Drawing.Point(426, 14);
            this.rightTopTrackBar.Name = "rightTopTrackBar";
            this.rightTopTrackBar.Size = new System.Drawing.Size(201, 45);
            this.rightTopTrackBar.TabIndex = 7;
            this.rightTopTrackBar.Value = 1;
            this.rightTopTrackBar.Scroll += new System.EventHandler(this.rightTopTrackBar_Scroll);
            // 
            // leftBotTextBox
            // 
            this.leftBotTextBox.Location = new System.Drawing.Point(114, 190);
            this.leftBotTextBox.Name = "leftBotTextBox";
            this.leftBotTextBox.Size = new System.Drawing.Size(100, 20);
            this.leftBotTextBox.TabIndex = 10;
            this.leftBotTextBox.Text = "1";
            this.leftBotTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftBotTextBox_KeyPress);
            this.leftBotTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.leftBotTextBox_KeyUp);
            // 
            // leftBotTrackBar
            // 
            this.leftBotTrackBar.Location = new System.Drawing.Point(13, 139);
            this.leftBotTrackBar.Name = "leftBotTrackBar";
            this.leftBotTrackBar.Size = new System.Drawing.Size(201, 45);
            this.leftBotTrackBar.TabIndex = 9;
            this.leftBotTrackBar.Value = 1;
            this.leftBotTrackBar.Scroll += new System.EventHandler(this.leftBotTrackBar_Scroll);
            // 
            // rightBotTextBox
            // 
            this.rightBotTextBox.Location = new System.Drawing.Point(426, 190);
            this.rightBotTextBox.Name = "rightBotTextBox";
            this.rightBotTextBox.Size = new System.Drawing.Size(100, 20);
            this.rightBotTextBox.TabIndex = 12;
            this.rightBotTextBox.Text = "1";
            this.rightBotTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightBotTextBox_KeyPress);
            this.rightBotTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rightBotTextBox_KeyUp);
            // 
            // rightBotTrackBar
            // 
            this.rightBotTrackBar.Location = new System.Drawing.Point(425, 139);
            this.rightBotTrackBar.Name = "rightBotTrackBar";
            this.rightBotTrackBar.Size = new System.Drawing.Size(201, 45);
            this.rightBotTrackBar.TabIndex = 11;
            this.rightBotTrackBar.Value = 1;
            this.rightBotTrackBar.Scroll += new System.EventHandler(this.rightBotTrackBar_Scroll);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(154, 239);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(60, 23);
            this.testButton.TabIndex = 13;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(12, 240);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(136, 21);
            this.portsComboBox.TabIndex = 14;
            this.portsComboBox.Text = "Choose connection link...";
            this.portsComboBox.SelectedIndexChanged += new System.EventHandler(this.portsComboBox_SelectedIndexChanged);
            this.portsComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.portsComboBox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Angle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Angle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Angle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Angle";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(478, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "123";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(219, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 204);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 273);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 295);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portsComboBox);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.rightBotTextBox);
            this.Controls.Add(this.rightBotTrackBar);
            this.Controls.Add(this.leftBotTextBox);
            this.Controls.Add(this.leftBotTrackBar);
            this.Controls.Add(this.rightTopTextBox);
            this.Controls.Add(this.rightTopTrackBar);
            this.Controls.Add(this.leftTopTextBox);
            this.Controls.Add(this.leftTopTrackBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TrackBar leftTopTrackBar;
        private System.Windows.Forms.TextBox leftTopTextBox;
        private System.Windows.Forms.TextBox rightTopTextBox;
        private System.Windows.Forms.TrackBar rightTopTrackBar;
        private System.Windows.Forms.TextBox leftBotTextBox;
        private System.Windows.Forms.TrackBar leftBotTrackBar;
        private System.Windows.Forms.TextBox rightBotTextBox;
        private System.Windows.Forms.TrackBar rightBotTrackBar;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
    }
}

