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

namespace InternshipApp
{
    public partial class PacketCapture : Form
    {
        PacketCaptureService _packetService;

        public PacketCapture()
        {
            InitializeComponent();
            _packetService = new PacketCaptureService();
            InitiailizeDevices();
            _packetService.PacketReceived += PacketService_PacketReceived;

            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Source", "Source");
            dataGridView1.Columns.Add("SourcePort", "Source Port");
            dataGridView1.Columns.Add("SourceHost", "Source Host");
            dataGridView1.Columns.Add("Destination", "Destination");
            dataGridView1.Columns.Add("DestinationPort", "Destination Port");
            dataGridView1.Columns.Add("DestinationHost", "Destination Host");
            dataGridView1.Columns.Add("Protocol", "Protocol");
            dataGridView1.Columns.Add("Length", "Length");

            dataGridView1.Columns["Time"].Width = 80;
            dataGridView1.Columns["Source"].Width = 100;
            dataGridView1.Columns["SourcePort"].Width = 70;
            dataGridView1.Columns["SourceHost"].Width = 100;
            dataGridView1.Columns["Destination"].Width = 100;
            dataGridView1.Columns["DestinationPort"].Width = 70;
            dataGridView1.Columns["DestinationHost"].Width = 100;
            dataGridView1.Columns["Protocol"].Width = 80;
            dataGridView1.Columns["Length"].Width = 60;
        }

        private void PacketService_PacketReceived(object sender, PacketEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => PacketService_PacketReceived(sender, e)));
                return;
            }
            dataGridView1.Rows.Add(e.Time.ToString("HH:mm:ss.fff"), e.Source, e.SourcePort, e.SourceHost, e.Destination, e.DestinationPort, e.DestinationHost, e.Protocol, e.Length);
        }

        private void InitiailizeDevices()
        {
                networkChoiceBox.DataSource = _packetService.getDevices();
                networkChoiceBox.DisplayMember = "Description";
                networkChoiceBox.ValueMember = "Name";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PacketCapture_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
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

        private void stopButton_Click(object sender, EventArgs e)
        {
            _packetService.stopCapture((ICaptureDevice)networkChoiceBox.SelectedItem);
            networkTextBox.Text = "Capture Stopped";
        }
        //private void fillDataGridView(string selectedDevice)
        //{
        //    dataGridView1.Rows.Clear();
        //    var packets = _packetService.fillData(selectedDevice);
        //    if (packets != null)
        //    {
        //        foreach (var packet in packets)
        //        {
        //            // Assuming packet has properties like Timestamp, Source, Destination, Protocol, Length
        //            dataGridView1.Rows.Add(packet.Timestamp, packet.Source, packet.Destination, packet.Protocol, packet.Length);
        //        }
        //    }
        //}

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
    }
}
