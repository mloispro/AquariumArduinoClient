
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
        public static string CurrentAquariumName { set; get; }

        public static double CurrentPH { private set; get; }
        public static double CurrentTDS { private set; get; }

        public static double CurrentRoPh { private set; get; }
        public static double CurrentRoTds { private set; get; }

        private static DateTime _lastPhSave;
        private static DateTime _lastTdsSave;

        public static List<PHLog> _rawPHLogs = new List<PHLog>();
        public static List<TDSLog> _rawTdsLogs = new List<TDSLog>();

        private static DateTime _lastROPhSave;
        private static DateTime _lastROTdsSave;

        public static List<PHLog> _rawROPHLogs = new List<PHLog>();
        public static List<TDSLog> _rawROTdsLogs = new List<TDSLog>();

        public static SensorValLogBag<T> GetLogBag<T>(bool isROSensor = false) where T : SensorValLog
        {
            SensorValLogBag<T> bag = new SensorValLogBag<T>(CurrentAquariumName);
            bag.IsTdsVal = typeof(T) == typeof(TDSLog);
            bag.IsRoSensor = isROSensor;
            
            
            //string filePrefix = CurrentAquariumName + "_";
            //string roFilePrefix = "ROSensor_";

            //DateTime lastSave = _lastPhSave.AddMinutes(Globals.SaveLogEveryMin);//ph
            //List<SensorValLog> rawLogs = _rawPHLogs.Cast<SensorValLog>().ToList();//ph
            //string logFile = filePrefix + Globals.PHLogFileName;

            //bool isTdsVal = typeof(T) == typeof(TDSLog);

            if (bag.IsTdsVal)
            {
                bag.LastSave = _lastTdsSave.AddMinutes(Globals.SaveLogEveryMin);//tds
                bag.RawLogs = _rawTdsLogs.Cast<T>().ToList();//tds
                bag.LogFile = bag.AquariumFilePrefix + Globals.TDSLogFileName;
            }
            else
            {
                bag.LastSave = _lastPhSave.AddMinutes(Globals.SaveLogEveryMin);//ph
                bag.RawLogs = _rawPHLogs.Cast<T>().ToList();//ph
                bag.LogFile = bag.AquariumFilePrefix + Globals.PHLogFileName;
            }

            if (isROSensor)
            {

                if (bag.IsTdsVal)
                {
                    bag.LastSave = _lastROTdsSave.AddMinutes(Globals.SaveLogEveryMin);//tds
                    bag.RawLogs = _rawROTdsLogs.Cast<T>().ToList();//tds
                    bag.LogFile = bag.RoFilePrefix + Globals.TDSLogFileName;
                }
                else
                {
                    bag.LastSave = _lastROPhSave.AddMinutes(Globals.SaveLogEveryMin);
                    bag.RawLogs = _rawROPHLogs.Cast<T>().ToList();
                    bag.LogFile = bag.RoFilePrefix + Globals.PHLogFileName;
                }
            }

            return bag;
        }


        public static void Log<T>(double val, bool isROSensor=false) where T: SensorValLog, new()
        {
            //SensorValLogBag bag = new SensorValLogBag(CurrentAquariumName);
            //bag.LastSave = _lastPhSave.AddMinutes(Globals.SaveLogEveryMin);//ph
            //bag.RawLogs = _rawPHLogs.Cast<SensorValLog>().ToList();//ph
            //bag.LogFile = bag.AquariumFilePrefix + Globals.PHLogFileName;
            //bag.IsTdsVal = typeof(T) == typeof(TDSLog);
            //string filePrefix = CurrentAquariumName + "_";
            //string roFilePrefix = "ROSensor_";

            //DateTime lastSave = _lastPhSave.AddMinutes(Globals.SaveLogEveryMin);//ph
            //List<SensorValLog> rawLogs = _rawPHLogs.Cast<SensorValLog>().ToList();//ph
            //string logFile = filePrefix + Globals.PHLogFileName;

            //bool isTdsVal = typeof(T) == typeof(TDSLog);



            //if (bag.IsTdsVal)
            //{
            //    bag.LastSave = _lastTdsSave.AddMinutes(Globals.SaveLogEveryMin);//tds
            //    bag.RawLogs = _rawTdsLogs.Cast<SensorValLog>().ToList();//tds
            //    bag.LogFile = bag.AquariumFilePrefix + Globals.TDSLogFileName;
            //}

            //if (isROSensor)
            //{
            //    bag.LastSave = _lastROPhSave.AddMinutes(Globals.SaveLogEveryMin);
            //    bag.RawLogs = _rawROPHLogs.Cast<SensorValLog>().ToList();
            //    bag.LogFile = bag.RoFilePrefix + Globals.PHLogFileName;

            //    if (bag.IsTdsVal)
            //    {
            //        bag.LastSave = _lastROTdsSave.AddMinutes(Globals.SaveLogEveryMin);//tds
            //        bag.RawLogs = _rawROTdsLogs.Cast<SensorValLog>().ToList();//tds
            //        bag.LogFile = bag.RoFilePrefix + Globals.TDSLogFileName;
            //    }
            //}

            SensorValLogBag<T> bag = GetLogBag<T>(isROSensor);

            if (DateTime.Now > bag.LastSave)
            {
                if (bag.RawLogs.Count > Globals.MaxLogs)
                {
                    bag.RawLogs.RemoveRange(0, Globals.MaxLogs / 2);
                    FileIO.SaveJson(bag.RawLogs, bag.LogFile);
                }

                var log = new T(){ LogDate = DateTime.Now, Val = val };
                var logs = GetLogs<T>(isROSensor);

                bag.RawLogs = logs;//.Cast<SensorValLog>().ToList();
                bag.RawLogs.Add((T)log);

                //log hourly avg to file.
                //var hourlyPHAverage = GetHourlyPhAverage();
                //var phLogFileEntry = new PHLog { LogDate = DateTime.Now, PhVal = hourlyPHAverage };
                //var phFileLogs = GetPHLogs();
                //phFileLogs.Add(phLogFileEntry);

                FileIO.SaveJson<T>(bag.RawLogs, bag.LogFile);

                if (isROSensor)
                {
                    if (bag.IsTdsVal)
                    {
                        _lastROTdsSave = DateTime.Now;
                        _rawROTdsLogs = bag.RawLogs.Select(l => new TDSLog { LogDate = l.LogDate, TdsVal = l.Val }).ToList();
                    }
                    else
                    {
                        _lastROPhSave = DateTime.Now;
                        _rawROPHLogs = bag.RawLogs.Select(l => new PHLog { LogDate = l.LogDate, PhVal = l.Val }).ToList();
                    }
                }
                else
                {
                    if (bag.IsTdsVal)
                    {
                        _lastTdsSave = DateTime.Now;
                        _rawTdsLogs = bag.RawLogs.Select(l => new TDSLog { LogDate = l.LogDate, TdsVal = l.Val }).ToList();
                    }
                    else
                    {
                        _lastPhSave = DateTime.Now;
                        _rawPHLogs = bag.RawLogs.Select(l => new PHLog { LogDate = l.LogDate, PhVal = l.Val }).ToList();
                    }
                }


            }
        }
        
        public static List<T> GetLogs<T>(bool isROSensor = false) where T : SensorValLog
        {
            SensorValLogBag<T> bag = GetLogBag<T>(isROSensor);

            List<T> logs = FileIO.GetJson<T>(bag.LogFile);
            if (logs.Count > 0)
            {
                if (isROSensor)
                {
                    if (bag.IsTdsVal)
                    {
                        CurrentRoTds = logs.OrderBy(x => x.LogDate).Last().Val;
                    }
                    else
                    {
                        CurrentRoPh = logs.OrderBy(x => x.LogDate).Last().Val;
                    }
                }
                else
                {
                    if (bag.IsTdsVal)
                    {
                        CurrentTDS = logs.OrderBy(x => x.LogDate).Last().Val;
                    }
                    else
                    {
                        CurrentPH = logs.OrderBy(x => x.LogDate).Last().Val;
                    }
                }


            }

            return logs;
            //var cnvLogs = logs.Select(x => new SensorValLog { LogDate = x.LogDate, Val = x.Val }).ToList();
            //var cnvLogs2 = cnvLogs.Cast<T>().ToList();
            //return cnvLogs2;

            //var logs = _rawPHLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, 0, 0, 0))
            //     .Select(g => new PHLog
            //     {
            //         LogDate = g.Key,
            //         PhVal = g.Average(i => i.PhVal)
            //     }).OrderBy(x => x.LogDate).ToList();
        }


        //public static void LogTds(double tdsVal, bool isROSensor = false)
        //{

        //    if (DateTime.Now > _lastTdsSave.AddMinutes(Globals.SaveLogEveryMin))
        //    {
        //        if (_rawTdsLogs.Count >= Globals.MaxLogs)
        //        {
        //            //prune
        //            _rawTdsLogs.RemoveRange(0, Globals.MaxLogs / 2);
        //            FileIO.SaveJson(_rawTdsLogs, Globals.TDSLogFileName);
        //        }

        //        var log = new TDSLog { LogDate = DateTime.Now, TdsVal = tdsVal };
        //        _rawTdsLogs = GetTDSLogs();
        //        _rawTdsLogs.Add(log);

        //        //log hourly avg to file.
        //        //var hourlyTdsAverage = GetHourlyTdsAverage();
        //        //var tdsLogFileEntry = new TDSLog { LogDate = DateTime.Now, TdsVal = hourlyTdsAverage };
        //        //var tdsFileLogs = GetTDSLogs();
        //        //tdsFileLogs.Add(tdsLogFileEntry);

        //        FileIO.SaveJson(_rawTdsLogs, Globals.TDSLogFileName);
        //        _lastTdsSave = DateTime.Now;
        //    }
        //}
        //public static List<TDSLog> GetTDSLogs()
        //{
        //    var logs = FileIO.GetJson<TDSLog>(Globals.TDSLogFileName);
        //    if (logs.Count > 0)
        //        CurrentTDS = logs.OrderBy(x => x.LogDate).Last().TdsVal;
        //    return logs;
        //}

        public static List<PHLog> GetHourlyPhLogs()
        {
            var hourlyPhLogs = _rawPHLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day &&
                x.LogDate.Hour == DateTime.Now.Hour);

            return hourlyPhLogs;
        }
        //todo: change this to List<T>
        public static List<PHLog> GetDailySummaryPhLogs()
        {

            _rawPHLogs = GetLogs<PHLog>();

            var logs = _rawPHLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, 0, 0, 0))
                  .Select(g => new PHLog
                  {
                      LogDate = g.Key,
                      PhVal = g.Average(i => i.PhVal)
                  }).OrderBy(x => x.LogDate).ToList();

            return logs;
        }
        public static List<PHLog> GetHourlySummaryPHLogs(int numOfDays)
        {

            _rawPHLogs = GetLogs<PHLog>();

            var logs = _rawPHLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, x.LogDate.Hour, 0, 0))
                  .Select(g => new PHLog
                  {
                      LogDate = g.Key,
                      PhVal = g.Average(i => i.PhVal)
                  })
                  .Where(x => x.LogDate >= DateTime.Now.Date.AddDays(numOfDays * -1))
                  .OrderBy(x => x.LogDate).ToList();

            return logs;
        }
        public static List<TDSLog> GetDailySummaryTdsLogs()
        {

            _rawTdsLogs = GetLogs<TDSLog>();

            var logs = _rawTdsLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, 0, 0, 0))
                  .Select(g => new TDSLog
                  {
                      LogDate = g.Key,
                      TdsVal = g.Average(i => i.TdsVal)
                  }).OrderBy(x => x.LogDate).ToList();

            return logs;
        }
        public static List<TDSLog> GetHourlySummaryTdsLogs(int numOfDays)
        {

            _rawTdsLogs = GetLogs<TDSLog>();

            var logs = _rawTdsLogs.GroupBy(x => new DateTime(x.LogDate.Year, x.LogDate.Month, x.LogDate.Day, x.LogDate.Hour, 0, 0))
                  .Select(g => new TDSLog
                  {
                      LogDate = g.Key,
                      TdsVal = g.Average(i => i.TdsVal)
                  })
                  .Where(x=>x.LogDate >= DateTime.Now.Date.AddDays(numOfDays*-1))
                  .OrderBy(x => x.LogDate).ToList();

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
        public static double GetDailyTds()
        {
            double avg = 0;

            var logs = _rawTdsLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day);

            avg = GetAverageTds(logs);

            return Math.Round(avg,0);
        }
        public static double GetWeeklyTds()
        {
            double avg = 0;

            var logs = _rawTdsLogs.FindAll(x =>
                x.LogDate >= DateTime.Now.Date.AddDays(-7));

            avg = GetAverageTds(logs);

            return Math.Round(avg, 0);
        }
        public static double GetDailyPh()
        {
            double avg = 0;

            var dailyPhLogs = _rawPHLogs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day);

            avg = GetAveragePh(dailyPhLogs);

            return Math.Round(avg, 2);
        }
        public static double GetWeeklyPh()
        {
            double avg = 0;

            var logs = _rawPHLogs.FindAll(x =>
                x.LogDate >= DateTime.Now.Date.AddDays(-7));

            avg = GetAveragePh(logs);

            return Math.Round(avg, 2);
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
