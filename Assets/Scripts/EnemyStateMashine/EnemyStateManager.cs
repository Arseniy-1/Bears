using EnemyStateMashine.States;
using UnityEngine;

namespace EnemyStateMashine
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyStateManager : MonoBehaviour
    {
        private IEnemyBaseState _currentState;

        public EnemyIdleState IdleState { get; private set; }
        public EnemyWalkState WalkState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        
        public Rigidbody EnemyBody { get; private set; }  

        private void Awake()
        {
            IdleState = new ();
            WalkState = new ();
            AttackState = new();

            EnemyBody = GetComponent<Rigidbody>();
            
            ChangeState(IdleState);
        }

        public void ChangeState(IEnemyBaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
    }
}