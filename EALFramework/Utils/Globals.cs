using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EALFramework.Utils
{
    public class Globals
    {
        public static string UserSettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AquariumArduinoClient";
        public static string AppDir;
        public static string PHLogFileName = "PHLog.json";
        public static double SavePHLogEveryMin = 5;
        public static int MaxPHLogs = 1000;
    }
}
