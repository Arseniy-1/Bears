using System.Collections.Generic;
using _Project.Scripts.Inventory;
using UnityEngine;

namespace _Project.Scripts.Storage
{
    public class StorageFactory
    {
        private readonly InventoryFactory _inventoryFactory;
        private readonly InventoriesService _inventoriesService;
        private readonly Storage _prefab;

        public StorageFactory(InventoryFactory inventoryFactory, InventoriesService inventoriesService, Storage prefab)
        {
            _inventoryFactory = inventoryFactory;
            _inventoriesService = inventoriesService;
            _prefab = prefab;
        }

        public Storage Create(StorageDataSO storageData)
        {
            Storage storage = GameObject.Instantiate(_prefab);

            _inventoryFactory.Create(storageData);
            var presenter = new StoragePresenter(storageData, _inventoriesService);
            storage.Construct(presenter);
            
            return storage;
        }
    }
}