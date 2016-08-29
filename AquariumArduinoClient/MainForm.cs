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
        private static ConnectionManager _connectionManager;
        private DateTime _alertLastSent;
        private const string CommunicationIdentifier = "WaterSensors";

        enum Command
        {
            Acknowledge,
            Error,
            StartLogging,
            SendPH,
            SetPHOffset,
            SetPHOffsetResult,
            Identify,           // Command to identify device
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
            SetupComm();

        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            CloseComm();
          
        }

        private void btnDetectComPort_Click(object sender, EventArgs e)
        {
            tbCmdLog.Text = "";
         
            CloseComm();
            SetupComm();

            lblComPort.Text = "Arduino Port: Not Found";
            //if (portFound)
            //{
            //    lblComPort.Text = "Arduino Port: " + _arduinoPort;
            //    SetupComm();
            //}
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
            _serialTransport = new SerialTransport { CurrentSerialSettings = { DtrEnable = false } };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16)
            {
                PrintLfCr = false // Do not print newLine at end of command, to reduce data being sent
            };

            // Tell CmdMessenger to "Invoke" commands on the thread running the WinForms UI
            _cmdMessenger.ControlToInvokeOn = this;

            // Set Received command strategy that removes commands that are older than 1 sec
            _cmdMessenger.AddReceiveCommandStrategy(new StaleGeneralStrategy(8000));

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            // The Connection manager is capable or storing connection settings, in order to reconnect more quickly  
            // the next time the application is run. You can determine yourself where and how to store the settings
            // by supplying a class, that implements ISerialConnectionStorer. For convenience, CmdMessenger provides
            //  simple binary file storage functionality
            var serialConnectionStorer = new SerialConnectionStorer("SerialConnectionManagerSettings.cfg");

            // We don't need to provide a handler for the Identify command - this is a job for Connection Manager.
            _connectionManager = new SerialConnectionManager(
                _serialTransport as SerialTransport,
                _cmdMessenger,
                (int)Command.Identify,
                CommunicationIdentifier,
                serialConnectionStorer)
            {
                // Enable watchdog functionality.
                WatchdogEnabled = true,

                // Instead of scanning for the connected port, you can disable scanning and only try the port set in CurrentSerialSettings
                //DeviceScanEnabled = false
            };

            // Show all connection progress on command line             
            _connectionManager.Progress += (sender, eventArgs) =>
            {
                // If you want to reduce verbosity, you can only show events of level <=2 or ==1
                if (eventArgs.Level <= 3) LogCommand(eventArgs.Description);
            };

            // If connection found, tell the arduino to turn the (internal) led on
            _connectionManager.ConnectionFound += (sender, eventArgs) =>
            {
                // Create command
                var command = new SendCommand((int)Command.StartLogging);
                // Send command
                _cmdMessenger.SendCommand(command);
                lblComPort.Text = "Arduino Port: " + _serialTransport.CurrentSerialSettings.PortName;
            };

            //You can also do something when the connection is lost
            _connectionManager.ConnectionTimeout += (sender, eventArgs) =>
            {
                //Do something
                _isConnected = false;
                lblComPort.Text = "Arduino Port: Not Found";
                SendEmail("Arduino Water Sensor Disconnected from PC", "Arduino Water Sensor Disconnected from PC at :"+ DateTime.Now.ToString());
            };

            // Attach to NewLinesReceived for logging purposes
            _cmdMessenger.NewLineReceived += NewLineReceived;

            // Attach to NewLineSent for logging purposes
            _cmdMessenger.NewLineSent += NewLineSent;

            // Finally - activate connection manager
            _connectionManager.StartConnectionManager();


        }

        // Exit function
        public void CloseComm()
        {
            try
            {
                //_cmdMessenger.NewLineReceived -= NewLineReceived;

                //_cmdMessenger.NewLineSent -= NewLineSent;

                _connectionManager.Dispose();
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
                SendEmailAlert("PH is High! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
                lblPH.ForeColor = Color.Red;
            }
            if (phVal < _settings.PHSettings.LowValue)
            {
                SendEmailAlert("PH is Low! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
                lblPH.ForeColor = Color.Red;
            }

        }
        private void SendEmailAlert(string subject, string body)
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
            _isConnected = true;
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
                try
                {
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }catch(Exception ex)
                {
                    LogCommand("Failed to send mail -> " + ex.Message);
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
                LogCommand("Offset - No response!");

            // Stop running loop
            //RunLoop = false;
        }
    }
}
    

