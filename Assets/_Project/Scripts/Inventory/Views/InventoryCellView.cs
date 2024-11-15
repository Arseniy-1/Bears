using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Inventory.Views
{
    public class InventoryCellView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTitle;
        [SerializeField] private TextMeshProUGUI _textAmount;

        public string Title
        {
            get => _textTitle.text;
            set => _textTitle.text = value;
        }

        public int Amount
        {
            get => _textAmount.text == "" ? 0 : Convert.ToInt32(_textAmount.text);
            set
            {
                _textAmount.text = value == 0 ? "": value.ToString();
            }
        }
    }
}