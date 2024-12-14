using UnityEngine;

public class CharacterAnimator : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void StartIdleWithWeapon()
    {
        _animator.Play(Constants.AnimatorConstants.IdleWithWeaponAnimation);
        Debug.Log("Idle****");
    }

    public void StartRunning()
    {
        _animator.Play(Constants.AnimatorConstants.RunningAnimation);
        Debug.Log("Run");
    }

    public void StartInactivity()
    {
        _animator.Play(Constants.AnimatorConstants.ActivityAnimation);
    }

    public void StartRunningWithWeapon()
    {
        _animator.Play(Constants.AnimatorConstants.RunWithWeaponAnimation);
        Debug.Log("RunWW");
    }

    public void StartCollecting()
    {
        _animator.Play(Constants.AnimatorConstants.CollectAnimation);
        Debug.Log("Collect");
    }

    public void StartJumping()
    {
        _animator.Play(Constants.AnimatorConstants.JumpAnimation);
        Debug.Log("Jump");
    }
}
