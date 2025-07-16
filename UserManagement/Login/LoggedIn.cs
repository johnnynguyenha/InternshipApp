using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;

namespace InternshipApp
{

    // Form for when user is logged in. Displays different if user is an admin or a regular user.
    public partial class loggedInForm : Form
    {
        UserService _userService;
        User _user;
        string _username;
        loginForm _login;
        public loggedInForm(User user, UserService userService, loginForm login)
        {
            InitializeComponent();
            _userService = userService;
            _user = user;
            _username = _user.UserName;
            _login = login;
            linkLabel1.Text = _username;
            checkRole();
        }
        // FUNCTIONS //

        // function to check if the user is an admin. if the user is an admin, show/hide manage button.
        private void checkRole()
        {
            if (_userService.GetRole(_user) == "Admin")
            {
                manageButton.Show();
            }
            else
            {
                manageButton.Hide();
            }
        }

        // EVENTS //

        // User presses delete button to delete their account. Displays delete account form.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deletePopup deletePop = new deletePopup(_user, this, _userService);
            deletePop.StartPosition = FormStartPosition.CenterScreen;
            deletePop.Show();
        }
        // user presses manage button. if user is an admin, opens manage form to manage users.
        private void manageButton_Click(object sender, EventArgs e)
        {
            if (_userService.GetRole(_user) != "Admin")
            {
                MessageBox.Show("You do not have permission to manage users.");
                return;
            }
            Manage manage = new Manage(_userService, _user);
            LoadFormInPanel(manage);
        }
        // user presses edit details button. opens details form.
        private void editDetailsButton_Click_1(object sender, EventArgs e)
        {
            Details editDetails = new Details(_userService, _user, this, _login);
            editDetails.StartPosition = FormStartPosition.CenterScreen;
            editDetails.Show();
        }

        // user presses log out button. closes the form and returns to login screen
        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _login.Show();
        }

        // user closes the form instead of logging out, disposes the entire app.
        private void loggedInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _login.Show();
        }

        private void commLabel_Click(object sender, EventArgs e)
        {

        }

        private void commButton_MouseHover(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Communication Service that allows for users \r\nto send messages using TCP/IP or RS232 protocol. \r\nUsers can host or connect to a server \r\nand send/receive messages.";
        }

        private void packetButton_MouseHover(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Packet Capture service that allows for users \r\nto view packets on the network.";
        }

        private void magnaButton_MouseHover(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Communication Service that allows for users \r\nto send or script commands to the MagnaTran Robot Arm.";
        }

        private void packetButton_MouseEnter(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Packet Capture service that allows for users \r\nto view packets on the network.";

        }

        private void commButton_MouseEnter(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Communication Service that allows for users \r\nto send messages using TCP/IP or RS232 protocol. \r\nUsers can host or connect to a server \r\nand send/receive messages.";

        }

        private void magnaButton_MouseEnter(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Communication Service that allows for users \r\nto send or script commands to the MagnaTran Robot Arm.";

        }

        private void commButton_Click(object sender, EventArgs e)
        {
            resetButtonsColor();
            commButton.BackColor = Color.LightBlue;
            Communications commForm = new Communications();
            LoadFormInPanel(commForm);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            _login.Dispose();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Details editDetails = new Details(_userService, _user, this, _login);
            editDetails.StartPosition = FormStartPosition.CenterScreen;
            editDetails.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void LoadFormInPanel(Form formToLoad)
        {
            panel1.Controls.Clear(); // Remove existing controls

            formToLoad.TopLevel = false; // Make it embeddable
            formToLoad.FormBorderStyle = FormBorderStyle.None; // No title bar
            formToLoad.Dock = DockStyle.Fill; // Fills the panel

            panel1.Controls.Add(formToLoad);
            panel1.Tag = formToLoad;

            formToLoad.Show();
        }

        private void packetButton_Click(object sender, EventArgs e)
        {
            PacketCapture packetForm = new PacketCapture();
            LoadFormInPanel(packetForm);
            resetButtonsColor();
            packetButton.BackColor = Color.LightBlue;
        }

        private void magnaButton_Click(object sender, EventArgs e)
        {
            MagnaTran magnaForm = new MagnaTran();
            LoadFormInPanel(magnaForm);
            resetButtonsColor();
            magnaButton.BackColor = Color.LightBlue;
        }

        private void manageButton_MouseEnter(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Manage other users, supports username change \r\nPassword change, details change, and \r\ndeleting account.";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            commLabel.Visible = true;
            commLabel.Text = "Logout and Exit the Program";
        }

        private void resetButtonsColor()
        {
            manageButton.BackColor = SystemColors.Control;
            packetButton.BackColor = SystemColors.Control;
            magnaButton.BackColor = SystemColors.Control;
            commButton.BackColor = SystemColors.Control;
            button1.BackColor = SystemColors.Control;
        }

    }
}
