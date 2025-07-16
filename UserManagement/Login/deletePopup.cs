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

    // form for confirming deleting account (user is logged in or not).
    public partial class deletePopup : Form
    {
        string _username;
        Form _loggedin;
        UserService _userService;
        public EventHandler UserUpdated;
        User _user;

        // constructor for if user is logged in (delete account from logged in menu).
        public deletePopup(User user, Form loggedin, UserService userService)
        {
            InitializeComponent();
            _user = user;
            _username = _user.UserName;
            _loggedin = loggedin;
            _userService = userService;
        }

        // overloaded constructor for if user is not logged in (delete account from different menu).
        public deletePopup(string username, UserService userService)
        {
            InitializeComponent();
            _username = username;
            _loggedin = this;
            _userService = userService;
        }

        // FUNCTIONS //

        // EVENTS //

        // closes popup if user presses no
        private void noButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        // user presses yes to delete account. if account is deleted, log out. if not, display error message.
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
