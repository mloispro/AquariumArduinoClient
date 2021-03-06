﻿using System;
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
//using CommandMessenger;
//using CommandMessenger.Queue;
//using CommandMessenger.Transport.Serial;
using AquariumArduinoClient.Controls;
using System.Net.Mail;
using System.Net;
using AquariumArduinoClient.Utilities;
using AquariumArduinoClient.Models;
using EALFramework.Controllers;
using EALFramework.Models;
using EALFramework.Utils;

namespace AquariumArduinoClient
{
    public partial class MainForm : Form
    {
        private Settings _settings; 
        //private bool _isConnected;
        //private SerialTransport _serialTransport;
        //private CmdMessenger _cmdMessenger;
        //private static ConnectionManager _connectionManager;
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
            Logging.Init(tbCmdLog);
            Status.Init(statusBar);
            //new PHLog().TestPhLogs();
            //return;

            _settings = Settings.Get();

            tbLowPH.Text = _settings.PHSettings.LowValue.ToString();
            tbHighPH.Text = _settings.PHSettings.HighValue.ToString();
            tbPHOffset.Text = _settings.PHSettings.Offset.ToString();
            tbTDSOffset.Text = _settings.TDSSettings.Offset.ToString();
            //lblPH.Text = "PH: Not Connected!";
            //lblPH.ForeColor = Color.Red;
            tbGetSenValsEvery.Text = _settings.GetSensorValsEvery.ToString();
            tbGetContValsEvery.Text = _settings.GetControllerValsEvery.ToString();
            tbGetROSenValsEvery.Text = _settings.GetROSensorValsEvery.ToString();
            if (_settings.GetSensorValsEvery > 0)
            {
                timerGetSensorData.Interval = _settings.GetSensorValsEvery * 60 * 1000;
            }
            if (_settings.GetROSensorValsEvery > 0)
            {
                timerGetROSensorData.Interval = _settings.GetROSensorValsEvery * 60 * 1000;
            }
            if (_settings.GetControllerValsEvery > 0)
            {
                timerGetControllerData.Interval = _settings.GetControllerValsEvery * 60 * 1000;
            }
            if (_settings.PHSettings.Offset < 0)
                cbOffsetNegative.Checked = true;

            if (!string.IsNullOrWhiteSpace(_settings.SensorIP))
            {
                List<string> ipSplit = _settings.SensorIP.Split('.').ToList();
                if (ipSplit.Count > 0)
                {
                    tbSensorIP1.Text = ipSplit[0];
                    tbSensorIP2.Text = ipSplit[1];
                    tbSensorIP3.Text = ipSplit[2];
                    tbSensorIP4.Text = ipSplit[3];
                }
            }
            else
            {
                ControlHelpers.ShowMessageBox("Sensor Ip not set.");
            }

            if (!string.IsNullOrWhiteSpace(_settings.ROSensorIP))
            {
                List<string> ipSplit = _settings.ROSensorIP.Split('.').ToList();
                if (ipSplit.Count > 0)
                {
                    tbROSensorIP1.Text = ipSplit[0];
                    tbROSensorIP2.Text = ipSplit[1];
                    tbROSensorIP3.Text = ipSplit[2];
                    tbROSensorIP4.Text = ipSplit[3];
                }
            }
            else
            {
                ControlHelpers.ShowMessageBox("RO Sensor Ip not set.");
            }

            //populate controller data
            if (!string.IsNullOrWhiteSpace(_settings.ControllerIP))
            {
                List<string> ipSplit = _settings.ControllerIP.Split('.').ToList();
                if (ipSplit.Count > 0)
                {
                    tbContIP1.Text = ipSplit[0];
                    tbContIP2.Text = ipSplit[1];
                    tbContIP3.Text = ipSplit[2];
                    tbContIP4.Text = ipSplit[3];
                }
            }
            else
            {
                ControlHelpers.ShowMessageBox("Controller Ip not set.");
            }
            if (!_settings.AquariumNames.Any())
            {
                _settings.AquariumNames.Add(new NameValue<string, int> { Name = "Aqua 1", Value = 0 });
                Settings.Save(_settings);
            }
            cbTankName.DataSource = _settings.AquariumNames;
            cbTankName.DisplayMember = "Name";

