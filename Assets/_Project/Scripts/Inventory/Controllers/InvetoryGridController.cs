using System.Collections.Generic;
using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Inventory.Views;
using UnityEngine;

namespace _Project.Scripts.Inventory.Controllers
{
    public class InvetoryGridController
    {
        private readonly List<InventoryCellController> _cellControllers = new();

        public InvetoryGridController(IReadOnlyInventoryGrid inventory, InventoryView view)
        {
            Vector2Int size = inventory.Size;
            IReadOnlyInventoryCell[,] cells = inventory.GetCells();
            int lineLenght = size.y;
            
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    int index = x * lineLenght + y;
                    InventoryCellView cellView = view.GetInvetoryCellView(index);
                    IReadOnlyInventoryCell cell = cells[x, y];
                    _cellControllers.Add(new InventoryCellController(cell, cellView));
                }
            }

            view.OwnerId = inventory.OwnerId;
        }
    }
}