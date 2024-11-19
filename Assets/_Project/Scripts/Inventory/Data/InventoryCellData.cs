using System;
using _Project.Scripts.Storage;

namespace _Project.Scripts.Inventory.Data
{
    [Serializable]
    public class InventoryCellData
    {
        public ItemType Type;
        public int Amount;
    }
}