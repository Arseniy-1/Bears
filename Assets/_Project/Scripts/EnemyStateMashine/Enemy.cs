using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, ITarget
{
    public Vector2 Position => transform.position;
}
