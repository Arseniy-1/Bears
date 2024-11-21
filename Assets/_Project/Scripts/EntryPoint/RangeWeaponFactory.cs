using _Project.Scripts.Spawner;
using UnityEngine;

public class RangeWeaponFactory<T> : MonoBehaviour where T : Ammo
{
    [SerializeField] private RangeWeapon<T> _weapon;

    public Weapon Create(Transform parent, MotherAmmoBoss ammoSpawner)
    {
        RangeWeapon<T> weapon = Instantiate(_weapon, parent);
        weapon.transform.parent = parent;
        weapon.Construct(ammoSpawner);

        return weapon;
    }
}
