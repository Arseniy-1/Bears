using System;
using _Project.Scripts.Item;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        public event Action<CollectableObject> CollectableFound;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider2D collider)
        {
            if (collider.TryGetComponent(out CollectableObject collectable))
            {
                CollectableFound?.Invoke(collectable);
            }
        }
    }
}