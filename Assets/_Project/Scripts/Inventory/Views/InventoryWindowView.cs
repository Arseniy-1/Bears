using UnityEngine;

namespace _Project.Scripts.Inventory.Views
{
    public class InventoryWindowView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;

        public InventoryView InventoryView => _inventoryView;
    }
}