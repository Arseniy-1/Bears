namespace _Project.Scripts.EnemyStateMashine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly Enemy Enemy;

        protected MovementState(IStateSwitcher stateSwitcher, Enemy enemy)
        {
            StateSwitcher = stateSwitcher;
            Enemy = enemy;
        }
        
        protected EnemyView View => Enemy.View;

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}