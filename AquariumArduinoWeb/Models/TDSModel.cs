﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquariumArduinoWeb.Models
{
    public class TDSModel
    {
        public SampleFrequency Frequency { get; set; }
        public List<double> TDSVal { get; set; }
        public List<string> SampleDate { get; set; }
        public double CurrentTDS{ get; set; }
        public double DailyAvgTDS { get; set; }
        public double WeeklyAvgTDS { get; set; }

        public List<double> TDSDailyVal { get; set; }
        public List<string> SampleDay { get; set; }
    }
}