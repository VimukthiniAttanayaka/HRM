using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace HRM_DAL.Utility
{
    public class SmsHelper
    {
        #region Open and Close Ports

        static SerialPort port = new SerialPort();
        //Open Port
        //public SerialPort OpenPort(string portName, int baudRate, int dataBits, int readTimeout, int writeTimeout)
        private SerialPort OpenPort()
        {
            receiveNow = new AutoResetEvent(false);

            try
            {
                //port.PortName = portName;                 //COM1
                //port.BaudRate = baudRate;                   //9600
                //port.DataBits = dataBits;                   //8
                //port.StopBits = StopBits.One;                  //1
                //port.Parity = Parity.None;                     //None
                //port.ReadTimeout = readTimeout;             //300
                //port.WriteTimeout = writeTimeout;           //300
                //port.Encoding = Encoding.GetEncoding("iso-8859-1");
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                //port.Open();
                //port.DtrEnable = true;
                //port.RtsEnable = true;

                port.PortName = "COM4";                 //COM1
                port.BaudRate = 115200;                   //9600
                port.DataBits = 8;                  //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = 300;             //300
                port.WriteTimeout = 300;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return port;
        }
        private static SerialPort OpenPort(string portName)
        {
            receiveNow = new AutoResetEvent(false);

            try
            {
                //port.PortName = portName;                 //COM1
                //port.BaudRate = baudRate;                   //9600
                //port.DataBits = dataBits;                   //8
                //port.StopBits = StopBits.One;                  //1
                //port.Parity = Parity.None;                     //None
                //port.ReadTimeout = readTimeout;             //300
                //port.WriteTimeout = writeTimeout;           //300
                //port.Encoding = Encoding.GetEncoding("iso-8859-1");
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                //port.Open();
                //port.DtrEnable = true;
                //port.RtsEnable = true;

                port.PortName = portName;                 //COM1
                port.BaudRate = 115200;                   //9600
                port.DataBits = 8;                  //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = 300;             //300
                port.WriteTimeout = 300;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return port;
        }
        //Close Port
        protected static void ClosePort()
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                //port = null;
                port = new SerialPort();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        // Send AT Command
        protected static string SendATCommand(string command, int responseTimeout, string errorMessage)
        {
            try
            {

                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Receive data from port
        protected static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected static string ReadResponse(SerialPort port, int timeout)
        {
            string serialPortData = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string data = port.ReadExisting();
                        serialPortData += data;
                    }
                    else
                    {
                        if (serialPortData.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("No data received from phone.");
                    }
                }
                while (!serialPortData.EndsWith("\r\nOK\r\n") && !serialPortData.EndsWith("\r\n> ") && !serialPortData.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return serialPortData;
        }


        int GetMessageCount(string recievedData, out bool encounteredError)
        {
            encounteredError = false;
            int messageCount = 0;

            if (recievedData.StartsWith("AT+CPMS") && recievedData.Contains("\r\nOK\r\n"))
            {
                string[] receivedDataSplitted = recievedData.Split(',');
                string messageStorageArea = receivedDataSplitted[0];
                string messageReceivedCount = receivedDataSplitted[1];
                messageCount = Convert.ToInt32(messageReceivedCount);
            }
            else if (recievedData.Contains("ERROR"))
            {
                string recievedError = recievedData;
                recievedError = recievedError.Trim();
                recievedData = "Following error occured while counting the message "
                    + recievedError;
                encounteredError = true;
                messageCount = 0;
            }
            return messageCount;
        }

        #region Read SMS

        protected static AutoResetEvent receiveNow;

        //protected ShortMessageCollection ReadSMS(SerialPort port, string atCommand)
        //{
        //    // Set up the phone and read the messages
        //    ShortMessageCollection messages = null;
        //    try
        //    {

        //        #region Execute Command
        //        // Check connection
        //        SendATCommand(port, "AT", 300, "No phone connected");
        //        // Use message format "Text mode"
        //        SendATCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
        //        // Use character set "PCCP437"
        //        //ExecCommand(port,"AT+CSCS=\"PCCP437\"", 300, "Failed to set character set.");
        //        // Select SIM storage
        //        //(port,"AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
        //        // Read the messages
        //        string input = SendATCommand(port, atCommand, 5000, "Failed to read the messages.");
        //        #endregion

        //        #region Parse messages
        //        messages = ParseMessages(input);
        //        #endregion

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    if (messages != null)
        //        return messages;
        //    else
        //        return null;
        //}

        //protected ShortMessageCollection ParseMessages(string input)
        //{
        //    ShortMessageCollection messages = new ShortMessageCollection();
        //    try
        //    {
        //        Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
        //        Match m = r.Match(input);
        //        while (m.Success)
        //        {
        //            ShortMessage msg = new ShortMessage();
        //            msg.Index = m.Groups[1].Value;
        //            msg.Status = m.Groups[2].Value;
        //            msg.Sender = m.Groups[3].Value;
        //            msg.Alphabet = m.Groups[4].Value;
        //            msg.Sent = m.Groups[5].Value;
        //            msg.Message = m.Groups[6].Value;
        //            messages.Add(msg);
        //            m = m.NextMatch();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return messages;
        //}

        #endregion

        #region Send SMS

        static AutoResetEvent readNow = new AutoResetEvent(false);

        public static SMSSendReturn SendSMSMessage(string phoneNo, string message, string portName)
        {
            bool isSend = false;
            try
            {
                OpenPort(portName);

                string recievedData = SendATCommand("AT", 300, "No phone connected");
                string command = "AT+CMGF=1" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(command, 300, "Failed to set message format.");

                // AT Command Syntax - http://www.smssolutions.net/tutorials/gsm/sendsmsat/
                command = "AT+CMGS=\"" + phoneNo + "\"" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(command, 300,
                    "Failed to accept phoneNo");

                command = message + char.ConvertFromUtf32(26);
                recievedData = SendATCommand(command, 3000,
                    "Failed to send message"); //3 seconds

                if (recievedData.EndsWith("\r\nOK\r\n"))
                    isSend = true;
                else if (recievedData.Contains("ERROR"))
                    isSend = false;
                ClosePort();
                return new SMSSendReturn() { PhoneNo = phoneNo, PortName = portName, IsSend = isSend, Message = recievedData };
            }
            catch (Exception ex)
            {
                return new SMSSendReturn() { PhoneNo = phoneNo, PortName = portName, IsSend = isSend, Message = ex.Message };
            }
        }

        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    readNow.Set();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete SMS
        //protected bool DeleteMessage(SerialPort port, string atCommand)
        //{
        //    bool isDeleted = false;
        //    try
        //    {
        //        #region Execute Command
        //        string recievedData = SendATCommand(port, "AT", 300, "No phone connected");
        //        recievedData = SendATCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
        //        String command = atCommand;
        //        recievedData = SendATCommand(port, command, 300, "Failed to delete message");
        //        #endregion

        //        if (recievedData.EndsWith("\r\nOK\r\n"))
        //        {
        //            isDeleted = true;
        //        }
        //        if (recievedData.Contains("ERROR"))
        //        {
        //            isDeleted = false;
        //        }
        //        return isDeleted;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        public class SMSModel
        {
            public string MobileNo { get; set; }
            public string DisplayName { get; set; }
        }

        public class SMSSettings
        {
            public SMSSettings(string SMSComPort)
            {
                this.SMSComPort = SMSComPort;
            }

            public string SMSComPort { get; set; }// = "COM8";
        }

        public class SMSSendReturn
        {
            public string PhoneNo { get; set; }
            public string PortName { get; set; }
            public bool IsSend { get; set; }
            public string Message { get; set; }
        }
    }
}
