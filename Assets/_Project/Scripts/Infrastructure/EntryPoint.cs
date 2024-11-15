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
            // add config to provider
            // make loading acync
            var gameStateProvider = new GameStatePlayerPrefsProvider();
            gameStateProvider.LoadGameState();
            
            _inventoriesService = new InventoriesService(gameStateProvider);
            GameStateData gameState = gameStateProvider.GameState;
            
            
            foreach (InventoryGridData inventoryData in gameState.Inventories)
            {
                _inventoriesService.RegisterInventory(inventoryData);
            }

            _screenController = new ScreenController(_inventoriesService, _screenView);
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
    }
}