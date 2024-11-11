using Enemy.EnemyStateMaсhine.States;

namespace Enemy.EnemyStateMaсhine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}