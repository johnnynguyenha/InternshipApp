using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;

namespace InternshipApp
{
    /// <summary>
    /// Login form for the application. User can enter username and password to log in. 
    /// </summary>
    public partial class loginForm : Form
    {
        UserService _userService;
        public loginForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            registerLinkLabel.Visible = false;
        }

        // FUNCTIONS //
        /// <summary>
        /// Login function that checks if the user has entered a username and password. If so, it calls the UserService to log in the user.
        /// </summary>
        private void login()
        {
            try
            {
                string username = usernameTextBox.Text;
                string password = passwordBox.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }
                User user = _userService.Login(username, password, out string message);
                if (user != null)
                {
                    loggedInForm loginForm = new loggedInForm(user, _userService, this);
                    loginForm.StartPosition = FormStartPosition.CenterScreen;
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login.");
            }
        }

        // EVENTS //

        /// <summary>
        /// user presses login button. if login is successful, open logged in form. if not, display error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            login();
            
        }

        
        /// <summary>
        /// user presses forgot password button. opens forgot password form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            forgotPasswordForm changePasswordForm = new forgotPasswordForm(_userService);
            changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
            changePasswordForm.Show();
        }
        /// <summary>
        /// user presses sign up button. opens sign up form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signup = new SignUp(_userService);
            signup.StartPosition = FormStartPosition.CenterScreen;
            signup.Show();
        }

        /// <summary>
        /// Alternate behavior for instead of pressing login button, user presses Enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Optional: prevent default behavior like the "ding"
                login();
            }
        }
    }
}
