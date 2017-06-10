using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class AxisTitleViewResult
    {
        public string text { get; set; }
        public string align { get; set; }
        public int? offset { get; set; }
        public int rotation { get; set; }

        public AxisTitleViewResult()
        {
            align = AxisAlign.middle.ToString();
        }
    }
}