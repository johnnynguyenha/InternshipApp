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
    /// Form for signing up a new user account.
    /// </summary>
    public partial class SignUp : Form
    {
        UserService _userService;
        public EventHandler UserUpdated;
        public User CreatedUser { get; private set; }


        public SignUp(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        /// <summary>
        /// user presses register button to create a new account. display message if successful or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;
            string message = "";

            Dictionary<string, bool> permissions = new Dictionary<string, bool>
            {
                { "Communications", permissionCheckBox.CheckedItems.Contains("Communications") },
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
                            UserUpdated?.Invoke(this, EventArgs.Empty); // notify user list has been updated.
                        }
                        this.Close();
                        message = "Register was Successful";
                        CreatedUser = _userService.GetUserByUsername(username);
                        UserUpdated?.Invoke(this, EventArgs.Empty);
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
