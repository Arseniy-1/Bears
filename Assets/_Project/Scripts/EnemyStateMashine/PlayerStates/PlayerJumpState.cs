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

        public virtual void Enter()
        {
            //_player.CharacterAnimator.StartJumping();
            _player.Jumper.JumpPerformed += OnJumpPerformed;
            _player.WeaponHolder.DeselectWeapon();

            _player.Jumper.Jump(_player.CharacterRigidbody2D.velocity);
            _player.Flipper.enabled = false;
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            _player.Flipper.enabled = true;
            _player.CharacterRigidbody2D.velocity = Vector3.zero;
        }

        public virtual void Update()
        {

        }

        public void OnJumpPerformed()
        {
            Debug.Log("OnJumpPerformed");
            _player.Jumper.JumpPerformed -= OnJumpPerformed;
            _player.WeaponHolder.PutHands();
            _stateSwitcher.SwitchState<PlayerIdleState>();

        }
    }
}
