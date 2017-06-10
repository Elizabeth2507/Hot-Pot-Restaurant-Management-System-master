using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class PlotOptionsViewResult
    {
        public GeneralOptionsViewResult series { get; set; }

        public PlotOptionsViewResult()
        {
            series = new GeneralOptionsViewResult();
        }
    }
}