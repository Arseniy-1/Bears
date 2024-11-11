using System;

namespace _Project.Scripts.Enemy.EnemyStateMaсhine
{
    public class StateMachineData
    {
        private float _speed;

        public float Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(_speed));
                
                _speed = value;
            }
        }
    }
}