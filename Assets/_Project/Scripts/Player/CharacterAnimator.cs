using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Coroutine _checkIdleTime;
    private float _minIdleDuration = 15f;
    private float _maxIdleDuration = 48f;

    public void StartIdle()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(Constants.AnimatorConstants.TakeDamage))
        {
            return;
        }
        
        if (DetermineAnimationPriority())
        {
            _animator.Play(Constants.AnimatorConstants.IdleAnimation);
            //TODO Реализовать enable оружия
        }


        if (_checkIdleTime == null)
        {
            _checkIdleTime = StartCoroutine(CheckIdleTime());
        }
    }

    public void StartRunning(bool isMovingBackward)
    {
        if (isMovingBackward)
        {
            _animator.Play(Constants.AnimatorConstants.ReverseWalkAnimation);
            return;
        }

        _animator.Play(Constants.AnimatorConstants.RunningAnimation);
    }

    public void StartRunningWithWeapon(bool isMovingBackward)
    {
        if (isMovingBackward)
        {
            _animator.Play(Constants.AnimatorConstants.ReverseWalkAnimation);
            return;
        }

        _animator.Play(Constants.AnimatorConstants.RunInWeaponAnimation);
    }

    public void TakeDamage()
    {
        _animator.Play(Constants.AnimatorConstants.TakeDamageAnimation);
    }

    private IEnumerator CheckIdleTime()
    {
        var waitTime = new WaitForSeconds(Random.Range(_minIdleDuration, _maxIdleDuration));

        while (enabled)
        {
            yield return waitTime;
            _animator.Play(Constants.AnimatorConstants.ActivityAnimation);
            //TODO Реализовать disable оружия
        }

        _checkIdleTime = null;
    }

    private bool DetermineAnimationPriority()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(Constants.AnimatorConstants.TakeDamage))
        {
            return true;
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(Constants.AnimatorConstants.LongInactivity))
        {
            return true;
        }

        return false;
    }
}

public class AnimatorController : MonoBehaviour
{
}