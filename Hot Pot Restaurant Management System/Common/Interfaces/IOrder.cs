using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Pot_Restaurant_Management_System.Common.Interfaces
{
    public interface IOrder<T>
        where T : IOrderDetails
    {
        string ID { get; set; }
        string WarehouseName { get; set; }
        int OperatorID { get; set; }
        string OperatorName { get; set; }
        int UserID { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }
        string Remark { get; set; }
        List<T> Details { get; set; }
    }
}
