    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    using SerialCommunication;
    using Utilities;
    using System.Linq.Expressions;

namespace InternshipApp
    {
        public partial class CommSettings : Form
        {
            public enum ConnectionMode { COM, TCPClient, TCPServer }
        

            public class SettingsAppliedEventArgs : EventArgs
            {
                public ConnectionMode Mode { get; }
                public object Settings { get; }

                public SettingsAppliedEventArgs(ConnectionMode mode, object settings)
                {
                    Mode = mode;
                    Settings = settings;
                }
            }

            public event EventHandler<SettingsAppliedEventArgs> SettingsApplied;
            private PortService _portService;
            private TCPServiceClient _tcpServiceClient;
            private static readonly log4net.ILog log = LogHelper.GetLogger();

        public CommSettings(PortService portService, TCPServiceClient tcp)
            {
                InitializeComponent();
                _portService = portService;
                _tcpServiceClient = tcp;
                var ports = _portService.GetAvailablePorts(); // gets ports
                comPortCBox.Items.AddRange(ports); // add ports to combobox
                connectionTab.TabPages.RemoveAt(1); // remove TCP Server tab if not needed


        }

            private void CommSettings_Load(object sender, EventArgs e)
            {
                serverIPBox.Text = _tcpServiceClient.returnIP();

            }

            private void connectButton_Click(object sender, EventArgs e)
            {

            }

            private void startButton_Click(object sender, EventArgs e)
            {

            }

            private void applyButton_Click(object sender, EventArgs e)
            {
                var selectedTab = connectionTab.SelectedTab.Text;

                if (selectedTab == "COM")
                {
                    if (string.IsNullOrEmpty(comPortCBox.Text))
                    {
                        MessageBox.Show("Please select a COM port.");
                        return;
                    }
                try // try to apply COM settings
                {
                    var comSettings = new CommPageSettings
                    {
                        PortName = comPortCBox.Text,
                        BaudRate = int.Parse(baudRateCBox.Text),    
                        DataBits = int.Parse(dataBitsCBox.Text),
                        StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsCBox.Text),
                        ParityBits = (Parity)Enum.Parse(typeof(Parity), parityBitsCBox.Text),
                        dtrEnabled = dtrCheckBox.Checked,
                        rtsEnabled = rtsCheckBox.Checked
                    };

                    SettingsApplied?.Invoke(this, new SettingsAppliedEventArgs(ConnectionMode.COM, comSettings));
                } catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while applying COM settings. Check settings.");
                    log.Error("Error applying COM settings", ex);
                }
                } 
                else if (selectedTab == "TCP/IP Client")
                {
                    if (string.IsNullOrEmpty(clientIPBox.Text) || string.IsNullOrEmpty(clientPortBox.Text) || !int.TryParse(clientPortBox.Text, out int port) || port <= 0)
                    {
                        MessageBox.Show("Please enter a valid IP address and port for the server.");
                        return;
                    }
                    try
                { // try to apply TCP Client settings
                    var tcpSettings = new TcpClientSettings
                        {
                            IpAddress = clientIPBox.Text,
                            Port = int.Parse(clientPortBox.Text)
                        };
                        SettingsApplied?.Invoke(this, new SettingsAppliedEventArgs(ConnectionMode.TCPClient, tcpSettings));
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while applying TCP Client settings. Check settings.");
                        log.Error("Error applying TCP Client settings", ex);
                }
                }
                else if (selectedTab == "TCP/IP Server")
                {
                    if (string.IsNullOrEmpty(serverIPBox.Text) || string.IsNullOrEmpty(portBox.Text) || !int.TryParse(portBox.Text, out int port) || port <= 0)
                    {
                        MessageBox.Show("Please enter a valid IP address and port for the server.");
                        return;
                    }
                try // try to apply tcp server settings
                {
                    var serverSettings = new TcpServerSettings
                    {
                        IpAddress = serverIPBox.Text,
                        Port = int.Parse(portBox.Text)
                    };
                    SettingsApplied?.Invoke(this, new SettingsAppliedEventArgs(ConnectionMode.TCPServer, serverSettings));
                } catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while applying TCP Server settings. Check settings.");
                    log.Error("Error applying TCP Server settings", ex);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            }
        }
}