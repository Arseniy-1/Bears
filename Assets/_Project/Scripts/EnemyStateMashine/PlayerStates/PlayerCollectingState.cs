using UnityEngine;

namespace EnemyStateMashine
{
    public class PlayerCollectingState : IState
    {
        private readonly PlayerBehaviour _player;
        private IStateSwitcher _stateSwitcher;

        public PlayerCollectingState(PlayerBehaviour enemy)
        {
            _player = enemy;
        }

        public void Initialize(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Enter()
        {
            //_enemy.CharacterAnimator.StartRunning();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {

        }
    }
}
