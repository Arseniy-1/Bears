using _Project.Scripts.EnemyStateMashine;
using UnityEngine;

namespace _Project.Scripts.EnemyStateMashine
{
    public class Enemy : Character, ITarget
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private float _detectionRange;
        
        private EnemyStateMachine _stateMachine;
        private Transform _transform;
        
        public EnemyView View => _enemyView;
        public bool TargetDetected => Vector3.Distance(_transform.position, Scaner.ClosestTarget.Position) < _detectionRange;
        public Vector2 Position => transform.position;

        private void Awake()
        {
            _enemyView.Initialize();
            _stateMachine = new EnemyStateMachine(this);
            _transform = transform;
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}