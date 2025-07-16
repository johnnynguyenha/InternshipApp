namespace InternshipApp
{
    partial class MagnaTran
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
            this.sendButton = new System.Windows.Forms.Button();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.clientIPLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientIPBox = new System.Windows.Forms.TextBox();
            this.clientPortBox = new System.Windows.Forms.TextBox();
            this.scriptButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.magnaTranStatusLabel = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(715, 405);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 46);
            this.sendButton.TabIndex = 14;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(12, 428);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(696, 22);
            this.sendBox.TabIndex = 13;
            this.sendBox.TextChanged += new System.EventHandler(this.sendBox_TextChanged);
            this.sendBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendBox_KeyPress);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(13, 118);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(775, 281);
            this.chatBox.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.disconnectButton);
            this.groupBox2.Controls.Add(this.clientPortLabel);
            this.groupBox2.Controls.Add(this.clientIPLabel);
            this.groupBox2.Controls.Add(this.connectButton);
            this.groupBox2.Controls.Add(this.clientIPBox);
            this.groupBox2.Controls.Add(this.clientPortBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
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
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
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
            // scriptButton
            // 
            this.scriptButton.Location = new System.Drawing.Point(808, 39);
            this.scriptButton.Name = "scriptButton";
            this.scriptButton.Size = new System.Drawing.Size(139, 70);
            this.scriptButton.TabIndex = 15;
            this.scriptButton.Text = "Script";
            this.scriptButton.UseVisualStyleBackColor = true;
            this.scriptButton.Click += new System.EventHandler(this.scriptButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.magnaTranStatusLabel);
            this.groupBox8.Location = new System.Drawing.Point(808, 282);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 100);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "MagnaTran STATUS";
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
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(655, 71);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(97, 23);
            this.disconnectButton.TabIndex = 8;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // MagnaTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 604);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.scriptButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "MagnaTran";
            this.Text = "MagnaTran";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.Label clientIPLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox clientIPBox;
        private System.Windows.Forms.TextBox clientPortBox;
        private System.Windows.Forms.Button scriptButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label magnaTranStatusLabel;
        private System.Windows.Forms.Button disconnectButton;
    }
}