using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class UserQueryConditions : QueryConditions
    {
        public int ID { get; set; }
        public int ShortID { get; set; }
        public string UserName { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string RealPost { get; set; }
    }
}