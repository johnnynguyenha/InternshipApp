using SerialCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static InternshipApp.CommSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace InternshipApp.Communication
{
    public partial class UCCommunications : UserControl
    {
        private string _comPortName;
        private int _comBaudRate;
        private int _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private bool _dtrEnabled;
        private bool _rtsEnabled;
        private string _tcpIpAddress;
        private int _tcpPort;
        private string _tcpServerIpAddress;
        private int _tcpServerPort;
        private bool _usingCom;
        TCPServiceClient _tcpServiceClient;
        private bool _waitingForResponse = false;
        CancellationTokenSource _responseTimeoutTokenSource;
        private static readonly log4net.ILog log = LogHelper.GetLogger();


        private SerialPort serialPort1 = new SerialPort();
        string dataOUT;
        string sendWith;
        PortService _portService;
        private StringBuilder buffer;
        public UCCommunications()
        {
            InitializeComponent();
            initializeTCPService(); // initialize TCP service
            _portService = new PortService(serialPort1);
            buffer = new StringBuilder();
            disconnectButton.Enabled = false;

        }
        private void OpenSettingsForm()
        {
            var settingsForm = new CommSettings(_portService, _tcpServiceClient);
            settingsForm.SettingsApplied += SettingsForm_SettingsApplied;
            settingsForm.FormClosed += (s, e) => // when settings form is closed, check if it was closed with OK or Cancel
            {
                if (settingsForm.DialogResult == DialogResult.Cancel)
                {
                    _usingCom = false; // reset usingCom to false
                    connectButton.Visible = false;
                    startButton.Visible = false;
                }
            };
            settingsForm.StartPosition = FormStartPosition.CenterScreen;
            settingsForm.ShowDialog();
        }

        // get settings from settings form and apply them
        private void SettingsForm_SettingsApplied(object sender, SettingsAppliedEventArgs e)
        {
            if (_portService.isPortOpen())
            {
                _portService.closePort();
            }
            else if (_tcpServiceClient.IsConnected)
            {
                _tcpServiceClient.Disconnect();
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
            }
            try
            {
                switch (e.Mode)
                {
                    case ConnectionMode.COM:
                        var com = (CommPageSettings)e.Settings;
                        _comPortName = com.PortName;
                        _comBaudRate = com.BaudRate;
                        _dataBits = com.DataBits;
                        _parity = com.ParityBits;
                        _stopBits = com.StopBits;
                        _dtrEnabled = com.dtrEnabled;
                        _rtsEnabled = com.rtsEnabled;
                        _usingCom = true;
                        connectButton.Visible = true;
                        startButton.Visible = false;

                        break;

                    case ConnectionMode.TCPClient:
                        var tcp = (TcpClientSettings)e.Settings;
                        _tcpIpAddress = tcp.IpAddress;
                        _tcpPort = tcp.Port;
                        _usingCom = false;
                        connectButton.Visible = true;
                        startButton.Visible = false;

                        break;

                    case ConnectionMode.TCPServer:
                        var server = (TcpServerSettings)e.Settings;
                        _tcpServerIpAddress = server.IpAddress;
                        _tcpServerPort = server.Port;
                        _usingCom = false;
                        connectButton.Visible = false;
                        startButton.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while applying settings. Check fields");
                log.Error("Error applying settings", ex);
                return;
            }
        }
        private void initializeTCPService()
        {
            _tcpServiceClient = new TCPServiceClient();
            _tcpServiceClient.ClientConnected += OnClientConnected;
            _tcpServiceClient.ClientDisconnected += OnClientDisconnected;
            _tcpServiceClient.MessageReceived += OnMessageReceived;
            _tcpServiceClient.ErrorOccurred += OnErrorOccurred;
        }

        // message receive from TCP
        private void OnMessageReceived(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnMessageReceived), message);
                return;
            }
            chatBox.AppendText($"Received: {message}\r\n");
            if (_waitingForResponse)
            {
                _waitingForResponse = false;
                _responseTimeoutTokenSource?.Cancel();
            }
        }
        // error on tcp
        private void OnErrorOccurred(string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnErrorOccurred), error);
                return;
            }

            MessageBox.Show($"Error: {error}");
        }
        // client connect tcp
        private void OnClientConnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnClientConnected));
                return;
            }

            chatBox.AppendText("Client connected!\r\n");
        }
        // client disconnect tcp
        private void OnClientDisconnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnClientDisconnected));
                return;
            }
            chatBox.AppendText("Client disconnected!\r\n");
        }

        // wait for response tcp
        private async Task WaitMessageAsync()
        {
            _waitingForResponse = true;
            _responseTimeoutTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(3000, _responseTimeoutTokenSource.Token);

                // If we get here, it's a timeout
                if (_waitingForResponse)
                {
                    _waitingForResponse = false;
                    MessageBox.Show("COM Port device is not responding. Check the connection.");
                }
            }
            catch (OperationCanceledException)
            {
                // response was received
                return;
            }
            finally
            {
                _responseTimeoutTokenSource?.Dispose();
            }
        }

        // tcp send message function
        private async void TcpSendMessage()
        {
            if (string.IsNullOrEmpty(sendBox.Text))
            {
                MessageBox.Show("Please enter a message to send.");
                return;
            }
            string message = sendBox.Text;
            try
            {
                bool success = await _tcpServiceClient.SendMessageAsync(message);
                if (success)
                {
                    chatBox.AppendText($"Sent: {message}\r\n");
                    sendBox.Clear();
                    await WaitMessageAsync();
                }
                else
                {
                    MessageBox.Show("Failed to send message. Please check the connection.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to send message. Check connection.");
                log.Error("Error sending message", ex);
            }
        }

 
        // receive data using com
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string incomingData = _portService.readData(); // read available bytes
                buffer.Append(incomingData);

                this.Invoke((MethodInvoker)delegate { // updates ui from background thread
                    chatBox.AppendText(incomingData + "\r\n"); // show raw incoming data
                });

                // Check for complete message(s)
                while (buffer.ToString().Contains("\n"))
                {
                    int index = buffer.ToString().IndexOf("\n");
                    string fullLine = buffer.ToString().Substring(0, index).Trim(); // remove \n

                    buffer.Remove(0, index + 1); // remove processed line

                    if (fullLine == "hi")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            _portService.writeLineData("Keyword: 'Hi' detected. Hello from the Computer");
                        });
                    }
                    else
                    {
                        Task.Delay(2000);
                        this.Invoke((MethodInvoker)delegate
                        {
                            _portService.writeLineData("_RDY");
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to receive Data. Check connections and fields.");
                log.Error("Error receiving data from COM port", ex);
            }
        }


        // send message using com
        private void ComSendMessage()
        {
            if (_portService.isPortOpen())
            {
                try
                {
                    dataOUT = sendBox.Text; // get data from textbox
                    _portService.writeLineData(dataOUT); // send data using WriteLine method
                    chatBox.AppendText(dataOUT + "\r\n");
                    MessageBox.Show("Data sent successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data. Check connections/fields.");
                    log.Error("Error sending data to COM port", ex);
                }
            }
            else
            {
                MessageBox.Show("Port is not open. Please open the port first.");
            }
        }

        // start tcp server
        private async void startButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_tcpServerPort >= 0)
                {
                    bool success = await _tcpServiceClient.Start(_tcpServerPort);
                    if (success)
                    {
                        chatBox.AppendText("Server started on port " + _tcpServerPort + "\r\n");
                        disconnectButton.Enabled = true;
                        disconnectButton.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to start server. Please check the port number.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to start TCP server. Check connection and fields.");
                log.Error("Error starting TCP server", ex);
                disconnectButton.Enabled = false;
                disconnectButton.Visible = false;
            }
        }

        private async void connectButton_Click_1(object sender, EventArgs e)
        {
            {
                if (_usingCom)
                {
                    try
                    {
                        _portService.setPortName(_comPortName); // set port name
                        _portService.setBaudRate(_comBaudRate); // set baud rate
                        _portService.setDataBits(_dataBits); // set data bits
                        _portService.setStopBits(_stopBits); // set stop bits
                        _portService.setParity(_parity); // set parity
                        _portService.setDtr(_dtrEnabled);
                        _portService.setRts(_rtsEnabled);

                        _portService.openPort();
                        chatBox.AppendText("Connected to " + _comPortName + "\r\n");
                        connectButton.Enabled = false;
                        disconnectButton.Enabled = true;
                        serialPort1.DataReceived += SerialPort1_DataReceived;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error setting connecting to COM Port. Check connections and fields.");
                        log.Error("Error occurred when trying to connect with COM.", ex);
                        connectButton.Enabled = true;
                        disconnectButton.Enabled = false;
                        return;
                    }
                }
                else
                {
                    initializeTCPService(); // reiinitialize TCP service
                    try
                    {
                        connectButton.Enabled = false;
                        disconnectButton.Enabled = false;
                        bool success = await _tcpServiceClient.ConnectServerAsync(_tcpIpAddress, _tcpPort);
                        if (success)
                        {
                            chatBox.AppendText("Connected to server at " + _tcpIpAddress + ":" + _tcpPort + "\r\n");
                            disconnectButton.Enabled = true;
                            connectButton.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Failed to connect to server.");
                            connectButton.Enabled = true;
                            disconnectButton.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred when trying to connect to TCP server. Check connection and fields.");
                        log.Error("Error connecting to TCP server", ex);
                        connectButton.Enabled = true;
                        disconnectButton.Enabled = false;
                        return;
                    }
                }
            }
        }

        private void disconnectButton_Click_1(object sender, EventArgs e)
        {
            {
                if (_usingCom)
                {
                    if (_portService.isPortOpen())
                    {
                        serialPort1.DataReceived -= SerialPort1_DataReceived;
                        _portService.closePort(); // close the port
                        chatBox.AppendText("Disconnected from " + _comPortName + "\r\n");
                        connectButton.Enabled = true;
                        disconnectButton.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Port is not open."); // show message if port is not open
                        connectButton.Enabled = false;
                        disconnectButton.Enabled = true;
                    }
                }
                else
                {
                    _tcpServiceClient.Disconnect(); // disconnect from TCP server
                    chatBox.AppendText("Disconnected from " + _tcpIpAddress + " on port " + _tcpPort + "\r\n");
                    connectButton.Enabled = true;
                    disconnectButton.Enabled = false;
                }
            }
        }

        private void settingsButton_Click_1(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
            {
                if (_usingCom)
                {
                    ComSendMessage();
                }
                else
                {
                    TcpSendMessage();
                }
            }
        }

        private void sendBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (_usingCom)
                { // check if enter key is pressed   
                    ComSendMessage();
                }
                else
                {
                    TcpSendMessage();
                }
            }
        }

        private void UCCommunications_Load(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }
    }
}
