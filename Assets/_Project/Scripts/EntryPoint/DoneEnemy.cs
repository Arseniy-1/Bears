using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DoneEnemy
{
    [field: SerializeField] public List<Transform> Waypoints { get; private set; }
    [field: SerializeField] public EnemyBehavior Enemy { get; private set; }
}
