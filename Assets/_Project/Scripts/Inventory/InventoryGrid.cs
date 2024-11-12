using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.ReadOnly;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoryGrid : IReadOnlyInvetoryGrid
    {
        private readonly InventoryGridData _data;
        private readonly Dictionary<Vector2Int, InventoryCell> _cellsMap = new ();
        
        public event Action<string, int> ItemsAdded;
        public event Action<string, int> ItemsRemoved;
        public event Action<Vector2Int> SizeChanged;

        public string OwnerId => _data.OwnerId;
        
        public Vector2Int Size
        {
            get => _data.Size;
            set
            {
                if (_data.Size != value)
                {
                    _data.Size = value;
                    SizeChanged?.Invoke(value);
                }   
            }
        }

        public InventoryGrid(InventoryGridData data)
        {
            _data = data;
            
            Vector2Int size = _data.Size;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    int listIndex = x * size.y + y;
                    InventoryCellData cellData = data.Cells[listIndex];
                    var cell = new InventoryCell(cellData);
                    var position = new Vector2Int(x, y);

                    _cellsMap[position] = cell;
                }
            }
        }

        public int GetAmount(string itemId)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string itemId, int amount)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyInventoryCell[,] GetCells()
        {
            var array = new IReadOnlyInventoryCell[Size.x, Size.y];

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    array[x, y] = _cellsMap[position];
                }
            }

            return array;
        }

        public bool AddItems(string itemId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}