using System;
using UnityEngine;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Configs
{
    [Serializable]
    public class WalkStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed {get; private set;}
    }
}