using UnityEngine;

namespace _Project.Scripts.Item
{
    public class CollectableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _count;
        
        public void Collect()
        {
            Debug.Log($"collected {_itemType.Name} x{_count}");
        }
    }
}