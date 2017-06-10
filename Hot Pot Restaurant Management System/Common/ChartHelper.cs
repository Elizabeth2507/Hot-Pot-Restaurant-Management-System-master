using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class ChartHelper<T>
    {
        
        private HighChartsViewResult<T> highCharts; 

        
        public ChartViewResult Chart
        {
            get { return highCharts.chart; }
            set { highCharts.chart = value; }
        }

        
        public TitleViewResult Title
        {
            get { return highCharts.title; }
            set { highCharts.title = value; }
        }

        
        public TitleViewResult Subtitle
        {
            get { return highCharts.subtitle; }
            set { highCharts.subtitle = value; }
        }

        
        public AxisViewResult XAxis
        {
            get { return highCharts.xAxis; }
            set { highCharts.xAxis = value; }
        }

        
        public AxisViewResult YAxis
        {
            get { return highCharts.yAxis; }
            set { highCharts.yAxis = value; }
        }

        
        public PlotOptionsViewResult PlotOptions
        {
            get { return highCharts.plotOptions; }
            set { highCharts.plotOptions = value; }
        }

        
        public CreditsViewResult Credits
        {
            get { return highCharts.credits; }
            set { highCharts.credits = value; }
        }

        public ChartHelper()
        {
            highCharts = new HighChartsViewResult<T>();
            highCharts.series = new List<SeriesViewResult<T>>();
        }

        
        public HighChartsViewResult<T> HighCharts()
        {
            highCharts.chart = Chart;
            highCharts.title = Title;
            highCharts.subtitle = Subtitle;
            highCharts.xAxis = XAxis;
            highCharts.yAxis = YAxis;
            highCharts.plotOptions = PlotOptions;
            highCharts.credits = Credits;

            return highCharts;
        }

        
        public HighChartsViewResult<T> HighCharts(string name, ChartType type, List<T> data)
        {
            HighCharts();
            AddData(name, type, data);

            return highCharts;
        }

        
        public void AddData(string name, ChartType type, List<T> data)
        {
            var seriesViewResult = new SeriesViewResult<T> { name = name, type = type.ToString(), data = data };
            highCharts.series.Add(seriesViewResult);
        }

        
        public void RemoveData(string name)
        {
            highCharts.series.RemoveAll(s => s.name == name);
        }
    }
}