using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Spawner
{
    public class MainAmmoSpawner  : MonoBehaviour
    {
        [SerializeField] private List<AmmoSpawner> _spawners;

        public Ammo Spawn(Ammo ammo)
        {
            var spawner = _spawners.FirstOrDefault(spawner => spawner.PrefabType == ammo.GetType());

            return spawner.Spawn();
        }
    }
}