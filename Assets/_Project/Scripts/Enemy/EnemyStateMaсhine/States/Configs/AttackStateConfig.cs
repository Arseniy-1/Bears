using System;
using UnityEngine;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Configs
{
    [Serializable]
    public class AttackStateConfig
    {
        [field: SerializeField, Range(0,10)] public float Range { get; private set; }
        [field: SerializeField, Range(0,100)] public float Damage { get; private set; }
        [field: SerializeField, Range(0,10)] public float Duration { get; private set; }
    }
}