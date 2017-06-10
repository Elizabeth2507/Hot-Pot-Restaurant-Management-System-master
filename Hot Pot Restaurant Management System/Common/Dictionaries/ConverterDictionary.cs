using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Dictionaries
{
    public class ConverterDictionary
    {
        //Time period
        public static Dictionary<int, string> TimePeriodDictionary = new Dictionary<int, string>
        {
            { 1, "Morning market" },
            { 2, "Afternoon" },
            { 3, "Evening market" },
            { 4, "Supper" }
        };

        //Current time period
        public static Dictionary<int[], int> NowTimePeriodDictionary = new Dictionary<int[], int>
        {
            { new int[]{ 0, 6 }, 4 },
            { new int[]{ 6, 10 }, 1 },
            { new int[]{ 10, 14 }, 2 },
            { new int[]{ 14, 22 }, 3 },
            { new int[]{ 22, 25 }, 4 },
        };

        //User role
        public static Dictionary<int, string> UserRoleDictionary = new Dictionary<int, string>
        {
            { 1, "Administrator" },
            { 2, "Warehouse Manager" },
            { 3, "Frontdesk cashier" },
            { 4, "Finance" }
        };
    }
}