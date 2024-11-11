namespace Enemy.EnemyStateMaсhine.States.Grounded
{
    public class EnemyIdleState : MovementState
    {
        public EnemyIdleState(IStateSwitcher switcher, StateMachineData data, Enemy enemy) : base(switcher, data, enemy) {}

        public override void Enter()
        {
            Data.Speed = 0;
        }

        public override void Update()
        {
            if (IsSpeedZero())
                return;
            
            StateSwitcher.SwitchState<EnemyWalkState>();
        }

        public override void Exit()
        {
            //Stop idling method in view
        }
    }
}