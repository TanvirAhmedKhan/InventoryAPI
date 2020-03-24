﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public class InventoryServices : IInvertoryServices
    {
        private List<InventoryItems> _inventoryItems;

        public InventoryServices()
        {
            _inventoryItems = new List<InventoryItems>();
        }

        public string AddInventoryItems(InventoryItems item)
        {
            string result = "";
            bool alreadyExist = _inventoryItems.Any((x) => x.Id == item.Id);

            if (alreadyExist)
            {
                result = "A Car with id:" + item.Id + " is already exist.";
            }
            else
            {
                _inventoryItems.Add(item);
                result = "Car with id: "+item.Id+ " has been added successfully.";
            }

            return result;
        }

        public string DeleteItemById(int id)
        {
            string result = "";
            bool has = _inventoryItems.Any((x) => x.Id == id);
            if (has)
            {
                _inventoryItems.RemoveAll((x) => x.Id == id);
                result= "Car with id:" + id + " has been deleted successfully.";
            }
            else
            {
                result = "Car not found.";
            }

            return result;
        }

        public InventoryItems GetInventoryItemById(int id)
        {
            return _inventoryItems.SingleOrDefault(s=>s.Id == id);
        }

        public List<InventoryItems> GetInventoryItems()
        {
            return _inventoryItems;
        }

        public string UpdateInventoryItem(InventoryItems updatedItem)
        {
            string result = "";
            bool itemExist = _inventoryItems.Any((x) => x.Id == updatedItem.Id);
            if (itemExist)
            {
                _inventoryItems = _inventoryItems
                    .Where((x) => x.Id == updatedItem.Id)
                    .Select(ex => new InventoryItems
                    {
                        Id     = ex.Id,
                        Body   = updatedItem.Body,
                        Color  = updatedItem.Color,
                        Make   = updatedItem.Make,
                        Model  = updatedItem.Model,
                        Photos = updatedItem.Photos,
                        Price  = updatedItem.Price,
                        Year   = updatedItem.Year
                    }).ToList();

                result = "Car with id:" + updatedItem.Id + " has been updated.";
            }
            else
            {
                _inventoryItems.Add(updatedItem);
                result = "There is no such car with id: "+ updatedItem.Id+ ".";
            }

            return result;
        }
    }
}
