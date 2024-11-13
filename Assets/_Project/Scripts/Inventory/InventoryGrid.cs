using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.ReadOnly;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoryGrid : IReadOnlyInventoryGrid
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

        public AddItemsPayload AddItems(string itemId, int amount = 1)
        {
            int remainingAmount = amount;
            int itemsAddedToSlotWithSameItemsAmount = AddToCellsWithSameItems(itemId, remainingAmount, out remainingAmount);

            if (remainingAmount <= 0)
            {
                return new AddItemsPayload(OwnerId, amount, itemsAddedToSlotWithSameItemsAmount);
            }

            int itemsAddedToAvailableSlotsAmount = AddToFirstAvailableCells(itemId, remainingAmount, out remainingAmount);
            int totalAddedItemsAmount = itemsAddedToSlotWithSameItemsAmount + itemsAddedToAvailableSlotsAmount;
            
            return new AddItemsPayload(OwnerId, amount, totalAddedItemsAmount);
        }

        public AddItemsPayload AddItems(Vector2Int cellPosition, string itemId, int amount = 1)
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

            return new AddItemsPayload(OwnerId, amount, itemsAddedAmount);
        }

        public RemoveItemsPayload RemoveItems(string itemId, int amount = 1)
        {
            if (Contains(itemId, amount) == false)
            {
                return new RemoveItemsPayload(OwnerId, amount, false);
            }

            int amountToRemove = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCell cell = _cellsMap[position];

                    if (cell.ItemId != itemId)
                    {
                        continue;
                    }

                    if (amountToRemove > cell.Amount)
                    {
                        amountToRemove -= cell.Amount;
                        
                        RemoveItems(position, itemId, cell.Amount);
                    }
                    else
                    {
                        RemoveItems(position, itemId, amountToRemove);

                        return new RemoveItemsPayload(OwnerId, amount, true);
                    }
                }
            }

            throw new Exception("Something went wrong, couldn't remove some items");
        }

        public RemoveItemsPayload RemoveItems(Vector2Int cellPosition, string itemId, int amount = 1)
        {
            var cell = _cellsMap[cellPosition];

            if (cell.IsEmpty || cell.ItemId != itemId || cell.Amount < amount)
            {
                return new RemoveItemsPayload(OwnerId, amount, false);
            }

            cell.Amount -= amount;

            if (cell.Amount == 0)
            {
                cell.ItemId = null;
            }

            return new RemoveItemsPayload(OwnerId, amount, true);
        }

        public int GetAmount(string itemId)
        {
            int amount = 0;
            List<InventoryCellData> cells = _data.Cells;

            // to Linq
            foreach (InventoryCellData cell in cells)
            {
                if (cell.ItemId == itemId) 
                    amount += cell.Amount;
            }

            return amount;
        }

        public bool Contains(string itemId, int amount) => 
            GetAmount(itemId) >= amount;

        public void SwapCells(Vector2Int cellPositionA, Vector2Int cellPositionB)
        {
            InventoryCell cellA = _cellsMap[cellPositionA];
            InventoryCell cellB = _cellsMap[cellPositionB];

            string tempCellItemId = cellA.ItemId;
            int tempCellItemAmount = cellA.Amount;

            cellA.ItemId = cellB.ItemId;
            cellA.Amount = cellB.Amount;
            
            cellB.ItemId = tempCellItemId;
            cellB.Amount = tempCellItemAmount;
        }

        public void SetSize(Vector2Int size)
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

        // can be refactored
        private int AddToFirstAvailableCells(string itemId, int amount, out int remainingAmount)
        {
            int itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCell cell = _cellsMap[position];
                    
                    if(cell.IsEmpty == false)
                        continue;

                    cell.ItemId = itemId;
                    int newAmount = remainingAmount;
                    int cellItemCapacity = GetItemCellCapacity(itemId);

                    if (newAmount > cellItemCapacity)
                    {
                        remainingAmount = newAmount - cellItemCapacity;
                        int itemsToAddAmount = cellItemCapacity;
                        itemsAddedAmount += itemsToAddAmount;
                        cell.Amount = cellItemCapacity;
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        cell.Amount = newAmount;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }
            
            return itemsAddedAmount;
        }

        // can be refactored
        private int AddToCellsWithSameItems(string itemId, int amount, out int remainingAmount)
        {
            var itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCell cell = _cellsMap[position];

                    if (cell.IsEmpty)
                    {
                        continue;
                    }

                    int cellItemCapacity = GetItemCellCapacity(itemId);

                    if (cell.Amount >= cellItemCapacity)
                    {
                        continue;
                    }

                    if (cell.ItemId != itemId)
                    {
                        continue;
                    }

                    int newAmount = cell.Amount + remainingAmount;

                    if (newAmount > cellItemCapacity)
                    {
                        remainingAmount = newAmount - cellItemCapacity;
                        int itemsToAddAmount = cellItemCapacity - cell.Amount;
                        itemsAddedAmount += itemsToAddAmount;
                        cell.Amount = cellItemCapacity;

                        if (remainingAmount == 0)
                        {
                            return itemsAddedAmount;
                        }
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        cell.Amount = newAmount;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }

            return itemsAddedAmount;
        }

        
        // move to service
        private int GetItemCellCapacity(string itemId)
        {
            return 99;
        }
    }
}