            cbContrAccInfo.DataSource = AquaControllerCmd.Cmds;
            cbContrAccInfo.DisplayMember = "Name";

            cbContrAccUpdate.DataSource = AquaControllerCmd.Cmds;
            cbContrAccUpdate.DisplayMember = "Name";

            cbRunDuration.DataSource = AquaControllerCmd.PumpRunDur;
            cbRunDuration.DisplayMember = "Name";

            cbRunEvery.DataSource = AquaControllerCmd.PumpRunEveryInHrs;
            cbRunEvery.DisplayMember = "Name";

            timerGetSensorData.Start();
            timerGetROSensorData.Start();
            timerGetControllerData.Start();
            Status.SetStatus("Getting controller data, please wait...");

            //DataBindUIControllerData();
            //DataBindUIAccInfoData();
            //GetSensorData();
            // SetupComm();

        }


        private async void GetSensorData(bool isROSensor = false, bool hasPHSensor = true)
        {
            string sensorIP = "";
            string sensorTxt = "";
            
            if (isROSensor)
            {
                if (string.IsNullOrWhiteSpace(_settings.ROSensorIP))
                {
                    //ControlHelpers.ShowMessageBox("Sensor Ip not set.");
                    return;
                }
                sensorIP = _settings.ROSensorIP.Replace(" ", "");
                sensorTxt = "RO";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(_settings.SensorIP))
                {
                    //ControlHelpers.ShowMessageBox("Sensor Ip not set.");
                    return;
                }
                sensorIP = _settings.SensorIP.Replace(" ", "");
            }


