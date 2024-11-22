using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DoneEnemy
{
    [field: SerializeField] public List<Transform> Waypoints { get; private set; }
    [field: SerializeField] public Enemy Enemy { get; private set; }
}
