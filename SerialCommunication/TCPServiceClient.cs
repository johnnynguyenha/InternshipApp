using System;
using System.CodeDom;
using System.ComponentModel.Design;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace SerialCommunication
{
    /// <summary>
    /// TCP Service class for handling TCP connections, sending and receiving messages.
    /// </summary>
    public class TCPServiceClient
    {
        private TcpListener _listener;
        private TcpClient _client;
        public StreamReader _reader;
        public StreamWriter _writer;
        public string receive;
        public string TextToSend;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _receiveTask;

        private bool _isListening { get; set; } = false;
        private bool _isConnected = false;
        public bool IsConnected => _isConnected && _client?.Connected == true;

        // events
        public event Action<string> MessageReceived;
        public event Action<string> ErrorOccurred;
        public event Action ClientConnected;
        public event Action ClientDisconnected;
        public event Action RunScript;
        private static readonly log4net.ILog log = LogHelper.GetLogger();



        // functions
        /// <summary>
        /// Function to initialize the streams for reading and writing messages.
        /// </summary>
        /// <returns></returns>
        private async Task InitializeStreamsAsync()
        {
            var stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };
        }

        /// <summary>
        /// Function to start the server
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<bool> Start(string port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, int.Parse(port));
                _listener.Start();
                try
                {
                    _client = await _listener.AcceptTcpClientAsync();
                    await InitializeStreamsAsync();
                    ClientConnected?.Invoke();

                    _receiveTask = Task.Run(() => ReceiveMessagesAsync(_cancellationTokenSource.Token));

                }
                catch (Exception e)
                {
                    log.Error("Error: Starting server error", e);
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error: Starting server error", e);
                return false;
            }
        }
        /// <summary>
        /// Function to start the server with port as integer
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<bool> Start(int port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();
                try
                {
                    _client = await _listener.AcceptTcpClientAsync();
                    await InitializeStreamsAsync();
                    ClientConnected?.Invoke();

                    _receiveTask = Task.Run(() => ReceiveMessagesAsync(_cancellationTokenSource.Token));

                }
                catch (Exception e)
                {
                    log.Error("Error: Starting server error", e);
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error: Starting server error", e);
                return false;
            }
        }


        /// <summary>
        /// Function to connect to server asynchronously
        /// </summary>
        /// <param name="clientText"></param>
        /// <param name="clientPortText"></param>
        /// <returns></returns>
        public async Task<bool> ConnectServerAsync(string clientText, string clientPortText)
        {
            try
            {
                _client?.Close();
                _client = new TcpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(clientText), int.Parse(clientPortText));
                await _client.ConnectAsync(IPAddress.Parse(clientText), int.Parse(clientPortText));
                _isConnected = true;
                await InitializeStreamsAsync();

                _cancellationTokenSource = new CancellationTokenSource();

                _receiveTask = Task.Run(() => ReceiveMessagesAsync(_cancellationTokenSource.Token));

                return true;

            }
            catch (Exception e)
            {
                log.Error("Error: Connecting to server async error + ", e);
                return false;

            }
        }
        /// <summary>
        /// Function to connect to server asynchronously with port as integer
        /// </summary>
        /// <param name="clientText"></param>
        /// <param name="clientPortText"></param>
        /// <returns></returns>
        public async Task<bool> ConnectServerAsync(string clientText, int clientPortText)
        {
            try
            {
                _client?.Close();
                _client = new TcpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(clientText), (clientPortText));
                await _client.ConnectAsync(IPAddress.Parse(clientText), clientPortText);
                _isConnected = true;

                await InitializeStreamsAsync();

                _cancellationTokenSource = new CancellationTokenSource();

                _receiveTask = Task.Run(() => ReceiveMessagesAsync(_cancellationTokenSource.Token));

                return true;

            }
            catch (Exception e)
            {
                log.Error("Error: Connecting to server async error + ", e);
                return false;

            }
        }

        /// <summary>
        /// Function to connect to server asynchronously with port as integer
        /// </summary>
        /// <param name="clientText"></param>
        /// <param name="clientPortText"></param>
        /// <returns></returns>
        public async Task<bool> ConnectServer(string clientText, int clientPortText)
        {
            try
            {
                _client = new TcpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(clientText), (clientPortText));
                _client.Connect(endPoint);
                _isConnected = true;

                await InitializeStreamsAsync();

                _cancellationTokenSource = new CancellationTokenSource();


                _receiveTask = Task.Run(() => ReceiveMessagesAsync(_cancellationTokenSource.Token));
                return true;

            }
            catch (Exception e)
            {
                log.Error("Error: Connecting to server async error + ", e);
                return false;

            }
        }

        /// <summary>
        /// Function to receive messages asynchronously with ability to wait for response
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task ReceiveMessagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (IsConnected && !cancellationToken.IsCancellationRequested)
                {
                    string message = await _reader.ReadLineAsync();
                    if (message != null)
                    {
                        MessageReceived?.Invoke(message);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (ObjectDisposedException) { /*Expected on disconnect, ignore */ }
            catch (IOException) { /* Expected on disconnect, ignore */ }
            catch (OperationCanceledException) { /* Expected on disconnect, ignore */ }
            catch (Exception e)
            {
                log.Error("Error: Receiving messages async error + ", e);
                ErrorOccurred?.Invoke(e.Message);
            }
            finally
            {
                ClientDisconnected?.Invoke();
            }
        }

        /// <summary>
        /// Function to send messages asynchronously with error handling
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendMessageAsync(string message)
        {
            try
            {
                if (!IsConnected)
                {
                    throw new InvalidOperationException("Client is not connected.");
                }

                await _writer.WriteLineAsync(message);
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error: Sending messages async + ", e);
            }
            return false;
        }

        /// <summary>
        /// Helper function to return ip address
        /// </summary>
        /// <returns></returns>
        public string returnIP()
        {
            try
            {
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in localIP)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
                }
            }
            catch (Exception e)
            {
                log.Error("Error: Returning ip address + ", e);
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// Function to disconnect from the server and clean up resources.
        /// </summary>
        public void Disconnect()
        {
            _isConnected = false;
            try
            {
                // cancel the receive task
                _cancellationTokenSource?.Cancel();

                _reader?.Close();
                _writer?.Close();
                _client?.Close();

                // wait for the receive task to finish for 1 second
                try
                {
                    _receiveTask?.Wait(1000);
                }
                catch (AggregateException ex)
                {
                    foreach (var inner in ex.InnerExceptions)
                    {
                        if (!(inner is ObjectDisposedException || inner is IOException || inner is OperationCanceledException))
                            log.Error("Unexpected error during disconnect", inner);
                    }
                }

                _listener?.Stop();
                _isListening = false;
            }
            catch (Exception e)
            {
                log.Error("Error: Disconnecting from server + ", e);
            }
        }
    }
}
    