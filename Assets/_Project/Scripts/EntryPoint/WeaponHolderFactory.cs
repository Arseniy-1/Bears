using UnityEngine;

public class WeaponHolderFactory : MonoBehaviour
{
    [SerializeField] private WeaponHolder _weaponHolder;

    public WeaponHolder Create(TargetScanner targetScanner, Weapon weapon, Transform parent)
    {
        WeaponHolder gunHolder = Instantiate(_weaponHolder, parent.transform);
        gunHolder.transform.parent = parent;

        //gunHolder.Construct(targetScanner);

        return gunHolder;
    }
}
