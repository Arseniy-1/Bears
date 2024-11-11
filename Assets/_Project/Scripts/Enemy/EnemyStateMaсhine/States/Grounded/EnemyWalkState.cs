using _Project.Scripts.Enemy.EnemyStateMaсhine.States.Configs;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Grounded
{
    public class EnemyWalkState : MovementState
    {
        private WalkStateConfig _config;

        public EnemyWalkState(IStateSwitcher stateSwitcher, StateMachineData data, Enemy enemy) : base(
            stateSwitcher, data, enemy)
            => _config = enemy.Config.WalkStateConfig;
        
        public override void Enter()
        {
            Data.Speed = _config.Speed;
        }

        public override void Update()
        {
            if(IsSpeedZero())
                StateSwitcher.SwitchState<EnemyIdleState>();
        }

        public override void Exit()
        {
            //stop running method in view
        }
    }
}