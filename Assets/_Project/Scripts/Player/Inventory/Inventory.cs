using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Project.Scripts.Item;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.Player.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ItemCollector _collector;
        
        private List<Cell> _cells = new ();

        public IReadOnlyList<Cell> Cells => _cells;

        public event Action ContentChanged;

        private void OnEnable()
        {
            _collector.CollectableFound += OnCollectableFound;
        }

        private void OnCollectableFound(CollectableObject collectable)
        {
            collectable.Collect();
            Add(collectable.ItemType, collectable.Count);
        }

        private void Add([NotNull] ItemType itemType, int count)
        {
            if (itemType == null)
                throw new ArgumentNullException(nameof(itemType));
            
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            Cell newCell = new Cell(itemType, count);
            Cell foundCell = _cells.FirstOrDefault(cell => cell.ItemType == itemType);
            
            if(foundCell == null)
                _cells.Add(newCell);
            else
                foundCell.Merge(newCell);
            
            ContentChanged?.Invoke();
        }
    }
}