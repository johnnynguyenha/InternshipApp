using BL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InternshipApp
{

    // form for managing users (admin or user). allows editing, deleting, and viewing user details.
    public partial class Manage : Form
    {
        List<User> userList;
        UserService _userService;
        string _username;
        bool _editVisible;
        bool _isFilling;
        User _user;
        User _selecteduser;
        public Manage(UserService userService, User user)
        {
            InitializeComponent();
            _userService = userService;
            userList = _userService.GetUserList();
            FillListAsync();
            progressBar1.Style = ProgressBarStyle.Marquee;
            _user = user;
            _username = _user.UserName;
            SetVisibility(false);
        }

        // FUNCTIONS //

        // fills the list box with users.
        private void FillList()
        {
            listBox1.Items.Clear();
            userList = _userService.GetUserList();
            if (userList == null || userList.Count == 0)
            {
                MessageBox.Show("No users found");
                return;
            }
            foreach (User user in userList)
            {
                if (user != null)
                {
                    listBox1.Items.Add(_userService.GetUserName(user));
                }
            }
        }

        // function to fill list with users asynchronously.
        private async Task FillListAsync()
        {
            progressBar1.Visible = true;
            _isFilling = true;
            HideButtons(_isFilling);
            listBox1.Items.Clear();
            userList = await _userService.GetUserListAsync();
            // await Task.Delay(5000); // Simulate a delay for filling the list
            if (userList == null || userList.Count == 0)
            {
                MessageBox.Show("No users found");
                return;
            }
            foreach (User user in userList)
            {
                if (user != null)
                {
                    listBox1.Items.Add(_userService.GetUserName(user));
                }
            }
            progressBar1.Visible = false;
            _isFilling = false;
            HideButtons(_isFilling);
        }

        // function to change visibility of labels and textboxes.
        private void SetVisibility(bool setting)
        {
            usernameLabel.Visible = setting;
            passwordLabel.Visible = setting;
            firstNameLabel.Visible = setting;
            lastNameLabel.Visible = setting;
            phoneLabel.Visible = setting;
            addressLabel.Visible = setting;
            roleLabel.Visible = setting;
            usernameBox.Visible = setting;
            passwordBox.Visible = setting;
            firstNameBox.Visible = setting;
            lastNameBox.Visible = setting;
            phoneBox.Visible = setting;
            addressBox.Visible = setting;
            roleBox.Visible = setting;
            applyButton.Visible = setting;
            changePasswordButton.Visible = setting;
            _editVisible = setting;
            passwordBox.Enabled = false;
        }

        // function to fill boxes with user details.
        private void FillUser(User user)
        {
            if (user == null) return;
            usernameBox.Text = user.UserName;
            firstNameBox.Text = user.FirstName;
            lastNameBox.Text = user.LastName;
            phoneBox.Text = user.PhoneNumber;
            addressBox.Text = user.Address;
            roleBox.Text = user.Role;
        }

        private void HideButtons(bool filling)
        {
            if (filling)
            {
                deleteButton.Visible = false;
                editButton.Visible = false;
            } else
            {
                deleteButton.Visible = true;
                editButton.Visible = true;
            }
        }
        // EVENTS //

        // if user presses another user in the list, change the textboxes to match the user
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            var username = listBox1.SelectedItem.ToString();
            _selecteduser = _userService.GetUserByUsername(username);
            if (_editVisible)
            {
                FillUser(_selecteduser);
            }
        }

        // user presses delete. if a user is selected, open delete popup to confirm deletion.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("No user selected to delete");
                return;
            }
            if (listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedItem.ToString() == _username)
                {
                    MessageBox.Show("Cannot delete yourself from this menu. Please use the main menu.");
                    return;
                }
                string username = listBox1.SelectedItem.ToString();
                deletePopup delete = new deletePopup(username, _userService);
                delete.StartPosition = FormStartPosition.CenterScreen;
                delete.UserUpdated += UserUpdated;
                delete.ShowDialog();
            }
        }

        // user updated event to refresh user list.
        private void UserUpdated(object sender, EventArgs e)
        {
            FillListAsync();
        }

        // user presses edit button. if user is selected, show textboxes for editing user details.
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SetVisibility(true);
                string username = listBox1.SelectedItem.ToString();
                User user = _userService.GetUserByUsername(username);
                if (user == null)
                {
                    MessageBox.Show("User not found");
                    return;
                }
                FillUser(user);
            }
        }

        // user presses apply button to apply changes.
        private void applyButton_Click(object sender, EventArgs e)
        {
            bool selfEdit = false;
            if (_selecteduser == null)
            {
                MessageBox.Show("No user");
                return;
            }
            if (_selecteduser.UserName == _username)
            {
                selfEdit = true;
            }
            string newusername = usernameBox.Text;
            string password = passwordBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string address = addressBox.Text;
            string role = roleBox.Text;
            if (_userService.ChangeDetails(_selecteduser, _selecteduser.UserName, newusername, password, firstName, lastName, phoneNumber, address, role))
            {
                MessageBox.Show("Details were successfully changed");
            } else
            {
                MessageBox.Show("Details were not successfully changed");
            }
            if (selfEdit)
            {
                _user = _userService.GetUserByUsername(newusername);
                _username = _user.UserName;
            }
            FillListAsync();
            SetVisibility(false);
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (_selecteduser == null)
            {
                MessageBox.Show("No user selected to change password");
                return;
            }
            AdminChangePassword changePassword = new AdminChangePassword(_userService, _selecteduser);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.ShowDialog();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp(_userService);
            signup.StartPosition = FormStartPosition.CenterScreen;
            signup.ShowDialog();
        }
    }
}
