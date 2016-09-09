using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AquariumArduinoClient.Utilities;
using AquariumArduinoClient.Models;
using System.Threading;
using EALFramework.Utils;
using EALFramework.Models;
using EALFramework.Controllers;

namespace AquariumArduinoClient.Test
{
    [TestClass]
    public class PHLogTest
    {
        Settings _settings = Settings.Get();

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
                var pastDate = DateTime.Now.AddMinutes(Globals.SavePHLogEveryMin * i * -1);
                PHLogController._rawLogs.Add(new PHLog(phVal, pastDate));
            }

            var hourlyAvg = PHLogController.GetHourlyPhAverage();
            var dailyAvg = PHLogController.GetDailyPh();
            
        }

        [TestMethod]
        public void TestPhLogToFile()
        {
            Globals.SavePHLogEveryMin = 1;
            var phStart = 5.0;
            var samples = 10;
            for (int i = 0; i < samples; i++)
            {
                string dec = "1." + i;
                double aDec = double.Parse(dec);
                var phVal = phStart * aDec;
                PHLogController.Log(phVal);
                Thread.Sleep((int)Globals.SavePHLogEveryMin * 60 * 1000 + 500);
            }

            var phLogs = PHLogController.GetLogs();
            Assert.IsTrue(phLogs.Count > 0);

        }

    }
}
