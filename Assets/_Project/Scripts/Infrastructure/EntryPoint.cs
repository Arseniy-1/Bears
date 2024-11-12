using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        public InventoryGridView _view;

        private void Start()
        {
            var inventoryData = new InventoryGridData()
            {
                Size = new Vector2Int(3, 4),
                OwnerId = "Player",
                Cells = new List<InventoryCellData>()
            };
            
            // fill the cells
            var size = inventoryData.Size;
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    inventoryData.Cells.Add(new InventoryCellData());
                }
            }

            var cellData = inventoryData.Cells[0];
            cellData.ItemId = "brick";
            cellData.Amount = 15;
            //Debug.Log($"{cellData.Amount}");
            
            var inventory = new InventoryGrid(inventoryData);
            
            _view.Setup(inventory);
        }
    }
}