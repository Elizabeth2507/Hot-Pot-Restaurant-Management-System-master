using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class GeneralOptionsViewResult
    {
        public DataLabelsViewResult dataLabels { get; set; }
        public bool enableMouseTracking { get; set; }
        public string pointStart { get; set; }
        public int pointInterval { get; set; }

        public GeneralOptionsViewResult()
        {
            dataLabels = new DataLabelsViewResult();
            pointStart = "0";
            pointInterval = 1;
        }
    }
}