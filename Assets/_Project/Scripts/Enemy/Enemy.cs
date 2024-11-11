using _Project.Scripts.Enemy.EnemyStateMaсhine;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class Enemy : Character, ITarget
    {
        [SerializeField] private EnemyView _enemyView;
        private EnemyStateMachine _stateMachine;
        
        public EnemyView View => _enemyView;

        private void Awake()
        {
            _enemyView.Initialize();
            _stateMachine = new EnemyStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public Vector2 Position { get; }
    }
}