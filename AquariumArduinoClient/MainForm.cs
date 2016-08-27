using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;
using AquariumArduinoClient.Controls;
using System.Net.Mail;
using System.Net;
using AquariumArduinoClient.Utilities;

namespace AquariumArduinoClient
{
    public partial class MainForm : Form
    {
        private Settings _settings; 
        private bool _isConnected;
        private SerialTransport _serialTransport;
        private CmdMessenger _cmdMessenger;
        private bool _arduinoFound;
        private string _arduinoPort;
        private DateTime _alertLastSent;
        //private DateTime _lastCommTime;

        enum Command
        {
            Acknowledge,
            Error,
            StartLogging,
            SendPH,
            SetPHOffset,
            SetPHOffsetResult
        };

        public MainForm()
        {
            InitializeComponent();
            _settings = Settings.Get();

            tbLowPH.Text = _settings.PHSettings.LowValue.ToString();
            tbHighPH.Text = _settings.PHSettings.HighValue.ToString();
            tbOffset.Text = _settings.PHSettings.Offset.ToString();
            lblPH.Text = "PH: Not Connected!";
            lblPH.ForeColor = Color.Red;
            //BackgroundWorker bw = new BackgroundWorker();
            
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            CloseComm();
          
        }

        private void btnDetectComPort_Click(object sender, EventArgs e)
        {
            tbCmdLog.Text = "";
            //FindComPort();
            //SetupComm();
            bool portFound = FindComPort();
            CloseComm();
            lblComPort.Text = "Arduino Port: Not Found";
            if (portFound)
            {
                lblComPort.Text = "Arduino Port: " + _arduinoPort;
                SetupComm();
            }
        }

        
        private bool FindComPort()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    //_currentPort = new SerialPort(port, 9600);
                    FindArduino(port);
                    if (_arduinoFound)
                    {
                        _arduinoPort = port;
                        return true;
                    }
                   
                }

            }
            catch (Exception e)
            {
            }
            return false;
        }
        private void FindArduino(string port)
        {
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = port, BaudRate = 9600, DtrEnable = false } // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);

            // Tell CmdMessenger to "Invoke" commands on the thread running the WinForms UI
            _cmdMessenger.ControlToInvokeOn = this;

            // Set Received command strategy that removes commands that are older than 1 sec
            _cmdMessenger.AddReceiveCommandStrategy(new StaleGeneralStrategy(1000));

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            // Attach to NewLinesReceived for logging purposes
            _cmdMessenger.NewLineReceived += NewLineReceived;

            // Attach to NewLineSent for logging purposes
            _cmdMessenger.NewLineSent += NewLineSent;

            //_cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);

            // Start listening
           bool connected = _cmdMessenger.Connect();
            if (!connected) return;
            // Send command to start sending data
            var command = new SendCommand((int)Command.StartLogging);

            // Send command
            var receiveCommand = _cmdMessenger.SendCommand(command);
            WaitSeconds(2);
           // _arduinoFound = receiveCommand.Ok;
            //CloseComm();
        }
        private void WaitSeconds(int seconds)
        {
            if (seconds < 1) return;
            DateTime waitTime = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < waitTime)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void SetupComm()
        {
    
            // Create Serial Port object
            // Note that for some boards (e.g. Sparkfun Pro Micro) DtrEnable may need to be true.
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = _arduinoPort, BaudRate = 9600, DtrEnable = false } // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);

            // Tell CmdMessenger to "Invoke" commands on the thread running the WinForms UI
            _cmdMessenger.ControlToInvokeOn = this;

            // Set Received command strategy that removes commands that are older than 1 sec
            _cmdMessenger.AddReceiveCommandStrategy(new StaleGeneralStrategy(1000));

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            // Attach to NewLinesReceived for logging purposes
            _cmdMessenger.NewLineReceived += NewLineReceived;

            // Attach to NewLineSent for logging purposes
            _cmdMessenger.NewLineSent += NewLineSent;

            // Start listening
            _cmdMessenger.Connect();
            
            // Send command to start sending data
            var command = new SendCommand((int)Command.StartLogging);

            // Send command
            _cmdMessenger.SendCommand(command);
            _isConnected = true;
        }

        // Exit function
        public void CloseComm()
        {
            try
            {
                _cmdMessenger.NewLineReceived -= NewLineReceived;

                _cmdMessenger.NewLineSent -= NewLineSent;
                // Stop listening
                _cmdMessenger.Disconnect();

                lblPH.Text = "PH: Not Connected!";
                lblPH.ForeColor = Color.Red;

                // Dispose Command Messenger
                _cmdMessenger.Dispose();

                // Dispose Serial Port object
                _serialTransport.Dispose();
            }
            catch
            {
                try
                {
                    // Dispose Command Messenger
                    _cmdMessenger.Dispose();

                    // Dispose Serial Port object
                    _serialTransport.Dispose();
                }
                catch
                {
                    try
                    {
                        // Dispose Serial Port object
                        _serialTransport.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            _isConnected = false;
            Settings.Save(_settings);
        }

        /// Attach command call backs. 
        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
            _cmdMessenger.Attach((int)Command.SendPH, OnSendPH);
        }

        // ------------------  CALLBACKS ---------------------

        // Called when a received command has no attached function.
        // In a WinForm application, console output gets routed to the output panel of your IDE
        void OnUnknownCommand(ReceivedCommand arguments)
        {
            LogCommand(@"Command without attached callback received");
        }

        // Callback function that prints that the Arduino has acknowledged
        void OnAcknowledge(ReceivedCommand arguments)
        {
            _arduinoFound = true;
            LogCommand(@" Arduino is ready");
        }

        // Callback function that prints that the Arduino has experienced an error
        void OnError(ReceivedCommand arguments)
        {
            LogCommand(@"Arduino has experienced an error");
        }

        // Callback function that plots a data point for ADC 1 and ADC 2
        private void OnSendPH(ReceivedCommand arguments)
        {
            var time = arguments.ReadFloatArg();
            var phVal = arguments.ReadFloatArg();
            var voltsVal = arguments.ReadFloatArg();

            TimeSpan runtime = TimeSpan.FromSeconds(time);

            LogCommand(@"PHSend > PH=" + phVal+ ", V=" + voltsVal, runtime);
            //todo: log and display data
            lblPH.Text = "PH: " + phVal;
            lblPH.ForeColor = Color.Green;
            if (phVal > _settings.PHSettings.HighValue)
            {
                SendAlert("PH is High! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
                lblPH.ForeColor = Color.Red;
            }
            if (phVal < _settings.PHSettings.LowValue)
            {
                SendAlert("PH is Low! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
                lblPH.ForeColor = Color.Red;
            }

        }
        private void SendAlert(string subject, string body)
        {
            if (_alertLastSent.Date != DateTime.Now.Date)
            {
                SendEmail(subject, body);
                _alertLastSent = DateTime.Now;
            }
        }
        private void LogCommand(string text, TimeSpan runtime)
        {
            string minSec = runtime.ToString(@"hh\:mm\:ss");
            text = minSec + " - "+ text;
            LogCommand(text);
        }
        private void LogCommand(string text)
        {
            tbCmdLog.AppendLine(text, 100);
        }

        // Log received line to console
        private void NewLineReceived(object sender, CommandEventArgs e)
        {
            LogCommand(@"Received > " + e.Command.CommandString());
        }

        // Log sent line to console
        private void NewLineSent(object sender, CommandEventArgs e)
        {
            LogCommand(@"Sent > " + e.Command.CommandString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseComm();
        }

        private void tbCmdLog_TextChanged(object sender, EventArgs e)
        {
            tbCmdLog.SelectionStart = tbCmdLog.Text.Length;
            tbCmdLog.ScrollToCaret();
        }

        private void SendEmail(string subject, string body)
        {
            string smtpAddress = "smtp.live.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "EALAlerts@outlook.com";
            string password = "oly01uwl1#";
            string emailTo = "olson_mitchell@hotmail.com";
            //string subject = "Hello";
            //string body = "Hello, I'm just writing this to say Hi!";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                // Can set to false, if you are sending pure text.

                //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

        private void tbLowPH_TextChanged(object sender, EventArgs e)
        {
            _settings.PHSettings.LowValue = double.Parse(tbLowPH.Text);
            Settings.Save(_settings);
        }

        private void tbHighPH_TextChanged(object sender, EventArgs e)
        {
            _settings.PHSettings.HighValue = double.Parse(tbHighPH.Text);
            Settings.Save(_settings);
        }

        private void tbOffset_TextChanged(object sender, EventArgs e)
        {

        }
        private void tbOffset_Leave(object sender, EventArgs e)
        {
            var offsetString = tbOffset.Text;
            double offset = Convert.ToDouble(offsetString);
            _settings.PHSettings.Offset = offset;

            Settings.Save(_settings);

            if (!_isConnected) return;
            // Create command FloatAddition, which will wait for a return command FloatAdditionResult
            var command = new SendCommand((int)Command.SetPHOffset, (int)Command.SetPHOffsetResult, 1000); 

            

            command.AddArgument((float)offset);
            
            // Send command
            var cmdResult = _cmdMessenger.SendCommand(command);

            // Check if received a (valid) response
            if (cmdResult.Ok)
            {
                // Read returned argument
                var returnedOffset = cmdResult.ReadFloatArg();
                if (Math.Round(returnedOffset, 2) != Math.Round(offset, 2))
                    LogCommand("Returned Offset doesnt match: " + returnedOffset);

            }
            else
                LogCommand("No response!");

            // Stop running loop
            //RunLoop = false;
        }
    }
}
    

