using _Project.Scripts.Enemy.EnemyStateMaсhine.States;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}