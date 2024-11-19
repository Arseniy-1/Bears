using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Inventory.Views;
using UnityEngine;

namespace _Project.Scripts.Inventory.Controllers
{
    public class InventoriesWindowView
    {
        private readonly InventoriesService _inventoriesService;
        private readonly InventoryWindowView _view;

        private InvetoryGridController _currentInventoryController;

        public InventoriesWindowView(InventoriesService inventoriesService, InventoryWindowView view)
        {
            _inventoriesService = inventoriesService;
            _view = view;

            _inventoriesService.InventoryPresenterOpening += OnInventoryOpening;
        }

        private void OnInventoryOpening(string ownerId)
        {
            Debug.Log($"opening {ownerId}");
            IReadOnlyInventoryGrid inventory = _inventoriesService.GetInventory(ownerId);
            InventoryView invetoryView = _view.InventoryView;

            _currentInventoryController = new InvetoryGridController(inventory, invetoryView);
        }
    }
}