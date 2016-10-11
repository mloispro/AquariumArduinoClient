using EALFramework.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumArduinoClient.Models
{
    public class WaterSensorData
    {
        //        "host":"WaterSensor-1",
        //"ph":20.52,
        //"tds":0,
        //"phOffset":3.10,
        //"tdsOffset":1310,
        //"reading":"ph",
        //"readingDur":"23s",
        //"readingInter":"600s"
        public string host { get; set; }
        public double ph { get; set; }
        public double tds { get; set; }
        public double phOffset { get; set; }
        public int tdsOffset { get; set; }
        public string reading { get; set; }
        public string readingDur { get; set; }
        public string readingInter { get; set; }

        public static WaterSensorData Deserialize(string json)
        {
            WaterSensorData obj = JsonConvert.DeserializeObject<WaterSensorData>(json);
            return obj;
        }
        public static WaterSensorData Log(string json)
        {
            WaterSensorData data = Deserialize(json);

            if (data.reading == "ph")
            {
                //log tds
                WaterSensorController.LogTds(data.tds);
            }else
            {
                //lob ph
                WaterSensorController.LogPh(data.ph);
            }
            return data;
        }
    }
}
