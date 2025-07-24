using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;

namespace InternshipApp
{

    /// <summary>
    /// Form for changing the password of a user.
    /// </summary>
    public partial class ChangePassword : Form
    {
        private readonly UserService _userService;
        private string _username;
        User _user;
        public ChangePassword(UserService userService, User user)
        {   
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
        }

        // FUNCTIONS //

        // EVENTS //

        /// <summary>
        /// User presses apply button to change password. If successful, display message and close form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void applyButton_Click_1(object sender, EventArgs e)
        {
            string oldpassword = oldPasswordBox.Text;
            string newpassword = newPasswordBox.Text;
            string confirmpassword = confirmPasswordBox.Text;
            string message = "";
            if (string.IsNullOrEmpty(oldpassword) || string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(confirmpassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (newpassword != confirmpassword)
            {
                MessageBox.Show("New password is not the same as confirm password.");
                return;
            }
            if (_userService.ChangePassword(_username, oldpassword, newpassword, confirmpassword, out message))
            {
                MessageBox.Show(message);
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
