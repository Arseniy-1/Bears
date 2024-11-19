using UnityEngine;

namespace _Project.Scripts.Storage
{
    public class StorageSpawnPoint : MonoBehaviour
    {
        [field: SerializeField] public StorageDataSO StorageData { get; private set; }
    }
}