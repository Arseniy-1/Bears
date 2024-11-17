using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Storage
{
    public class InventoryFactory
    {
        private readonly InventoriesService _inventoriesService;

        public InventoryFactory(InventoriesService inventoriesService)
        {
            _inventoriesService = inventoriesService;
        }

        public string Create()
        {
            string ownerId = GenerateId();
            InventoryGridData inventoryGridData = CreateEmptyInventory(ownerId);

            _inventoriesService.RegisterInventory(inventoryGridData);
            return ownerId;
        }

        private string GenerateId()
        {
            return "1";
        }
        
        private InventoryGridData CreateEmptyInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4); // load from configs
            var cellsData = new List<InventoryCellData>();
            var length = size.x * size.y;

            for (int i = 0; i < length; i++)
                cellsData.Add(new InventoryCellData());

            var inventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Cells = cellsData
            };
            
            return inventoryData;
        }
    }
}