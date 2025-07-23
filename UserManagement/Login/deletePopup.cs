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
    /// Form to delete and confirm deletion of user account. 
    /// </summary>
    public partial class deletePopup : Form
    {
        string _username;
        Form _loggedin;
        UserService _userService;
        public EventHandler UserUpdated;
        User _user;

        /// <summary>
        /// Constructor for if user is logged in.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="loggedin"></param>
        /// <param name="userService"></param>
        public deletePopup(User user, Form loggedin, UserService userService)
        {
            InitializeComponent();
            _user = user;
            _username = _user.UserName;
            _loggedin = loggedin;
            _userService = userService;
        }

        /// <summary>
        /// Constructor for if user is not logged in.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userService"></param>
        public deletePopup(string username, UserService userService)
        {
            InitializeComponent();
            _username = username;
            _loggedin = this;
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        /// <summary>
        /// If user presses no, close popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        /// <summary>
        /// User presses yes to delete account. If successful, display message and close popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yesButton_Click(object sender, EventArgs e)
        {
            if (_userService.DeleteAccount(_username))
            {
                MessageBox.Show("Account Deleted");
                _loggedin.Dispose();
                UserUpdated?.Invoke(this, EventArgs.Empty); // notify user list has been updated.
                this.Close();
            } else
            {
                MessageBox.Show("Account Couldn't Be Deleted");
            }
        }
    }
}
