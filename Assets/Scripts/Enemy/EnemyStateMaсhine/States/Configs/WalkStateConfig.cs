using System;
using UnityEngine;

namespace Enemy.EnemyStateMaсhine.States.Configs
{
    [Serializable]
    public class WalkStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed {get; private set;}
    }
}