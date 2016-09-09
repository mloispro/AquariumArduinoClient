using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using AquariumArduinoClient.Models;


namespace EALFramework.Utils
{
    public class FileIO : IDisposable
    {
      
        public static string GetTopLevelFolder(string path)
        {
            string folder = "";
            if (!path.Contains(@"\")) return folder;
            string[] split = path.Split(@"\".ToCharArray());
            if (split.Count() > 0) folder = GetPath(split[0]);
            return folder;
        }
        public static string GetPath(string fileOrDirPath)
        {
            bool isDirectory = false;
            try { isDirectory = IsDirectory(fileOrDirPath); }
            catch { return fileOrDirPath + @"\"; }

            if (!isDirectory)
            {
                fileOrDirPath = Path.GetDirectoryName(fileOrDirPath) + @"\";
            }
            if (isDirectory)
            {
                fileOrDirPath = fileOrDirPath.TrimEnd(@"\".ToCharArray());
                fileOrDirPath += @"\";
                fileOrDirPath = Path.GetDirectoryName(fileOrDirPath) + @"\";
            }
            return fileOrDirPath;
        }
        public static bool IsDirectory(string path)
        {
            System.IO.FileAttributes fa = System.IO.File.GetAttributes(path);
            bool isDirectory = false;
            if ((fa & FileAttributes.Directory) != 0)
            {
                isDirectory = true;
            }
            return isDirectory;
        }
        public async static Task FileClose(FileStream file)
        {
            file.Close();
            await EnsureFileClosed(file.Name);
        }
        public async static Task EnsureFileClosed(string filename)
        {
            bool isClosed = false;
            while (!isClosed)
            {
                isClosed = FileIO.IsFileClosed(filename);
                //Task.Delay(300).Wait();
                await Task.Delay(300);
            }
        }
        //public async static Task<bool> IsFileClosed(string filename)
        public static bool IsFileClosed(string filename)
        {
            try
            {
                using (var inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
        public static void ChangeFolderName(string folderName, string newFolderName)
        {

            if (folderName.Equals(newFolderName)) return;
            try
            {
                Directory.Move(folderName, newFolderName);
            }
            catch (Exception ex)
            {
                //Logging.Log("Error: Folder not available : " + folderName);
                throw ex;
            }
        }
      
        public static void CopyDirectory(string sourceDir, string targetDir, bool recursive=true)
        {
            try
            {
                string sourceDirName = sourceDir;
                string destDirName = targetDir;

                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                   // Logging.LogError(
                    //    "Source directory does not exist or could not be found: "
                    //    + sourceDirName);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (recursive)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        CopyDirectory(subdir.FullName, temppath, recursive);
                    }
                }
            }

            catch (Exception ex)
            {
                //Logging.LogError(ex.Message);
            }
        }
        public static void ForceDeleteDirectory(string path)
        {
            try
            {
                var directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

                foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
                {
                    info.Attributes = FileAttributes.Normal;
                }
                directory.Attributes = FileAttributes.Normal;

                directory.Delete(true);
                //Directory.Delete(path, true);
            }
            catch (Exception ex)
            {
                //Logging.LogError(ex.Message);
            }
        }

        public static void SaveJson<T>(List<T> list, string filename)
        {
            //var binDir = System.Reflection.Assembly.GetExecutingAssembly().Location;

            var file = Globals.UserSettingsDir + @"\" + filename;

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


            var file = Globals.UserSettingsDir + @"\" + filename;

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

            var file = Globals.UserSettingsDir + @"\" + filename;

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

            var file = Globals.UserSettingsDir + @"\" + filename;

            await Task.Factory.StartNew(() =>
            {

                

                //create bakup
                if (File.Exists(file))
                {
                    FileIO.EnsureFileClosed(file).Wait();
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

        #region Dispose

        private bool _disposed;
        ~FileIO()
        {
            Dispose(true);
        }

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }

                //ResetTransfers();
                _disposed = true;
            }

        }
        #endregion Dispose


    }

    public class FinshedFileTransferEventArgs : EventArgs
    {
        public string SourceFile{get;set;}
        //public string TargetFile{get;set;}

        //public FinshedFileTransferEventArgs(string sourceFile, string targetFile)
        //{
        //    SourceFile = sourceFile;
        //    TargetFile = targetFile;
        //}
        public FinshedFileTransferEventArgs(string sourceFile)
        {
            SourceFile = sourceFile;
            //TargetFile = targetFile;
        }
    }
    public class FileTransferProgressEventArgs : EventArgs
    {
        //public int TranserfedBytes { get; set; }
        //public int TotalBytes { get; set; }
        public string PercentComplete { get; set; }
        public string SourceFile { get; set; }

        //public FileTransferProgressEventArgs(int transferedBytes, int totalBytes)
        //{
        //    TranserfedBytes = transferedBytes;
        //    TotalBytes = totalBytes;
        //    PercentComplete = transferedBytes / totalBytes;
        //}
       // public FileTransferProgressEventArgs(double percentComplete, FileTransfer fileTransfer)
        public FileTransferProgressEventArgs(double percentComplete, string fileTransfer)
        {
            percentComplete = (int)Math.Round(percentComplete, 0);
            PercentComplete = percentComplete.ToString();
            SourceFile = fileTransfer;
            //SourceFile = Path.GetFileName(fileTransfer.SourceDirectory);
        }
        
    }
}
