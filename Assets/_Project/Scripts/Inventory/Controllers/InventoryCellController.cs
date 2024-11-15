using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Inventory.Views;
using UnityEngine;

namespace _Project.Scripts.Inventory.Controllers
{
    public class InventoryCellController
    {
        private readonly IReadOnlyInventoryCell _cell;
        private readonly InventoryCellView _view;

        public InventoryCellController(
            IReadOnlyInventoryCell cell,
            InventoryCellView view)
        {
            _cell = cell;
            _view = view;

            _cell.ItemIdChanged += OnCellItemIdChanged;
            _cell.ItemAmountChanged += OnCellItemAmountChanged;

            _view.Title = cell.ItemId;
            _view.Amount = cell.Amount;
        }

        private void OnCellItemAmountChanged(int newAmount)
        {
            _view.Amount = newAmount;
        }

        private void OnCellItemIdChanged(string newItemId)
        {
            _view.Title = newItemId;
        }
    }
}