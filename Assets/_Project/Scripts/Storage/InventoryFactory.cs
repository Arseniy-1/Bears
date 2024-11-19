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

        public void Create(StorageDataSO storageDataSo)
        {
            InventoryGridData inventoryGridData = LoadFromSO(storageDataSo);

            _inventoriesService.RegisterInventory(inventoryGridData);
        }

        private InventoryGridData LoadFromSO(StorageDataSO storageDataSo)
        {
            Vector2Int size = storageDataSo.Size; // load from configs
            var cellsData = new List<InventoryCellData>();
            var length = size.x * size.y;

            for (int i = 0; i < length; i++)
                cellsData.Add(new InventoryCellData());

            for (int i = 0; i < storageDataSo.Cells.Count; i++) 
                cellsData[i] = storageDataSo.Cells[i];

            var inventoryData = new InventoryGridData
            {
                OwnerId = storageDataSo.ownerId,
                Size = size,
                Cells = cellsData
            };
            
            return inventoryData;
        }
    }
}