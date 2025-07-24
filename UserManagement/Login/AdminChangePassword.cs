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
    /// Form for changing the password of a user using Admin privileges.
    /// </summary>
    public partial class AdminChangePassword : Form
    {
        private readonly UserService _userService;
        private string _username;
        User _user;
        public AdminChangePassword(UserService userService, User user)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
        }

        // FUNCTIONS //

        // EVENTS //

       /// <summary>
       /// User presses apply button. Checks fields and applies new password.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void applyButton_Click(object sender, EventArgs e)
        {
                string newpassword = newPasswordBox.Text;
                string confirmpassword = confirmPasswordBox.Text;
                string message = "";
            if (string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(confirmpassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (newpassword != confirmpassword)
                {
                    MessageBox.Show("New password is not the same as confirm password.");
                    return;
                }
                if (_userService.ChangePasswordNoOld(_username, newpassword, confirmpassword, out message))
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
