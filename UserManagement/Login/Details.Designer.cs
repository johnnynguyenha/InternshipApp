namespace InternshipApp
{
    partial class Details
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
            this.addressLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.logOutButton = new System.Windows.Forms.Button();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(39, 164);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(58, 16);
            this.addressLabel.TabIndex = 26;
            this.addressLabel.Text = "Address";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(0, 136);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(97, 16);
            this.phoneLabel.TabIndex = 25;
            this.phoneLabel.Text = "Phone Number";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(25, 108);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(72, 16);
            this.lastNameLabel.TabIndex = 24;
            this.lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(25, 80);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(72, 16);
            this.firstNameLabel.TabIndex = 23;
            this.firstNameLabel.Text = "First Name";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(30, 52);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordLabel.TabIndex = 22;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(27, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(70, 16);
            this.usernameLabel.TabIndex = 21;
            this.usernameLabel.Text = "Username";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(103, 161);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(348, 22);
            this.addressBox.TabIndex = 20;
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(103, 133);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(348, 22);
            this.phoneBox.TabIndex = 19;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(103, 105);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(348, 22);
            this.lastNameBox.TabIndex = 18;
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(103, 77);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(348, 22);
            this.firstNameBox.TabIndex = 17;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(103, 49);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(348, 22);
            this.passwordBox.TabIndex = 16;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(103, 21);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(348, 22);
            this.usernameBox.TabIndex = 15;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(394, 189);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(57, 32);
            this.applyButton.TabIndex = 28;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(511, 81);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(96, 49);
            this.changePasswordButton.TabIndex = 30;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.usernameBox);
            this.settingsGroupBox.Controls.Add(this.passwordBox);
            this.settingsGroupBox.Controls.Add(this.applyButton);
            this.settingsGroupBox.Controls.Add(this.firstNameBox);
            this.settingsGroupBox.Controls.Add(this.lastNameBox);
            this.settingsGroupBox.Controls.Add(this.addressLabel);
            this.settingsGroupBox.Controls.Add(this.phoneBox);
            this.settingsGroupBox.Controls.Add(this.phoneLabel);
            this.settingsGroupBox.Controls.Add(this.addressBox);
            this.settingsGroupBox.Controls.Add(this.lastNameLabel);
            this.settingsGroupBox.Controls.Add(this.usernameLabel);
            this.settingsGroupBox.Controls.Add(this.firstNameLabel);
            this.settingsGroupBox.Controls.Add(this.passwordLabel);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 29);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(465, 227);
            this.settingsGroupBox.TabIndex = 31;
            this.settingsGroupBox.TabStop = false;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.IndianRed;
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logOutButton.Location = new System.Drawing.Point(694, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(94, 29);
            this.logOutButton.TabIndex = 32;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.changePasswordButton);
            this.Name = "Details";
            this.Text = "Details";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Button logOutButton;
    }
}