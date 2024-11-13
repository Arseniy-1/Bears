using UnityEngine;

public class Enemy : Character, ITarget
{
    public Vector2 Position => transform.position;
    
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}
