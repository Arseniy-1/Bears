using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Inventory.ReadOnly
{
    public interface IReadOnlyInvetoryGrid : IReadOnlyInvetory
    {
        event Action<Vector2Int> SizeChanged;
        
        Vector2Int Size { get; }

        IReadOnlyInventoryCell[,] GetCells();
    }
}