using EALFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquariumArduinoWeb.Utils
{
    public static class DataHelpers
    {
        public static SelectListItem ToSelectListItem<T, H>(this NameValue<T, H> nv)
        {
            var sli = new SelectListItem { Text = nv.Name.ToString(), Value = nv.Value.ToString() };
            return sli;
            
        }
        public static List<SelectListItem> ToSelectListItems<T,H>(this List<NameValue<T, H>> nvs)
        {
            var slis = nvs.Select(c => c.ToSelectListItem()).ToList();
            return slis;

        }
    }
}