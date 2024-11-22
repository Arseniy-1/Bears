using System;
using UnityEngine;

namespace _Project.Scripts.Spawner
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IDestoyable<T>
    {
        [SerializeField] private T Prefab;

        [SerializeField] private int _startAmount = 1;

        protected Pool<T> _pool;
        protected int _activeCount = 0;
        protected int _spawnsCount = 0;
        
        public event Action<int, int, int> CounterChanged;
        
        public Type PrefabType => Prefab.GetType();

        protected virtual void Awake()
        {
            _pool = new Pool<T>(Prefab, transform, transform, _startAmount);
        }

        protected virtual void Start()
        {
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);
        }

        public T Spawn()
        {
            T spawnedObject = _pool.Get();

            spawnedObject.Destroed += OnSpawnedDestroy;
            spawnedObject.gameObject.SetActive(true);

            _activeCount++;
            _spawnsCount++;
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);

            return spawnedObject;
        }

        protected void OnSpawnedDestroy(T spawnableObject)
        {
            spawnableObject.Destroed -= OnSpawnedDestroy;
            spawnableObject.gameObject.SetActive(false);
            _pool.Release(spawnableObject);

            _activeCount--;
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);
        }
    }

}