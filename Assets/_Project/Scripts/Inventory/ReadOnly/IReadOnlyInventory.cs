using System;
using _Project.Scripts.Storage;
using Unity.VisualScripting;

namespace _Project.Scripts.Inventory.ReadOnly
{
    public interface IReadOnlyInventory
    {
        event Action<ItemType, int> ItemsAdded;
        event Action<ItemType, int> ItemsRemoved;
        
        string OwnerId { get; }

        int GetAmount(ItemType type);
        bool Contains(ItemType type, int amount);
    }
}