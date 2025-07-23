using log4net.Core;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace NetworkCapture
{
    /// <summary>
    /// Packet capture service. Takes care of capturing packets from a network device and raising events with the captured packet information.
    /// </summary>
    public class PacketEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public string Source { get; set; }
        public string SourcePort { get; set; }
        public string SourceHost { get; set; }

        public string Destination { get; set; }
        public string DestinationPort { get; set; }
        public string DestinationHost { get; set; }
        public string Protocol { get; set; }
        public int Length { get; set; }
    }
    public class PacketCaptureService
    {

        ICaptureDevice _currentDevice;
        public event EventHandler<PacketEventArgs> PacketReceived;
        private static readonly log4net.ILog log = LogHelper.GetLogger();


        public PacketCaptureService() { 
        
        }

        /// <summary>
        /// Function that gets all available capture devices on the system and returns it in a list.
        /// </summary>
        /// <returns></returns>
        public List<ICaptureDevice> getDevices()
        {
            var devices = CaptureDeviceList.Instance;
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices found.");
                return null;
            }
            var result = new List<ICaptureDevice>();
            foreach (var dev in devices)
            {
                result.Add(dev);
            }
            return result;
        }

        /// <summary>
        /// Function that begins capture on a specified device with a read timeout in milliseconds.
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="readTimeoutMilliseconds"></param>
        public void startCapture(string deviceName, int readTimeoutMilliseconds)
        {
            try
            {
                var devices = CaptureDeviceList.Instance;
                ICaptureDevice selectedDevice = devices.FirstOrDefault(d => d.Name == deviceName);
                selectedDevice.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
                if (selectedDevice == null)
                {
                    Console.WriteLine("Device not found.");
                    return;
                }
                selectedDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
                _currentDevice = selectedDevice;
                selectedDevice.StartCapture();
            } catch (Exception ex)
            {
                log.Error("Error starting packet capture", ex);
            }

        }
        /// <summary>
        /// Function that stops the capture on the specified device.
        /// </summary>
        /// <param name="device"></param>
        public void stopCapture(ICaptureDevice device)
        {
            device.StopCapture();
        }
        /// <summary>
        /// Event handler for when a packet arrives. Parses the packet and raises the PacketReceived event with the packet information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            try
            {
                var time = e.Packet.Timeval.Date;
                var raw = e.Packet;
                var len = e.Packet.Data.Length;

                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var ip = packet.Extract<IPPacket>();
                var tcp = packet.Extract<TcpPacket>();
                var udp = packet.Extract<UdpPacket>();

                string srcHost = "";
                string dstHost = "";

                try { if (ip != null) srcHost = Dns.GetHostEntry(ip.SourceAddress).HostName; } catch (Exception ex) { Console.WriteLine("Could not get srcHost " + ex); srcHost = "N/A"; }
                try { if (ip != null) dstHost = Dns.GetHostEntry(ip.DestinationAddress).HostName; } catch (Exception ex) { Console.WriteLine("Could not get destHost " + ex); dstHost = "N/A"; }

                string src = ip?.SourceAddress.ToString() ?? "Unknown Source";
                string srcPort = tcp?.SourcePort.ToString() ?? udp?.SourcePort.ToString() ?? "Unknown Source Port";
                string dst = ip?.DestinationAddress.ToString() ?? "Unknown Destination";
                string dstPort = tcp?.DestinationPort.ToString() ?? udp?.DestinationPort.ToString() ?? "Unknown Destination Port";
                string protocol = packet.GetType().Name;


                PacketReceived?.Invoke(this, new PacketEventArgs
                {
                    Time = time,
                    Source = src,
                    SourcePort = srcPort,
                    SourceHost = srcHost,
                    Destination = dst,
                    DestinationPort = dstPort,
                    DestinationHost = dstHost,
                    Protocol = protocol,
                    Length = raw.Data.Length
                });
            } catch (Exception ex)
            {
                log.Error("Error get information from packet", ex);
            }
        }

        /// <summary>
        /// Function that gets packets from the capture service based on a specified time. This is a placeholder function and should be implemented to return actual captured packets.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>

        public List<string> getPackets(string time)
        {
                var packets = new List<string>();
            try
            {
                packets.Add(time);
            } catch (Exception ex)
            {
                log.Error("Error getting packet and adding the time", ex);
            }
            return packets;
        }
    }
}
