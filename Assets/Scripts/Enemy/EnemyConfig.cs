using Enemy.EnemyStateMaсhine.States.Configs;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Configs/EnemyConfig", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public WalkStateConfig WalkStateConfig { get; private set; }
        [field: SerializeField] public AttackStateConfig AttackStateConfig  { get; private set; }
    }
}