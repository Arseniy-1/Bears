using System.Collections.Generic;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Storage
{
    [CreateAssetMenu(fileName = "StorageDataSO", menuName = "Data", order = 51)]
    public class StorageDataSO : ScriptableObject
    {
        [SerializeField] public string ownerId;
        [SerializeField] public List<InventoryCellData> Cells;
        [SerializeField] public Vector2Int Size;

    }
}