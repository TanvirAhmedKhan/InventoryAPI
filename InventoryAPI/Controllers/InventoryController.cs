using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Produces("application/json")]
    [Route("v1/")]
    public class InventoryController : Controller
    {
        private readonly IInvertoryServices _services;
        public InventoryController(IInvertoryServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        [Route("AddInventoryItems")]
        public string AddInventoryItems([FromBody]InventoryItems item)
        {
            var response = _services.AddInventoryItems(item);
            return response;
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public List<InventoryItems> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();
            if(inventoryItems.Count == 0)
            {
                return null;
            }
            return inventoryItems;
        }

        [HttpGet]
        [Route("GetInventoryItemById/{id}")]
        public InventoryItems GetInventoryItemById(int id)
        {
            var specificCar = _services.GetInventoryItemById(id);
            return specificCar;
        }

        [HttpDelete]
        [Route("DeleteItemById/{id}")]
        public string DeleteItemById(int id)
        {
            var response = _services.DeleteItemById(id);
            return response;
        }

        [HttpPut]
        [Route("UpdateInventoryItem")]
        public string UpdateInventoryItem([FromBody]InventoryItems item)
        {
            var response = _services.UpdateInventoryItem(item);
            return response;
        }
    }
}
