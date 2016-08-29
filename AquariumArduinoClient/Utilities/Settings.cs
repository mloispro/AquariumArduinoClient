using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AquariumArduinoClient.Models;

namespace AquariumArduinoClient.Utilities
{
    public class Settings
    {
        public static string UserSettingsDir = Application.UserAppDataPath;
        public static string AppDir = Application.StartupPath;

        public PHSettings PHSettings;
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
        
        public static Settings Get()
        {
            
            // Create a file that the application will store user specific data in.
            if (_settings != null)
            {
                //FillOPNVPNConfigs();
                return _settings;
            }

            _settings = Settings.GetJsonObject<Settings>("settings.json");
            if (_settings.PHSettings==null)
            {
                _settings.PHSettings = new Models.PHSettings { HighValue = 7.0, LowValue = 6.2, Offset = 1.1 };
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

        public static void Save(Settings settings)
        {
            //if (string.IsNullOrWhiteSpace(settings.OpenVPNDirectory))
            //{
            //    settings.OpenVPNDirectory = DefaultOpenVPNDirectory;
            //}
            Settings.SaveJsonObject(settings, "settings.json");
            //Logging.Log("Saved Settings To: " + UserSettingsDir);
            //MessageBox.Show("Saved Settings To: " + UserSettingsDir);
            _settings = settings;
        }

        public static void SaveJson<T>(List<T> list, string filename)
        {
            //var binDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            
            var file = UserSettingsDir + @"\" + filename;

            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }
            //clear file
            File.WriteAllText(file, String.Empty);

            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(file, json);

        }
        public static List<T> GetJson<T>(string filename)
        {
            
          
            var file = UserSettingsDir + @"\" + filename;

            List<T> list = new List<T>();
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }
            else
            {
                if (new FileInfo(file).Length == 0)
                {
                    return list;
                }
            }

            list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file));
            if (list == null) list = new List<T>();
            return list;
        }
        public static T GetJsonObject<T>(string filename) where T : new()
        {
           
            var file = UserSettingsDir + @"\" + filename;

            T obj = new T();
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }
            else
            {
                if (new FileInfo(file).Length == 0)
                {
                    return obj;
                }
            }
            try
            {
                obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
            catch
            {
                File.WriteAllText(file, "");
            }
            if (obj == null) obj = new T();
            return obj;
        }
        public async static Task SaveJsonObject<T>(T obj, string filename)
        {
            //var binDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
          
            var file = UserSettingsDir + @"\" + filename;

            await Task.Factory.StartNew(() =>
            {
                
                FileIO.EnsureFileClosed(file).Wait();

                //create bakup
                if (File.Exists(file))
                {
                    string bakFile = file + "_bak";
                    if (File.Exists(bakFile))
                    {
                        FileIO.EnsureFileClosed(bakFile).Wait();
                        File.Delete(bakFile);
                    }

                    if (!File.Exists(bakFile))
                        File.Create(bakFile).Close();
            
                    FileIO.EnsureFileClosed(bakFile).Wait();
                    File.Copy(file, bakFile, true);
                    //MessageBox.Show("created bak: " + bakFile);
                }
               
                File.Delete(file);

                bool isSerialized = false;
                string json = "";
                while (!isSerialized)
                {
                    try
                    {

                        json = JsonConvert.SerializeObject(obj);
                        isSerialized = true;
                    }
                    catch
                    {
                        isSerialized = false; 
                        Task.Delay(100).Wait();
                    }
                }
                
                File.WriteAllText(file, json);
            });

        }
        //private static void FillOPNVPNConfigs()
        //{
        //    //string configDir = _settings.OpenVPNDirectory + @"\config";
        //    //_settings.OpenVPNConfigs = new List<KeyValue>();

        //    //var ext = new List<string> { ".ovpn" };
        //    //var configFiles = Directory.GetFiles(configDir, "*.*", SearchOption.AllDirectories)
        //    //     .Where(s => ext.Any(e => s.EndsWith(e)));

        //    //if (configFiles.Count() == 0)
        //    //{
        //    //    var config = File.Create(configDir + @"\" + VPNGate.VpnGateConifg);
        //    //    FileIO.FileClose(config);
        //    //}

        //    //foreach (var file in configFiles)
        //    //{
        //    //    var fileName = Path.GetFileName(file);
        //    //    if (!_settings.OpenVPNConfigs.Any(x => x.Key == fileName))
        //    //    {
        //    //        _settings.OpenVPNConfigs.Add(new KeyValue { Key = fileName, Value = file });
        //    //    }
        //    //}
        //}
    }
}
