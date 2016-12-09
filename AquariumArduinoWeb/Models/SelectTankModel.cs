using EALFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquariumArduinoWeb.Models
{
    public class SelectTankModel
    {
        [Display(Name = "Tank:")]
        public List<SelectListItem> Tanks;
        public SelectListItem SelectedTank;
    }
}