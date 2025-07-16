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
    public class PortService
    {
        private SerialPort _serialPort1;
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public PortService(SerialPort serialPort)
        {
            _serialPort1 = serialPort;
            _serialPort1.Handshake = Handshake.None; // Set default handshake to None
        }
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }
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

        public void setDtr(bool enable)
        {
            _serialPort1.DtrEnable = enable;
        }
        public void setRts(bool enable)
        {
            _serialPort1.RtsEnable = enable;
        }

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

        public bool isPortOpen()
        {
            return _serialPort1.IsOpen;
        }
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
