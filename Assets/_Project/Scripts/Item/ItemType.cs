using System;
using UnityEngine;

namespace _Project.Scripts.Item
{
    [Serializable]
    public class ItemType
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}