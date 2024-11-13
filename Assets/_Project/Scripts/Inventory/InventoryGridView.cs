using _Project.Scripts.Inventory.ReadOnly;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoryGridView : MonoBehaviour
    {
        private IReadOnlyInventoryGrid _inventory;
        
        public void Setup(IReadOnlyInventoryGrid inventory)
        {
            _inventory = inventory;
            Print();
        }

        public void Print()
        {
            var cells = _inventory.GetCells();
            var size = _inventory.Size;
            string line = $"";
            
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    IReadOnlyInventoryCell cell = cells[x, y];
                    
                    line += ($"Cell ({x};{y}), Item: {cell.ItemId}, Amount: {cell.Amount}\n");
                }
            }
            
            Debug.Log(line);
        }
    }
}