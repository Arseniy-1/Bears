using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.EnemyStateMashine.States;
using _Project.Scripts.EnemyStateMashine.States.Grounded;

namespace _Project.Scripts.EnemyStateMashine
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState; 

        public EnemyStateMachine(Enemy enemy)
        {
            _states = new List<IState>()
            {
                new EnemyIdleState(this, enemy),
                new EnemyWalkState(this, enemy),
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