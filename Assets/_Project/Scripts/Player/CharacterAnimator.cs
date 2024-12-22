using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    private Coroutine _checkIdleTime;
    private float _minIdleDuration = 15f;
    private float _maxIdleDuration = 48f;
    private int _layerIndexTake = 1;
    private int _layerIndexBase = 0;

    public void StartIdleWithWeapon()
    {
        _animator.Play(Constants.AnimatorConstants.IdleWithWeaponAnimation);
        Debug.Log("Idle****");
        
        if (IsPlayingInactivity() == false)
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
        Debug.Log("Run");
    }

    public void StartRunningWithWeapon(bool isMovingBackward)
    {
        if (isMovingBackward)
        {
            _animator.Play(Constants.AnimatorConstants.ReverseWalkAnimation);
            return;
        }

        _animator.Play(Constants.AnimatorConstants.RunWithWeaponAnimation);
    }

    public void TakeItem()
    {
        _animator.Play(Constants.AnimatorConstants.ItemPickupAnimation);
    }

    public void TakeDamage()
    {
        _animator.Play(Constants.AnimatorConstants.TakeDamageAnimation);
        StartCoroutine(ResetLayer());
    }

    public void TakeHeal()
    {
        _animator.Play(Constants.AnimatorConstants.TakeHealAnimation);
        StartCoroutine(ResetLayer());
    }

    private IEnumerator CheckIdleTime()
    {
        var waitTime = new WaitForSeconds(Random.Range(_minIdleDuration, _maxIdleDuration));

        while (enabled)
        {
            yield return waitTime;
            _animator.Play(Constants.AnimatorConstants.InactivityAnimation);
            //TODO Реализовать disable оружия
        }

        _checkIdleTime = null;
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

    private IEnumerator ResetLayer()
    {
        _animator.SetLayerWeight(1, _layerIndexTake);
        
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(_layerIndexTake).length);
        
        _animator.SetLayerWeight(1, _layerIndexBase);
    }

    private bool IsPlayingInactivity() => _animator.GetCurrentAnimatorStateInfo(0).IsName(Constants.AnimatorConstants.LongInactivity);
    private bool IsPlayingTakeItem() => _animator.GetCurrentAnimatorStateInfo(0).IsName(Constants.AnimatorConstants.ItemPickup);
}