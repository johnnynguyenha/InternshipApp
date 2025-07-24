using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Threading;
using SerialCommunication;
using Utilities;

namespace InternshipApp.MagnaTran
{
    /// <summary>
    /// User ontrol for managing the MagnaTran communication interface. Users communicate using TCP /IP to send and receive messages from the MagnaTran device.
    /// </summary>
    public partial class UCMagnaTran : UserControl
    {
        private TCPServiceClient _tcpServiceClient;
        private bool _waitingForResponse = false;
        private CancellationTokenSource _responseTimeoutTokenSource;
        private Script _script;
        private bool _cancelLoop = false;
        private bool _ready;
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public UCMagnaTran()
        {
            InitializeComponent();
            _ready = false;
            disconnectButton.Enabled = false;
        }
        /// <summary>
        /// Helper function to initialize the TCP service client and set up event handlers for communication.
        /// </summary>
        private void initializeTCPService()
        {
            try
            {
                _tcpServiceClient = new TCPServiceClient();
                _tcpServiceClient.ClientConnected += OnClientConnected;
                _tcpServiceClient.ClientDisconnected += OnClientDisconnected;
                _tcpServiceClient.MessageReceived += OnMessageReceived;
                _tcpServiceClient.ErrorOccurred += OnErrorOccurred;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when initializing TCP service.");
                log.Error("Error initializing TCP service", ex);
            }
        }

