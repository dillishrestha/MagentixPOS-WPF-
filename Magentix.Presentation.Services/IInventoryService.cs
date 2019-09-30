using System.Collections.Generic;
using Magentix.Domain.Models.Inventory;
using Magentix.Domain.Models.Settings;

namespace Magentix.Presentation.Services
{
    public interface IInventoryService
    {
        PeriodicConsumption GetPreviousPeriodicConsumption();
        PeriodicConsumption GetCurrentPeriodicConsumption();
        void CalculateCost(PeriodicConsumption pc, WorkPeriod workPeriod);
        IEnumerable<string> GetInventoryItemNames();
        IEnumerable<string> GetGroupCodes();
        void SavePeriodicConsumption(PeriodicConsumption pc);
        decimal GetInventory(InventoryItem inventoryItem, Warehouse warehouse);
        void DoWorkPeriodStart();
        void DoWorkPeriodEnd();
        IEnumerable<string> GetWarehouseNames();
        void FilterUnneededItems(PeriodicConsumption pc);
        void AddMissingItems(WarehouseConsumption whc);
        IEnumerable<string> GetRequiredRecipesForSales();
        IEnumerable<string> GetMissingRecipes();
    }
}
