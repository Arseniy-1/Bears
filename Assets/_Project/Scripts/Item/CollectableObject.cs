using _Project.Scripts.Storage;
using UnityEngine;

namespace _Project.Scripts.Item
{
    public class CollectableObject : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public ItemType ItemType { get; private set; }

        public void Collect()
        {
            //ebug.Log($"collected {ItemType.Name} x{Count}");
        }
    }
}