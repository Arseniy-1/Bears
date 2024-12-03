using UnityEngine;

public class CharacterAnimator : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.Play(Constants.AnimatorConstants.IdleAnimation);
    }

    public void StartRunning()
    {
        _animator.Play(Constants.AnimatorConstants.RunningAnimation);
    }

    public void StartInactivity()
    {
        _animator.Play(Constants.AnimatorConstants.ActivityAnimation);
    }

    public void StartRunningWithWeapon()
    {
        _animator.Play(Constants.AnimatorConstants.RunInWeaponAnimation);
    }
}

public class AnimatorController : MonoBehaviour
{

}
