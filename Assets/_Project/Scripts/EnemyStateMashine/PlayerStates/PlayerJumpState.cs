using System;
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
            _player.Jumper.JumpPerformed += OnJumpPerformed;
            _player.WeaponHolder.DeselectWeapon();
            _player.Jumper.Jump();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {

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
