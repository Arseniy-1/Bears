namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States.Grounded
{
    public class EnemyWalkState : MovementState
    {
        public EnemyWalkState(IStateSwitcher stateSwitcher, Enemy enemy, TargetScaner scanner) : base(
            stateSwitcher, enemy, scanner) { }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if(TargetScanner.HasTarget == false)
                StateSwitcher.SwitchState<EnemyIdleState>();
        }

        public override void Exit()
        {
            //stop running method in view
        }
    }
}