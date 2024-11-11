using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteCharacter; 
    [SerializeField] public SpriteRenderer spriteWeapon;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TargetScaner _scaner;
    
    public Weapon Weapon => _weapon;
    public TargetScaner Scaner => _scaner;
}
