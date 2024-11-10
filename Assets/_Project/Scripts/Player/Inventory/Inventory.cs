using System;
using System.Collections.Generic;
using _Project.Scripts.Item;
using UnityEngine;

namespace _Project.Scripts.Player.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ItemCollector _collector;
        
        private List<Cell> _cells;

        private void OnEnable()
        {
            _collector.CollectableFound += OnCollectableFound;
        }

        private void OnCollectableFound(CollectableObject collectable)
        {
            collectable.Collect();
        }

        public void Add(Cell cell)
        {
            
        }
    }
}