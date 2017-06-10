using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Dictionaries
{
    public class DBDictionary
    {
        //database service returns the result
        public static Dictionary<DBResult, string[]> DBResultDictionary = new Dictionary<DBResult, string[]>
        {
            { DBResult.IDExisted, new string[]{ "ID", "The number already exists" } },
            { DBResult.NameExisted, new string[]{ "Name", "Name already exists" } },
            { DBResult.NotFound, new string[]{ "", "Query failed" } },
            { DBResult.ShortIDExisted, new string[]{ "ShortID", "Name already exists" } },
            { DBResult.Succeed, new string[]{ "", "Success" } },
            { DBResult.Unknown, new string[]{ "", "Unknown" } },
            { DBResult.WrongParameter, new string[]{ "", "Wrong Parameter" } },
            { DBResult.ShortNameExisted, new string[]{ "ShortName", "Short Name Existed" } },
            { DBResult.InventoryListExisted, new string[]{ "", "Inventory ListExisted" } },
            { DBResult.TableExisted, new string[]{ "TableID", "Table Existed" } },
            { DBResult.InventoryEmpty, new string[]{ "DishName", "Inventory is less than the number of points" } },
            { DBResult.UserNotFound, new string[]{ "", "Wrong username or password" } },
            { DBResult.PropertyValueExisted, new string[]{ "", "Data already exists" } },
            { DBResult.UserNameExisted, new string[]{ "UserName", "Username already exists" } }
        };

        
        public static Dictionary<string, DBResult> ExistsDictionary = new Dictionary<string, DBResult>
        {
            { "ID", DBResult.IDExisted },
            { "ShortID", DBResult.ShortIDExisted },
            { "Name", DBResult.NameExisted },
            { "ShortName", DBResult.ShortNameExisted },
            { "UserName",DBResult.UserNameExisted }
        };

        //The entity corresponds to the database context
        public static Dictionary<string, Type[]> DBEntitiesDictionary = new Dictionary<string, Type[]>
        {
            { "WarehouseEntities", new Type[]{ typeof(Category), typeof(CODetails), typeof(CreditOrder), typeof(InventoryList), typeof(MaterialsRequisition), 
                typeof(MaterialsReturnOrder), typeof(MRDetails), typeof(MRODetails), typeof(PODetails), typeof(Product), typeof(PurchaseOrder), typeof(SLDetails), 
                typeof(StocktakingList), typeof(TODetails), typeof(TransferOrder), typeof(Warehouse), typeof(InventoryList), typeof(VInventoryList) } },

            { "FrontDeskEntities", new Type[]{ typeof(Bill), typeof(Dish), typeof(BillDetails), typeof(Discount), typeof(ServingTable), typeof(Member) } },

            { "SystemEntities", new Type[]{ typeof(User) } },

            { "ReportEntities", new Type[]{ typeof(MonthlyReport), typeof(MReportDetails), typeof(StartOfTerm), typeof(VPurchaseOrder), typeof(VCreditOrder),
            typeof(VMaterialsRequisition), typeof(VMaterialsReturnOrder), typeof(VStockingList)} },
        };
    }
}