using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class SeriesViewResult<T>
    {
        public string name { get; set; }
        public List<T> data { get; set; }
        public string type { get; set; }

        public SeriesViewResult() { }
    }
}