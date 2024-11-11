namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Grounded
{
    public class EnemyIdleState : MovementState
    {
        public EnemyIdleState(IStateSwitcher switcher,  Enemy enemy, TargetScaner scanner) : base(switcher, enemy, scanner) {}

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if (TargetScanner.HasTarget)
                return;
            
            StateSwitcher.SwitchState<EnemyWalkState>();
        }

        public override void Exit()
        {
            //Stop idling method in view
        }
    }
}