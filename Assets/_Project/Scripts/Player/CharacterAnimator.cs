using UnityEngine;

public class CharacterAnimator : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.Play(Constants.AnimatorConstants.IdleAnimation);
        Debug.Log("Idle");
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
}
