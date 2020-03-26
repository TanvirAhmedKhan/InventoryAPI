using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public interface IInvertoryServices
    {
        string AddInventoryItems(InventoryItems item);
        List<InventoryItems> GetInventoryItems();
        InventoryItems GetInventoryItemById(int id);
        string DeleteItemById(int id);
        string UpdateInventoryItem(InventoryItems item);
        List<InventoryItems> GetSearchResult(SearchModel inquiry);
    }
}
