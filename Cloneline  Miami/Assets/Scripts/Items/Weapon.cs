using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int WeaponType { get; private set; }
    public string Name { get; private set; }
    public List<Vector2> CollidersValues { get; private set; }

    public virtual void SetWeaponData(GunData _gunData)
    {
        _gunData.AddColliderValuesToList();
        WeaponType = _gunData.Type;
        Name = _gunData.Name;
        CollidersValues = _gunData.CollidersValues;
    }

    public virtual void SetWeaponData(GunData _gunData, int remainingAmmo)
    {
        _gunData.AddColliderValuesToList();
        WeaponType = _gunData.Type;
        Name = _gunData.Name;
        CollidersValues = _gunData.CollidersValues;
    }

    public virtual void SetWeaponData(MeleeWeaponData _meleeData)
    {
        _meleeData.AddColliderValuesToList();
        WeaponType = _meleeData.Type;
        Name = _meleeData.Name;
        CollidersValues = _meleeData.CollidersValues;
    }
}
