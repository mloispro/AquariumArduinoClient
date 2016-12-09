
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chart.Mvc.ComplexChart;
using EALFramework.Models;
using AquariumArduinoWeb.Models;
using AquariumArduinoWeb.Utils;
using EALFramework.Utils;


namespace EALFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tanks = Settings.Get().AquariumNames;
            WaterSensorController.CurrentAquariumName = tanks.First().Name;
            return View();
        }
        public ActionResult _SensorCharts()
        {
            return PartialView("_SensorCharts",PopulateModel());
        }

        private WaterSensorModel PopulateModel()
        {
            WaterSensorModel model = new WaterSensorModel();

            List<PHLog> phLogs = WaterSensorController.GetHourlySummaryPHLogs(2);

            model.PHModel.Frequency = SampleFrequency.Hourly;
            model.PHModel.SampleDate = phLogs.Select(x => string.Format("{0:htt}", x.LogDate)).ToList();
            model.PHModel.PHVal = phLogs.Select(x => Math.Round(x.PhVal, 2)).ToList();
            model.PHModel.CurrentPH = WaterSensorController.CurrentPH;
            model.PHModel.DailyAvgPH = WaterSensorController.GetDailyPh();
            model.PHModel.WeeklyAvgPH = WaterSensorController.GetWeeklyPh();

            //daily summary
            List<PHLog> phDailyLogs = WaterSensorController.GetDailySummaryPhLogs();
            model.PHModel.SampleDay = phDailyLogs.Select(x => string.Format("{0:d}", x.LogDate)).ToList();
            model.PHModel.PHDailyVal = phDailyLogs.Select(x => Math.Round(x.PhVal, 2)).ToList();

            List<TDSLog> tdsLogs = WaterSensorController.GetHourlySummaryTdsLogs(2);

            model.TDSModel.Frequency = SampleFrequency.Hourly;
            model.TDSModel.SampleDate = tdsLogs.Select(x => string.Format("{0:htt}", x.LogDate)).ToList();
            model.TDSModel.TDSVal = tdsLogs.Select(x => Math.Round(x.TdsVal, 0)).ToList();
            model.TDSModel.CurrentTDS = WaterSensorController.CurrentTDS;
            model.TDSModel.DailyAvgTDS = WaterSensorController.GetDailyTds();
            model.TDSModel.WeeklyAvgTDS = WaterSensorController.GetWeeklyTds();

            //daily summary
            List<TDSLog> tdsDailyLogs = WaterSensorController.GetDailySummaryTdsLogs();
            model.TDSModel.SampleDay = tdsDailyLogs.Select(x => string.Format("{0:d}", x.LogDate)).ToList();
            model.TDSModel.TDSDailyVal = tdsDailyLogs.Select(x => Math.Round(x.TdsVal, 2)).ToList();

            

            return model;
        }

        public ActionResult SetSelectedTank(SelectTankModel stm)
        {
            WaterSensorController.CurrentAquariumName = stm.SelectedTank.Text;
            //var tanks = Settings.Get().AquariumNames;
            //var slis = tanks.ToSelectListItems();
            //var stm = new SelectTankModel { Tanks = slis };
            return PartialView("_SelectTank", stm);
        }

        public ActionResult _SelectTank()
        {
            var tanks = Settings.Get().AquariumNames;
            var selectedtank = tanks.Find(x => x.Name == WaterSensorController.CurrentAquariumName);
            var st = selectedtank.ToSelectListItem();
            var slis = tanks.ToSelectListItems();
            foreach (var tank in slis)
            {
                if (tank.Value == st.Value)
                {
                    tank.Selected = true;
                    break;
                }
            }
            var stm = new SelectTankModel { Tanks = slis, SelectedTank=st };
            return PartialView("_SelectTank", stm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}