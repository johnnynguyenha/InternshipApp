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
using InternshipApp.Communication;
using InternshipApp.PacketCapture;
using InternshipApp.MagnaTran;
using InternshipApp.Login;

using Model;


namespace InternshipApp
{

    /// <summary>
    /// Main Menu form for logged in users. Displays user details and allows access to different services based on permissions.
    /// </summary>
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
            detailsLinkLabel.Text = _username;
            setButtonVisibility();

        }
        // FUNCTIONS //

        /// <summary>
        ///  function to check if admin is a user and hide button based on role.
        /// </summary>
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

        /// <summary>
        /// helper function to check if user has a permission
        /// </summary>
        /// <param name="perms"> Requires a dictionary that contains the permissions. </param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static bool HasPerm(Dictionary<string, bool> perms, string key, bool defaultValue = false)
        {
            if (perms == null) return defaultValue;
            return perms.TryGetValue(key, out bool allowed) ? allowed : defaultValue;
        }
        /// <summary>
        /// Function to set button visibility based on user permissions.
        /// </summary>
        private void setButtonVisibility()
        {
            string message;
            Dictionary<string, bool> perms = _userService.getPerms(_username, out message);

            if (message == "Permissions Retrieved")
            {
                commButton.Visible = HasPerm(perms, "Communications");
                packetButton.Visible = HasPerm(perms, "Network");
                magnaButton.Visible = HasPerm(perms, "MagnaTran");
                detailsLinkLabel.Visible = HasPerm(perms, "Details");
                manageButton.Visible = HasPerm(perms, "Manage");
            }
            else
            {
                commButton.Visible = false;
                packetButton.Visible = false;
                magnaButton.Visible = false;
                detailsLinkLabel.Visible = false;
                manageButton.Visible = false;
            }
        }


        // EVENTS //

        /// <summary>
        /// user presses delete button to delete account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deletePopup deletePop = new deletePopup(_user, this, _userService);
            deletePop.StartPosition = FormStartPosition.CenterScreen;
            deletePop.Show();
        }
        /// <summary>
        /// user presses manage button to maanage open manage form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageButton_Click(object sender, EventArgs e)
        {
            resetButtonsColor();
            manageButton.BackColor = Color.LightBlue;
            InternshipApp.Login.UCManage manage = new InternshipApp.Login.UCManage(_userService, _user);
            LoadUCInPanel(manage);
        }
        /// <summary>
        /// user presses edit details button to open details screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editDetailsButton_Click_1(object sender, EventArgs e)
        {
            Details editDetails = new Details(_userService, _user, this, _login);
            editDetails.StartPosition = FormStartPosition.CenterScreen;
            editDetails.Show();
        }

        /// <summary>
        ///  user presses log out to close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _login.Show();
        }

        /// <summary>
        ///  user closes this form to open the login screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// user presses comm button to open the communications form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commButton_Click(object sender, EventArgs e)
        {
            resetButtonsColor();
            commButton.BackColor = Color.LightBlue;
            UCCommunications comm = new UCCommunications();
            LoadUCInPanel(comm);

        }
        /// <summary>
        /// user presses exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            _login.Dispose();
            this.Close();
        }
        /// <summary>
        /// user presses details link label to open details form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Details editDetails = new Details(_userService, _user, this, _login);
            editDetails.StartPosition = FormStartPosition.CenterScreen;
            editDetails.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// function to load a form into a panel
        /// </summary>
        /// <param name="formToLoad"></param>
        private void LoadFormInPanel(Form formToLoad)
        {
            mainPanel.Controls.Clear(); // Remove existing controls

            formToLoad.TopLevel = false; // Make it embeddable
            formToLoad.FormBorderStyle = FormBorderStyle.None; // No title bar
            formToLoad.Dock = DockStyle.Fill; // Fills the panel

            mainPanel.Controls.Add(formToLoad);
            mainPanel.Tag = formToLoad;

            formToLoad.Show();
        }
        /// <summary>
        /// function to load a user control into a panel.
        /// </summary>
        /// <param name="userControlToLoad"></param>

        private void LoadUCInPanel(UserControl userControlToLoad)
        {
            mainPanel.Controls.Clear(); // Remove existing controls
            userControlToLoad.Dock = DockStyle.Fill; // Fills the panel
            mainPanel.Controls.Add(userControlToLoad);
            mainPanel.Tag = userControlToLoad;
            userControlToLoad.Show();
        }

        /// <summary>
        /// user presses packet button to open the packet capture service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void packetButton_Click(object sender, EventArgs e)
        {
            resetButtonsColor();
            packetButton.BackColor = Color.LightBlue;
            InternshipApp.PacketCapture.UCPacketCapture packet = new InternshipApp.PacketCapture.UCPacketCapture();
            LoadUCInPanel(packet);
        }
        /// <summary>
        /// user presses the magnatran button to open the magnatran service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magnaButton_Click(object sender, EventArgs e)
        {
            resetButtonsColor();
            magnaButton.BackColor = Color.LightBlue;
            InternshipApp.MagnaTran.UCMagnaTran magna = new InternshipApp.MagnaTran.UCMagnaTran();
            LoadUCInPanel(magna);
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

        /// <summary>
        /// helper function to reset the button colors to default.
        /// </summary>
        private void resetButtonsColor()
        {
            manageButton.BackColor = SystemColors.Control;
            packetButton.BackColor = SystemColors.Control;
            magnaButton.BackColor = SystemColors.Control;
            commButton.BackColor = SystemColors.Control;
            exitButton.BackColor = SystemColors.Control;
        }

    }
}
