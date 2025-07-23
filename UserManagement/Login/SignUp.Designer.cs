namespace InternshipApp
{
    partial class SignUp
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
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.permissionCheckBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(251, 183);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(360, 22);
            this.passwordBox.TabIndex = 9;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(251, 132);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(360, 22);
            this.usernameBox.TabIndex = 8;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(138, 183);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 16);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(331, 46);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(191, 51);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Register";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(138, 132);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(70, 16);
            this.userNameLabel.TabIndex = 6;
            this.userNameLabel.Text = "Username";
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(251, 230);
            this.confirmPasswordBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.Size = new System.Drawing.Size(360, 22);
            this.confirmPasswordBox.TabIndex = 10;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(120, 236);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(115, 16);
            this.confirmPasswordLabel.TabIndex = 11;
            this.confirmPasswordLabel.Text = "Confirm Password";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(251, 284);
            this.registerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(360, 35);
            this.registerButton.TabIndex = 12;
            this.registerButton.Text = "Sign Up";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // permissionCheckBox
            // 
            this.permissionCheckBox.FormattingEnabled = true;
            this.permissionCheckBox.Items.AddRange(new object[] {
            "Communications",
            "Network",
            "MagnaTran",
            "Details",
            "Manage"});
            this.permissionCheckBox.Location = new System.Drawing.Point(640, 132);
            this.permissionCheckBox.Name = "permissionCheckBox";
            this.permissionCheckBox.Size = new System.Drawing.Size(134, 123);
            this.permissionCheckBox.TabIndex = 13;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.permissionCheckBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.CheckedListBox permissionCheckBox;
    }
}