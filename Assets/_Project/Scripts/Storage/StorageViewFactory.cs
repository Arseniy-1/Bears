using _Project.Scripts.Inventory;
using UnityEngine;

namespace _Project.Scripts.Storage
{
    public class StorageViewFactory
    {
        private readonly InventoryFactory _inventoryFactory;
        private readonly InventoriesService _inventoriesService;
        private readonly StorageView _viewPrefab;

        public StorageViewFactory(InventoryFactory inventoryFactory, InventoriesService inventoriesService, StorageView viewPrefab)
        {
            _inventoryFactory = inventoryFactory;
            _inventoriesService = inventoriesService;
            _viewPrefab = viewPrefab;
        }

        public StorageView Create() // entrypoint or spawner calls it, changes it's transform
        {
            StorageView newView = GameObject.Instantiate(_viewPrefab); // add pos

            //string ownerId = inventoryIdsService(); 
            string ownerId = _inventoryFactory.Create(); // onwerId as parameter of function
            var presenter = new StoragePresenter(ownerId, _inventoriesService);
            newView.Construct(presenter);
            
            return newView;
        }
    }
}