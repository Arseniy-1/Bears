using _Project.Scripts.Inventory.ReadOnly;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoryGridView : MonoBehaviour
    {
        public void Setup(IReadOnlyInvetoryGrid invetory)
        {
            var cells = invetory.GetCells();
            var size = invetory.Size;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    IReadOnlyInventoryCell cell = cells[x, y];
                    
                    Debug.Log($"Cell ({x};{y}), Item: {cell.ItemId}, Amount: {cell.Amount}");
                }
            }
        }
    }
}