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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InternshipApp.Login
{
    /// <summary>
    /// User Control for managing users, allowing admins to edit, delete, and create user accounts.
    /// </summary>
    public partial class UCManage : UserControl
    {
        List<User> userList;
        UserService _userService;
        string _username;
        bool _editVisible;
        bool _isFilling;
        User _user;
        User _selectedUser;
        private BindingList<User> _bindingUsers;
        private BindingSource _usersBindingSource;
        public UCManage(UserService userService, User user)
        {

            InitializeComponent();
            _userService = userService;
            userList = _userService.GetUserList();
            usersProgressBar.Style = ProgressBarStyle.Marquee;
            _user = user;
            _username = _user.UserName;
            SetVisibility(false);
            CreateGrid();
            _bindingUsers = new BindingList<User>(userList);
            _usersBindingSource = new BindingSource(_bindingUsers, null);
            usersDataGridView.DataSource = _usersBindingSource;
            FillGrid();

        }

        // FUNCTIONS //
        /// <summary>
        /// Function to create the DataGridView for displaying users.
        /// </summary>
        private void CreateGrid()
        {
            usersDataGridView.Columns.Clear();

            usersDataGridView.AutoGenerateColumns = false;
            usersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersDataGridView.MultiSelect = false;

            usersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserName", // matches User property
                HeaderText = "User",
                Width = 80
            });
            usersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Width = 80
            });
            usersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Width = 80
            });
            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Edit",
                Name = "EditButton",
                UseColumnTextForButtonValue = true,
                Width = 60
            };

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Delete",
                Name = "DeleteButton",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            usersDataGridView.Columns.Add(editButtonColumn);
            usersDataGridView.Columns.Add(deleteButtonColumn);
            usersDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        /// <summary>
        /// Function to fill the grid with users asynchronously.
        /// </summary>
        private async void FillGrid()
        {
            usersProgressBar.Visible = true;
            _isFilling = true;

            userList = await _userService.GetUserListAsync();
            if (userList == null || userList.Count == 0)
            {
                MessageBox.Show("No users found");
                usersProgressBar.Visible = false;
                _isFilling = false;
                return;
            }


            usersDataGridView.AutoGenerateColumns = false;
            usersDataGridView.DataSource = null;
            _bindingUsers = new BindingList<User>(userList);
            _usersBindingSource.DataSource = _bindingUsers;
            usersDataGridView.DataSource = _usersBindingSource;

            usersProgressBar.Visible = false;
            _isFilling = false;


        }
        /// <summary>
        /// Helper function to update user details in the DataGridView after changes are made.
        /// </summary>
        /// <param name="updatedUser"></param>
        private void UpdateUserInGrid(User updatedUser)
        {
            var index = _bindingUsers.ToList().FindIndex(u => _userService.GetUserName(u) == _userService.GetUserName(updatedUser));
            if (index >= 0)
            {
                _bindingUsers[index].UserName = updatedUser.UserName;
                _bindingUsers[index].FirstName = updatedUser.FirstName;
                _bindingUsers[index].LastName = updatedUser.LastName;

                _bindingUsers.ResetItem(index);
            }
        }

        /// <summary>
        /// Helper function to remove a user from the DataGridView after deletion.
        /// </summary>
        /// <param name="deletedUser"></param>
        private void RemoveUserFromGrid(User deletedUser)
        {
            var userToRemove = _bindingUsers.FirstOrDefault(u => _userService.GetUserName(u) == _userService.GetUserName(deletedUser));
            if (userToRemove != null)
            {
                _bindingUsers.Remove(userToRemove);
            }
        }

        /// <summary>
        /// Helper function to add a new user to the DataGridView after creation.
        /// </summary>
        /// <param name="newUser"></param>
        private void AddUserToGrid(User newUser)
        {
            if (_bindingUsers == null || newUser == null)
                return;

            // Prevent duplicates based on username
            bool alreadyExists = _bindingUsers.Any(u => _userService.GetUserName(u) == _userService.GetUserName(newUser));
            if (!alreadyExists)
            {
                _bindingUsers.Add(newUser);
            }
        }
        /// <summary>
        /// Function to set the visibility of labels and textboxes based on the setting parameter.
        /// </summary>
        /// <param name="setting"></param>
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
            permissionCheckBox.Visible = setting;
            _editVisible = setting;
            passwordBox.Enabled = false;

            if (usernameBox.Text == "admin")
            {
                permissionCheckBox.Enabled = false;
            } else
            {
                permissionCheckBox.Enabled = true;
            }
        }

        /// <summary>
        /// Function to fill user details into the textboxes based on the selected user.
        /// </summary>
        /// <param name="user"></param>
        private void FillUser(User user)
        {
            if (user == null) return;
            string selectedUsername = _userService.GetUserName(user);
            Dictionary<string, bool> perms = _userService.getPerms(selectedUsername, out string message);
            try
            {
                usernameBox.Text = selectedUsername;
                firstNameBox.Text = _userService.GetFirstName(selectedUsername);
                lastNameBox.Text = _userService.GetLastName(selectedUsername);
                phoneBox.Text = _userService.GetPhoneNumber(selectedUsername);
                addressBox.Text = _userService.GetAddress(selectedUsername);
                roleBox.Text = _userService.GetRole(user);
                if (message == "Permissions Retrieved")
                {
                    permissionCheckBox.SetItemChecked(0, HasPerm(perms, "Communications"));
                    permissionCheckBox.SetItemChecked(1, HasPerm(perms, "Network"));
                    permissionCheckBox.SetItemChecked(2, HasPerm(perms, "MagnaTran"));
                    permissionCheckBox.SetItemChecked(3, HasPerm(perms, "Details"));
                    permissionCheckBox.SetItemChecked(4, HasPerm(perms, "Manage"));
                }
                else
                {
                    MessageBox.Show("Error retrieving permissions: ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filling user details: {ex.Message}");
                return;

            }
            if (selectedUsername == "admin")
            {
                permissionCheckBox.Enabled = false;
                usernameBox.Enabled = false;
                roleBox.Enabled = false;
            }
            else
            {
                permissionCheckBox.Enabled = true;
                usernameBox.Enabled = true;
                roleBox.Enabled = true;
            }
        }
        // EVENTS //

        /// <summary>
        /// Helper function to get permissions for a user based on the key provided.
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
        /// User presses apply button to submit changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            bool selfEdit = false;
            if (_selectedUser == null)
            {
                MessageBox.Show("No user");
                return;
            }
            string selectedUsername = _userService.GetUserName(_selectedUser);
            if (selectedUsername == _username)
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
            if (string.IsNullOrEmpty(newusername) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Username and Role required");
                return;
            }
            Dictionary<string, bool> permissions = new Dictionary<string, bool>
            {
                { "Communications", permissionCheckBox.CheckedItems.Contains("Communications") },
                { "Network", permissionCheckBox.CheckedItems.Contains("Network") },
                { "MagnaTran", permissionCheckBox.CheckedItems.Contains("MagnaTran") },
                { "Details", permissionCheckBox.CheckedItems.Contains("Details") },
                { "Manage", permissionCheckBox.CheckedItems.Contains("Manage") }
            };
            string message;
            Dictionary<string, bool> perms = _userService.getPerms(_username, out message);
            if (
                (newusername ?? "").Trim() == (_userService.GetUserName(_selectedUser) ?? "").Trim() &&
                (firstName ?? "").Trim() == (_userService.GetFirstName(selectedUsername) ?? "").Trim() &&
                (lastName ?? "").Trim() == (_userService.GetLastName(selectedUsername) ?? "").Trim() &&
                (phoneNumber ?? "").Trim() == (_userService.GetPhoneNumber(selectedUsername) ?? "").Trim() &&
                (address ?? "").Trim() == (_userService.GetAddress(selectedUsername) ?? "").Trim() &&
                (role ?? "").Trim() == (_userService.GetRole(_selectedUser) ?? "").Trim() &&
                (HasPerm(perms, "Communications") == permissionCheckBox.CheckedItems.Contains("Communications")) &&
                (HasPerm(perms, "Network") == permissionCheckBox.CheckedItems.Contains("Network")) &&
                (HasPerm(perms, "MagnaTran") == permissionCheckBox.CheckedItems.Contains("MagnaTran")) &&
                (HasPerm(perms, "Details") == permissionCheckBox.CheckedItems.Contains("Details")) &&
                (HasPerm(perms, "Manage") == permissionCheckBox.CheckedItems.Contains("Manage"))
            )
            {
                MessageBox.Show("No changes were made.");
                return;
            }
            if (role != "Admin" && role != "User")
            {   
                MessageBox.Show("Role must be either 'Admin' or 'User'.");
                return;
            }
            if (_userService.ChangeDetailsNoPassword(_selectedUser, _userService.GetUserName(_selectedUser), newusername, firstName, lastName, phoneNumber, address, role))
            {
                MessageBox.Show("Details were successfully changed");
                if (selectedUsername != "admin")
                {
                    foreach (var perm in permissions)
                    {
                        _userService.setPerm(newusername, perm.Key, perm.Value, out message);
                    }
                }
                _selectedUser = _userService.GetUserByUsername(newusername);
                UpdateUserInGrid(_selectedUser);
            }
            else
            {
                MessageBox.Show("Details were not successfully changed");
            }
            if (selfEdit)
            {
                _user = _userService.GetUserByUsername(newusername);
                _username = _user.UserName;
            }
            SetVisibility(false);
        }

        /// <summary>
        /// Admin presses change password button to change the password of the selected user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("No user selected to change password");
                return;
            }
            AdminChangePassword changePassword = new AdminChangePassword(_userService, _selectedUser);
            changePassword.StartPosition = FormStartPosition.CenterScreen;
            changePassword.ShowDialog();
        }

        /// <summary>
        /// Admin presses create button to open the SignUp form for creating a new user account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createButton_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp(_userService);
            signup.StartPosition = FormStartPosition.CenterScreen;
            signup.UserUpdated += (s, args) =>
            {
                // Assuming your SignUp form sets a public CreatedUser field/property after successful registration
                var createdUser = signup.CreatedUser;

                if (createdUser != null)
                {
                    AddUserToGrid(createdUser);
                }
            };
            signup.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// UC Manage Load event handler to set the Dock style of the UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCManage_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Change selected user variable to whatever the user selects in the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count == 0) return;

            var row = usersDataGridView.SelectedRows[0];
            var user = row.DataBoundItem as User;
            if (user == null) return;

            _selectedUser = user;

            SetVisibility(false);
        }
        /// <summary>
        /// handle logic for when a user clicks on a button in the DataGridView, either Edit or Delete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            var user = usersDataGridView.Rows[e.RowIndex].DataBoundItem as User;

            if (user == null) return;
            _selectedUser = user;


            if (usersDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
            {
                // Edit logic
                SetVisibility(true);
                FillUser(user);
            }
            else if (usersDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // Delete logic
                if (user == _user || _userService.GetUserName(user) == "admin")
                {
                    MessageBox.Show("Cannot delete yourself or default Admin user.");
                    return;
                }
                deletePopup delete = new deletePopup(_userService.GetUserName(_selectedUser), _userService);
                delete.UserUpdated += (s, args) => RemoveUserFromGrid(user);
                delete.StartPosition = FormStartPosition.CenterScreen;
                delete.ShowDialog();
            }
        }
        }
    }