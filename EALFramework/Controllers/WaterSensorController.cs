
using EALFramework.Models;
using EALFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Controllers
{
    public static class WaterSensorController
    {
        public static double CurrentPH { private set; get; }
        public static double CurrentTDS { private set; get; }

        private static DateTime _lastPhSave;
        private static DateTime _lastTdsSave;

        public static List<PHLog> _rawPHLogs = new List<PHLog>();
        public static List<TDSLog> _rawTdsLogs = new List<TDSLog>();

        public static void LogPh(double phVal)
        {
            if (DateTime.Now > _lastPhSave.AddMinutes(Globals.SaveLogEveryMin))
            {
                if (_rawPHLogs.Count > Globals.MaxLogs)
                {
                    _rawPHLogs.RemoveRange(0, Globals.MaxLogs / 2);
                }

                var log = new PHLog { LogDate = DateTime.Now, PhVal = phVal };
                _rawPHLogs = GetPHLogs();
                _rawPHLogs.Add(log);

                //log hourly avg to file.
                //var hourlyPHAverage = GetHourlyPhAverage();
                //var phLogFileEntry = new PHLog { LogDate = DateTime.Now, PhVal = hourlyPHAverage };
                //var phFileLogs = GetPHLogs();
                //phFileLogs.Add(phLogFileEntry);

                FileIO.SaveJson(_rawPHLogs, Globals.PHLogFileName); 
                _lastPhSave = DateTime.Now;
            }
        }
        public static List<PHLog> GetPHLogs()
        {
            var logs = FileIO.GetJson<PHLog>(Globals.PHLogFileName);
            if (logs.Count > 0)
                CurrentPH = logs.OrderBy(x=>x.LogDate).Last().PhVal;
            return logs;
        }
        public static void LogTds(double tdsVal)
        {
            if (DateTime.Now > _lastTdsSave.AddMinutes(Globals.SaveLogEveryMin))
            {
                if (_rawTdsLogs.Count > Globals.MaxLogs)
                {
                    _rawTdsLogs.RemoveRange(0, Globals.MaxLogs / 2);
                }

                var log = new TDSLog { LogDate = DateTime.Now, TdsVal = tdsVal };
                _rawTdsLogs = GetTDSLogs();
                _rawTdsLogs.Add(log);

                //log hourly avg to file.
                //var hourlyTdsAverage = GetHourlyTdsAverage();
                //var tdsLogFileEntry = new TDSLog { LogDate = DateTime.Now, TdsVal = hourlyTdsAverage };
                //var tdsFileLogs = GetTDSLogs();
                //tdsFileLogs.Add(tdsLogFileEntry);

                FileIO.SaveJson(_rawTdsLogs, Globals.TDSLogFileName);
                _lastTdsSave = DateTime.Now;
            }
        }
        public static List<TDSLog> GetTDSLogs()
        {
            var logs = FileIO.GetJson<TDSLog>(Globals.TDSLogFileName);
            if (logs.Count > 0)
                CurrentTDS = logs.OrderBy(x => x.LogDate).Last().TdsVal;
            return logs;
        }
        public static List<PHLog> GetHourlyPhLogs()
        {
            var hourlyPhLogs = _rawPHLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day &&
                x.LogDate.Hour == DateTime.Now.Hour);

            return hourlyPhLogs;
        }
        public static List<PHLog> GetHourlySummaryPHLogs()
        {

            _rawPHLogs = GetPHLogs();

            var logs = _rawPHLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, x.LogDate.Hour, 0, 0))
                  .Select(g => new PHLog
                  {
                      LogDate = g.Key,
                      PhVal = g.Average(i => i.PhVal)
                  }).OrderBy(x => x.LogDate).ToList();

            return logs;
        }
        public static List<TDSLog> GetHourlySummaryTdsLogs()
        {

            _rawTdsLogs = GetTDSLogs();

            var logs = _rawTdsLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, x.LogDate.Hour, 0, 0))
                  .Select(g => new TDSLog
                  {
                      LogDate = g.Key,
                      TdsVal = g.Average(i => i.TdsVal)
                  }).OrderBy(x => x.LogDate).ToList();

            return logs;
        }
        public static List<TDSLog> GetHourlyTdsLogs()
        {
            var logs = _rawTdsLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day &&
                x.LogDate.Hour == DateTime.Now.Hour);

            return logs;
        }

        public static double GetHourlyPhAverage()
        {
            double phAverage = 0;
            var hourlyPhLogs = GetHourlyPhLogs();

            phAverage = GetAveragePh(hourlyPhLogs);

            return phAverage;
        }
        public static double GetHourlyTdsAverage()
        {
            double avg = 0;
            var hourlyTdsLogs = GetHourlyTdsLogs();

            avg = GetAverageTds(hourlyTdsLogs);

            return avg;
        }

        public static double GetDailyPh()
        {
            double phAverage = 0;

            var dailyPhLogs = _rawPHLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day);

            phAverage = GetAveragePh(dailyPhLogs);

            return phAverage;
        }
        private static double GetAveragePh(List<PHLog> logs)
        {
            double phAverage = 0;
            double sum = logs.Sum(x => x.PhVal);
            phAverage = sum / logs.Count;

            return phAverage;
        }
        private static double GetAverageTds(List<TDSLog> logs)
        {
            double avg = 0;
            double sum = logs.Sum(x => x.TdsVal);
            avg = sum / logs.Count;

            return avg;
        }


    }
}
