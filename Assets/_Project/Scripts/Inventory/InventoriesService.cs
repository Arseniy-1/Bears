using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Storage;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoriesService
    {
        private readonly IGameStateSaver _gameStateSaver;
        
        private Dictionary<string, InventoryGridService> _inventoriesMap = new();

        public event Action<string> InventoryPresenterOpening;

        public InventoriesService(IGameStateSaver gameStateSaver)
        {
            _gameStateSaver = gameStateSaver;
        }

        public void OpenInventory(string ownerId)
        {
            InventoryPresenterOpening?.Invoke(ownerId);
        }

        public InventoryGridService RegisterInventory(InventoryGridData inventoryData)
        {
            var inventory = new InventoryGridService(inventoryData);
            _inventoriesMap[inventory.OwnerId] = inventory;

            return inventory;
        }
        
        public ItemTransactionInfo AddItems(
            string ownerId,
            ItemType type,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].AddItems(type, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo AddItems(
            string ownerId,
            Vector2Int position,
            ItemType type,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].AddItems(position, type, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo RemoveItems(
            string ownerId,
            ItemType type,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].RemoveItems(type, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo RemoveItems(
            string ownerId,
            Vector2Int position,
            ItemType type,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].RemoveItems(position, type, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public bool Contains(string ownerId, ItemType type, int amount = 1) => 
            _inventoriesMap[ownerId].Contains(type, amount);

        public IReadOnlyInventoryGrid GetInventory(string ownerId) => 
            _inventoriesMap[ownerId];
    }
}