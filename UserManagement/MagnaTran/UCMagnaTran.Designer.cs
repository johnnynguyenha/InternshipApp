namespace InternshipApp.MagnaTran
{
    partial class UCMagnaTran
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientIPLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientIPBox = new System.Windows.Forms.TextBox();
            this.clientPortBox = new System.Windows.Forms.TextBox();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.magnaTranStatusLabel = new System.Windows.Forms.Label();
            this.scriptButton = new System.Windows.Forms.Button();
            this.clientGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(706, 396);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 46);
            this.sendButton.TabIndex = 20;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click_1);
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(3, 419);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(696, 22);
            this.sendBox.TabIndex = 19;
            this.sendBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendBox_KeyPress_1);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(4, 109);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(775, 281);
            this.chatBox.TabIndex = 18;
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Controls.Add(this.disconnectButton);
            this.clientGroupBox.Controls.Add(this.clientPortLabel);
            this.clientGroupBox.Controls.Add(this.clientIPLabel);
            this.clientGroupBox.Controls.Add(this.connectButton);
            this.clientGroupBox.Controls.Add(this.clientIPBox);
            this.clientGroupBox.Controls.Add(this.clientPortBox);
            this.clientGroupBox.Location = new System.Drawing.Point(3, 3);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Size = new System.Drawing.Size(776, 100);
            this.clientGroupBox.TabIndex = 17;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Client";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(655, 71);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(97, 23);
            this.disconnectButton.TabIndex = 8;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click_1);
            // 
            // clientPortLabel
            // 
            this.clientPortLabel.AutoSize = true;
            this.clientPortLabel.Location = new System.Drawing.Point(309, 53);
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
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(655, 27);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(97, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click_1);
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
            this.clientPortBox.Location = new System.Drawing.Point(391, 50);
            this.clientPortBox.Name = "clientPortBox";
            this.clientPortBox.Size = new System.Drawing.Size(187, 22);
            this.clientPortBox.TabIndex = 2;
            this.clientPortBox.Text = "4004";
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.magnaTranStatusLabel);
            this.statusGroupBox.Location = new System.Drawing.Point(799, 273);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(200, 100);
            this.statusGroupBox.TabIndex = 22;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "MagnaTran STATUS";
            // 
            // magnaTranStatusLabel
            // 
            this.magnaTranStatusLabel.AutoSize = true;
            this.magnaTranStatusLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magnaTranStatusLabel.Location = new System.Drawing.Point(60, 32);
            this.magnaTranStatusLabel.Name = "magnaTranStatusLabel";
            this.magnaTranStatusLabel.Size = new System.Drawing.Size(53, 28);
            this.magnaTranStatusLabel.TabIndex = 0;
            this.magnaTranStatusLabel.Text = "OFF";
            // 
            // scriptButton
            // 
            this.scriptButton.Location = new System.Drawing.Point(799, 30);
            this.scriptButton.Name = "scriptButton";
            this.scriptButton.Size = new System.Drawing.Size(139, 70);
            this.scriptButton.TabIndex = 21;
            this.scriptButton.Text = "Script";
            this.scriptButton.UseVisualStyleBackColor = true;
            this.scriptButton.Click += new System.EventHandler(this.scriptButton_Click_1);
            // 
            // UCMagnaTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.clientGroupBox);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.scriptButton);
            this.Name = "UCMagnaTran";
            this.Size = new System.Drawing.Size(1009, 460);
            this.Load += new System.EventHandler(this.UCMagnaTran_Load);
            this.clientGroupBox.ResumeLayout(false);
            this.clientGroupBox.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.Label clientIPLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox clientIPBox;
        private System.Windows.Forms.TextBox clientPortBox;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label magnaTranStatusLabel;
        private System.Windows.Forms.Button scriptButton;
    }
}
