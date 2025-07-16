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

    // form for changing password from details menu (user is logged in).
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

        // user presses apply button to change password. display message if successful or not.

        private void applyButton_Click_1(object sender, EventArgs e)
        {
            string oldpassword = oldPasswordBox.Text;
            string newpassword = newPasswordBox.Text;
            string confirmpassword = confirmPasswordBox.Text;
            string message = "";
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
