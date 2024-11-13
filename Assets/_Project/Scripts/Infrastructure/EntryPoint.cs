using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        public InventoryGridView _view;
        private InventoriesService _inventoriesService;

        private void Start()
        {
            _inventoriesService = new InventoriesService();

            string ownerId = "Player";
            var inventoryData = CreateTestInventory(ownerId);
            var inventory = _inventoriesService.RegisterInventory(inventoryData);
            
            _view.Setup(inventory);

            var addedResult = _inventoriesService.AddItems(ownerId, "apple", 30);
            Debug.Log($"{addedResult.ToString()}, ItemId: apple");
            
            addedResult = _inventoriesService.AddItems(ownerId, "кирпич", 112);
            Debug.Log($"{addedResult.ToString()}, ItemId: кирпич");
            
            addedResult = _inventoriesService.AddItems(ownerId, "letter", 10);
            Debug.Log($"{addedResult.ToString()}, ItemId: letter");
            
            _view.Print();

            var removedResult = _inventoriesService.RemoveItems(ownerId, "apple", 13);
            Debug.Log($"{removedResult.ToString()}, ItemId: apple");
            
            removedResult = _inventoriesService.RemoveItems(ownerId, "apple", 18);
            Debug.Log($"{removedResult.ToString()}, ItemId: apple");
            
            _view.Print();

        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4); // load from configs
            var cellsData = new List<InventoryCellData>();
            var length = size.x * size.y;
            
            for(int i = 0; i < length; i++)
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