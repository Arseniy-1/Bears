using TMPro;
using UnityEngine;

namespace _Project.Scripts.Inventory.Views
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCellView[] _cells;
        [SerializeField] private TMP_Text _textOwner;

        public string OwnerId
        {
            get => _textOwner.text;
            set => _textOwner.text = value;
        }

        public InventoryCellView GetInvetoryCellView(int index)
        {
            return _cells[index];
        }
    }
}