using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquariumArduinoWeb.Models
{
    public enum SampleFrequency
    {
        Raw,
        Hourly,
        Daily,
        Weekly
    }
    public class WaterSensorModel
    {
        public WaterSensorModel()
        {
            PHModel = new PHModel();
            TDSModel = new TDSModel();
        }
        public SampleFrequency Frequency { get; set; }
        public PHModel PHModel { get; set; }
        public TDSModel TDSModel { get; set; }

    }
}