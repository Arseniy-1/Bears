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

        // add service to load items configs
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

        public AddItemsToInvetoryPayload AddItems(string itemId, int amount = 1)
        {
            
        }

        public AddItemsToInvetoryPayload AddItems(Vector2Int cellPosition, string itemId, int amount = 1)
        {
            InventoryCell cell = _cellsMap[cellPosition];
            int newAmount = cell.Amount + amount;
            int itemsAddedAmount = 0;

            if (cell.IsEmpty) 
                cell.ItemId = itemId;

            int itemCellCapacity = GetItemCellCapacity(itemId);

            if (newAmount > itemCellCapacity)
            {
                int itemsReaminingAmount = newAmount - itemCellCapacity;
                int itemsToAddAmount = itemCellCapacity - cell.Amount;
                itemsAddedAmount += itemsToAddAmount;
                cell.Amount = itemCellCapacity;

                var payload = AddItems(itemId, itemsReaminingAmount);
                itemsAddedAmount += payload.ItemsAddedAmount;
            }
            else
            {
                itemsAddedAmount = amount;
                cell.Amount = newAmount;
            }

            return new AddItemsToInvetoryPayload(OwnerId, amount, itemsAddedAmount);
        }

        public RemoveItemsFromInvetoryPayload RemoveItems(string itemId, int amount = 1)
        {
            
        }

        public RemoveItemsFromInvetoryPayload RemoveItems(Vector2Int cellPosition, string itemId, int amount = 1)
        {
            var cell = _cellsMap[cellPosition];

            if (cell.IsEmpty || cell.ItemId != itemId || cell.Amount < amount)
            {
                return new RemoveItemsFromInvetoryPayload(OwnerId, amount, false);
            }

            cell.Amount -= amount;

            if (cell.Amount == 0)
            {
                cell.ItemId = null;
            }

            return new RemoveItemsFromInvetoryPayload(OwnerId, amount, true);
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

        private int GetItemCellCapacity(string itemId)
        {
            return 99;
        }
    }
}