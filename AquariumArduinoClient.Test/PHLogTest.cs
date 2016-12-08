using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AquariumArduinoClient.Utilities;
using AquariumArduinoClient.Models;
using System.Threading;
using EALFramework.Utils;
using EALFramework.Models;
using EALFramework.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace AquariumArduinoClient.Test
{
    [TestClass]
    public class PHLogTest
    {
        Settings _settings = Settings.Get();

        [TestMethod]
        public void TestGetHourlyLogs()
        {
            var phHourlyLogs = WaterSensorController.GetHourlySummaryPHLogs(2);
            List<PHLog> phDailyLogs = WaterSensorController.GetDailySummaryPhLogs();
            List<PHLog> phHourlyDailyLogs = new List<PHLog>();
            phHourlyDailyLogs.AddRange(phHourlyLogs);
            foreach (var hourlyLog in phHourlyDailyLogs)
            {
                var dailyLog = phDailyLogs.Find(x => x.LogDate.Day == hourlyLog.LogDate.Day);

                if (dailyLog != null)
                {
                    hourlyLog.PhVal = dailyLog.PhVal;
                }
            }
            //foreach (var hourlyLog in phHourlyLogs)
            //{
            //    var dailyLog = phDailyLogs.Find(x => x.LogDate == hourlyLog.LogDate);
               
            //    if (dailyLog != null)
            //    {
            //        phHourlyDailyLogs.Add(dailyLog);
            //    }
            //    else
            //    {
            //        phHourlyDailyLogs.Add(hourlyLog);
            //    }
            //}
            //var hourlyAvg = WaterSensorController.GetHourlyPhAverage();
            //var dailyAvg = WaterSensorController.GetDailyPh();

        }

        [TestMethod]
        public void TestPhHourlyDailyLogs()
        {
            var now = DateTime.Now;
            var phStart = 5.0;
            var samples = 1100;
            for (int i = 0; i < samples; i++)
            {
                string dec = "1." + i;
                double aDec = double.Parse(dec);
                var phVal = phStart * aDec;
                var pastDate = DateTime.Now.AddMinutes(Globals.SaveLogEveryMin * i * -1);
                WaterSensorController._rawPHLogs.Add(new PHLog { PhVal = phVal, LogDate = pastDate });
            }

            var hourlyAvg = WaterSensorController.GetHourlyPhAverage();
            var dailyAvg = WaterSensorController.GetDailyPh();
            
        }

        [TestMethod]
        public void TestPhLogToFile()
        {
            Globals.SaveLogEveryMin = 1;
            var phStart = 5.0;
            var samples = 10;
            for (int i = 0; i < samples; i++)
            {
                string dec = "1." + i;
                double aDec = double.Parse(dec);
                var phVal = phStart * aDec;
                WaterSensorController.Log<PHLog>(phVal);
                Thread.Sleep((int)Globals.SaveLogEveryMin * 60 * 1000 + 500);
            }

            var phLogs = WaterSensorController.GetLogs<PHLog>();
            Assert.IsTrue(phLogs.Count > 0);

        }

    }
}
