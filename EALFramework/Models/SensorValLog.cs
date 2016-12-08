using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    //public class SensorValLog<T> : SensorValLog where T : SensorValLog, new()
    //{
    //    public SensorValLog() : base() { }
    //}
    public class SensorValLog
    {
        public DateTime LogDate { get; set; }
        [JsonIgnore]
        public double Val { get; set; }

        public SensorValLog()
        {
        }
        public SensorValLog(double val, DateTime logDate)
        {
            this.Val = val;
            this.LogDate = logDate;
        }

    }
}
