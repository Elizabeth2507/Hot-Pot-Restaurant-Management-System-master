using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class AxisViewResult
    {
        public AxisTitleViewResult title { get; set; }
        public string type { get; set; }
        public List<string> categories { get; set; }

        public AxisViewResult()
        {
            title = new AxisTitleViewResult();
            type = AxisType.linear.ToString();
        }
    }
}