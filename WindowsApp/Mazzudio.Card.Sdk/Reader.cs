using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Mazzudio.Card.Sdk
{
    public class Reader 
    {
        public event EventHandler<ReadCardEventArgs> OnReadCard;

        private void ResponseReadedCard(byte[] uid)
        {
            var temp = OnReadCard;
            if (temp != null)
            {
                temp(this, new ReadCardEventArgs(uid));
            }
        }

        private SerialPort _communicationPort = null;
        private bool _isStart = false;
        public Reader(string port)
        {
            try
            {
                _communicationPort = new SerialPort();
                _communicationPort.PortName = port;
                _communicationPort.BaudRate = 9600;
                _communicationPort.DataReceived += new SerialDataReceivedEventHandler(CommunicationPort_DataReceived);
            }
            catch(Exception ex)
            {
                throw ex;
            } 
        }

        ~Reader()
        {
            if (_communicationPort != null && _communicationPort.IsOpen)
            {
                _communicationPort.Close();
            }
        }

        void CommunicationPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        { 
            byte[] buffer = new byte[_communicationPort.BytesToRead];// { 0x00, 0x00, 0x00, 0x00 };  
            var res = _communicationPort.Read(buffer, 0, _communicationPort.BytesToRead);
            if(buffer.Length > 2 && _isStart)
            {
                if (buffer[0] == 0xFA)// && buffer[_communicationPort.BytesToRead - 1] == 0xCA)
                {
                    byte snLen = buffer[1];
                    byte chkSum = 0;
                    byte[] uid = new byte[snLen];
                    // Check sum will check all imcoming bytes except head, length and its checksum byte.
                    // |0xFA|Len| d a t a |chk|
                    for (var i=0;i<snLen; i++)
                    {
                        uid[i] = buffer[i + 2];
                        chkSum = Convert.ToByte((chkSum + uid[i]) % 256); 
                    }
                    if(chkSum == buffer[buffer.Length - 1])
                    {
                        ResponseReadedCard(uid);
                    } 
                }
            }
             
            System.Threading.Thread.Sleep(100);
        }

        public int StartReadCard()
        {
            if (!_isStart)
            {
                if (!_communicationPort.IsOpen)
                {
                    _communicationPort.Open();
                }
                // Send start cmd to reader.
                _communicationPort.Write(new byte[] { 0x07 }, 0, 1);
                _isStart = true;
            }
            
            return _isStart ? 0 : 1;
        }

        public int StopReadCard()
        { 
            if (_communicationPort.IsOpen)
            {
                _communicationPort.Write(new byte[] { 0x08 }, 0, 1);
            }
            _isStart = false;
            return 0;
        }
    }
}
