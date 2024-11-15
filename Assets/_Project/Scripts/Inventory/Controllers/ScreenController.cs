using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Inventory.Views;

namespace _Project.Scripts.Inventory.Controllers
{
    public class ScreenController
    {
        private readonly InventoriesService _inventoriesService;
        private readonly ScreenView _view;

        private InvetoryGridController _currentInventoryController;

        public ScreenController(InventoriesService inventoriesService, ScreenView view)
        {
            _inventoriesService = inventoriesService;
            _view = view;
        }

        public void OpenInventory(string ownerId)
        {
            IReadOnlyInventoryGrid inventory = _inventoriesService.GetInventory(ownerId);
            InventoryView invetoryView = _view.InventoryView;

            _currentInventoryController = new InvetoryGridController(inventory, invetoryView);
        }
    }
}