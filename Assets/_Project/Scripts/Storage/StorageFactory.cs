using System.Collections.Generic;
using _Project.Scripts.Inventory;
using UnityEngine;

namespace _Project.Scripts.Storage
{
    public class StorageFactory
    {
        private readonly List<StorageDataSO> _defaultStorageData;
        private readonly InventoryFactory _inventoryFactory;
        private readonly InventoriesService _inventoriesService;
        private readonly Storage _prefab;

        public StorageFactory(List<StorageDataSO> defaultStorageData, InventoryFactory inventoryFactory, InventoriesService inventoriesService, Storage prefab)
        {
            _defaultStorageData = defaultStorageData;
            _inventoryFactory = inventoryFactory;
            _inventoriesService = inventoriesService;
            _prefab = prefab;
        }

        public Storage Create() // entrypoint or spawner calls it, changes it's transform
        {
            Storage storage = GameObject.Instantiate(_prefab);

            _inventoryFactory.Create(_defaultStorageData[0]); // onwerId as parameter of function
            var presenter = new StoragePresenter(_defaultStorageData[0], _inventoriesService);
            storage.Construct(presenter);
            
            return storage;
        }
    }
}