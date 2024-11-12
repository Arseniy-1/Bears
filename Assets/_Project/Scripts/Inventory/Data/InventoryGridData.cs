using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    [Serializable]
    public class InventoryGridData
    {
        public string OwnerId;
        public List<InventoryCellData> Cells;
        public Vector2Int Size;
    }
}