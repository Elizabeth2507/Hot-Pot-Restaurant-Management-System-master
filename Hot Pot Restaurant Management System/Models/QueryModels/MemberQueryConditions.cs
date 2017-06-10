using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class MemberQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Tele { get; set; }
        public int Point { get; set; }
        public int PointMin { get; set; }
        public int PointMax { get; set; }
    }
}