namespace InternshipApp
{
    partial class loggedInForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.manageButton = new System.Windows.Forms.Button();
            this.commButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.magnaButton = new System.Windows.Forms.Button();
            this.packetButton = new System.Windows.Forms.Button();
            this.commLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.detailsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(640, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(116, 24);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Logged in: ";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // manageButton
            // 
            this.manageButton.Location = new System.Drawing.Point(16, 179);
            this.manageButton.Name = "manageButton";
            this.manageButton.Size = new System.Drawing.Size(114, 44);
            this.manageButton.TabIndex = 3;
            this.manageButton.Text = "User Management";
            this.manageButton.UseVisualStyleBackColor = true;
            this.manageButton.Click += new System.EventHandler(this.manageButton_Click);
            this.manageButton.MouseEnter += new System.EventHandler(this.manageButton_MouseEnter);
            // 
            // commButton
            // 
            this.commButton.Location = new System.Drawing.Point(16, 31);
            this.commButton.Name = "commButton";
            this.commButton.Size = new System.Drawing.Size(114, 44);
            this.commButton.TabIndex = 5;
            this.commButton.Text = "Communications";
            this.commButton.UseVisualStyleBackColor = true;
            this.commButton.Click += new System.EventHandler(this.commButton_Click);
            this.commButton.MouseEnter += new System.EventHandler(this.commButton_MouseEnter);
            this.commButton.MouseHover += new System.EventHandler(this.commButton_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.manageButton);
            this.groupBox1.Controls.Add(this.exitButton);
            this.groupBox1.Controls.Add(this.magnaButton);
            this.groupBox1.Controls.Add(this.packetButton);
            this.groupBox1.Controls.Add(this.commButton);
            this.groupBox1.Location = new System.Drawing.Point(19, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 347);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(16, 297);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(114, 44);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.button1_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // magnaButton
            // 
            this.magnaButton.Location = new System.Drawing.Point(16, 129);
            this.magnaButton.Name = "magnaButton";
            this.magnaButton.Size = new System.Drawing.Size(114, 44);
            this.magnaButton.TabIndex = 7;
            this.magnaButton.Text = "Control MagnaTran";
            this.magnaButton.UseVisualStyleBackColor = true;
            this.magnaButton.Click += new System.EventHandler(this.magnaButton_Click);
            this.magnaButton.MouseEnter += new System.EventHandler(this.magnaButton_MouseEnter);
            this.magnaButton.MouseHover += new System.EventHandler(this.magnaButton_MouseHover);
            // 
            // packetButton
            // 
            this.packetButton.Location = new System.Drawing.Point(16, 81);
            this.packetButton.Name = "packetButton";
            this.packetButton.Size = new System.Drawing.Size(114, 44);
            this.packetButton.TabIndex = 6;
            this.packetButton.Text = "Packet Capture";
            this.packetButton.UseVisualStyleBackColor = true;
            this.packetButton.Click += new System.EventHandler(this.packetButton_Click);
            this.packetButton.MouseEnter += new System.EventHandler(this.packetButton_MouseEnter);
            this.packetButton.MouseHover += new System.EventHandler(this.packetButton_MouseHover);
            // 
            // commLabel
            // 
            this.commLabel.AutoSize = true;
            this.commLabel.Location = new System.Drawing.Point(362, 243);
            this.commLabel.Name = "commLabel";
            this.commLabel.Size = new System.Drawing.Size(0, 16);
            this.commLabel.TabIndex = 8;
            this.commLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.commLabel.Click += new System.EventHandler(this.commLabel_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.commLabel);
            this.mainPanel.Location = new System.Drawing.Point(171, 50);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1099, 576);
            this.mainPanel.TabIndex = 8;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // detailsLinkLabel
            // 
            this.detailsLinkLabel.AutoSize = true;
            this.detailsLinkLabel.Location = new System.Drawing.Point(756, 14);
            this.detailsLinkLabel.Name = "detailsLinkLabel";
            this.detailsLinkLabel.Size = new System.Drawing.Size(30, 16);
            this.detailsLinkLabel.TabIndex = 9;
            this.detailsLinkLabel.TabStop = true;
            this.detailsLinkLabel.Text = "abc";
            this.detailsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // loggedInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 638);
            this.Controls.Add(this.detailsLinkLabel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.titleLabel);
            this.Name = "loggedInForm";
            this.Text = "LoggedIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.loggedInForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button manageButton;
        private System.Windows.Forms.Button commButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button magnaButton;
        private System.Windows.Forms.Button packetButton;
        private System.Windows.Forms.Label commLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.LinkLabel detailsLinkLabel;
    }
}