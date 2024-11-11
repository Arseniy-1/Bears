using _Project.Scripts.Enemy.EnemyStateMaсhine.States.Configs;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Grounded
{
    public class EnemyAttackState : MovementState
    {
        private AttackStateConfig _config;

        public EnemyAttackState(IStateSwitcher stateSwitcher, StateMachineData data, Enemy enemy) : base(
            stateSwitcher, data, enemy)
            => _config = enemy.Config.AttackStateConfig;

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}