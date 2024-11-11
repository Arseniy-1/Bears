using UnityEngine;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        private readonly Enemy _enemy;

        public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Enemy enemy)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            _enemy = enemy;
        }
        
        protected EnemyView View => _enemy.View;

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
        
        protected bool IsSpeedZero() => Mathf.Approximately(Data.Speed, 0f);
    }
}