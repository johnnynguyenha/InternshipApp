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
    /// Popup to show user details and allow editing of them.
    /// </summary>
    public partial class Details : Form
    {
        UserService _userService;
        string _username;
        string _password;
        User _user;
        loggedInForm _mainmenu;
        loginForm _login;

        public Details(UserService userService, User user, loggedInForm mainmenu, loginForm login)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
            fillDetails();
            enableBoxes(true);
            _password = _userService.GetPassword(_username);
            _mainmenu = mainmenu;
            _login = login;
        }

        // FUNCTIONS //

        /// <summary>
        /// Fills textbox with user details.
        /// </summary>
        private void fillDetails()
        {
            var user = _user;
            if (user != null)
            {
                usernameBox.Text = user.UserName;
                firstNameBox.Text = user.FirstName;
                lastNameBox.Text = user.LastName;
                phoneBox.Text = user.PhoneNumber;
                addressBox.Text = user.Address;
            }
            else
            {
                MessageBox.Show("User not found.");
                this.Dispose();
            }
        }

       /// <summary>
       /// Function to disable or enable boxes for editing.
       /// </summary>
       /// <param name="setting"></param>

        private void enableBoxes(bool setting)
        {
            usernameBox.Enabled = false;
            passwordBox.Enabled = false;
            firstNameBox.Enabled = setting;
            lastNameBox.Enabled = setting;
            phoneBox.Enabled = setting;
            addressBox.Enabled = setting;
        }

        // EVENTS //

        /// <summary>
        ///  User presses edit button to enable the boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void editButton_Click(object sender, EventArgs e)
        {
            enableBoxes(true);
        }

        /// <summary>
        /// Function to check permissions of user. (used in future if developer wants to add permissions to user details form)
        /// </summary>
        /// <param name="perms"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static bool HasPerm(Dictionary<string, bool> perms, string key, bool defaultValue = false)
        {
            if (perms == null) return defaultValue;
            return perms.TryGetValue(key, out bool allowed) ? allowed : defaultValue;
        }
        /// <summary>
        /// User presses apply button to save changes. If successful, display message and close form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == string.Empty)
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }
            string newusername = usernameBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string address = addressBox.Text;
            string role = _userService.GetRole(_user);
            if (
                (newusername ?? "").Trim() == (_userService.GetUserName(_user) ?? "").Trim() &&
                (firstName ?? "").Trim() == (_userService.GetFirstName(_username) ?? "").Trim() &&
                (lastName ?? "").Trim() == (_userService.GetLastName(_username) ?? "").Trim() &&
                (phoneNumber ?? "").Trim() == (_userService.GetPhoneNumber(_username) ?? "").Trim() &&
                (address ?? "").Trim() == (_userService.GetAddress(_username) ?? "").Trim()
            )
            {
                MessageBox.Show("No changes were made.");
                return;
            }
            if (_userService.ChangeDetailsNoPassword(_user, _username, newusername, firstName, lastName, phoneNumber, address, role))
            {
                MessageBox.Show("Details were successfully changed");
                _username = newusername;
                _user = _userService.GetUserByUsername(_username);
            }
            else
            {
                MessageBox.Show("Details were not successfully changed");
            }
            fillDetails();
        }

        /// <summary>
        /// User presses change password button to open change password form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(_userService, _user);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.ShowDialog();
        }

        /// <summary>
        /// User presses logout button. Closes form and returns to login screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutButton_Click(object sender, EventArgs e)
        {
            _mainmenu.Dispose();
            this.Dispose();
            _login.Show();
            
        }

        /// <summary>
        /// User presses delete button to delete their account. If user is an admin, display message that they cannot delete their own account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_userService.GetRole(_user) == "Admin")
            {
                MessageBox.Show("Admins cannot delete their own accounts. Please contact another admin to delete your account.");
                return;
            }
            deletePopup deleteForm = new deletePopup(_user, _mainmenu, _userService);
            deleteForm.StartPosition = FormStartPosition.CenterScreen;
            deleteForm.ShowDialog();
        }
    }
}
