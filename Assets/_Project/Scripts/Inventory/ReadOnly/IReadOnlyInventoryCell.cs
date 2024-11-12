using System;
using Unity.VisualScripting;

namespace _Project.Scripts.Inventory.ReadOnly
{
    public interface IReadOnlyInventoryCell
    {
        event Action<string> ItemIdChanged;
        event Action<int> ItemAmountChanged;
        
        string ItemId { get; }
        int Amount { get; }
        bool IsEmpty { get; }
    }
}