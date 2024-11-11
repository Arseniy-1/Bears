using UnityEngine;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly TargetScaner TargetScanner;
        private readonly Enemy _enemy;

        public MovementState(IStateSwitcher stateSwitcher, Enemy enemy, TargetScaner targetScanner)
        {
            StateSwitcher = stateSwitcher;
            _enemy = enemy;
            TargetScanner = targetScanner;
        }
        
        protected EnemyView View => _enemy.View;

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}