using _Project.Scripts.Inventory;

namespace _Project.Scripts.Storage
{
    public class StoragePresenter
    {
        private string _ownerId;
        private readonly InventoriesService _inventoriesService;

        public StoragePresenter(string ownerId, InventoriesService inventoriesService)
        {
            _ownerId = ownerId;
            _inventoriesService = inventoriesService;
        }

        public void OnClick()
        {
            _inventoriesService.OpenInventory(_ownerId);
        }
            
    }
}