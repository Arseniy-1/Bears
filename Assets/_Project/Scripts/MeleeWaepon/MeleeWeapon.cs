using System.Collections;
using UnityEngine;

namespace _Project.Scripts.MeleeWaepon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private float _attackSpeed = 1f;

        private void Start()
        {
            StartCoroutine(Hitting());
        }
        
        public override void Attack()
        {
            Debug.Log("attack");
            //todo: Animation for axe or any other melee weapon
        }
        
        private IEnumerator Hitting()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(_attackSpeed);
                Attack();
            }
        }
    }
}