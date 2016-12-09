using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Newtonsoft.Json;
using EALFramework.Utils;
using System.Threading;
using EALFramework.Models;

namespace EALFramework.Utils
{
    public class Settings
    {
        
        public PHSettings PHSettings;
        public TDSSettings TDSSettings;
        public string UserSettingsDir;
        public string AppDir;
        public string SensorIP;
        public string ROSensorIP;
        public string ControllerIP;
        public int GetSensorValsEvery;
        public int GetControllerValsEvery;
        public int GetROSensorValsEvery;
        public List<NameValue<string, int>> AquariumNames = new List<NameValue<string, int>>();
        //public const string DefaultOpenVPNDirectory = @"C:\Program Files (x86)\OpenVPN";
        //public const string DefaultVPNBookConfigDownload = @"http://www.vpnbook.com/free-openvpn-account/VPNBook.com-OpenVPN-Euro1.zip";
        //public const string DefaultVPNBookCredsPage = @"http://www.vpnbook.com/freevpn";
        //public const string DefaultGoogleDNSPrimary = @"8.8.8.8";
        //public const string DefaultGoogleDNSSecondary = @"8.8.4.4";
        //public const string DefaultOpenDNSPrimary = @"208.67.222.222";
        //public const string DefaultOpenDNSSecondary = @"208.67.220.220";
        //public const string DefaultComodoDNSPrimary = @"8.26.56.26";
        //public const string DefaultComodoDNSSecondary = @"8.20.247.20";
        //public const string BlockedVpnBookProxyText = @"block.opendns";
        //public const string BrowserProxy = "127.0.0.1";
        //public const string ChromeExe = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        //public const string FirefoxExe = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
        //public const string ChromeWebRTCExtensionUrl = @"https://chrome.google.com/webstore/detail/webrtc-leak-prevent/eiadekoaikejlgdbkbdfeijglgfdalml?hl=en";

        //public const string ChromeKProxyExtensionUrl = @"https://chrome.google.com/webstore/detail/kproxy-extension/gdocgbfmddcfnlnpmnghmjicjognhonm";
        //public const string IPLeakUrl = @"http://www.ipleak.net";
        //public const string OpenVPNDownloadUrl = @"https://openvpn.net/index.php/open-source/downloads.html";
        //public const string FirefoxKProxyExtensionUrl = @"https://addons.mozilla.org/es/firefox/addon/kproxy-extension/";
        //public const string TorBrowserDownloadUrl = @"https://www.torproject.org/download/download-easy.html.en";
        //public const string PeerBlockDownloadUrl = @"http://www.peerblock.com/releases";
        //public const string CCCleanerDownloadUrl = @"https://www.piriform.com/ccleaner/download";
        //public const string QBittorrentUrl = @"http://www.qbittorrent.org/download.php";
        //public static string CPortsDownloadUrl = @"http://www.nirsoft.net/utils/cports.html";


        ////[DisplayName("OpenVPN Directory")]
        //public string OpenVPNDirectory { get; set; }
        //public string OpenVPNConfig { get; set; }
        //public string VPNBookUsername { get; set; }
        //public string VPNBookPassword { get; set; }
        //public string PrimaryDNS { get; set; }
        //public string SecondaryDNS { get; set; }
        //public bool DontResetDNS { get; set; }
        //public List<NetworkAdapterDns> StartupNetworkAdapterDns { get; set; }
        //public List<KeyValue> OpenVPNConfigs { get; set; }
        //public bool EnableTorProxyForChrome { get; set; }
        //public VPNService VPNServer { get; set; }
        //public bool RetrieveVPNBookCredsOnLoad { get; set; }
        //public bool SplitRoute { get; set; }
        //public string VPNGateServerHost { get; set; }
        //public FileTransfer MediaFileTransfer { get; set; }
        //public Models.MediaServer MediaServer { get; set; }
        ////public List<FileTransfer> MediaFileTransferQue { get; set; }
        //public bool PreventSystemSleep { get; set; }
        //public VPNGateServer SelectedVPNGateServer { get; set; }
        //public bool RetryVPNGateConnect { get; set; }
        //public string ExcludedFolderFromMediaTransfer { get; set; }

        private static Settings _settings;

        //private static void EnsureAppDataSettings()
        //{

        //    //if (String.IsNullOrEmpty(_settings.UserSettingsDir) ||
        //    //    String.IsNullOrEmpty(_settings.AppDir))
        //    //{
        //    //    _settings.UserSettingsDir = Application.UserAppDataPath;
        //    //    _settings.AppDir = Application.StartupPath;
        //    //    Save(_settings);

        //    //}
        //    string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AquariumArduinoClient";
        //    if (_settings == null &&
        //        String.IsNullOrEmpty(Globals.UserSettingsDir) ||
        //       String.IsNullOrEmpty(Globals.AppDir))
        //    {
        //        Globals.UserSettingsDir = Application.UserAppDataPath;
        //        Globals.AppDir = Application.StartupPath;
        //    }
        //    else if (_settings != null &&
        //       String.IsNullOrEmpty(_settings.UserSettingsDir) ||
        //      String.IsNullOrEmpty(_settings.AppDir))
        //    {
        //        _settings.UserSettingsDir = Application.UserAppDataPath;
        //        _settings.AppDir = Application.StartupPath;

        //        Save(_settings);
        //    }
        //    if (_settings != null &&
        //     String.IsNullOrEmpty(Globals.UserSettingsDir) ||
        //    String.IsNullOrEmpty(Globals.AppDir))
        //    {
        //        Globals.UserSettingsDir = _settings.UserSettingsDir;
        //        Globals.AppDir = _settings.AppDir;
        //    }
        //}

        public static Settings Get()
        {
            // Create a file that the application will store user specific data in.
            if (_settings != null)
            {
                //FillOPNVPNConfigs();
                return _settings;
            }

            _settings = FileIO.GetJsonObject<Settings>("settings.json");

            if (_settings.PHSettings == null)
            {
                _settings.PHSettings = new Models.PHSettings { HighValue = 7.0, LowValue = 6.2, Offset = 1.1 };
            }
            if (_settings.TDSSettings == null)
            {
                _settings.TDSSettings = new Models.TDSSettings { HighValue = 220, LowValue = 180, Offset = 340 };
            }
            //if (string.IsNullOrWhiteSpace(_settings.OpenVPNDirectory))
            //{
            //    _settings.OpenVPNDirectory = DefaultOpenVPNDirectory;
            //}
            //if (_settings.VPNServer == null)
            //{
            //    _settings.VPNServer = new VPNService() { VPNBook = true };
            //    _settings.RetrieveVPNBookCredsOnLoad = true;
            //}
            //if (_settings.MediaFileTransfer == null)
            //{
            //    _settings.MediaFileTransfer = new FileTransfer();
            //}
            //if (_settings.MediaServer == null)
            //{
            //    _settings.MediaServer = new Models.MediaServer();
            //}
            //if (_settings.MediaFileTransferQue == null)
            //{
            //    _settings.MediaFileTransferQue = new List<FileTransfer>();
            //}
            return _settings;
        }

       
        public static async void Save(Settings settings)
        {


            
                //await WriteTextToLog();
                await FileIO.SaveJsonObject(settings, "settings.json");

           

            _settings = settings;
            //if (string.IsNullOrWhiteSpace(settings.OpenVPNDirectory))
            //{
            //    settings.OpenVPNDirectory = DefaultOpenVPNDirectory;
            //}

            //Logging.Log("Saved Settings To: " + UserSettingsDir);
            //MessageBox.Show("Saved Settings To: " + UserSettingsDir);





        }
    }
}
