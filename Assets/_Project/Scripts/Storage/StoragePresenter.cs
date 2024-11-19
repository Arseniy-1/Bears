using _Project.Scripts.Inventory;

namespace _Project.Scripts.Storage
{
    public class StoragePresenter
    {
        private string _ownerId;
        private readonly InventoriesService _inventoriesService;
        
        public string OwnerId => _ownerId;

        public StoragePresenter(StorageDataSO storageData, InventoriesService inventoriesService)
        {
            _ownerId = storageData.ownerId;
            _inventoriesService = inventoriesService;
        }

        public void OnClick()
        {
            _inventoriesService.OpenInventory(_ownerId);
        }
            
    }
}