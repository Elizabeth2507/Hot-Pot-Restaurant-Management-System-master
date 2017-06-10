using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Pot_Restaurant_Management_System.Common.Interfaces
{
    public interface ITreeView
    {
        int ID { get; set; } 
        string Name { get; set; } 
        int SuperiorID { get; set; } 
        List<ITreeView> Children { get; set; } 
    }
}
