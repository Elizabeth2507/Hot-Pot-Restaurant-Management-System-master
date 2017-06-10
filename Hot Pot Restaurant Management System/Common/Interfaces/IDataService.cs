using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Pot_Restaurant_Management_System.Common.Interfaces
{
    public interface IDataService<T>
    {
        
        List<T> Query(QueryConditions queryConditions, out int totalCount);

        
        DBResult Add(T entity);

        
        DBResult Edit(T entity);

        
        DBResult EditAll(List<T> entities);

        
        DBResult Delete(T entity);

        
        DBResult DeleteAll(List<T> entities);

        
        DBResult Delete(int id);

        
        DBResult DeleteAll(List<int> list);
    }
}
