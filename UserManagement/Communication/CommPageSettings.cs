using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using SerialCommunication;

namespace InternshipApp
{
    public class CommPageSettings
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public Parity ParityBits { get; set; }
        public bool dtrEnabled { get; set; }
        public bool rtsEnabled { get; set; }
    }

    public class TcpClientSettings
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
    }

    public class TcpServerSettings
    {
        public string IpAddress{ get; set; }
        public int Port { get; set; }
    }
}