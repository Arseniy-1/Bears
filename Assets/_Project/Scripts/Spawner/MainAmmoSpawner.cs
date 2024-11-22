using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Spawner
{
    public class MainAmmoSpawner : MonoBehaviour
    {
        [SerializeField] private List<AmmoSpawner> _ammoSpawners;

        private Dictionary<Type, AmmoSpawner> _spawners = new();

        private void Awake()
        {
            foreach (AmmoSpawner ammoSpawer in _ammoSpawners)
            {
                //_spawners.Add(ammoSpawer.GetType(), ammoSpawer);
                _spawners[ammoSpawer.PrefabType] = ammoSpawer;
            }

            //var bullets =  Resources.LoadAll("Bullets"); TODO: попробовать подгрузку из папки
        }

        public Ammo Spawn(Ammo ammo)
        {
            var spawner = _spawners[ammo.GetType()];

            return spawner.Spawn();
        }
    }
}