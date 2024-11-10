using UnityEngine;

namespace EnemyStateMashine.States
{
    public class EnemyWalkState : IEnemyBaseState
    {
        private bool _isMoving;
        
        public void EnterState(EnemyStateManager enemy)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState(EnemyStateManager enemy)
        {
            _isMoving = !Mathf.Approximately(enemy.EnemyBody.velocity.x, 0f) && !Mathf.Approximately(enemy.EnemyBody.velocity.y, 0f);
            
            if (_isMoving == false)
                ExitState(enemy);
        }

        public void ExitState(EnemyStateManager enemy)
        {
            enemy.ChangeState(enemy.IdleState);
        }
    }
}