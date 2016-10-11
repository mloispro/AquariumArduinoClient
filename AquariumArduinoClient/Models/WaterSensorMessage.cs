using EALFramework.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumArduinoClient.Models
{
    public class WaterSensorMessage
    {
        
        public string msg { get; set; }


        public static WaterSensorMessage Deserialize(string json)
        {
            WaterSensorMessage obj = JsonConvert.DeserializeObject<WaterSensorMessage>(json);
            return obj;
        }
        
    }
}
