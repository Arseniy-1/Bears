using Enemy.EnemyStateMaсhine;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyConfig _config;
        private EnemyStateMachine _stateMachine;

        public EnemyView View => _enemyView;
        public EnemyConfig Config => _config;

        private void Awake()
        {
            _enemyView.Initialize();
            _stateMachine = new EnemyStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}