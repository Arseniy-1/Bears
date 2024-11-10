using UnityEngine;
using System;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEnter;
        public event Action<Collider2D> TriggerExit;
        
        private void OnTriggerExit2D(Collider2D other) => 
            TriggerExit?.Invoke(other);

        private void OnTriggerEnter2D(Collider2D other) => 
            TriggerEnter?.Invoke(other);
    }
}