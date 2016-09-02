using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumArduinoClient.Models
{
    public class PHLog
    {
        private int _saveEveryMin = 5;
        private int _maxLogs = 1000;
        private DateTime _lastSave;
       
        public DateTime LogDate { get; set; }
        public double PhVal { get; set; }

        private List<PHLog> _logs = new List<PHLog>();

        public PHLog()
        {
        }
        private PHLog(double phVal, DateTime logDate)
        {
            this.PhVal = phVal;
            this.LogDate = logDate;
        }

        public void Log(double phVal)
        {
            if (DateTime.Now > _lastSave.AddMinutes(_saveEveryMin))
            {
                if (_logs.Count > _maxLogs)
                {
                    _logs.RemoveRange(0, _maxLogs / 2);
                }
                _logs.Add(new PHLog { LogDate = DateTime.Now, PhVal = phVal });
                _lastSave = DateTime.Now;
            }
        }
        public double GetHourlyPh()
        {
            double phAverage = 0;
            var hourlyPhLogs = _logs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day &&
                x.LogDate.Hour == DateTime.Now.Hour);

            phAverage = GetAverage(hourlyPhLogs);

            return phAverage;
        }
        public double GetDailyPh()
        {
            double phAverage = 0;

            var dailyPhLogs = _logs.FindAll(x =>
                x.LogDate.Day == DateTime.Now.Day);

            phAverage = GetAverage(dailyPhLogs);

            return phAverage;
        }
        private double GetAverage(List<PHLog> logs)
        {
            double phAverage = 0;
            double sum = logs.Sum(x => x.PhVal);
            phAverage = sum / logs.Count;

            return phAverage;
        }

        public void TestPhLogs()
        {
            var now = DateTime.Now;
            var phStart = 5.0;
            var samples = 1100;
            for(int i = 0;  i < samples; i++) {
                string dec = "1." + i;
                double aDec = double.Parse(dec);
                var phVal = phStart * aDec;
                var pastDate = DateTime.Now.AddMinutes(_saveEveryMin * i * -1);
                _logs.Add(new PHLog(phVal, pastDate));
            }
            
            var hourlyAvg = GetHourlyPh();
            var dailyAvg = GetDailyPh();

        }
    }
}
