using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Spawner
{
    public class MotherAmmoBoss  : MonoBehaviour
    {
        [SerializeField] private List<Spawner<Ammo>> _spawners;
        [SerializeField] private BuckshotSpawner _buckshotSpawner;

        public MotherAmmoBoss(params Spawner<Ammo>[] spawners)
        {
            _spawners = spawners.ToList();
            _spawners.Add(_buckshotSpawner);   
        }

        public Ammo Spawn<T>() where T : Ammo
        {
            var spawner = _spawners.FirstOrDefault(spawner => spawner is BuckshotSpawner);

            return _buckshotSpawner.Spawn();
        }
    }

    public class AmmoSpawner<T> : Spawner<Ammo> where T : Ammo
    {

    }
}