using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class HighChartsViewResult<T>
    {
        public ChartViewResult chart { get; set; }
        public TitleViewResult title { get; set; }
        public TitleViewResult subtitle { get; set; }
        public AxisViewResult xAxis { get; set; }
        public AxisViewResult yAxis { get; set; }
        public PlotOptionsViewResult plotOptions { get; set; }
        public List<SeriesViewResult<T>> series { get; set; }
        public CreditsViewResult credits { get; set; }

        public HighChartsViewResult()
        {
            chart = new ChartViewResult();
            title = new TitleViewResult();
            subtitle = new TitleViewResult();
            xAxis = new AxisViewResult();
            yAxis = new AxisViewResult();
            plotOptions = new PlotOptionsViewResult();
            credits = new CreditsViewResult();
        }
    }
}