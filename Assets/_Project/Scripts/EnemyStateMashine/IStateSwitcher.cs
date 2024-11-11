using _Project.Scripts.EnemyStateMashine.States;

namespace _Project.Scripts.EnemyStateMashine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}