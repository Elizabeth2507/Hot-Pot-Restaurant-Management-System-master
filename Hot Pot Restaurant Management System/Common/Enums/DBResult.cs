using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Enums
{
    //The database service returns the value
    public enum DBResult
    {
        Succeed, 
        Unknown,
        WrongParameter, 
        NotFound,
        IDExisted,
        ShortIDExisted,
        NameExisted,
        ShortNameExisted,
        InventoryListExisted,
        TableExisted,
        InventoryEmpty,
        UserNotFound,
        UserNameExisted,
        PropertyValueExisted,
    }
}