using System;
using _Project.Scripts.Item;

namespace _Project.Scripts.Player.Inventory
{
    public class Cell
    {
        public ItemType ItemType { get; private set; }
        public int Count { get; private set; }

        public Cell(ItemType itemType, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            ItemType = itemType;
            Count = count;
        }
        
        public void Merge(Cell newCell)
        {
            if (newCell.ItemType != ItemType)
                throw new InvalidOperationException();

            Count += newCell.Count;
        }
    }
}