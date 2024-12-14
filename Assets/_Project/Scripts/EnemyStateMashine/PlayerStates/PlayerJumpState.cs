using System.Collections;
using UnityEngine;

namespace EnemyStateMashine
{
    public class PlayerJumpState : IState
    {
        private readonly PlayerBehaviour _player;
        private IStateSwitcher _stateSwitcher;

        public PlayerJumpState(PlayerBehaviour enemy)
        {
            _player = enemy;
        }

        public void Initialize(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public IEnumerator Jumping()
        {
            yield return new WaitForSeconds(2);

            _stateSwitcher.SwitchState<PlayerIdleState>();
        }

        public virtual void Enter()
        {
            _player.CharacterAnimator.StartJumping();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {

        }

        public void OnJumpButtonPressed()
        {

        }
    }
}
