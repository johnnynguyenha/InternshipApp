namespace InternshipApp
{
    partial class CommSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionTab = new System.Windows.Forms.TabControl();
            this.comPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtsCheckBox = new System.Windows.Forms.CheckBox();
            this.dtrCheckBox = new System.Windows.Forms.CheckBox();
            this.comPortCBox = new System.Windows.Forms.ComboBox();
            this.parityBitsCBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stopBitsCBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBitsCBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baudRateCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tcpPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.serverIPBox = new System.Windows.Forms.TextBox();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverIPLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.tcpclientPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientIPLabel = new System.Windows.Forms.Label();
            this.clientIPBox = new System.Windows.Forms.TextBox();
            this.clientPortBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.connectionTab.SuspendLayout();
            this.comPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcpPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tcpclientPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionTab
            // 
            this.connectionTab.Controls.Add(this.comPage);
            this.connectionTab.Controls.Add(this.tcpPage);
            this.connectionTab.Controls.Add(this.tcpclientPage);
            this.connectionTab.Location = new System.Drawing.Point(12, 12);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.SelectedIndex = 0;
            this.connectionTab.Size = new System.Drawing.Size(396, 318);
            this.connectionTab.TabIndex = 0;
            // 
            // comPage
            // 
            this.comPage.Controls.Add(this.groupBox1);
            this.comPage.Location = new System.Drawing.Point(4, 25);
            this.comPage.Name = "comPage";
            this.comPage.Padding = new System.Windows.Forms.Padding(3);
            this.comPage.Size = new System.Drawing.Size(388, 289);
            this.comPage.TabIndex = 0;
            this.comPage.Text = "COM";
            this.comPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtsCheckBox);
            this.groupBox1.Controls.Add(this.dtrCheckBox);
            this.groupBox1.Controls.Add(this.comPortCBox);
            this.groupBox1.Controls.Add(this.parityBitsCBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.stopBitsCBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dataBitsCBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.baudRateCBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Port Control";
            // 
            // rtsCheckBox
            // 
            this.rtsCheckBox.AutoSize = true;
            this.rtsCheckBox.Location = new System.Drawing.Point(126, 171);
            this.rtsCheckBox.Name = "rtsCheckBox";
            this.rtsCheckBox.Size = new System.Drawing.Size(113, 20);
            this.rtsCheckBox.TabIndex = 10;
            this.rtsCheckBox.Text = "RTS ENABLE";
            this.rtsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dtrCheckBox
            // 
            this.dtrCheckBox.AutoSize = true;
            this.dtrCheckBox.Location = new System.Drawing.Point(6, 171);
            this.dtrCheckBox.Name = "dtrCheckBox";
            this.dtrCheckBox.Size = new System.Drawing.Size(114, 20);
            this.dtrCheckBox.TabIndex = 9;
            this.dtrCheckBox.Text = "DTR ENABLE";
            this.dtrCheckBox.UseVisualStyleBackColor = true;
            // 
            // comPortCBox
            // 
            this.comPortCBox.FormattingEnabled = true;
            this.comPortCBox.Location = new System.Drawing.Point(107, 21);
            this.comPortCBox.Name = "comPortCBox";
            this.comPortCBox.Size = new System.Drawing.Size(121, 24);
            this.comPortCBox.TabIndex = 0;
            // 
            // parityBitsCBox
            // 
            this.parityBitsCBox.FormattingEnabled = true;
            this.parityBitsCBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.parityBitsCBox.Location = new System.Drawing.Point(107, 141);
            this.parityBitsCBox.Name = "parityBitsCBox";
            this.parityBitsCBox.Size = new System.Drawing.Size(121, 24);
            this.parityBitsCBox.TabIndex = 7;
            this.parityBitsCBox.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "PARITY BITS";
            // 
            // stopBitsCBox
            // 
            this.stopBitsCBox.FormattingEnabled = true;
            this.stopBitsCBox.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.stopBitsCBox.Location = new System.Drawing.Point(107, 111);
            this.stopBitsCBox.Name = "stopBitsCBox";
            this.stopBitsCBox.Size = new System.Drawing.Size(121, 24);
            this.stopBitsCBox.TabIndex = 5;
            this.stopBitsCBox.Text = "One";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "STOP BITS";
            // 
            // dataBitsCBox
            // 
            this.dataBitsCBox.FormattingEnabled = true;
            this.dataBitsCBox.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.dataBitsCBox.Location = new System.Drawing.Point(107, 81);
            this.dataBitsCBox.Name = "dataBitsCBox";
            this.dataBitsCBox.Size = new System.Drawing.Size(121, 24);
            this.dataBitsCBox.TabIndex = 3;
            this.dataBitsCBox.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "DATA BITS";
            // 
            // baudRateCBox
            // 
            this.baudRateCBox.FormattingEnabled = true;
            this.baudRateCBox.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600"});
            this.baudRateCBox.Location = new System.Drawing.Point(107, 51);
            this.baudRateCBox.Name = "baudRateCBox";
            this.baudRateCBox.Size = new System.Drawing.Size(121, 24);
            this.baudRateCBox.TabIndex = 1;
            this.baudRateCBox.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "BAUD RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM PORT";
            // 
            // tcpPage
            // 
            this.tcpPage.Controls.Add(this.groupBox3);
            this.tcpPage.Location = new System.Drawing.Point(4, 25);
            this.tcpPage.Name = "tcpPage";
            this.tcpPage.Padding = new System.Windows.Forms.Padding(3);
            this.tcpPage.Size = new System.Drawing.Size(388, 289);
            this.tcpPage.TabIndex = 1;
            this.tcpPage.Text = "TCP/IP Server";
            this.tcpPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.serverIPBox);
            this.groupBox3.Controls.Add(this.serverPortLabel);
            this.groupBox3.Controls.Add(this.serverIPLabel);
            this.groupBox3.Controls.Add(this.portBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 186);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // serverIPBox
            // 
            this.serverIPBox.Location = new System.Drawing.Point(76, 39);
            this.serverIPBox.Name = "serverIPBox";
            this.serverIPBox.Size = new System.Drawing.Size(187, 22);
            this.serverIPBox.TabIndex = 6;
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(16, 72);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(45, 16);
            this.serverPortLabel.TabIndex = 5;
            this.serverPortLabel.Text = "PORT";
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.AutoSize = true;
            this.serverIPLabel.Location = new System.Drawing.Point(42, 38);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(19, 16);
            this.serverIPLabel.TabIndex = 4;
            this.serverIPLabel.Text = "IP";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(76, 72);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(187, 22);
            this.portBox.TabIndex = 1;
            // 
            // tcpclientPage
            // 
            this.tcpclientPage.Controls.Add(this.groupBox2);
            this.tcpclientPage.Location = new System.Drawing.Point(4, 25);
            this.tcpclientPage.Name = "tcpclientPage";
            this.tcpclientPage.Padding = new System.Windows.Forms.Padding(3);
            this.tcpclientPage.Size = new System.Drawing.Size(388, 289);
            this.tcpclientPage.TabIndex = 2;
            this.tcpclientPage.Text = "TCP/IP Client";
            this.tcpclientPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clientPortLabel);
            this.groupBox2.Controls.Add(this.clientIPLabel);
            this.groupBox2.Controls.Add(this.clientIPBox);
            this.groupBox2.Controls.Add(this.clientPortBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // clientPortLabel
            // 
            this.clientPortLabel.AutoSize = true;
            this.clientPortLabel.Location = new System.Drawing.Point(25, 82);
            this.clientPortLabel.Name = "clientPortLabel";
            this.clientPortLabel.Size = new System.Drawing.Size(45, 16);
            this.clientPortLabel.TabIndex = 7;
            this.clientPortLabel.Text = "PORT";
            // 
            // clientIPLabel
            // 
            this.clientIPLabel.AutoSize = true;
            this.clientIPLabel.Location = new System.Drawing.Point(42, 53);
            this.clientIPLabel.Name = "clientIPLabel";
            this.clientIPLabel.Size = new System.Drawing.Size(19, 16);
            this.clientIPLabel.TabIndex = 7;
            this.clientIPLabel.Text = "IP";
            // 
            // clientIPBox
            // 
            this.clientIPBox.Location = new System.Drawing.Point(76, 47);
            this.clientIPBox.Name = "clientIPBox";
            this.clientIPBox.Size = new System.Drawing.Size(187, 22);
            this.clientIPBox.TabIndex = 3;
            this.clientIPBox.Text = "209.36.30.70";
            // 
            // clientPortBox
            // 
            this.clientPortBox.Location = new System.Drawing.Point(76, 82);
            this.clientPortBox.Name = "clientPortBox";
            this.clientPortBox.Size = new System.Drawing.Size(187, 22);
            this.clientPortBox.TabIndex = 2;
            this.clientPortBox.Text = "4004";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(300, 353);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(104, 38);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // CommSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 408);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.connectionTab);
            this.Name = "CommSettings";
            this.Text = "CommSettings";
            this.Load += new System.EventHandler(this.CommSettings_Load);
            this.connectionTab.ResumeLayout(false);
            this.comPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcpPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tcpclientPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl connectionTab;
        private System.Windows.Forms.TabPage comPage;
        private System.Windows.Forms.TabPage tcpPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comPortCBox;
        private System.Windows.Forms.ComboBox parityBitsCBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox stopBitsCBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataBitsCBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox baudRateCBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.Label clientIPLabel;
        private System.Windows.Forms.TextBox clientIPBox;
        private System.Windows.Forms.TextBox clientPortBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox serverIPBox;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TabPage tcpclientPage;
        private System.Windows.Forms.CheckBox rtsCheckBox;
        private System.Windows.Forms.CheckBox dtrCheckBox;
    }
}