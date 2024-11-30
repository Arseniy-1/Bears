using UnityEngine;

public class CharacterAnimator : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.Play(Constans.AnimatorConstans.IdleAnimation);
    }

    public void StartRunning()
    {
        _animator.Play(Constans.AnimatorConstans.RunningAnimation);
    }

    public void StartInactivity()
    {
        _animator.Play(Constans.AnimatorConstans.ActivityAnimation);
    }

    public void StartRunningWithWeapon()
    {
        _animator.Play(Constans.AnimatorConstans.RunInWeaponAnimation);
    }
}

public class AnimatorController : MonoBehaviour
{

}
