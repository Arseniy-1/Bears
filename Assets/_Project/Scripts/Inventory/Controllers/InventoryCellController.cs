using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Inventory.Views;
using _Project.Scripts.Storage;
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

            _cell.ItemTypeChanged += OnCellItemTypeChanged;
            _cell.ItemAmountChanged += OnCellItemAmountChanged;

            _view.Title = cell.Type.ToString();
            _view.Amount = cell.Amount;
        }

        private void OnCellItemAmountChanged(int newAmount)
        {
            _view.Amount = newAmount;
        }

        private void OnCellItemTypeChanged(ItemType type)
        {
            _view.Title = type.ToString();
        }
    }
}