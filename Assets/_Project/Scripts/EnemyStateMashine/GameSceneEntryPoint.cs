using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour 
{
    [SerializeField] private List<Way> _enemyWays;
    [SerializeField] private EnemyFabric _enemyFabric;

    private void Start()
    {
        foreach (Way way in _enemyWays)
        {
            _enemyFabric.Create(way._waypoints[0].transform, way._waypoints);
        }
    }
}

[Serializable]
public class Way
{
    [field: SerializeField] public List<Transform> _waypoints { get; private set; }
}
