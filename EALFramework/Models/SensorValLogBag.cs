using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class SensorValLogBag<T> where T: SensorValLog
    {
        public string AquariumFilePrefix;
        public string RoFilePrefix = "ROSensor_";

        public DateTime LastSave;
        //public List<SensorValLog> RawLogs;
        public List<T> RawLogs;
        public string LogFile;
        public bool IsTdsVal;
        public bool IsRoSensor;

        public SensorValLogBag(string aquariumName)
        {
            AquariumFilePrefix = aquariumName + "_";
        }

    }
}
