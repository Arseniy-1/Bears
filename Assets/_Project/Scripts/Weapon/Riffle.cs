using System.Collections;
using UnityEngine;

public class Riffle : RangeWeapon
{
    [SerializeField, Range(1, 50), Header("(Количество пуль в очереди)")] private int _bulletCount = 6;
    [SerializeField, Range(0.001f, 1), Header("(Задержка между пулями в очереди)")] private float _delayBetweenShots = 0.2f;

    protected override void Attack()
    {
        StartCoroutine(StartAttacking());
    }

    private IEnumerator StartAttacking()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayBetweenShots);

        for (int i = 0; i < _bulletCount; i++)
        {
            ShowAttackAnimation();
            base.Attack();
            yield return delay;
        }
    }
}