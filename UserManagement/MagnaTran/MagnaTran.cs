using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialCommunication;
using Utilities;

namespace InternshipApp
{
    public partial class MagnaTran : Form
    {
        private TCPServiceClient _tcpServiceClient;
        private bool _waitingForResponse = false;
        private CancellationTokenSource _responseTimeoutTokenSource;
        private Script _script;
        private bool _cancelLoop = false;
        private bool _ready;
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public MagnaTran()
        {
            InitializeComponent();
            _ready = false;
            disconnectButton.Enabled = false;
        }

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

        // event for receiving a message
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

        // event for error occurred
        private void OnErrorOccurred(string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnErrorOccurred), error);
                return;
            }

            MessageBox.Show($"Error: {error}");
        }

        // event for client connected
        private void OnClientConnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnClientConnected));
                return;
            }

            chatBox.AppendText("Client connected!\r\n");
        }

        // event for client disconnected
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

        // event for script run button clicked
        private async void Script_RunScriptClicked(object sender, EventArgs e)
        {
            await RunScript();
            _script.Invoke((Action)(() => _script.RunScriptButton.Enabled = true));
        }

        // asynchronous task for running the script
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

        // asynchronous task for waiting for a message
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

        // server start (for TCP server)
        private async void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(clientPortBox.Text))
                {
                    bool success = await _tcpServiceClient.Start(clientPortBox.Text);
                    if (success)
                    {
                        chatBox.AppendText("Server started on port " + clientPortBox.Text + "\r\n");
                    }
                    else
                    {
                        MessageBox.Show("Failed to start server. Please check the port number.");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to start server.");
                log.Error("Error starting server", ex);
            }
        }


        // connect to server (for TCP client)
        private async void connectButton_Click(object sender, EventArgs e)
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


        // send message via TCP
        private async void sendButton_Click(object sender, EventArgs e)
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


        // open script form
        private void scriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_script == null || _script.IsDisposed)
                {
                    _script = new Script();
                    _script.RunScriptClicked += Script_RunScriptClicked; // Subscribe to event
                }

                _script.Show();
                _script.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening script window.");
                log.Error("Error opening script form", ex);
            }
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            
        }


        // change status of magnatran
        private void setStatus(bool open)
        {
            if (open)
            {
                magnaTranStatusLabel.Text = "Ready";
            } else
            {
                magnaTranStatusLabel.Text = "Not Ready";
            }
        }

        private void sendBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound on Enter key press
                sendButton_Click(sender, e); // Call the send button click event
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            _tcpServiceClient.Disconnect(); // disconnect from TCP server
            chatBox.AppendText("Disconnected from magnatran \r\n");
            setStatus(false);
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            clientIPBox.Enabled = true;
            clientPortBox.Enabled = true;
        }
    }
}
