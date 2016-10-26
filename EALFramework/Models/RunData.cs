using EALFramework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class RunData
    {
        public string host;
        public int accType;
        public int lastRun;
        public int nextRun;
        public int countDown;
        public int runEvery;
        public int shakesOrTurns;
        public int lastSave;
        public bool enabled;
        public int runDurration;
        public int updated;

        public DateTime GetLastRun()
        {
            var t = lastRun.ConvArduinoTimeToDT();
            return t;
        }
        public DateTime GetNextRun()
        {
            var nr = nextRun.ConvArduinoTimeToDT();
            return nr;
        }
        public void SetNextRun(DateTime val)
        {
            var nextRun = val.ConvDTToArduinoTime();
        }
        public DateTime GetLastSave()
        {
            var t = lastSave.ConvArduinoTimeToDT();
            return t;
        }
        public TimeSpan GetCountDown()
        {
            var t = countDown.ConvArduinoTimeToTS();
            return t;
        }
        public TimeSpan GetRunDurration()
        {
            var t = runDurration.ConvArduinoTimeToTS();
            return t;
        }
        public TimeSpan GetRunEvery()
        {
            var t = runEvery.ConvArduinoTimeToTS();
            return t;
        }
    }
    public class RunDataMessage
    {

        public string msg { get; set; }


        public static RunDataMessage Deserialize(string json)
        {
            RunDataMessage obj = JsonConvert.DeserializeObject<RunDataMessage>(json);
            return obj;
        }

    }
}
