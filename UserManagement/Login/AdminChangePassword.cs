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

    // form for changing password from manage menu (admin is changing someone else's password).
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

        // user presses apply button to change password. display message if successful or not.

        private void applyButton_Click(object sender, EventArgs e)
        {
                string newpassword = newPasswordBox.Text;
                string confirmpassword = confirmPasswordBox.Text;
                string message = "";
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
