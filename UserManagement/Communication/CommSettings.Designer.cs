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
            this.comPortGroupBox = new System.Windows.Forms.GroupBox();
            this.rtsCheckBox = new System.Windows.Forms.CheckBox();
            this.dtrCheckBox = new System.Windows.Forms.CheckBox();
            this.comPortCBox = new System.Windows.Forms.ComboBox();
            this.parityBitsCBox = new System.Windows.Forms.ComboBox();
            this.parityBitsLabel = new System.Windows.Forms.Label();
            this.stopBitsCBox = new System.Windows.Forms.ComboBox();
            this.stopBitsLabel = new System.Windows.Forms.Label();
            this.dataBitsCBox = new System.Windows.Forms.ComboBox();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.baudRateCBox = new System.Windows.Forms.ComboBox();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.tcpPage = new System.Windows.Forms.TabPage();
            this.tcpServerGroupBox = new System.Windows.Forms.GroupBox();
            this.serverIPBox = new System.Windows.Forms.TextBox();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverIPLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.tcpclientPage = new System.Windows.Forms.TabPage();
            this.tcpClientGroupBox = new System.Windows.Forms.GroupBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientIPLabel = new System.Windows.Forms.Label();
            this.clientIPBox = new System.Windows.Forms.TextBox();
            this.clientPortBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.connectionTab.SuspendLayout();
            this.comPage.SuspendLayout();
            this.comPortGroupBox.SuspendLayout();
            this.tcpPage.SuspendLayout();
            this.tcpServerGroupBox.SuspendLayout();
            this.tcpclientPage.SuspendLayout();
            this.tcpClientGroupBox.SuspendLayout();
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
            this.comPage.Controls.Add(this.comPortGroupBox);
            this.comPage.Location = new System.Drawing.Point(4, 25);
            this.comPage.Name = "comPage";
            this.comPage.Padding = new System.Windows.Forms.Padding(3);
            this.comPage.Size = new System.Drawing.Size(388, 289);
            this.comPage.TabIndex = 0;
            this.comPage.Text = "COM";
            this.comPage.UseVisualStyleBackColor = true;
            // 
            // comPortGroupBox
            // 
            this.comPortGroupBox.Controls.Add(this.rtsCheckBox);
            this.comPortGroupBox.Controls.Add(this.dtrCheckBox);
            this.comPortGroupBox.Controls.Add(this.comPortCBox);
            this.comPortGroupBox.Controls.Add(this.parityBitsCBox);
            this.comPortGroupBox.Controls.Add(this.parityBitsLabel);
            this.comPortGroupBox.Controls.Add(this.stopBitsCBox);
            this.comPortGroupBox.Controls.Add(this.stopBitsLabel);
            this.comPortGroupBox.Controls.Add(this.dataBitsCBox);
            this.comPortGroupBox.Controls.Add(this.dataBitsLabel);
            this.comPortGroupBox.Controls.Add(this.baudRateCBox);
            this.comPortGroupBox.Controls.Add(this.baudRateLabel);
            this.comPortGroupBox.Controls.Add(this.comPortLabel);
            this.comPortGroupBox.Location = new System.Drawing.Point(6, 39);
            this.comPortGroupBox.Name = "comPortGroupBox";
            this.comPortGroupBox.Size = new System.Drawing.Size(366, 197);
            this.comPortGroupBox.TabIndex = 1;
            this.comPortGroupBox.TabStop = false;
            this.comPortGroupBox.Text = "Com Port Control";
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
            // parityBitsLabel
            // 
            this.parityBitsLabel.AutoSize = true;
            this.parityBitsLabel.Location = new System.Drawing.Point(10, 144);
            this.parityBitsLabel.Name = "parityBitsLabel";
            this.parityBitsLabel.Size = new System.Drawing.Size(89, 16);
            this.parityBitsLabel.TabIndex = 8;
            this.parityBitsLabel.Text = "PARITY BITS";
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
            // stopBitsLabel
            // 
            this.stopBitsLabel.AutoSize = true;
            this.stopBitsLabel.Location = new System.Drawing.Point(10, 114);
            this.stopBitsLabel.Name = "stopBitsLabel";
            this.stopBitsLabel.Size = new System.Drawing.Size(77, 16);
            this.stopBitsLabel.TabIndex = 6;
            this.stopBitsLabel.Text = "STOP BITS";
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
            // dataBitsLabel
            // 
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Location = new System.Drawing.Point(10, 84);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(77, 16);
            this.dataBitsLabel.TabIndex = 4;
            this.dataBitsLabel.Text = "DATA BITS";
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
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(10, 54);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(85, 16);
            this.baudRateLabel.TabIndex = 2;
            this.baudRateLabel.Text = "BAUD RATE";
            // 
            // comPortLabel
            // 
            this.comPortLabel.AutoSize = true;
            this.comPortLabel.Location = new System.Drawing.Point(10, 24);
            this.comPortLabel.Name = "comPortLabel";
            this.comPortLabel.Size = new System.Drawing.Size(78, 16);
            this.comPortLabel.TabIndex = 0;
            this.comPortLabel.Text = "COM PORT";
            // 
            // tcpPage
            // 
            this.tcpPage.Controls.Add(this.tcpServerGroupBox);
            this.tcpPage.Location = new System.Drawing.Point(4, 25);
            this.tcpPage.Name = "tcpPage";
            this.tcpPage.Padding = new System.Windows.Forms.Padding(3);
            this.tcpPage.Size = new System.Drawing.Size(388, 289);
            this.tcpPage.TabIndex = 1;
            this.tcpPage.Text = "TCP/IP Server";
            this.tcpPage.UseVisualStyleBackColor = true;
            // 
            // tcpServerGroupBox
            // 
            this.tcpServerGroupBox.Controls.Add(this.serverIPBox);
            this.tcpServerGroupBox.Controls.Add(this.serverPortLabel);
            this.tcpServerGroupBox.Controls.Add(this.serverIPLabel);
            this.tcpServerGroupBox.Controls.Add(this.portBox);
            this.tcpServerGroupBox.Location = new System.Drawing.Point(6, 6);
            this.tcpServerGroupBox.Name = "tcpServerGroupBox";
            this.tcpServerGroupBox.Size = new System.Drawing.Size(376, 186);
            this.tcpServerGroupBox.TabIndex = 7;
            this.tcpServerGroupBox.TabStop = false;
            this.tcpServerGroupBox.Text = "Server";
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
            this.tcpclientPage.Controls.Add(this.tcpClientGroupBox);
            this.tcpclientPage.Location = new System.Drawing.Point(4, 25);
            this.tcpclientPage.Name = "tcpclientPage";
            this.tcpclientPage.Padding = new System.Windows.Forms.Padding(3);
            this.tcpclientPage.Size = new System.Drawing.Size(388, 289);
            this.tcpclientPage.TabIndex = 2;
            this.tcpclientPage.Text = "TCP/IP Client";
            this.tcpclientPage.UseVisualStyleBackColor = true;
            // 
            // tcpClientGroupBox
            // 
            this.tcpClientGroupBox.Controls.Add(this.clientPortLabel);
            this.tcpClientGroupBox.Controls.Add(this.clientIPLabel);
            this.tcpClientGroupBox.Controls.Add(this.clientIPBox);
            this.tcpClientGroupBox.Controls.Add(this.clientPortBox);
            this.tcpClientGroupBox.Location = new System.Drawing.Point(17, 16);
            this.tcpClientGroupBox.Name = "tcpClientGroupBox";
            this.tcpClientGroupBox.Size = new System.Drawing.Size(352, 167);
            this.tcpClientGroupBox.TabIndex = 8;
            this.tcpClientGroupBox.TabStop = false;
            this.tcpClientGroupBox.Text = "Client";
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
            this.comPortGroupBox.ResumeLayout(false);
            this.comPortGroupBox.PerformLayout();
            this.tcpPage.ResumeLayout(false);
            this.tcpServerGroupBox.ResumeLayout(false);
            this.tcpServerGroupBox.PerformLayout();
            this.tcpclientPage.ResumeLayout(false);
            this.tcpClientGroupBox.ResumeLayout(false);
            this.tcpClientGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl connectionTab;
        private System.Windows.Forms.TabPage comPage;
        private System.Windows.Forms.TabPage tcpPage;
        private System.Windows.Forms.GroupBox comPortGroupBox;
        private System.Windows.Forms.ComboBox comPortCBox;
        private System.Windows.Forms.ComboBox parityBitsCBox;
        private System.Windows.Forms.Label parityBitsLabel;
        private System.Windows.Forms.ComboBox stopBitsCBox;
        private System.Windows.Forms.Label stopBitsLabel;
        private System.Windows.Forms.ComboBox dataBitsCBox;
        private System.Windows.Forms.Label dataBitsLabel;
        private System.Windows.Forms.ComboBox baudRateCBox;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox tcpClientGroupBox;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.Label clientIPLabel;
        private System.Windows.Forms.TextBox clientIPBox;
        private System.Windows.Forms.TextBox clientPortBox;
        private System.Windows.Forms.GroupBox tcpServerGroupBox;
        private System.Windows.Forms.TextBox serverIPBox;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TabPage tcpclientPage;
        private System.Windows.Forms.CheckBox rtsCheckBox;
        private System.Windows.Forms.CheckBox dtrCheckBox;
    }
}