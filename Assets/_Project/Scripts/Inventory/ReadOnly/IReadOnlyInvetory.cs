using System;
using Unity.VisualScripting;

namespace _Project.Scripts.Inventory.ReadOnly
{
    public interface IReadOnlyInvetory
    {
        event Action<string, int> ItemsAdded;
        event Action<string, int> ItemsRemoved;
        
        string OwnerId { get; }

        int GetAmount(string itemId);
        bool Contains(string itemId, int amount);
    }
}