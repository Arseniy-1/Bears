using UnityEngine;

public class Enemy : Character, ITarget
{
    [field: SerializeField] public TargetScaner TargetScaner { get; private set; }
    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }

    private EnemyStateMachine _stateMachine;

    public Vector2 Position => transform.position;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
