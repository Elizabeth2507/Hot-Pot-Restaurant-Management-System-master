using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts
{
    public class TitleViewResult
    {
        public string text { get; set; }
        public string align { get; set; }
        public string verticalAlign { get; set; }

        public TitleViewResult()
        {
            text = string.Empty;
            align = Align.center.ToString();
        }
    }
}