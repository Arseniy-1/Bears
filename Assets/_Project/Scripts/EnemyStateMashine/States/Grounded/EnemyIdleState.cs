namespace _Project.Scripts.EnemyStateMashine.States.Grounded
{
    public class EnemyIdleState : MovementState
    {
        public EnemyIdleState(IStateSwitcher switcher,  EnemyStateMashine.Enemy enemy) : base(switcher, enemy) {}

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if (Enemy.TargetDetected)
                StateSwitcher.SwitchState<EnemyWalkState>();
        }

        public override void Exit()
        {
            //Stop idling method in view
        }
    }
}