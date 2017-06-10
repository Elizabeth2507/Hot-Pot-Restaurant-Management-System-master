using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Pot_Restaurant_Management_System.Common.Interfaces
{
    public interface IOrderDetails
    {
        string ID { get; set; }
        string ProductName { get; set; }
        double Amount { get; set; }
        string OrderID { get; set; }
    }
}