        /// <summary>
        /// Event action for receiving messages from the TCP service client.
        /// </summary>
        /// <param name="message"></param>
        private void OnMessageReceived(string message)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(OnMessageReceived), message);
                    return;
                }

                chatBox.AppendText($"Received: {message}\r\n");

                bool hasError = message.Contains("_ERR");
                bool hasReady = message.Contains("_RDY");

                if (_waitingForResponse && message == "_RDY")
                {
                    _waitingForResponse = false;
                    _responseTimeoutTokenSource?.Cancel();
                    setStatus(true);
                }
                else if (_waitingForResponse && hasError && hasReady)
                {
                    _waitingForResponse = false;
                    _responseTimeoutTokenSource?.Cancel();
                    _cancelLoop = true;
                    MessageBox.Show("Error response received from server with _RDY.");
                    setStatus(true);
                }
                else if (_waitingForResponse && hasError)
                {
                    _waitingForResponse = false;
                    _responseTimeoutTokenSource?.Cancel();
                    _cancelLoop = true;
                    MessageBox.Show("Error response received from server.");
                    setStatus(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to receive message.");
                log.Error("Error in OnMessageReceived", ex);
            }
        }

        /// <summary>
        /// Event action for handling errors that occur during communication with the TCP service client.
        /// </summary>
        /// <param name="error"></param>
        private void OnErrorOccurred(string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnErrorOccurred), error);
                return;
            }

            MessageBox.Show($"Error: {error}");
        }

        /// <summary>
        /// Event action for client connected. Updates the chat box to indicate a client has connected.
        /// </summary>
        private void OnClientConnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnClientConnected));
                return;
            }

            chatBox.AppendText("Client connected!\r\n");
        }

        /// <summary>
        /// Event action for client disconnected. Updates the chat box and UI elements to indicate a client has disconnected.
        /// </summary>
        private void OnClientDisconnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnClientDisconnected));
                return;
            }
            chatBox.AppendText("Client disconnected!\r\n");
            magnaTranStatusLabel.Text = "OFF";
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            clientIPBox.Enabled = true;
            clientPortBox.Enabled = true;

        }

        /// <summary>
        /// Event handler for when the script's RunScript button is clicked. It runs the script and enables the button again after completion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Script_RunScriptClicked(object sender, EventArgs e)
        {
            await RunScript();
            _script.Invoke((Action)(() => _script.RunScriptButton.Enabled = true));
        }

        /// <summary>
        /// Function that runs the script by iterating through each line of the script text and sending it to the MagnaTran device.
        /// </summary>
        /// <returns></returns>
        private async Task RunScript()
        {
            try
            {
                // _tcpServiceClient.SendMessageAsync("HLLO");
                // await WaitMessageAsync();
                _cancelLoop = false;
                for (int i = 0; i < _script.LoopText; i++)
                {
                    foreach (var line in _script.ScriptText)
                    {
                        if (_cancelLoop)
                        {
                            chatBox.AppendText("Script execution cancelled due to error.\r\n");
                            return;
                        }
                        string msg = line.ToString();
                        if (!string.IsNullOrEmpty(msg))
                        {
                            bool success = await _tcpServiceClient.SendMessageAsync(line.ToString());
                            if (success)
                            {
                                chatBox.AppendText($"Sent: {line.ToString()}\r\n");
                                sendBox.Clear();
                                await WaitMessageAsync();
                            }
                            else
                            {
                                MessageBox.Show("Failed to send message. Please check the connection.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to run script.");
                log.Error("Error running script", ex);
                _cancelLoop = true;
            }
        }

        /// <summary>
        /// Asynchronously waits for a response from the MagnaTran device. If no response is received within 3 seconds, it shows an error message and sets the status to not ready.
        /// </summary>
        /// <returns></returns>
        private async Task WaitMessageAsync()
        {
            _responseTimeoutTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            _waitingForResponse = true;

            try
            {
                await Task.Delay(Timeout.Infinite, _responseTimeoutTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                if (!_waitingForResponse)
                {
                    Console.WriteLine("Response received");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while waiting for response. Check connections.");
                log.Error("Error while waiting for response", ex);
                _cancelLoop = true;
                return;
            }

            // if this is reached, there was a timeout
            MessageBox.Show("MagnaTran is not responsive. Check connections.");
            _cancelLoop = true;
            setStatus(false);
        }

        /// <summary>
        /// Changes the status label to indicate whether the MagnaTran device is ready or not.
        /// </summary>
        /// <param name="open"></param>
        private void setStatus(bool open)
        {
            if (open)
            {
                magnaTranStatusLabel.Text = "Ready";
            }
            else
            {
                magnaTranStatusLabel.Text = "Not Ready";
            }
        }

        private void sendBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Connect button click event handler. Initializes the TCP service client, attempts to connect to the MagnaTran device using the provided IP address and port number, and sends a "HLLO" message to indicate readiness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void connectButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientIPBox.Text) || string.IsNullOrEmpty(clientPortBox.Text))
            {
                MessageBox.Show("Please enter both IP address and port number.");
                return;
            }
            initializeTCPService();
            chatBox.AppendText("Attempting to connect to MagnaTran... \r\n");
            connectButton.Enabled = false;
            disconnectButton.Enabled = false;
            if (int.TryParse(clientPortBox.Text, out int port))
            {
                bool success = await _tcpServiceClient.ConnectServerAsync(clientIPBox.Text, clientPortBox.Text); // change to ConnectServer for nonasync
                if (success)
                {
                    chatBox.AppendText("Connected to server at " + clientIPBox.Text + ":" + clientPortBox.Text + "\r\n");
                    try
                    {
                        await _tcpServiceClient.SendMessageAsync("HLLO");
                        setStatus(true);
                        connectButton.Enabled = false;
                        disconnectButton.Enabled = true;
                        clientIPBox.Enabled = false;
                        clientPortBox.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred when trying to connect to TCP Client.");
                        log.Error("Error sending HLLO message on Connect", ex);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to connect to server.");
                    connectButton.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Disconnect button click event handler. Disconnects from the TCP server, updates the chat box, and resets the UI elements to their initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click_1(object sender, EventArgs e)
        {
            _tcpServiceClient.Disconnect(); // disconnect from TCP server
            chatBox.AppendText("Disconnected from magnatran \r\n");
            setStatus(false);
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            clientIPBox.Enabled = true;
            clientPortBox.Enabled = true;
        }

        /// <summary>
        /// Script button click event handler. Opens the script form, allowing users to run scripts against the MagnaTran device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scriptButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_script == null || _script.IsDisposed)
                {
                    _script = new Script();
                    _script.RunScriptClicked += Script_RunScriptClicked; // Subscribe to event
                }
                _script.StartPosition = FormStartPosition.CenterScreen;
                _script.ShowDialog();
                _script.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening script window.");
                log.Error("Error opening script form", ex);
            }
        }

        /// <summary>
        /// Send button click event handler. Sends the message entered in the send box to the MagnaTran device and waits for a response. If the message is empty, it prompts the user to enter a message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void sendButton_Click_1(object sender, EventArgs e)
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
                MessageBox.Show($"Error sending message.");
                log.Error("Error sending message through send", ex);
            }
        }

        /// <summary>
        /// Send box key press event handler. If the Enter key is pressed, it prevents the beep sound and calls the send button click event to send the message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound on Enter key press
                sendButton_Click_1(sender, e); // Call the send button click event
            }
        }
        /// <summary>
        /// Usercontrol load event handler. Sets the docking style to fill the parent container.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCMagnaTran_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

        }
    }
}

