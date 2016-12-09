using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class PHSettings
    {
        public double LowValue { get; set; }
        public double HighValue { get; set; }
        public double Offset { get; set; }
        //private static List<Apps> _apps;

        //public static void Save(List<Apps> apps)
        //{
        //    apps.RemoveAll(x => string.IsNullOrWhiteSpace(x.Program));
        //    // apps.ForEach(x => x.Program = x.Program.Replace("\"", ""));
        //    Settings.SaveJson(apps, "apps.json");

        //    Logging.Log("Saved Apps To: " + Settings.UserSettingsDir);
        //    _apps = apps;
        //}
        //public static List<Apps> Get()
        //{
        //    if (_apps != null && _apps.Count() > 0)
        //    {
        //        //_apps.ForEach(x => x.Program = x.Program.Replace("\"", ""));
        //        return _apps;
        //    }

        //    _apps = Settings.GetJson<Apps>("apps.json");

        //    if (_apps == null && _apps.Count == 0)
        //    {
        //        Apps chrome = new Apps() { Program = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" };
        //        _apps = new List<Apps>();
        //        _apps.Add(chrome);
        //        Save(_apps);
        //    }
        //    // _apps.ForEach(x => x.Program = x.Program.Replace("\"", ""));
        //    return _apps;
        //}
    }
}
