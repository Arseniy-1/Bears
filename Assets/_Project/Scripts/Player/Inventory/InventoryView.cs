using System;
using System.Text;
using UnityEngine;

namespace _Project.Scripts.Player.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        private void OnEnable()
        {
            _inventory.ContentChanged += DrawContent;
        }

        private void OnDisable()
        {
            _inventory.ContentChanged += DrawContent;
        }

        private void DrawContent()
        {
            DrawConsole();   
        }

        private void DrawConsole()
        {
            StringBuilder content = new StringBuilder();
            content.Append("[");
            
            foreach (Cell cell in _inventory.Cells)
            {
                content.Append($"[{cell.ItemType.Name}x{cell.Count}], ");
            }
            
            content.Append(']');
            
            Debug.Log(content.ToString());
        }

        private void ShowGUI()
        {
            
        }
    }
}