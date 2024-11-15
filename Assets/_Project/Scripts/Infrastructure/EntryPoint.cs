using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Controllers;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        private const string OWNER1 = "Player";
        private const string OWNER2 = "chest_1";

        private readonly string[] _itemIds = {"Apple", "Seed", "Stone", "Buckshot"};
        
        [SerializeField] private ScreenView _screenView;
        private InventoriesService _inventoriesService;
        private ScreenController _screenController;

        private string _openedOwnerId;

        private void Start()
        {
            _inventoriesService = new InventoriesService();
            _screenController = new ScreenController(_inventoriesService, _screenView);
            
            InventoryGridData inventoryDataPlayer = CreateTestInventory(OWNER1);
            _inventoriesService.RegisterInventory(inventoryDataPlayer);
            
            InventoryGridData inventoryDataChest = CreateTestInventory(OWNER2);
            _inventoriesService.RegisterInventory(inventoryDataChest);

            _screenController.OpenInventory(OWNER1);
            _openedOwnerId = OWNER1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenController.OpenInventory(OWNER1);
                _openedOwnerId = OWNER1;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenController.OpenInventory(OWNER2);
                _openedOwnerId = OWNER2;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                int randomIndex = Random.Range(0, _itemIds.Length);
                string randomItemId = _itemIds[randomIndex];
                int randomAmount = Random.Range(1, 200);
                AddItemsPayload result = _inventoriesService.AddItems(_openedOwnerId, randomItemId, randomAmount);
                
                Debug.Log(result.ToString());
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                int randomIndex = Random.Range(0, _itemIds.Length);
                string randomItemId = _itemIds[randomIndex];
                int randomAmount = Random.Range(1, 200);
                RemoveItemsPayload result = _inventoriesService.RemoveItems(_openedOwnerId, randomItemId, randomAmount);
                
                Debug.Log(result.ToString());
            }
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