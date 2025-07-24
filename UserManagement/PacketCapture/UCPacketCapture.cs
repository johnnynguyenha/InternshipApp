using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;
using NetworkCapture;

namespace InternshipApp.PacketCapture
{
    /// <summary>
    /// User control for capturing network packets.
    /// </summary>
    public partial class UCPacketCapture : UserControl
    {
        PacketCaptureService _packetService;

        public UCPacketCapture()
        {
            InitializeComponent();
            _packetService = new PacketCaptureService();
            InitiailizeDevices();
            _packetService.PacketReceived += PacketService_PacketReceived;

            packetsDataGridView.Columns.Add("Time", "Time");
            packetsDataGridView.Columns.Add("Source", "Source");
            packetsDataGridView.Columns.Add("SourcePort", "Source Port");
            packetsDataGridView.Columns.Add("SourceHost", "Source Host");
            packetsDataGridView.Columns.Add("Destination", "Destination");
            packetsDataGridView.Columns.Add("DestinationPort", "Destination Port");
            packetsDataGridView.Columns.Add("DestinationHost", "Destination Host");
            packetsDataGridView.Columns.Add("Protocol", "Protocol");
            packetsDataGridView.Columns.Add("Length", "Length");

            packetsDataGridView.Columns["Time"].Width = 80;
            packetsDataGridView.Columns["Source"].Width = 100;
            packetsDataGridView.Columns["SourcePort"].Width = 70;
            packetsDataGridView.Columns["SourceHost"].Width = 100;
            packetsDataGridView.Columns["Destination"].Width = 100;
            packetsDataGridView.Columns["DestinationPort"].Width = 70;
            packetsDataGridView.Columns["DestinationHost"].Width = 100;
            packetsDataGridView.Columns["Protocol"].Width = 80;
            packetsDataGridView.Columns["Length"].Width = 60;
        }

        /// <summary>
        /// Event handler for when a packet is received. Adds the packet details to the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PacketService_PacketReceived(object sender, PacketEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => PacketService_PacketReceived(sender, e)));
                return;
            }
            packetsDataGridView.Rows.Add(e.Time.ToString("HH:mm:ss.fff"), e.Source, e.SourcePort, e.SourceHost, e.Destination, e.DestinationPort, e.DestinationHost, e.Protocol, e.Length);
        }

        /// <summary>
        /// Helper function to initialize the network devices in the choice box.
        /// </summary>
        private void InitiailizeDevices()
        {
            networkChoiceBox.DataSource = _packetService.getDevices();
            networkChoiceBox.DisplayMember = "Description";
            networkChoiceBox.ValueMember = "Name";
        }

        /// <summary>
        /// Helper function to fill the info box with details about the selected network device.
        /// </summary>
        private void fillInfoBox()
        {
            if (networkChoiceBox.SelectedItem != null)
            {
                var selectedDevice = (ICaptureDevice)networkChoiceBox.SelectedItem;
                networkTextBox.Text = $"Device: {selectedDevice.Name}\r\nDescription: {selectedDevice.Description}\r\n";
                networkTextBox.AppendText($"Device Type: {selectedDevice.GetType().Name}\r\n");
                networkTextBox.AppendText("Capture is started\r\n");

            }
            else
            {
                networkTextBox.Text = "No device selected.";
            }
        }

        /// <summary>
        /// Event handler for when the user clicks the start button. Starts capturing packets on the selected network device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click_1(object sender, EventArgs e)
        {
            if (networkChoiceBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a network device.");
                return;
            }
            var selectedDevice = (string)networkChoiceBox.SelectedValue;
            _packetService.startCapture(selectedDevice, 1000); // 1000 ms read timeout
            fillInfoBox();
        }
        /// <summary>
        /// Event handler for when the user clicks the stop button. Stops capturing packets on the selected network device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click_1(object sender, EventArgs e)
        {
            _packetService.stopCapture((ICaptureDevice)networkChoiceBox.SelectedItem);
            networkTextBox.Text = "Capture Stopped";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User control load event handler. Sets the docking style to fill.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCPacketCapture_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
