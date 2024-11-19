using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory.Data;
using _Project.Scripts.Inventory.ReadOnly;
using _Project.Scripts.Storage;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class InventoryGridService : IReadOnlyInventoryGrid
    {
        private readonly InventoryGridData _data;
        private readonly Dictionary<Vector2Int, InventoryCellService> _cellsMap = new ();
        
        public event Action<ItemType, int> ItemsAdded;
        public event Action<ItemType, int> ItemsRemoved;
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
        public InventoryGridService(InventoryGridData data)
        {
            _data = data;
            
            Vector2Int size = _data.Size;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    int listIndex = x * size.y + y;
                    InventoryCellData cellData = data.Cells[listIndex];
                    var cell = new InventoryCellService(cellData);
                    var position = new Vector2Int(x, y);

                    _cellsMap[position] = cell;
                }
            }
        }

        public ItemTransactionInfo AddItems(ItemType type, int amount = 1)
        {
            int remainingAmount = amount;
            int itemsAddedToSlotWithSameItemsAmount = AddToCellsWithSameItems(type, remainingAmount, out remainingAmount);

            if (remainingAmount <= 0)
            {
                return new ItemTransactionInfo(OwnerId, type, amount, itemsAddedToSlotWithSameItemsAmount);
            }

            int itemsAddedToAvailableSlotsAmount = AddToFirstAvailableCells(type, remainingAmount, out remainingAmount);
            int totalAddedItemsAmount = itemsAddedToSlotWithSameItemsAmount + itemsAddedToAvailableSlotsAmount;
            
            return new ItemTransactionInfo(OwnerId, type,amount, totalAddedItemsAmount);
        }

        public ItemTransactionInfo AddItems(Vector2Int cellPosition, ItemType type, int amount = 1)
        {
            InventoryCellService cellService = _cellsMap[cellPosition];
            int newAmount = cellService.Amount + amount;
            int itemsAddedAmount = 0;

            if (cellService.IsEmpty) 
                cellService.Type = type;

            int itemCellCapacity = GetItemCellCapacity(type);

            if (newAmount > itemCellCapacity)
            {
                int itemsReaminingAmount = newAmount - itemCellCapacity;
                int itemsToAddAmount = itemCellCapacity - cellService.Amount;
                itemsAddedAmount += itemsToAddAmount;
                cellService.Amount = itemCellCapacity;

                var payload = AddItems(type, itemsReaminingAmount);
                itemsAddedAmount += payload.ItemsChangedAmount;
            }
            else
            {
                itemsAddedAmount = amount;
                cellService.Amount = newAmount;
            }

            return new ItemTransactionInfo(OwnerId, type, amount, itemsAddedAmount);
        }

        public ItemTransactionInfo RemoveItems(ItemType type, int amount = 1)
        {
            int amountToRemove = 0;
            
            if (Contains(type, amount) == false)
            {
                return new ItemTransactionInfo(OwnerId, type, amount, amountToRemove);
            }

            amountToRemove = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCellService cellService = _cellsMap[position];

                    if (cellService.Type != type)
                    {
                        continue;
                    }

                    if (amountToRemove > cellService.Amount)
                    {
                        amountToRemove -= cellService.Amount;
                        
                        RemoveItems(position, type, cellService.Amount);
                    }
                    else
                    {
                        RemoveItems(position, type, amountToRemove);

                        return new ItemTransactionInfo(OwnerId, type, amount, amount);
                    }
                }
            }

            throw new Exception("Something went wrong, couldn't remove some items");
        }

        public ItemTransactionInfo RemoveItems(Vector2Int cellPosition, ItemType type, int amount = 1)
        {
            var cell = _cellsMap[cellPosition];

            if (cell.IsEmpty || cell.Type != type || cell.Amount < amount)
            {
                return new ItemTransactionInfo(OwnerId, type, amount, 0);
            }

            cell.Amount -= amount;

            if (cell.Amount == 0)
            {
                cell.Type = ItemType.None;
            }

            return new ItemTransactionInfo(OwnerId, type, amount, amount);
        }

        public int GetAmount(ItemType type)
        {
            int amount = 0;
            List<InventoryCellData> cells = _data.Cells;

            // to Linq
            foreach (InventoryCellData cell in cells)
            {
                if (cell.Type == type) 
                    amount += cell.Amount;
            }

            return amount;
        }

        public bool Contains(ItemType type, int amount) => 
            GetAmount(type) >= amount;

        public void SwapCells(Vector2Int cellPositionA, Vector2Int cellPositionB)
        {
            InventoryCellService cellServiceA = _cellsMap[cellPositionA];
            InventoryCellService cellServiceB = _cellsMap[cellPositionB];

            ItemType itemTypeA = cellServiceA.Type;
            int tempCellItemAmount = cellServiceA.Amount;

            cellServiceA.Type = cellServiceB.Type;
            cellServiceA.Amount = cellServiceB.Amount;
            
            cellServiceB.Type = itemTypeA;
            cellServiceB.Amount = tempCellItemAmount;
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
        private int AddToFirstAvailableCells(ItemType type, int amount, out int remainingAmount)
        {
            int itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCellService cellService = _cellsMap[position];
                    
                    if(cellService.IsEmpty == false)
                        continue;

                    cellService.Type = type;
                    int newAmount = remainingAmount;
                    int cellItemCapacity = GetItemCellCapacity(type);

                    if (newAmount > cellItemCapacity)
                    {
                        remainingAmount = newAmount - cellItemCapacity;
                        int itemsToAddAmount = cellItemCapacity;
                        itemsAddedAmount += itemsToAddAmount;
                        cellService.Amount = cellItemCapacity;
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        cellService.Amount = newAmount;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }
            
            return itemsAddedAmount;
        }

        // can be refactored
        private int AddToCellsWithSameItems(ItemType type, int amount, out int remainingAmount)
        {
            var itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    InventoryCellService cellService = _cellsMap[position];

                    if (cellService.IsEmpty)
                    {
                        continue;
                    }

                    int cellItemCapacity = GetItemCellCapacity(type);

                    if (cellService.Amount >= cellItemCapacity)
                    {
                        continue;
                    }

                    if (cellService.Type != type)
                    {
                        continue;
                    }

                    int newAmount = cellService.Amount + remainingAmount;

                    if (newAmount > cellItemCapacity)
                    {
                        remainingAmount = newAmount - cellItemCapacity;
                        int itemsToAddAmount = cellItemCapacity - cellService.Amount;
                        itemsAddedAmount += itemsToAddAmount;
                        cellService.Amount = cellItemCapacity;

                        if (remainingAmount == 0)
                        {
                            return itemsAddedAmount;
                        }
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        cellService.Amount = newAmount;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }

            return itemsAddedAmount;
        }

        
        // move to service
        private int GetItemCellCapacity(ItemType type)
        {
            return 99;
        }
    }
}