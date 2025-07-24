using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SerialCommunication
{
    /// <summary>
    /// Port service class for managing serial port communication. Can send, receive and configure serial ports.
    /// </summary>
    public class PortService
    {
        private SerialPort _serialPort1;
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public PortService(SerialPort serialPort)
        {
            _serialPort1 = serialPort;
            _serialPort1.Handshake = Handshake.None; // Set default handshake to None
        }
        /// <summary>
        /// Helper function that returns an array of available serial ports on the system.
        /// </summary>
        /// <returns></returns>
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }
        /// <summary>
        /// Function to set the port name of the serial port.
        /// </summary>
        /// <param name="portName"></param>
        public void setPortName(string portName)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.PortName = portName;
            } catch (Exception ex)
            {
                log.Error("Error setting com portname. ", ex);
            }
        }
        /// <summary>
        /// Function to set the baud rate of the serial port.
        /// </summary>
        /// <param name="baudRate"></param>
        public void setBaudRate(int baudRate)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.BaudRate = baudRate;
            } catch (Exception ex)
            {
                log.Error("Error setting baudRate int. ", ex);
            }
        }
        /// <summary>
        /// Function to set the baud rate of the serial port using a string value.
        /// </summary>
        /// <param name="baudRate"></param>
        public void setBaudRate(string baudRate)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.BaudRate = Convert.ToInt32(baudRate);
            } catch (Exception ex)
            {
                log.Error("Error setting baudrate string. ", ex);
            }
        }
        /// <summary>
        /// Function to set the data bits of the serial port.
        /// </summary>
        /// <param name="dataBits"></param>
        public void setDataBits(int dataBits)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.DataBits = dataBits;
            } catch (Exception ex)
            {
                log.Error("Error setting DataBits int.", ex);
            }
        }
        /// <summary>
        /// Function to set the data bits of the serial port using a string value.
        /// </summary>
        /// <param name="dataBits"></param>
        public void setDataBits(string dataBits)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.DataBits = Convert.ToInt32(dataBits);
            } catch (Exception ex)
            {
                log.Error("Error setting DataBits string.", ex);
            }
        }
        /// <summary>
        /// Function to set the stop bits of the serial port.
        /// </summary>
        /// <param name="stopBits"></param>
        public void setStopBits(StopBits stopBits)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.StopBits = stopBits;
            } catch (Exception ex)
            {
                log.Error("Error setting stopbits. ", ex);
            }
        }
        /// <summary>
        /// Function to set the stop bits of the serial port using a string value.
        /// </summary>
        /// <param name="stopBits"></param>
        public void setStopBits(string stopBits)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
            } catch (Exception ex)
            {
                log.Error("Error setting stopbits string. ", ex);
            }
        }
        /// <summary>
        /// Function to set the parity of the serial port.
        /// </summary>
        /// <param name="parity"></param>
        public void setParity(Parity parity)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.Parity = parity;
            } catch (Exception ex)
            {
                log.Error("Error setting parity", ex);
            }
        }
        /// <summary>
        /// Function to set the parity of the serial port using a string value.
        /// </summary>
        /// <param name="parity"></param>
        public void setParity(string parity)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
                _serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
            } catch (Exception ex)
            {
                log.Error("Error setting parity string", ex);
            }
        }
        /// <summary>
        /// Function to set the handshake of the serial port.
        /// </summary>
        /// <param name="enable"></param>
        public void setDtr(bool enable)
        {
            _serialPort1.DtrEnable = enable;
        }
        /// <summary>
        /// function to set the RTS (Request to Send) of the serial port.
        /// </summary>
        /// <param name="enable"></param>
        public void setRts(bool enable)
        {
            _serialPort1.RtsEnable = enable;
        }
        /// <summary>
        /// Function to open the serial port.
        /// </summary>
        public void openPort()
        {
            try
            {
                if (!_serialPort1.IsOpen)
                {
                    _serialPort1.Open();
                }
            } catch (Exception ex)
            {
                log.Error("Error: Could not open com port", ex);
            }
        }
        /// <summary>
        /// Function to close the serial port.
        /// </summary>
        public void closePort()
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Close();
                }
            } catch (Exception ex)
            {
                log.Error("Error: Could not close com port", ex);
            }
        }
        /// <summary>
        /// Function to check if the serial port is open.
        /// </summary>
        /// <returns></returns>
        public bool isPortOpen()
        {
            return _serialPort1.IsOpen;
        }
        /// <summary>
        /// Function to write data to the serial port.
        /// </summary>
        /// <param name="data"></param>
        public void writeData(string data)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.Write(data);
                }
            } catch (Exception ex)
            {
                log.Error("Error: Could not write com data", ex);
            }
        }
        /// <summary>
        /// Function to write a line of data to the serial port.
        /// </summary>
        /// <param name="data"></param>
        public void writeLineData(string data)
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    _serialPort1.WriteLine(data);
                }
            } catch (Exception ex)
            {
                log.Error("Error: Could not writeline com data", ex);
            }
        }
        /// <summary>
        /// Function to read data from the serial port.
        /// </summary>
        /// <returns></returns>

        public string readData()
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    return _serialPort1.ReadExisting();
                }
                return string.Empty;
            } catch (Exception ex)
            {
                log.Error("Error: Could not read com data", ex);
                return string.Empty;
            }
        }
        /// <summary>
        /// Function to read a line of data from the serial port.
        /// </summary>
        /// <returns></returns>
        public string readLineData()
        {
            try
            {
                if (_serialPort1.IsOpen)
                {
                    return _serialPort1.ReadLine();
                }
                return string.Empty;
            } catch (Exception ex)
            {
                log.Error("Error: Could not read com line data", ex);
                return string.Empty;
            }
        }
    }
}
