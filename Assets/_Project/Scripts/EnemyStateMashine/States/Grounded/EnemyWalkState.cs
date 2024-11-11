namespace _Project.Scripts.EnemyStateMashine.States.Grounded
{
    public class EnemyWalkState : MovementState
    {
        public EnemyWalkState(IStateSwitcher stateSwitcher, EnemyStateMashine.Enemy enemy) : base(
            stateSwitcher, enemy) { }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if(Enemy.TargetDetected == false)
                StateSwitcher.SwitchState<EnemyIdleState>();
        }

        public override void Exit()
        {
            //stop running method in view
        }
    }
}