namespace EnemyStateMashine.States
{
    public interface IEnemyBaseState
    {
        public void EnterState(EnemyStateManager enemy);
    
        public void UpdateState(EnemyStateManager enemy);
    
        public void ExitState(EnemyStateManager enemy);
    }
}
