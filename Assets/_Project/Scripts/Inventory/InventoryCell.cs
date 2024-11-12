using System;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.ReadOnly;

namespace _Project.Scripts.Inventory
{
    public class InventoryCell : IReadOnlyInventoryCell
    {
        private readonly InventoryCellData _data;
        
        public event Action<string> ItemIdChanged;
        public event Action<int> ItemAmountChanged;
        
        public string ItemId
        {
            get => _data.ItemId;
            set
            {
                if (_data.ItemId != value)
                {
                    _data.ItemId = value;
                    ItemIdChanged?.Invoke(value);
                }
            }
        }

        public int Amount => _data.Amount;
        public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemId);

        public InventoryCell(InventoryCellData data)
        {
            _data = data;
        }
    }
}