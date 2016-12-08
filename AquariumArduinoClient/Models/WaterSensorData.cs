using EALFramework.Controllers;
using EALFramework.Models;
using EALFramework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //"tdsOffset":2.00,
        //"reading":"ph",
        //"readingDur":"23s",
        //"readingInter":"600s"
        //"tdsVolts":"5.00",
        //"timeSinceLastDose":"61225s",
        //"tdsMin":"40",
        //"doseDurr":"2s",
        //"tdsSampleDurr":"3060"

            
        public string host { get; set; }
        [JsonProperty(PropertyName = "ph", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(0)]
        public double ph { get; set; }
        public double tds { get; set; }
        public double phOffset { get; set; }
        public double tdsOffset { get; set; }
        public string reading { get; set; }
        public string readingDur { get; set; }
        public string readingInter { get; set; }
        public double tdsVolts { get; set; }
        public string timeSinceLastDose { get; set; }
        public int tdsMin { get; set; }
        public string doseDurr { get; set; }
        public int tdsSampleDurr { get; set; }

        public static WaterSensorData Deserialize(string json)
        {
            var settings = Helpers.GetSerializerSettings();

            WaterSensorData obj = JsonConvert.DeserializeObject<WaterSensorData>(json, settings);
            return obj;
        }
        public static WaterSensorData Log(string json, bool isROSensor = false, bool hasPHSensor = true)
        {
            WaterSensorData data = Deserialize(json);

            if (!hasPHSensor)
            {
                int readingDurr = data.readingDur.ConvSecString();
                int readingInter = data.readingInter.ConvSecString();

                double minReadingTime = readingInter * .60; // has been reading tds for 70% of time.
                if (readingDurr >= minReadingTime)
                {
                    //log tds
                    if (data.tds >= 10 && data.tds <= 500)
                    {
                        WaterSensorController.Log<TDSLog>(data.tds, isROSensor);
                    }
                }
            }
            else if (data.reading == "ph")
            {
                //log tds
                if (data.tds >= 10 && data.tds <= 500)
                {
                    WaterSensorController.Log<TDSLog>(data.tds, isROSensor);
                }
            }
            else
            {
                //log ph
                if (data.ph >= 2 && data.ph <= 9.4)
                {
                    WaterSensorController.Log<PHLog>(data.ph, isROSensor);
                }
            }
            return data;
        }
    }
}
