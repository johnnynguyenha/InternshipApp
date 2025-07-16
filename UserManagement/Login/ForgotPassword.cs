using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;

namespace InternshipApp
{

    // form for resetting password (user is not logged in). user must enter username and new password.
    public partial class forgotPasswordForm : Form
    {
        private readonly UserService _userService;
        private string _username;

        public forgotPasswordForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        // user presses apply button to reset password. display message if successful or not.
        private void applyButton_Click(object sender, EventArgs e)
        {
            _username = usernameBox.Text;
            string newpassword = newPasswordBox.Text;
            string confirmpassword = confirmPasswordBox.Text;
            if (_userService.ResetPassword(_username, newpassword, confirmpassword, out string message))
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
