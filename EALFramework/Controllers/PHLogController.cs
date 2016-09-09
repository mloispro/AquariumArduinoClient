
using EALFramework.Models;
using EALFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Controllers
{
    public static class PHLogController
    {
        
        private static DateTime _lastSave;

        public static List<PHLog> _rawLogs = new List<PHLog>();

        public static void Log(double phVal)
        {
            if (DateTime.Now > _lastSave.AddMinutes(Globals.SavePHLogEveryMin))
            {
                if (_rawLogs.Count > Globals.MaxPHLogs)
                {
                    _rawLogs.RemoveRange(0, Globals.MaxPHLogs / 2);
                }

                var log = new PHLog { LogDate = DateTime.Now, PhVal = phVal };
                _rawLogs.Add(log);

                //log hourly avg to file.
                var hourlyPHAverage = GetHourlyPhAverage();
                var phLogFileEntry = new PHLog { LogDate = DateTime.Now, PhVal = hourlyPHAverage };
                var phFileLogs = GetLogs();
                phFileLogs.Add(phLogFileEntry);

                FileIO.SaveJson(phFileLogs, Globals.PHLogFileName); 
                _lastSave = DateTime.Now;
            }
        }
        public static List<PHLog> GetLogs()
        {
            var logs = FileIO.GetJson<PHLog>(Globals.PHLogFileName);
            return logs;
        }

        public static List<PHLog> GetHourlyPhLogs()
        {
            var hourlyPhLogs = _rawLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day &&
                x.LogDate.Hour == DateTime.Now.Hour);

            return hourlyPhLogs;
        }

        public static double GetHourlyPhAverage()
        {
            double phAverage = 0;
            var hourlyPhLogs = GetHourlyPhLogs();

            phAverage = GetAverage(hourlyPhLogs);

            return phAverage;
        }

        public static double GetDailyPh()
        {
            double phAverage = 0;

            var dailyPhLogs = _rawLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day);

            phAverage = GetAverage(dailyPhLogs);

            return phAverage;
        }
        private static double GetAverage(List<PHLog> logs)
        {
            double phAverage = 0;
            double sum = logs.Sum(x => x.PhVal);
            phAverage = sum / logs.Count;

            return phAverage;
        }

       
    }
}
