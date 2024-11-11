using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Enemy.EnemyStateMaсhine.States;
using _Project.Scripts.Enemy.EnemyStateMaсhine.States.Grounded;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState; 

        public EnemyStateMachine(Enemy enemy)
        {
            _states = new List<IState>()
            {
                new EnemyIdleState(this, enemy, enemy.Scaner),
                new EnemyWalkState(this, enemy, enemy.Scaner),
                new EnemyAttackState()
            };
            
            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            if (state == null)
                throw new ArgumentNullException(nameof(T));

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        
        public void Update() => _currentState.Update();
    }
}