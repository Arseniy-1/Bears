using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Controllers;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.Views;
using _Project.Scripts.Storage;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        // private const string OWNER1 = "Player";
        // private const string OWNER2 = "chest_1";

        [SerializeField] private List<StorageDataSO> _defaultStorageData;
        
        [SerializeField] private List<StorageSpawnPoint> _storageSpawnPoints;
        
        [SerializeField] private Storage.Storage storagePrefab;
        [SerializeField] private InventoryWindowView inventoryWindowView;
        
        private InventoriesService _inventoriesService;
        private InventoriesWindowView _inventoriesWindowView;
        private InventoryFactory _inventoryFactory;
        private StorageFactory _storageFactory;

        private string _openedOwnerId;

        private void Start()
        {
            // add config to provider
            // make loading acync
            var gameStateProvider = new GameStatePlayerPrefsProvider();
            gameStateProvider.LoadGameState();
            
            InventoryInit(gameStateProvider);

            // foreach (InventoryGridData inventoryData in gameState.Inventories)
            // {
            //     _inventoriesService.RegisterInventory(inventoryData);
            // }


            // _screenController.OnOpenInventoryOpened(OWNER1);
            // _openedOwnerId = OWNER1;
        }

        private void InventoryInit(GameStatePlayerPrefsProvider gameStateProvider)
        {
            _inventoriesService = new InventoriesService(gameStateProvider);
            GameStateData gameState = gameStateProvider.GameState;

            _inventoryFactory = new InventoryFactory(_inventoriesService);
            _storageFactory = new StorageFactory(_defaultStorageData, _inventoryFactory, _inventoriesService, storagePrefab);
            _inventoriesWindowView = new InventoriesWindowView(_inventoriesService, inventoryWindowView);
            StorageSpawner storageSpawner = new StorageSpawner(_storageFactory);

            foreach (StorageSpawnPoint spawnPoint in _storageSpawnPoints)
            {
                storageSpawner.Spawn(spawnPoint);
            }
        }

        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Alpha1))
            // {
            //     _screenController.OnOpenInventoryOpened(OWNER1);
            //     _openedOwnerId = OWNER1;
            // }
            //
            // if (Input.GetKeyDown(KeyCode.Alpha2))
            // {
            //     _screenController.OnOpenInventoryOpened(OWNER2);
            //     _openedOwnerId = OWNER2;
            // }

            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     int randomIndex = Random.Range(0, _itemIds.Length);
            //     string randomItemId = _itemIds[randomIndex];
            //     int randomAmount = Random.Range(1, 200);
            //     AddItemsPayload result = _inventoriesService.AddItems(_openedOwnerId, randomItemId, randomAmount);
            //     
            //     Debug.Log(result.ToString());
            // }
            //
            // if (Input.GetKeyDown(KeyCode.R))
            // {
            //     int randomIndex = Random.Range(0, _itemIds.Length);
            //     string randomItemId = _itemIds[randomIndex];
            //     int randomAmount = Random.Range(1, 200);
            //     RemoveItemsPayload result = _inventoriesService.RemoveItems(_openedOwnerId, randomItemId, randomAmount);
            //     
            //     Debug.Log(result.ToString());
            // }
        }
    }
}