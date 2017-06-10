using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class ChartViewResult
    {
        public string type { get; set; }

        public ChartViewResult()
        {
            type = ChartType.line.ToString();
        }
    }
}