using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.ReadOnly;
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
            string itemId,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].AddItems(itemId, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo AddItems(
            string ownerId,
            Vector2Int position,
            string itemId,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].AddItems(position, itemId, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo RemoveItems(
            string ownerId,
            string itemId,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].RemoveItems(itemId, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public ItemTransactionInfo RemoveItems(
            string ownerId,
            Vector2Int position,
            string itemId,
            int amount = 1)
        {
            ItemTransactionInfo result = _inventoriesMap[ownerId].RemoveItems(position, itemId, amount);
            _gameStateSaver.SaveGameState();
            
            return result;
        }

        public bool Contains(string ownerId, string itemId, int amount = 1) => 
            _inventoriesMap[ownerId].Contains(itemId, amount);

        public IReadOnlyInventoryGrid GetInventory(string ownerId) => 
            _inventoriesMap[ownerId];
    }
}