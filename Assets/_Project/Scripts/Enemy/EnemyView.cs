using UnityEngine;

namespace _Project.Scripts.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : MonoBehaviour
    {
        private Animator _animator;
        
        public void Initialize() => _animator = GetComponent<Animator>();
    }
}