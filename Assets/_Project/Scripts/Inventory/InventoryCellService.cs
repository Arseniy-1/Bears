using System;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Storage;

namespace _Project.Scripts.Inventory
{
    public class InventoryCellService : IReadOnlyInventoryCell
    {
        private readonly InventoryCellData _data;
        
        public event Action<ItemType> ItemTypeChanged;
        public event Action<int> ItemAmountChanged;
        
        public ItemType Type
        {
            get => _data.Type;
            set
            {
                if (_data.Type != value)
                {
                    _data.Type = value;
                    ItemTypeChanged?.Invoke(value);
                }
            }
        }

        

        public int Amount
        {
            get => _data.Amount;
            set
            {
                if (_data.Amount != value)
                {
                    _data.Amount = value;
                    ItemAmountChanged?.Invoke(value);
                }
            } 
        }

        public bool IsEmpty => Amount == 0 && Type == ItemType.None;

        public InventoryCellService(InventoryCellData data)
        {
            _data = data;
        }
    }
}