            try
            {
                await Task.Run(() =>
                {

                    System.Net.WebClient wc = new System.Net.WebClient();

                    string webData = wc.DownloadString(string.Format("http://{0}/GetSensorVals", sensorIP));
                    //string webData = FileIO.GetFileText(@"C:\Users\lenovo\downloads\WaterSensor.json");
                    //string webData = FileIO.GetFileText(@"C:\Users\lenovo\downloads\ROController.json");
                    WaterSensorData vals = WaterSensorData.Log(webData, isROSensor, hasPHSensor);

                    Status.SetStatus("Retrieved {0} sensor vals", sensorTxt);
                    if (!hasPHSensor)
                    {
                        Logging.Log("Retrieved {0} TDS sensor vals", sensorTxt);
                        if(!isROSensor)
                            lblTDS.SetControlText("TDS: " + vals.tds.ToString());
                        else
                            lblRoTds.SetControlText("TDS: " + vals.tds.ToString());
                    }
                    else if (vals.reading == "ph")
                    {
                        Logging.Log("Retrieved {0} TDS sensor vals", sensorTxt);
                        if (!isROSensor)
                            lblTDS.SetControlText("TDS: " + vals.tds.ToString());
                        else
                            lblRoTds.SetControlText("TDS: " + vals.tds.ToString());
                    }
                    else
                    {
                        Logging.Log("Retrieved {0} PH sensor vals", sensorTxt);
                       
                        if (!isROSensor)
                            lblPH.SetControlText("PH: " + vals.ph.ToString());
                        else
                            lblRoPH.SetControlText("PH: " + vals.ph.ToString());
                    }

                    if (isROSensor)
                    {
                    }
                    else
                    {
                        _settings.PHSettings.Offset = vals.phOffset;
                        _settings.TDSSettings.Offset = vals.tdsOffset;
                        tbPHOffset.SetControlText(vals.phOffset.ToString());
                        tbTDSOffset.SetControlText(vals.tdsOffset.ToString());
                    }
                });
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
                Status.SetStatus("Failed to get {0} sensor vals", Status.StatusType.ConnError, sensorTxt);
            }
        }

        private async void GetControllerData(bool force=false)
        {
            return;//todo: remove this when controller webserver is fixed.
            if (string.IsNullOrWhiteSpace(_settings.ControllerIP))
            {
                ControlHelpers.ShowMessageBox("Controller Ip not set.");
                return;
            }
            string controllerIP = _settings.ControllerIP.Replace(" ", "");

            try
            {

                string msg = await AquaController.GetControllerData(controllerIP, force);
                Status.SetStatus(msg);
                Logging.Log(msg);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
                Status.SetStatus("Failed to get controller data", Status.StatusType.ConnError);
            }
        }

        private void BwSensorsReadings_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDetectComPort_Click(object sender, EventArgs e)
        {
            tbCmdLog.Text = "";
         
            //CloseComm();
            //SetupComm();

            //lblComPort.Text = "Arduino Port: Not Found";
            //if (portFound)
            //{
            //    lblComPort.Text = "Arduino Port: " + _arduinoPort;
            //    SetupComm();
            //}
        }

        
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseComm();
        }

        private void tbCmdLog_TextChanged(object sender, EventArgs e)
        {
            tbCmdLog.SelectionStart = tbCmdLog.Text.Length;
            tbCmdLog.ScrollToCaret();
        }
        private void SendEmailAlert(string subject, string body)
        {
            if (_alertLastSent.Date != DateTime.Now.Date)
            {
                SendEmail(subject, body);
                _alertLastSent = DateTime.Now;
            }
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

        private void LogCommand(string text)
        {
            tbCmdLog.AppendLine(text, 100);
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

      
        private void tbOffset_Leave(object sender, EventArgs e)
        {
            SendPHOffset();
        }

        private void tbTDSOffset_Leave(object sender, EventArgs e)
        {
            SendTDSOffset();
        }
        private async void SendTDSOffset()
        {
            //todo:fix this method
            return;

            var offsetString = tbTDSOffset.Text;
            if (string.IsNullOrWhiteSpace(offsetString))
            {
                tbTDSOffset.Text = _settings.TDSSettings.Offset.ToString();
                return;
            }
            double offset = Convert.ToDouble(offsetString);

            _settings.TDSSettings.Offset = offset;

            Settings.Save(_settings);

            try
            {
                await Task.Run(() =>
                {

                    System.Net.WebClient wc = new System.Net.WebClient();

                    //http://192.168.10.102/SetPHOffset/3.4

                    string webData = wc.DownloadString(string.Format("http://{0}/SetTDSOffset/{1}", _settings.SensorIP, _settings.TDSSettings.Offset));
                    WaterSensorMessage msg = WaterSensorMessage.Deserialize(webData);
                    Logging.Log(msg.msg);
                    Status.SetStatus("Updated TDS Offset");

                });
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
                Status.SetStatus("Failed to update TDS Offset", Status.StatusType.ConnError);
            }
        }

        private async void SendControllerData(RunData data, bool runNow = false)
        {
            try
            {
                string controllerIP = _settings.ControllerIP.Replace(" ", "");
                string msg = await AquaController.SendControllerData(controllerIP, data, runNow);
                
                Logging.Log(msg);
                Status.SetStatus("Controller will update in 45 secinds..");

                await Task.Delay(45000);
                DataBindUIControllerData(true);

            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
                Status.SetStatus("Failed to update Aqua Controller", Status.StatusType.ConnError);
            }
        }

        private void cbOffsetNegative_CheckedChanged(object sender, EventArgs e)
        {
            SendPHOffset();
        }
        private async void SendPHOffset()
        {
            //todo:fix this method
            return;

            var offsetString = tbPHOffset.Text;
            if (string.IsNullOrWhiteSpace(offsetString))
            {
                tbPHOffset.Text = _settings.PHSettings.Offset.ToString();
                return;
            }
            double offset = Convert.ToDouble(offsetString);

            if (cbOffsetNegative.Checked)
                offset = offset * -1;

            _settings.PHSettings.Offset = offset;

            Settings.Save(_settings);

            try
            {
                await Task.Run(() =>
                {

                    System.Net.WebClient wc = new System.Net.WebClient();

                    //http://192.168.10.102/SetPHOffset/3.4

                    string webData = wc.DownloadString(string.Format("http://{0}/SetPHOffset/{1}", _settings.SensorIP, _settings.PHSettings.Offset));
                    WaterSensorMessage msg = WaterSensorMessage.Deserialize(webData);
                    Logging.Log(msg.msg);
                    Status.SetStatus("Updated PH Offset");

                });
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
                Status.SetStatus("Failed to Update PH Offset", Status.StatusType.ConnError);
            }


            //if (!_isConnected) return;
            //// Create command FloatAddition, which will wait for a return command FloatAdditionResult
            //var command = new SendCommand((int)Command.SetPHOffset, (int)Command.SetPHOffsetResult, 1000);



            //command.AddArgument((float)offset);

            //// Send command
            //var cmdResult = _cmdMessenger.SendCommand(command);

            //// Check if received a (valid) response
            //if (cmdResult.Ok)
            //{
            //    // Read returned argument
            //    var returnedOffset = cmdResult.ReadFloatArg();
            //    if (Math.Round(returnedOffset, 2) != Math.Round(offset, 2))
            //        LogCommand("Returned Offset doesnt match: " + returnedOffset);

            //}
            //else
            //    LogCommand("Offset - No response!");

            // Stop running loop
            //RunLoop = false;
        }

        private void timerGetSensorData_Tick(object sender, EventArgs e)
        {
            GetSensorData();
        }
        private void timerGetControllerData_Tick(object sender, EventArgs e)
        {
            DataBindUIControllerData();
        }
       
        private void tbSensorIP1_Leave(object sender, EventArgs e)
        {
            string sensorIp = tbSensorIP1.Text + "." + tbSensorIP2.Text + "." + tbSensorIP3.Text + "." + tbSensorIP4.Text;
            _settings.SensorIP = sensorIp;

            Settings.Save(_settings);
        }
        private void tbContIP1_Leave(object sender, EventArgs e)
        {
            string contIp = tbContIP1.Text + "." + tbContIP2.Text + "." + tbContIP3.Text + "." + tbContIP4.Text;
            _settings.ControllerIP = contIp;
            Settings.Save(_settings);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            GetSensorData();
            
        }

        private void btnRORead_Click(object sender, EventArgs e)
        {
            GetSensorData(true,false);
        }

        #region RO Tank Settings

        private void tbROSensorIP1_Leave(object sender, EventArgs e)
        {
            string sensorIp = tbROSensorIP1.Text + "." + tbROSensorIP2.Text + "." + tbROSensorIP3.Text + "." + tbROSensorIP4.Text;
            _settings.ROSensorIP = sensorIp;

            Settings.Save(_settings);
        }

        private void tbGetROSenValsEvery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGetROSenValsEvery.Text)) return;
            _settings.GetROSensorValsEvery = int.Parse(tbGetROSenValsEvery.Text);
            Settings.Save(_settings);
            if (_settings.GetROSensorValsEvery > 0)
            {
                timerGetROSensorData.Interval = _settings.GetROSensorValsEvery * 60 * 1000;
            }
        }

        private void timerGetROSensorData_Tick(object sender, EventArgs e)
        {
            GetSensorData(true,false);
        }

        #endregion RO Tank Settings

        private void tbGetSenValsEvery_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGetSenValsEvery.Text)) return;
            _settings.GetSensorValsEvery = int.Parse(tbGetSenValsEvery.Text);
            Settings.Save(_settings);
            if (_settings.GetSensorValsEvery > 0)
            {
                timerGetSensorData.Interval = _settings.GetSensorValsEvery * 60 * 1000;
            }
        }

        private void tbGetContValsEvery_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGetContValsEvery.Text)) return;
            _settings.GetControllerValsEvery = int.Parse(tbGetContValsEvery.Text);
            Settings.Save(_settings);
            EALFramework.Utils.Globals.RefreshRunDataEveryMin = _settings.GetControllerValsEvery;
            if (_settings.GetControllerValsEvery > 0)
            {
                timerGetControllerData.Interval = _settings.GetControllerValsEvery * 60 * 1000;
            }
        }

        private void cbContrAccUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindUIControllerData();
        }

        private void DataBindUIControllerData(bool force=false)
        {
            GetControllerData(force);

            DataBindUIAccInfoData();

            AquaControllerCmd cmd = (AquaControllerCmd)cbContrAccUpdate.SelectedItem;

            if (cmd == null) return;

            if (cmd.TheAccType == AquaControllerCmd.AccType.WaterPump ||
              cmd.TheAccType == AquaControllerCmd.AccType.DryDoser) //putting dry doser here for now, not sure how run ever works on arduino for dry doser.
            { 
                cbRunEvery.DataSource = AquaControllerCmd.PumpRunEveryInHrs;
                cbRunDuration.DataSource = AquaControllerCmd.PumpRunDur;
            }
            else
            {
                cbRunDuration.DataSource = AquaControllerCmd.MicrosMacrosRunDur;
                cbRunEvery.DataSource = AquaControllerCmd.MicrosMacrosRunEveryInHrs;
            }
            dtpNextRun.Value = DateTime.Now.AddDays(1);
            cbEnabled.Checked = false;

            SetUIControllerData();
        }

        private void SetUIControllerData()
        {
            AquaControllerCmd cmd = (AquaControllerCmd)cbContrAccUpdate.SelectedItem;
            var runDataList = AquaController.GetAllRunData();

            bool cmdExists = runDataList.Exists(x => x.accType == cmd.AccTypeMap);
            if (!cmdExists) return;

            RunData data = runDataList.Find(x => x.accType == cmd.AccTypeMap);
            cbEnabled.Checked = data.enabled;
            
            dtpNextRun.Value = data.GetNextRun();

            if (cmd.TheAccType == AquaControllerCmd.AccType.WaterPump ||
                cmd.TheAccType == AquaControllerCmd.AccType.DryDoser) //putting dry doser here for now, not sure how run ever works on arduino for dry doser.
            {
                //var runEvery = AquaControllerCmd.PumpRunEveryInHrs.Find(x => x.Value == data.GetRunEvery().TotalHours);
                var runEvery = AquaControllerCmd.PumpRunEveryInHrs.FindClosest(data.GetRunEvery().TotalSeconds);
                cbRunEvery.Text = runEvery.Name;

                var dur = AquaControllerCmd.PumpRunDur.FindClosest(data.runDurration);
                cbRunDuration.Text = dur;
            }
            else
            {
                var runEvery = AquaControllerCmd.MicrosMacrosRunEveryInHrs.FindClosest(data.GetRunEvery().TotalSeconds);
                if (runEvery != null)
                {
                    cbRunEvery.Text = runEvery.Name;
                }
                var dur = AquaControllerCmd.MicrosMacrosRunDur.FindClosest(data.runDurration);
                cbRunDuration.Text = dur;
            }

        }

        private void btnUpdateAcc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update accessory?", "Verify", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            AquaControllerCmd cmd = (AquaControllerCmd)cbContrAccUpdate.SelectedItem;
            var runDataList = AquaController.GetAllRunData();

            bool cmdExists = runDataList.Exists(x => x.accType == cmd.AccTypeMap);
            if (!cmdExists) return;

            RunData data = runDataList.Find(x => x.accType == cmd.AccTypeMap);

            data.enabled = cbEnabled.Checked;
            data.runDurration = int.Parse(cbRunDuration.Text);
            data.SetNextRun(dtpNextRun.Value);

            var re = (NameValue<string, int>)cbRunEvery.SelectedItem;
            data.runEvery = re.Value;

            AquaController.SaveRunData();
            SendControllerData(data, true);
            
        }

        private void cbContrAccInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindUIControllerData();
        }


        private void DataBindUIAccInfoData()
        {
            lblAccRunInfo.Text = "";

            AquaControllerCmd cmd = (AquaControllerCmd)cbContrAccInfo.SelectedItem;
            var runDataList = AquaController.GetAllRunData();

            bool cmdExists = runDataList.Exists(x => x.accType == cmd.AccTypeMap);
            if (!cmdExists)
            {
                lblAccRunInfo.Text = "diabled";
                return;
            }

            RunData data = runDataList.Find(x => x.accType == cmd.AccTypeMap);
            if (!data.enabled)
            {
                lblAccRunInfo.Text = "diabled";
                return;
            }

            lblAccRunInfo.Text = string.Format("Next Run: {0:MM/dd/yyyy h:mm tt}{1}Last Run: {2:MM/dd/yyyy h:mm tt}", data.GetNextRun(), Environment.NewLine, data.GetLastRun());
        }

        private void btnRunNow_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to run now?", "Verify", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            AquaControllerCmd cmd = (AquaControllerCmd)cbContrAccUpdate.SelectedItem;
            var runDataList = AquaController.GetAllRunData();

            bool cmdExists = runDataList.Exists(x => x.accType == cmd.AccTypeMap);
            if (!cmdExists) return;

            RunData data = runDataList.Find(x => x.accType == cmd.AccTypeMap);
            SendControllerData(data, true);
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataBindUIControllerData(true);
        }

        private void cbTankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAquarium = _settings.AquariumNames.Find(x => x.Value == cbTankName.SelectedIndex);
            WaterSensorController.CurrentAquariumName = selectedAquarium.Name; //todo: refresh aquarium name on form, use WaterSensorController.CurrentAquariumName for website
        }

        #region New Tank Dialog

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            NewTankDialog dialog = new NewTankDialog();
            dialog.ShowDialog(this);
        }

       



        #endregion New Tank Dialog














        //private void SetupComm()
        //{

        //    // Create Serial Port object
        //    // Note that for some boards (e.g. Sparkfun Pro Micro) DtrEnable may need to be true.
        //    _serialTransport = new SerialTransport { CurrentSerialSettings = { DtrEnable = false, BaudRate=9600 } };

        //    // Initialize the command messenger with the Serial Port transport layer
        //    // Set if it is communicating with a 16- or 32-bit Arduino board
        //    _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16)
        //    {
        //        PrintLfCr = false, // Do not print newLine at end of command, to reduce data being sent
        //    };

        //    // Tell CmdMessenger to "Invoke" commands on the thread running the WinForms UI
        //    _cmdMessenger.ControlToInvokeOn = this;

        //    // Set Received command strategy that removes commands that are older than 1 sec
        //    _cmdMessenger.AddReceiveCommandStrategy(new StaleGeneralStrategy(10000));

        //    // Attach the callbacks to the Command Messenger
        //    AttachCommandCallBacks();

        //    // The Connection manager is capable or storing connection settings, in order to reconnect more quickly  
        //    // the next time the application is run. You can determine yourself where and how to store the settings
        //    // by supplying a class, that implements ISerialConnectionStorer. For convenience, CmdMessenger provides
        //    //  simple binary file storage functionality
        //    var serialConnectionStorer = new SerialConnectionStorer("SerialConnectionManagerSettings.cfg");

        //    // We don't need to provide a handler for the Identify command - this is a job for Connection Manager.
        //    _connectionManager = new SerialConnectionManager(
        //        _serialTransport as SerialTransport,
        //        _cmdMessenger,
        //        (int)Command.Identify,
        //        CommunicationIdentifier,
        //        serialConnectionStorer)
        //    {
        //        WatchdogTimeout = 10000,
        //        WatchdogRetryTimeout = 6000,

        //        DeviceScanBaudRateSelection = false, //only use baudrate in serial settings

        //        // Enable watchdog functionality.
        //        WatchdogEnabled = true,

        //        // Instead of scanning for the connected port, you can disable scanning and only try the port set in CurrentSerialSettings
        //        //DeviceScanEnabled = false
        //    };

        //    // Show all connection progress on command line             
        //    _connectionManager.Progress += (sender, eventArgs) =>
        //    {
        //        // If you want to reduce verbosity, you can only show events of level <=2 or ==1
        //        if (eventArgs.Level <= 3) LogCommand(eventArgs.Description);
        //    };

        //    // If connection found, tell the arduino to turn the (internal) led on
        //    _connectionManager.ConnectionFound += (sender, eventArgs) =>
        //    {
        //        // Create command
        //        var command = new SendCommand((int)Command.StartLogging);
        //        // Send command
        //        _cmdMessenger.SendCommand(command);
        //        //lblComPort.Text = "Arduino Port: " + _serialTransport.CurrentSerialSettings.PortName;
        //    };

        //    //You can also do something when the connection is lost
        //    _connectionManager.ConnectionTimeout += (sender, eventArgs) =>
        //    {
        //        //Do something
        //        _isConnected = false;
        //        //lblComPort.Text = "Arduino Port: Not Found";
        //        SendEmail("Arduino Water Sensor Disconnected from PC", "Arduino Water Sensor Disconnected from PC at :"+ DateTime.Now.ToString());
        //    };

        //    // Attach to NewLinesReceived for logging purposes
        //    _cmdMessenger.NewLineReceived += NewLineReceived;

        //    // Attach to NewLineSent for logging purposes
        //    _cmdMessenger.NewLineSent += NewLineSent;

        //    // Finally - activate connection manager
        //    _connectionManager.StartConnectionManager();


        //}

        //// Exit function
        //public void CloseComm()
        //{
        //    try
        //    {
        //        //_cmdMessenger.NewLineReceived -= NewLineReceived;

        //        //_cmdMessenger.NewLineSent -= NewLineSent;

        //        _connectionManager.Dispose();
        //        // Stop listening
        //        _cmdMessenger.Disconnect();

        //        lblPH.Text = "PH: Not Connected!";
        //        lblPH.ForeColor = Color.Red;

        //        // Dispose Command Messenger
        //        _cmdMessenger.Dispose();

        //        // Dispose Serial Port object
        //        _serialTransport.Dispose();
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            // Dispose Command Messenger
        //            _cmdMessenger.Dispose();

        //            // Dispose Serial Port object
        //            _serialTransport.Dispose();
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                // Dispose Serial Port object
        //                _serialTransport.Dispose();
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }
        //    _isConnected = false;
        //    Settings.Save(_settings);
        //}

        ///// Attach command call backs. 
        //private void AttachCommandCallBacks()
        //{
        //    _cmdMessenger.Attach(OnUnknownCommand);
        //    _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
        //    _cmdMessenger.Attach((int)Command.Error, OnError);
        //    _cmdMessenger.Attach((int)Command.SendPH, OnSendPH);
        //}

        //// ------------------  CALLBACKS ---------------------

        //// Called when a received command has no attached function.
        //// In a WinForm application, console output gets routed to the output panel of your IDE
        //void OnUnknownCommand(ReceivedCommand arguments)
        //{
        //    LogCommand(@"Command without attached callback received");
        //}

        //// Callback function that prints that the Arduino has acknowledged
        //void OnAcknowledge(ReceivedCommand arguments)
        //{
        //    LogCommand(@" Arduino is ready");
        //}

        //// Callback function that prints that the Arduino has experienced an error
        //void OnError(ReceivedCommand arguments)
        //{
        //    LogCommand(@"Arduino has experienced an error");
        //}

        //// Callback function that Gets PH
        //private void OnSendPH(ReceivedCommand arguments)
        //{
        //    var time = arguments.ReadFloatArg();
        //    var phVal = arguments.ReadFloatArg();
        //    var voltsVal = arguments.ReadFloatArg();

        //    TimeSpan runtime = TimeSpan.FromSeconds(time);

        //    LogCommand(@"PHSend > PH=" + phVal+ ", V=" + voltsVal, runtime);
        //    PHLogController.Log(phVal);
        //    lblPH.Text = "PH: " + phVal;
        //    lblPH.ForeColor = Color.Green;
        //    if (phVal > _settings.PHSettings.HighValue)
        //    {
        //        SendEmailAlert("PH is High! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
        //        lblPH.ForeColor = Color.Red;
        //    }
        //    if (phVal < _settings.PHSettings.LowValue)
        //    {
        //        SendEmailAlert("PH is Low! - " + phVal, DateTime.Now.ToString() + " PH: " + phVal);
        //        lblPH.ForeColor = Color.Red;
        //    }

        //}

        //private void LogCommand(string text, TimeSpan runtime)
        //{
        //    string minSec = runtime.ToString(@"hh\:mm\:ss");
        //    text = minSec + " - "+ text;
        //    LogCommand(text);
        //}
        //private void LogCommand(string text)
        //{
        //    tbCmdLog.AppendLine(text, 100);
        //}

        //// Log received line to console
        //private void NewLineReceived(object sender, CommandEventArgs e)
        //{
        //    _isConnected = true;
        //    LogCommand(@"Received > " + e.Command.CommandString());
        //}

        //// Log sent line to console
        //private void NewLineSent(object sender, CommandEventArgs e)
        //{
        //    LogCommand(@"Sent > " + e.Command.CommandString());
        //}
    }
}
    

