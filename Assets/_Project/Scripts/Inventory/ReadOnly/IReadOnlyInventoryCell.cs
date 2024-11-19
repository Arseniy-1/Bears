using System;
using _Project.Scripts.Storage;

namespace _Project.Scripts.Inventory.ReadOnly
{
    public interface IReadOnlyInventoryCell
    {
        event Action<ItemType> ItemTypeChanged;
        event Action<int> ItemAmountChanged;
        
        ItemType Type { get; }
        int Amount { get; }
        bool IsEmpty { get; }
    }
}