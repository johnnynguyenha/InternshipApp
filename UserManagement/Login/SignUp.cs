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
    // form for signing up a new user (user is not logged in). user must enter username and password in order to register.
    public partial class SignUp : Form
    {
        UserService _userService;
        public SignUp(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        // user presses register button to create a new account. display message if successful or not.
        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;
            string message = "";

            Dictionary<string, bool> permissions = new Dictionary<string, bool>
            {
                { "Communication", permissionCheckBox.CheckedItems.Contains("Communication") },
                { "Network", permissionCheckBox.CheckedItems.Contains("Network") },
                { "MagnaTran", permissionCheckBox.CheckedItems.Contains("MagnaTran") },
                { "Details", permissionCheckBox.CheckedItems.Contains("Details") },
                { "Manage", permissionCheckBox.CheckedItems.Contains("Manage") }
            };

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (password == confirmPassword)
            {
                try
                {
                    _userService.Register(username, password, confirmPassword, out message);
                    if (message == "Register was Successful")
                    {
                        foreach (var perm in permissions)
                        {
                            _userService.setPerm(username, perm.Key, perm.Value, out message);
                        }
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred, user could not be registered.");
                    return;
                }
            }
            else
            {
                message = "Passwords do not match";
            }
            MessageBox.Show(message);
        }
    }
}
