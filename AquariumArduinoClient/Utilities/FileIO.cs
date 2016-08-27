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


namespace AquariumArduinoClient.Utilities
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
        public static void FileClose(FileStream file)
        {
            file.Close();
            EnsureFileClosed(file.Name);
        }
        public static void EnsureFileClosed(string filename)
        {
            while (!FileIO.IsFileClosed(filename))
            {
                Task.Delay(300).Wait();
            }
        }
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
                Logging.Log("Error: Folder not available : " + folderName);
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
                    Logging.LogError(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
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
                Logging.LogError(ex.Message);
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
                Logging.LogError(ex.Message);
            }
        }
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
