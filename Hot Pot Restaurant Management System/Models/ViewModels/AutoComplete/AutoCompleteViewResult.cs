using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels.AutoComplete
{
    public class AutoCompleteViewResult
    {
        public string query { get; set; }
        public string[] suggestions { get; set; }
    }
}